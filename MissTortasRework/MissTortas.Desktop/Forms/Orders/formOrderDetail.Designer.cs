namespace MissTortas.Desktop.Forms.Orders
{
    partial class formOrderDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            dgvPreparations = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assigneeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doneDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            preparationBindingSource = new BindingSource(components);
            btnModifyPreparation = new Button();
            btnAddPreparation = new Button();
            tabPage2 = new TabPage();
            dgvAskedSaleProducts = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityAskedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            saleProductAskedBindingSource = new BindingSource(components);
            panel1 = new Panel();
            txtCreationTime = new TextBox();
            txtClientUsername = new TextBox();
            txtOrderId = new TextBox();
            lblCreationTime = new Label();
            lblClientUsername = new Label();
            lblOrderId = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnFinishOrder = new Button();
            btnCancelOrder = new Button();
            txtPaymentStatus = new TextBox();
            label5 = new Label();
            lblOrderStatus = new Label();
            txtOrderStatus = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreparations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)preparationBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAskedSaleProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saleProductAskedBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 138);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 309);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 281);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Preparations";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvPreparations);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnModifyPreparation);
            splitContainer1.Panel2.Controls.Add(btnAddPreparation);
            splitContainer1.Size = new Size(780, 275);
            splitContainer1.SplitterDistance = 659;
            splitContainer1.TabIndex = 0;
            // 
            // dgvPreparations
            // 
            dgvPreparations.AllowUserToAddRows = false;
            dgvPreparations.AllowUserToDeleteRows = false;
            dgvPreparations.AllowUserToOrderColumns = true;
            dgvPreparations.AutoGenerateColumns = false;
            dgvPreparations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreparations.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, detailDataGridViewTextBoxColumn, assigneeIdDataGridViewTextBoxColumn, doneDataGridViewCheckBoxColumn });
            dgvPreparations.DataSource = preparationBindingSource;
            dgvPreparations.Dock = DockStyle.Fill;
            dgvPreparations.Location = new Point(0, 0);
            dgvPreparations.Name = "dgvPreparations";
            dgvPreparations.ReadOnly = true;
            dgvPreparations.Size = new Size(659, 275);
            dgvPreparations.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detailDataGridViewTextBoxColumn
            // 
            detailDataGridViewTextBoxColumn.DataPropertyName = "Detail";
            detailDataGridViewTextBoxColumn.HeaderText = "Detail";
            detailDataGridViewTextBoxColumn.Name = "detailDataGridViewTextBoxColumn";
            detailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assigneeIdDataGridViewTextBoxColumn
            // 
            assigneeIdDataGridViewTextBoxColumn.DataPropertyName = "AssigneeId";
            assigneeIdDataGridViewTextBoxColumn.HeaderText = "AssigneeId";
            assigneeIdDataGridViewTextBoxColumn.Name = "assigneeIdDataGridViewTextBoxColumn";
            assigneeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doneDataGridViewCheckBoxColumn
            // 
            doneDataGridViewCheckBoxColumn.DataPropertyName = "Done";
            doneDataGridViewCheckBoxColumn.HeaderText = "Done";
            doneDataGridViewCheckBoxColumn.Name = "doneDataGridViewCheckBoxColumn";
            doneDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // preparationBindingSource
            // 
            preparationBindingSource.DataSource = typeof(Model.Preparation);
            // 
            // btnModifyPreparation
            // 
            btnModifyPreparation.Location = new Point(7, 35);
            btnModifyPreparation.Name = "btnModifyPreparation";
            btnModifyPreparation.Size = new Size(107, 23);
            btnModifyPreparation.TabIndex = 1;
            btnModifyPreparation.Text = "Modify Preparation";
            btnModifyPreparation.UseVisualStyleBackColor = true;
            btnModifyPreparation.Click += btnModifyPreparation_Click;
            // 
            // btnAddPreparation
            // 
            btnAddPreparation.Location = new Point(7, 3);
            btnAddPreparation.Name = "btnAddPreparation";
            btnAddPreparation.Size = new Size(107, 26);
            btnAddPreparation.TabIndex = 0;
            btnAddPreparation.Text = "Add Preparation";
            btnAddPreparation.UseVisualStyleBackColor = true;
            btnAddPreparation.Click += btnAddPreparation_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvAskedSaleProducts);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 281);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Products";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAskedSaleProducts
            // 
            dgvAskedSaleProducts.AllowUserToAddRows = false;
            dgvAskedSaleProducts.AllowUserToDeleteRows = false;
            dgvAskedSaleProducts.AllowUserToOrderColumns = true;
            dgvAskedSaleProducts.AutoGenerateColumns = false;
            dgvAskedSaleProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAskedSaleProducts.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, quantityAskedDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn });
            dgvAskedSaleProducts.DataSource = saleProductAskedBindingSource;
            dgvAskedSaleProducts.Dock = DockStyle.Fill;
            dgvAskedSaleProducts.Location = new Point(3, 3);
            dgvAskedSaleProducts.Name = "dgvAskedSaleProducts";
            dgvAskedSaleProducts.ReadOnly = true;
            dgvAskedSaleProducts.Size = new Size(780, 275);
            dgvAskedSaleProducts.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityAskedDataGridViewTextBoxColumn
            // 
            quantityAskedDataGridViewTextBoxColumn.DataPropertyName = "QuantityAsked";
            quantityAskedDataGridViewTextBoxColumn.HeaderText = "QuantityAsked";
            quantityAskedDataGridViewTextBoxColumn.Name = "quantityAskedDataGridViewTextBoxColumn";
            quantityAskedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "Price";
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleProductAskedBindingSource
            // 
            saleProductAskedBindingSource.DataSource = typeof(Model.SaleProductAsked);
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCreationTime);
            panel1.Controls.Add(txtClientUsername);
            panel1.Controls.Add(txtOrderId);
            panel1.Controls.Add(lblCreationTime);
            panel1.Controls.Add(lblClientUsername);
            panel1.Controls.Add(lblOrderId);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 129);
            panel1.TabIndex = 1;
            // 
            // txtCreationTime
            // 
            txtCreationTime.Location = new Point(109, 88);
            txtCreationTime.Name = "txtCreationTime";
            txtCreationTime.ReadOnly = true;
            txtCreationTime.Size = new Size(148, 23);
            txtCreationTime.TabIndex = 5;
            // 
            // txtClientUsername
            // 
            txtClientUsername.Location = new Point(109, 49);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.ReadOnly = true;
            txtClientUsername.Size = new Size(148, 23);
            txtClientUsername.TabIndex = 4;
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(109, 9);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.ReadOnly = true;
            txtOrderId.Size = new Size(148, 23);
            txtOrderId.TabIndex = 3;
            // 
            // lblCreationTime
            // 
            lblCreationTime.AutoSize = true;
            lblCreationTime.Location = new Point(9, 91);
            lblCreationTime.Name = "lblCreationTime";
            lblCreationTime.Size = new Size(82, 15);
            lblCreationTime.TabIndex = 2;
            lblCreationTime.Text = "Creation Time";
            // 
            // lblClientUsername
            // 
            lblClientUsername.AutoSize = true;
            lblClientUsername.Location = new Point(9, 52);
            lblClientUsername.Name = "lblClientUsername";
            lblClientUsername.Size = new Size(94, 15);
            lblClientUsername.TabIndex = 1;
            lblClientUsername.Text = "Client Username";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(9, 15);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(50, 15);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Order Id";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnFinishOrder);
            panel2.Controls.Add(btnCancelOrder);
            panel2.Controls.Add(txtPaymentStatus);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(lblOrderStatus);
            panel2.Controls.Add(txtOrderStatus);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(403, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 129);
            panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(268, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnFinishOrder
            // 
            btnFinishOrder.Location = new Point(268, 49);
            btnFinishOrder.Name = "btnFinishOrder";
            btnFinishOrder.Size = new Size(107, 23);
            btnFinishOrder.TabIndex = 11;
            btnFinishOrder.Text = "Finish Order";
            btnFinishOrder.UseVisualStyleBackColor = true;
            btnFinishOrder.Click += btnFinishOrder_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Location = new Point(268, 87);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(107, 23);
            btnCancelOrder.TabIndex = 10;
            btnCancelOrder.Text = "Cancel Order";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // txtPaymentStatus
            // 
            txtPaymentStatus.Location = new Point(108, 61);
            txtPaymentStatus.Name = "txtPaymentStatus";
            txtPaymentStatus.ReadOnly = true;
            txtPaymentStatus.Size = new Size(127, 23);
            txtPaymentStatus.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 64);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 8;
            label5.Text = "Payment Status";
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Location = new Point(13, 15);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(72, 15);
            lblOrderStatus.TabIndex = 7;
            lblOrderStatus.Text = "Order Status";
            // 
            // txtOrderStatus
            // 
            txtOrderStatus.Location = new Point(108, 12);
            txtOrderStatus.Name = "txtOrderStatus";
            txtOrderStatus.ReadOnly = true;
            txtOrderStatus.Size = new Size(127, 23);
            txtOrderStatus.TabIndex = 6;
            // 
            // formOrderDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formOrderDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formOrderDetail";
            Load += formOrderDetail_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreparations).EndInit();
            ((System.ComponentModel.ISupportInitialize)preparationBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAskedSaleProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)saleProductAskedBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private Label lblOrderId;
        private TextBox txtCreationTime;
        private TextBox txtClientUsername;
        private TextBox txtOrderId;
        private Label lblCreationTime;
        private Label lblClientUsername;
        private Panel panel2;
        private Label lblOrderStatus;
        private TextBox txtOrderStatus;
        private TextBox txtPaymentStatus;
        private Label label5;
        private SplitContainer splitContainer1;
        private DataGridView dgvPreparations;
        private Button btnModifyPreparation;
        private Button btnAddPreparation;
        private DataGridView dgvAskedSaleProducts;
        private BindingSource preparationBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityAskedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private BindingSource saleProductAskedBindingSource;
        private Button btnFinishOrder;
        private Button btnCancelOrder;
        private Button btnCancel;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assigneeIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn doneDataGridViewCheckBoxColumn;
    }
}