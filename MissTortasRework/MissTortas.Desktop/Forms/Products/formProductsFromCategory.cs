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
    public partial class formProductsFromCategory : Form
    {
        private readonly ProductCategory productCategory;
        private readonly IProductService productService;
        private BindingList<Product> products = [];
        public formProductsFromCategory(ProductCategory pc, IProductService productService)
        {
            InitializeComponent();
            this.productCategory = pc;
            this.productService = productService;
            this.Text = $"Products from ({pc.ProductCategoryId}) - {pc.Name}";
        }

        private async void formProductsFromCategory_Load(object sender, EventArgs e)
        {
            var pc = await productService.GetProductsFromCategoryAsync(productCategory.ProductCategoryId);
            products = [..pc];
            dgvProducts.DataSource = products;
        }
    }
}
