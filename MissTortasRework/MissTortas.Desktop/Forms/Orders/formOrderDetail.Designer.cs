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
            panel5 = new Panel();
            lblCreationTime = new Label();
            txtCreationTime = new TextBox();
            panel4 = new Panel();
            lblClientUsername = new Label();
            txtClientUsername = new TextBox();
            panel3 = new Panel();
            txtOrderId = new TextBox();
            lblOrderId = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            panel8 = new Panel();
            label5 = new Label();
            txtPaymentStatus = new TextBox();
            panel7 = new Panel();
            lblOrderStatus = new Label();
            txtOrderStatus = new TextBox();
            panel6 = new Panel();
            btnCancel = new Button();
            btnCancelOrder = new Button();
            btnFinishOrder = new Button();
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
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 129);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 288);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 23);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 261);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tareas";
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
            splitContainer1.Panel2.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel2.Controls.Add(btnModifyPreparation);
            splitContainer1.Panel2.Controls.Add(btnAddPreparation);
            splitContainer1.Size = new Size(780, 255);
            splitContainer1.SplitterDistance = 659;
            splitContainer1.TabIndex = 0;
            // 
            // dgvPreparations
            // 
            dgvPreparations.AllowUserToAddRows = false;
            dgvPreparations.AllowUserToDeleteRows = false;
            dgvPreparations.AllowUserToOrderColumns = true;
            dgvPreparations.AutoGenerateColumns = false;
            dgvPreparations.BackgroundColor = Color.WhiteSmoke;
            dgvPreparations.BorderStyle = BorderStyle.None;
            dgvPreparations.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvPreparations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreparations.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, assigneeIdDataGridViewTextBoxColumn, doneDataGridViewCheckBoxColumn });
            dgvPreparations.DataSource = preparationBindingSource;
            dgvPreparations.Dock = DockStyle.Fill;
            dgvPreparations.Location = new Point(0, 0);
            dgvPreparations.Name = "dgvPreparations";
            dgvPreparations.ReadOnly = true;
            dgvPreparations.Size = new Size(659, 255);
            dgvPreparations.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Identificador";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assigneeIdDataGridViewTextBoxColumn
            // 
            assigneeIdDataGridViewTextBoxColumn.DataPropertyName = "AssigneeId";
            assigneeIdDataGridViewTextBoxColumn.HeaderText = "Usuario asignado";
            assigneeIdDataGridViewTextBoxColumn.Name = "assigneeIdDataGridViewTextBoxColumn";
            assigneeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doneDataGridViewCheckBoxColumn
            // 
            doneDataGridViewCheckBoxColumn.DataPropertyName = "Done";
            doneDataGridViewCheckBoxColumn.HeaderText = "Listo";
            doneDataGridViewCheckBoxColumn.Name = "doneDataGridViewCheckBoxColumn";
            doneDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // preparationBindingSource
            // 
            preparationBindingSource.DataSource = typeof(Model.Preparation);
            // 
            // btnModifyPreparation
            // 
            btnModifyPreparation.BackColor = SystemColors.ControlLightLight;
            btnModifyPreparation.Dock = DockStyle.Top;
            btnModifyPreparation.FlatStyle = FlatStyle.Flat;
            btnModifyPreparation.Location = new Point(0, 30);
            btnModifyPreparation.Name = "btnModifyPreparation";
            btnModifyPreparation.Size = new Size(117, 30);
            btnModifyPreparation.TabIndex = 1;
            btnModifyPreparation.Text = "Modificar tarea";
            btnModifyPreparation.UseVisualStyleBackColor = false;
            btnModifyPreparation.Click += btnModifyPreparation_Click;
            // 
            // btnAddPreparation
            // 
            btnAddPreparation.BackColor = SystemColors.ControlLightLight;
            btnAddPreparation.Dock = DockStyle.Top;
            btnAddPreparation.FlatStyle = FlatStyle.Flat;
            btnAddPreparation.Location = new Point(0, 0);
            btnAddPreparation.Name = "btnAddPreparation";
            btnAddPreparation.Size = new Size(117, 30);
            btnAddPreparation.TabIndex = 0;
            btnAddPreparation.Text = "Agregar tarea";
            btnAddPreparation.UseVisualStyleBackColor = false;
            btnAddPreparation.Click += btnAddPreparation_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvAskedSaleProducts);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 260);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Productos solicitados";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAskedSaleProducts
            // 
            dgvAskedSaleProducts.AllowUserToAddRows = false;
            dgvAskedSaleProducts.AllowUserToDeleteRows = false;
            dgvAskedSaleProducts.AllowUserToOrderColumns = true;
            dgvAskedSaleProducts.AutoGenerateColumns = false;
            dgvAskedSaleProducts.BackgroundColor = Color.WhiteSmoke;
            dgvAskedSaleProducts.BorderStyle = BorderStyle.None;
            dgvAskedSaleProducts.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvAskedSaleProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAskedSaleProducts.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, quantityAskedDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn });
            dgvAskedSaleProducts.DataSource = saleProductAskedBindingSource;
            dgvAskedSaleProducts.Dock = DockStyle.Fill;
            dgvAskedSaleProducts.Location = new Point(3, 3);
            dgvAskedSaleProducts.Name = "dgvAskedSaleProducts";
            dgvAskedSaleProducts.ReadOnly = true;
            dgvAskedSaleProducts.Size = new Size(780, 254);
            dgvAskedSaleProducts.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Identificador";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityAskedDataGridViewTextBoxColumn
            // 
            quantityAskedDataGridViewTextBoxColumn.DataPropertyName = "QuantityAsked";
            quantityAskedDataGridViewTextBoxColumn.HeaderText = "Cantidad solicitada";
            quantityAskedDataGridViewTextBoxColumn.Name = "quantityAskedDataGridViewTextBoxColumn";
            quantityAskedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "Precio";
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleProductAskedBindingSource
            // 
            saleProductAskedBindingSource.DataSource = typeof(Model.SaleProductAsked);
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 120);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblCreationTime);
            panel5.Controls.Add(txtCreationTime);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 70);
            panel5.Name = "panel5";
            panel5.Size = new Size(394, 35);
            panel5.TabIndex = 8;
            // 
            // lblCreationTime
            // 
            lblCreationTime.AutoSize = true;
            lblCreationTime.Dock = DockStyle.Top;
            lblCreationTime.Location = new Point(0, 0);
            lblCreationTime.Name = "lblCreationTime";
            lblCreationTime.Size = new Size(126, 14);
            lblCreationTime.TabIndex = 2;
            lblCreationTime.Text = "Momento de creacion";
            // 
            // txtCreationTime
            // 
            txtCreationTime.Dock = DockStyle.Bottom;
            txtCreationTime.Location = new Point(0, 11);
            txtCreationTime.Name = "txtCreationTime";
            txtCreationTime.ReadOnly = true;
            txtCreationTime.Size = new Size(392, 22);
            txtCreationTime.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblClientUsername);
            panel4.Controls.Add(txtClientUsername);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(394, 35);
            panel4.TabIndex = 7;
            // 
            // lblClientUsername
            // 
            lblClientUsername.AutoSize = true;
            lblClientUsername.Dock = DockStyle.Top;
            lblClientUsername.Location = new Point(0, 0);
            lblClientUsername.Name = "lblClientUsername";
            lblClientUsername.Size = new Size(106, 14);
            lblClientUsername.TabIndex = 1;
            lblClientUsername.Text = "Usuario del cliente";
            // 
            // txtClientUsername
            // 
            txtClientUsername.Dock = DockStyle.Bottom;
            txtClientUsername.Location = new Point(0, 11);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.ReadOnly = true;
            txtClientUsername.Size = new Size(392, 22);
            txtClientUsername.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtOrderId);
            panel3.Controls.Add(lblOrderId);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(394, 35);
            panel3.TabIndex = 6;
            // 
            // txtOrderId
            // 
            txtOrderId.BorderStyle = BorderStyle.None;
            txtOrderId.Dock = DockStyle.Bottom;
            txtOrderId.Location = new Point(0, 18);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.ReadOnly = true;
            txtOrderId.Size = new Size(392, 15);
            txtOrderId.TabIndex = 3;
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Dock = DockStyle.Top;
            lblOrderId.Location = new Point(0, 0);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(131, 14);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Identificador de Orden";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.05076F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.9492378F));
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Controls.Add(panel6, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(403, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(394, 120);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel7);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(269, 114);
            panel2.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label5);
            panel8.Controls.Add(txtPaymentStatus);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 35);
            panel8.Name = "panel8";
            panel8.Size = new Size(269, 35);
            panel8.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(95, 14);
            label5.TabIndex = 8;
            label5.Text = "Estado del pago";
            // 
            // txtPaymentStatus
            // 
            txtPaymentStatus.Dock = DockStyle.Bottom;
            txtPaymentStatus.Location = new Point(0, 11);
            txtPaymentStatus.Name = "txtPaymentStatus";
            txtPaymentStatus.ReadOnly = true;
            txtPaymentStatus.Size = new Size(267, 22);
            txtPaymentStatus.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(lblOrderStatus);
            panel7.Controls.Add(txtOrderStatus);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(269, 35);
            panel7.TabIndex = 13;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Dock = DockStyle.Top;
            lblOrderStatus.Location = new Point(0, 0);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(44, 14);
            lblOrderStatus.TabIndex = 7;
            lblOrderStatus.Text = "Estado";
            // 
            // txtOrderStatus
            // 
            txtOrderStatus.Dock = DockStyle.Bottom;
            txtOrderStatus.Location = new Point(0, 11);
            txtOrderStatus.Name = "txtOrderStatus";
            txtOrderStatus.ReadOnly = true;
            txtOrderStatus.Size = new Size(267, 22);
            txtOrderStatus.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnCancel);
            panel6.Controls.Add(btnCancelOrder);
            panel6.Controls.Add(btnFinishOrder);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(278, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(113, 114);
            panel6.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Bottom;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(113, 24);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.BackColor = SystemColors.ControlLightLight;
            btnCancelOrder.Dock = DockStyle.Top;
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.Location = new Point(0, 30);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(113, 30);
            btnCancelOrder.TabIndex = 10;
            btnCancelOrder.Text = "Cancelar orden";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnFinishOrder
            // 
            btnFinishOrder.BackColor = SystemColors.ControlLightLight;
            btnFinishOrder.Dock = DockStyle.Top;
            btnFinishOrder.FlatStyle = FlatStyle.Flat;
            btnFinishOrder.Location = new Point(0, 0);
            btnFinishOrder.Name = "btnFinishOrder";
            btnFinishOrder.Size = new Size(113, 30);
            btnFinishOrder.TabIndex = 11;
            btnFinishOrder.Text = "Finalizar orden";
            btnFinishOrder.UseVisualStyleBackColor = false;
            btnFinishOrder.Click += btnFinishOrder_Click;
            // 
            // formOrderDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formOrderDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de orden";
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
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
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
        private BindingSource saleProductAskedBindingSource;
        private Button btnFinishOrder;
        private Button btnCancelOrder;
        private Button btnCancel;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityAskedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assigneeIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn doneDataGridViewCheckBoxColumn;
    }
}