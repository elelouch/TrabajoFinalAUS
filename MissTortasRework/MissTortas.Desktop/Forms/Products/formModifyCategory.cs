using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;

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
            this.productService = productService;
            this.Text = $"Modificando categoría '{productCategory.Name}'";
            this.lblModifyCategory.Text = $"Modificar categoría: '{productCategory.Name}' ({productCategory.ProductCategoryId})";
            this.chkEnabled.Checked = productCategory.Enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var newPc = (ProductCategory)this.productCategory.Clone();
            var newName = txtCategoryName.Text;
            if (string.IsNullOrEmpty(newName) || newName.Length < 3 || newName.Length > 256)
            {
                MessageBox.Show("El nombre debe tener una longitud entre 3 y 255 caracteres");
                return;
            }
            newPc.Name = newName;
            newPc.Enabled = chkEnabled.Checked;
            if(comboMoveParent.SelectedItem is ProductCategory selectedParent && selectedParent.ProductCategoryId != 0)
            {
                newPc.ParentId = selectedParent.ProductCategoryId;
            }
            try
            {
                await productService.UpdateProductCategoryAsync(newPc);
                MessageBox.Show("Categoria actualizada correctamente. Vuelva a cargar las categorias para ver los cambios.", "Operación exitosa.", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Dispose();
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
        }

        private async void formModifyCategory_Load(object sender, EventArgs e)
        {
            try
            {
                var categories = await productService.GetCategoriesAsync();
                categories.Insert(0, new ProductCategory { ProductCategoryId = 0, Name = "-- Seleccionar Categoria --" });
                comboMoveParent.DataSource = categories;
                comboMoveParent.DisplayMember = "Name";
                comboMoveParent.ValueMember = "ProductCategoryId";
                this.txtCategoryName.Text = productCategory.Name;
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }

        }
    }


}
