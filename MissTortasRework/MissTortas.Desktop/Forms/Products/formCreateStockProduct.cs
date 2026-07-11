using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCreateStockProduct : Form
    {
        private readonly IProductService productService;
        private readonly ProductCategory? productCategory;
        private readonly Product? productToModify;
        private readonly long CategoryId;
        public event EventHandler<StockProductCreatedArgs> OnStockProductCreated;

        public formCreateStockProduct(IProductService productService, ProductCategory? pc, Product? product)
        {
            InitializeComponent();
            this.productService = productService;
            this.productCategory = pc;
            this.productToModify = product;
        }
        public formCreateStockProduct(IProductService productService, ProductCategory pc) : this(productService, pc, null) { }
        public formCreateStockProduct(IProductService productService) : this(productService, null, null) { }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void formCreateStockProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductCategory> cats = productCategory != null ? [productCategory] : await productService.GetCategoriesAsync();
                comboBoxCategory.DataSource = cats;
                comboBoxCategory.DisplayMember = nameof(ProductCategory.Name);
                comboBoxCategory.ValueMember = nameof(ProductCategory.ProductCategoryId);
                
                if (productToModify != null)
                {
                    this.Text = "Modify Product";
                    this.chkEnabled.Visible = true;
                    this.chkManageQtyAsInteger.Visible = false;
                    ProductToForm(productToModify);
                }
                else
                {
                    this.Text = "Create Product";
                    this.chkEnabled.Visible = false;
                    this.chkManageQtyAsInteger.Visible = true;
                }
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
            }
        }

        private void RaiseOnStockProductCreated(Product pc)
        {
            var handler = OnStockProductCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new StockProductCreatedArgs(pc));
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var product = FormToProduct();
                if (productToModify == null)
                {
                    var retrieveProduct = await productService.CreateProductAsync(product);
                    RaiseOnStockProductCreated(product);
                    MessageBox.Show("Product created successfully", "Product created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var retrieveProduct = await productService.ModifyProductAsync(product);

                }
                Dispose();
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
            }
            catch (FormatException exc)
            {
                MessageBox.Show($"{exc.Message}", "Couldn't create product, check inputs.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product FormToProduct()
        {
            var manageQtyAsInteger = chkManageQtyAsInteger.Checked;
            var qty = ParseQuantity(txtQuantity.Text, manageQtyAsInteger);
            var name = Validation.ValidateAndSanitize(txtProductName.Text, 3, 256);
            var description = Validation.ValidateAndSanitize(txtDescription.Text, 3, 256);
            var unit = Validation.ValidateAndSanitize(txtUnitName.Text, 3, 256);

            if (comboBoxCategory.SelectedItem is not ProductCategory selected)
            {
                throw new InvalidOperationException("Not valid item.");
            }
            var newProduct = new Product
            {
                Name = name,
                Description = description,
                Quantity = qty,
                ManageQuantityAsInteger = manageQtyAsInteger,
                CategoryId = selected.ProductCategoryId,
                Unit = unit
            };
            return newProduct;
        }

        private void ProductToForm(Product product)
        {
            txtProductName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
            chkManageQtyAsInteger.Checked = product.ManageQuantityAsInteger;
            txtUnitName.Text = product.Unit;
            chkEnabled.Enabled = product.Enabled;
        }

        public static decimal ParseQuantity(string input, bool manageQuantityAsInteger)
        {
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal quantity))
                throw new FormatException($"'{input}' is not a valid quantity.");

            return manageQuantityAsInteger
                ? Math.Round(quantity, 0, MidpointRounding.AwayFromZero)
                : quantity;
        }
    }
}
