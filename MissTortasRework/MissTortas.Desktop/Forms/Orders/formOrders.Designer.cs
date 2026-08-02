namespace MissTortas.Desktop.Forms.Orders
{
    partial class formOrders
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
            dgvOrders = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clientUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderBindingSource = new BindingSource(components);
            panel1 = new Panel();
            btnCancel = new Button();
            btnDetails = new Button();
            btnRefresh = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(dgvOrders, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.BackgroundColor = Color.WhiteSmoke;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, statusIdDataGridViewTextBoxColumn, clientUserIdDataGridViewTextBoxColumn });
            dgvOrders.DataSource = orderBindingSource;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.Size = new Size(634, 414);
            dgvOrders.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Identificador";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Estado";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusIdDataGridViewTextBoxColumn
            // 
            statusIdDataGridViewTextBoxColumn.DataPropertyName = "StatusId";
            statusIdDataGridViewTextBoxColumn.HeaderText = "Identificador Estado";
            statusIdDataGridViewTextBoxColumn.Name = "statusIdDataGridViewTextBoxColumn";
            statusIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientUserIdDataGridViewTextBoxColumn
            // 
            clientUserIdDataGridViewTextBoxColumn.DataPropertyName = "ClientUserId";
            clientUserIdDataGridViewTextBoxColumn.HeaderText = "Identificador del cliente";
            clientUserIdDataGridViewTextBoxColumn.Name = "clientUserIdDataGridViewTextBoxColumn";
            clientUserIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Model.Order);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnDetails);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(643, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(154, 414);
            panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Bottom;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 379);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(154, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDetails
            // 
            btnDetails.BackColor = SystemColors.ControlLightLight;
            btnDetails.Dock = DockStyle.Top;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Location = new Point(0, 0);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(154, 30);
            btnDetails.TabIndex = 0;
            btnDetails.Text = "Ver detalle";
            btnDetails.UseVisualStyleBackColor = false;
            btnDetails.Click += btnDetails_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ControlLightLight;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(0, 30);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(154, 35);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refrescar";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // formOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formOrders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de ordenes";
            Load += formOrders_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvOrders;
        private BindingSource orderBindingSource;
        private Panel panel1;
        private Button btnDetails;
        private Button btnCancel;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clientUserIdDataGridViewTextBoxColumn;
        private Button btnRefresh;
    }
}