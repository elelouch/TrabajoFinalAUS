using MissTortas.Desktop.Forms.Roles;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
        }

        private async void formCategories_Load(object sender, EventArgs e)
        {
            try
            {
                tvCategories.BeginUpdate();
                var categories = await productService.GetCategoriesAsync();
                LoadTreeView(categories);
                tvCategories.EndUpdate();
                tvCategories.NodeMouseDoubleClick += TvCategories_NodeMouseDoubleClick;
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
            }

        }

        private async void TvCategories_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is not ProductCategory category)
                return;

            if (!category.IsFinal)
                return;

            var formProductsFromCategory = new formProductsFromCategory(category, productService);
            formProductsFromCategory.ShowDialog();
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
            // Add child categories (recursive)
            foreach (var child in category.Children)
            {
                node.Nodes.Add(CreateCategoryNode(child));
            }

            // Add products belonging to this category
            foreach (var product in category.Products)
            {
                var productNode = new TreeNode(product.Name) // adjust to your Product properties
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
                var userMessage = MessageBox.Show("Must select a node before adding a child. If you wanted to create a root node, press 'OK' to continue. Else, press 'Cancel'", "Add tree warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                    MessageBox.Show("The node selected is marked as final. Only products can be appended.", "Can not append category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if(!productCategory.Enabled)
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
            if(selectedNode == null)
            {
                MessageBox.Show("Must select a node to modify.", "Modify node warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(selectedNode.Tag is ProductCategory productCategory)
            {
                var formModify = new formModifyCategory(productCategory, productService);
                formModify.ShowDialog();
            }
        }
    }
}