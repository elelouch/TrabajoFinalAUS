using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCategories : Form
    {
        private readonly Dictionary<long, TreeNode> treeMap;
        private readonly IProductService productService;
        public formCategories(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            this.treeMap = [];

            tvCategories.FullRowSelect = true;
            tvCategories.ShowLines = true;
            tvCategories.ShowPlusMinus = false;
            tvCategories.HideSelection = false;
            tvCategories.ItemHeight = 25;
            tvCategories.Indent = 20;
        }

        private void tvCategories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Seleccionar el nodo
            tvCategories.SelectedNode = e.Node;

            // Expandir o contraer al hacer clic
            if (e.Node.IsExpanded)
                e.Node.Collapse();
            else
                e.Node.Expand();
        }

        private async void formCategories_Load(object sender, EventArgs e)
        {
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            try
            {
                tvCategories.BeginUpdate();
                var categories = await productService.GetCategoriesAsync();
                LoadTreeView(categories);
                tvCategories.EndUpdate();
                tvCategories.NodeMouseDoubleClick += TvCategories_NodeMouseDoubleClick;
                tvCategories.MouseMove += TvCategories_MouseMove;
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

        private void TvCategories_MouseMove(object? sender, MouseEventArgs e)
        {
            var currentNode = tvCategories.GetNodeAt(e.Location);
            if (currentNode?.Tag is not ProductCategory pc)
                return;
            if (pc.IsFinal)
            {
                tvCategories.Cursor = Cursors.Hand;
            }
        }

        private async void TvCategories_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is not ProductCategory category)
                return;

            if (!category.IsFinal)
                return;

            var formProducts = new formProducts(productService, category);
            formProducts.ShowDialog();
        }

        private void LoadTreeView(List<ProductCategory> categories)
        {
            tvCategories.Nodes.Clear();
            tvCategories.BeginUpdate();
            foreach (var category in categories)
            {
                var categoryNode = CreateCategoryNode(category);
                tvCategories.Nodes.Add(categoryNode);
            }
            tvCategories.EndUpdate();
        }

        private TreeNode CreateCategoryNode(ProductCategory category)
        {
            var node = new TreeNode(category.Name)
            {
                Tag = category, // keep reference to the original object
                ForeColor = category.IsFinal ? Color.Black : Color.Gray
            };
            treeMap.Add(category.ProductCategoryId, node);
            foreach (var child in category.Children)
            {
                node.Nodes.Add(CreateCategoryNode(child));
            }

            foreach (var product in category.Products)
            {
                var productNode = new TreeNode(product.Name)
                {
                    Tag = product
                };
                node.Nodes.Add(productNode);
            }

            return node;
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            var selectedNode = tvCategories.SelectedNode;
            if (selectedNode == null)
            {
                var userMessage = MessageBox.Show("Debe seleccionar una categoria antes de agregar una categoria hija. Si desea crear una categoria raíz, presione 'Aceptar' para continuar. De lo contrario, presione 'Cancelar'", "Advertencia de árbol", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (userMessage == DialogResult.OK)
                {
                    var createCategoryForm = new formCreateCategory(null, productService);
                    createCategoryForm.OnCategoryCreated += CreateCategoryForm_OnCategoryCreated;
                    createCategoryForm.ShowDialog();
                }
                return;
            }
            if (selectedNode.Tag is ProductCategory currentPc)
            {
                if (currentPc.IsFinal)
                {
                    MessageBox.Show("La categoría seleccionada está marcada como final. Solo se pueden agregar productos realizando doble click sobre la misma.", "No se puede agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var createCategoryForm = new formCreateCategory(currentPc, productService);
                createCategoryForm.OnCategoryCreated += CreateCategoryForm_OnCategoryCreated;
                createCategoryForm.ShowDialog();
            }
        }

        private void CreateCategoryForm_OnCategoryCreated(object? sender, Events.CategoryCreatedArgs e)
        {
            var productCategory = e.Category;
            if (!productCategory.Enabled)
            {
                return;
            }
            var newNode = CreateCategoryNode(productCategory);
            treeMap.TryGetValue(productCategory.ParentId ?? 0, out TreeNode? parent);
            if (parent == null)
            {
                tvCategories.Nodes.Add(newNode);
                return;
            }
            parent.Nodes.Add(newNode);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnModifyCategory_Click(object sender, EventArgs e)
        {
            var selectedNode = tvCategories.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Debe seleccionar una categoría para modificar.", "Advertencia de modificación de categoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedNode.Tag is ProductCategory productCategory)
            {
                var formModify = new formModifyCategory(productCategory, productService);
                formModify.ShowDialog();
                formModify.Dispose();
            }
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            if (tvCategories.SelectedNode != null)
            {
                tvCategories.SelectedNode = null;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            treeMap.Clear();
            tvCategories.Nodes.Clear();
            await LoadCategories();
        }
    }
}