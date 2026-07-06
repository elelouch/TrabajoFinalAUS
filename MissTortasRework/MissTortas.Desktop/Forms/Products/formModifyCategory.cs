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
    public partial class formModifyCategory : Form
    {
        private readonly ProductCategory productCategory;
        private readonly IProductService productService;
        public formModifyCategory(ProductCategory productCategory, IProductService productService)
        {
            InitializeComponent();
            this.productCategory = productCategory;
            this.Text = $"Modifying {productCategory.Name} category";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var newPc = (ProductCategory)this.productCategory.Clone();
            var newName = txtCategoryName.Text;
            if (string.IsNullOrEmpty(newName) || newName.Length < 3 || newName.Length > 256)
            {
                MessageBox.Show("Name must have a length between 3 and 255 characters");
                return;
            }
            newPc.Name = newName;
            newPc.Enabled = chkEnabled.Checked;
            //newPc.ProductCategoryId;
        }

        private async void formModifyCategory_Load(object sender, EventArgs e)
        {
            var categories = await productService.GetCategoriesAsync();
            categories.Insert(0, new ProductCategory { ProductCategoryId = 0, Name = "-- Select Category --" });
            comboMoveParent.DataSource = categories;
            comboMoveParent.DisplayMember = "Name";
            comboMoveParent.ValueMember = "ProductCategoryId";
        }
    }


}
