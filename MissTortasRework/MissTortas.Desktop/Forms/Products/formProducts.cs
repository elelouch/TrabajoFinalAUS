using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formProducts : Form
    {
        private readonly IProductService productService;
        private readonly ProductCategory? productCategory;
        public event EventHandler<StockProductCreatedArgs>? OnStockProductCreated;
        public event EventHandler<StockProductModifiedArgs>? OnStockProductModified;

        public formProducts(IProductService productService, ProductCategory? pc)
        {
            InitializeComponent();
            this.productService = productService;
            this.productCategory = pc;
        }
        public formProducts(IProductService productService) : this(productService, null) { }

        private void formProducts_Load(object sender, EventArgs e)
        {
            var stockProducts = new formProductsFromCategory(productService, productCategory)
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                ControlBox = false
            };
            this.tabPageStock.Controls.Add(stockProducts);
            stockProducts.Show();
            var saleProducts = new formSaleProductsFromCategory(productService, productCategory)
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                ControlBox = false
            };
            this.tabSaleProducts.Controls.Add(saleProducts);
            saleProducts.Show();
        }
    }
}
