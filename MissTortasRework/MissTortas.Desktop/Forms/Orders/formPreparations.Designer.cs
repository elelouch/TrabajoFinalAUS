namespace MissTortas.Desktop.Forms.Orders
{
    partial class formPreparations
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
            splitContainer1 = new SplitContainer();
            dgvPreparations = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clientUsernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doneDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            OrderId = new DataGridViewTextBoxColumn();
            preparationBindingSource = new BindingSource(components);
            btnCancel = new Button();
            btnEndPreparation = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreparations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)preparationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvPreparations);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnEndPreparation);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 650;
            splitContainer1.TabIndex = 0;
            // 
            // dgvPreparations
            // 
            dgvPreparations.AllowUserToAddRows = false;
            dgvPreparations.AllowUserToDeleteRows = false;
            dgvPreparations.AutoGenerateColumns = false;
            dgvPreparations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreparations.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, detailDataGridViewTextBoxColumn, clientUsernameDataGridViewTextBoxColumn, doneDataGridViewCheckBoxColumn, OrderId });
            dgvPreparations.DataSource = preparationBindingSource;
            dgvPreparations.Dock = DockStyle.Fill;
            dgvPreparations.Location = new Point(0, 0);
            dgvPreparations.Name = "dgvPreparations";
            dgvPreparations.ReadOnly = true;
            dgvPreparations.Size = new Size(650, 450);
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
            // clientUsernameDataGridViewTextBoxColumn
            // 
            clientUsernameDataGridViewTextBoxColumn.DataPropertyName = "ClientUsername";
            clientUsernameDataGridViewTextBoxColumn.HeaderText = "ClientUsername";
            clientUsernameDataGridViewTextBoxColumn.Name = "clientUsernameDataGridViewTextBoxColumn";
            clientUsernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doneDataGridViewCheckBoxColumn
            // 
            doneDataGridViewCheckBoxColumn.DataPropertyName = "Done";
            doneDataGridViewCheckBoxColumn.HeaderText = "Done";
            doneDataGridViewCheckBoxColumn.Name = "doneDataGridViewCheckBoxColumn";
            doneDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // OrderId
            // 
            OrderId.DataPropertyName = "OrderId";
            OrderId.HeaderText = "OrderId";
            OrderId.Name = "OrderId";
            OrderId.ReadOnly = true;
            // 
            // preparationBindingSource
            // 
            preparationBindingSource.DataSource = typeof(Model.Preparation);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 75);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEndPreparation
            // 
            btnEndPreparation.Location = new Point(12, 30);
            btnEndPreparation.Name = "btnEndPreparation";
            btnEndPreparation.Size = new Size(122, 23);
            btnEndPreparation.TabIndex = 0;
            btnEndPreparation.Text = "End Preparation";
            btnEndPreparation.UseVisualStyleBackColor = true;
            btnEndPreparation.Click += btnEndPreparation_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Preparations";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreparations).EndInit();
            ((System.ComponentModel.ISupportInitialize)preparationBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvPreparations;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clientUsernameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn doneDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn OrderId;
        private BindingSource preparationBindingSource;
        private Button btnEndPreparation;
        private Button btnCancel;
    }
}