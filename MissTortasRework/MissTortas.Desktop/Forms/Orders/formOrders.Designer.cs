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
            btnDetails = new Button();
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
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, statusIdDataGridViewTextBoxColumn, clientUserIdDataGridViewTextBoxColumn });
            dgvOrders.DataSource = orderBindingSource;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(634, 444);
            dgvOrders.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // statusIdDataGridViewTextBoxColumn
            // 
            statusIdDataGridViewTextBoxColumn.DataPropertyName = "StatusId";
            statusIdDataGridViewTextBoxColumn.HeaderText = "StatusId";
            statusIdDataGridViewTextBoxColumn.Name = "statusIdDataGridViewTextBoxColumn";
            // 
            // clientUserIdDataGridViewTextBoxColumn
            // 
            clientUserIdDataGridViewTextBoxColumn.DataPropertyName = "ClientUserId";
            clientUserIdDataGridViewTextBoxColumn.HeaderText = "ClientUserId";
            clientUserIdDataGridViewTextBoxColumn.Name = "clientUserIdDataGridViewTextBoxColumn";
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Model.Order);
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDetails);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(643, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(154, 444);
            panel1.TabIndex = 1;
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(13, 9);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(92, 23);
            btnDetails.TabIndex = 0;
            btnDetails.Text = "Detail";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // formOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formOrders";
            Text = "formOrders";
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
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clientUserIdDataGridViewTextBoxColumn;
        private BindingSource orderBindingSource;
        private Panel panel1;
        private Button btnDetails;
    }
}