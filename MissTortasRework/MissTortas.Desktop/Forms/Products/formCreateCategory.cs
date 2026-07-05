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
        private readonly long parentCategoryId;
        public event EventHandler<CategoryCreatedArgs>? OnCategoryCreated;

        public formCreateCategory(long parentCategoryId,IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            this.parentCategoryId = parentCategoryId;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var newCategory = new ProductCategory { Name = txtCategoryName.Text, ParentId = parentCategoryId};
            try
            {
                var resultCategory = await productService.CreateProductCategoryAsync(newCategory) ?? throw new InvalidOperationException("Result category is null.");
                RaiseOnCategoryCreated(resultCategory);
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
    }
}
