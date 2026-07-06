using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCreateCategory : Form
    {
        private readonly IProductService productService;
        private readonly ProductCategory? parentCategory;
        public event EventHandler<CategoryCreatedArgs>? OnCategoryCreated;

        public formCreateCategory(ProductCategory? parentCategory, IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            this.parentCategory = parentCategory;
            if(parentCategory != null)
            {
                this.Text = $"Creating child category for ({parentCategory.ProductCategoryId}) - {parentCategory.Name}";
            }
            else
            {
                this.Text = $"Creating root node.";
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text;
            if(string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 256)
            {
                MessageBox.Show(
                    $"Name must have a length greater than two and less than 255",
                    "Category name incorrect",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            var newCategory = new ProductCategory { Name =  name, IsFinal = chkFinalCategory.Checked };
            if (parentCategory == null)
            {
                newCategory.ParentId = null;
            }
            else
            {
                newCategory.ParentId = parentCategory.ProductCategoryId;
            }
            try
            {
                var resultCategory = await productService.CreateProductCategoryAsync(newCategory) ?? throw new InvalidOperationException("Result category is null.");
                RaiseOnCategoryCreated(resultCategory);
                MessageBox.Show(
                    $"Category '{newCategory.Name}' created",
                    "Category created successfully",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Dispose();
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show(
                    $"Couldn't create category. Error: {err.Message}",
                    "Error category creation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
        private void RaiseOnCategoryCreated(ProductCategory cat)
        {
            var handler = OnCategoryCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new CategoryCreatedArgs(cat));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
