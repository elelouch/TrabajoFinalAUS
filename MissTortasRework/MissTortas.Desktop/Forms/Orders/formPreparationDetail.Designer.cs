namespace MissTortas.Desktop.Forms.Orders
{
    partial class formPreparationDetail
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
            txtOrderId = new TextBox();
            txtDetails = new TextBox();
            comboAssignee = new ComboBox();
            label1 = new Label();
            lblDetails = new Label();
            label3 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtPrepararationId = new TextBox();
            lblPreparationId = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            panel7 = new Panel();
            lblHeader = new Label();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtOrderId
            // 
            txtOrderId.Dock = DockStyle.Bottom;
            txtOrderId.Location = new Point(0, 11);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.ReadOnly = true;
            txtOrderId.Size = new Size(226, 22);
            txtOrderId.TabIndex = 0;
            // 
            // txtDetails
            // 
            txtDetails.BorderStyle = BorderStyle.None;
            txtDetails.Dock = DockStyle.Bottom;
            txtDetails.Location = new Point(0, 12);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.Size = new Size(226, 21);
            txtDetails.TabIndex = 1;
            // 
            // comboAssignee
            // 
            comboAssignee.Dock = DockStyle.Bottom;
            comboAssignee.FlatStyle = FlatStyle.Flat;
            comboAssignee.FormattingEnabled = true;
            comboAssignee.Location = new Point(0, 11);
            comboAssignee.Name = "comboAssignee";
            comboAssignee.Size = new Size(226, 22);
            comboAssignee.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 14);
            label1.TabIndex = 3;
            label1.Text = "Identificador de orden";
            // 
            // lblDetails
            // 
            lblDetails.AutoSize = true;
            lblDetails.Dock = DockStyle.Top;
            lblDetails.Location = new Point(0, 0);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(44, 14);
            lblDetails.TabIndex = 4;
            lblDetails.Text = "Detalle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 14);
            label3.TabIndex = 5;
            label3.Text = "Usuario a asignar";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(0, 259);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 30);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(150, 259);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPrepararationId
            // 
            txtPrepararationId.Dock = DockStyle.Bottom;
            txtPrepararationId.Location = new Point(0, 11);
            txtPrepararationId.Name = "txtPrepararationId";
            txtPrepararationId.ReadOnly = true;
            txtPrepararationId.Size = new Size(226, 22);
            txtPrepararationId.TabIndex = 8;
            // 
            // lblPreparationId
            // 
            lblPreparationId.AutoSize = true;
            lblPreparationId.Dock = DockStyle.Top;
            lblPreparationId.Location = new Point(0, 0);
            lblPreparationId.Name = "lblPreparationId";
            lblPreparationId.Size = new Size(75, 14);
            lblPreparationId.TabIndex = 9;
            lblPreparationId.Text = "Identificador";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel5);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(163, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(474, 414);
            panel6.TabIndex = 16;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblHeader);
            panel7.Location = new Point(133, 9);
            panel7.Name = "panel7";
            panel7.Size = new Size(227, 43);
            panel7.TabIndex = 16;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(43, 14);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "label2";
            // 
            // panel5
            // 
            panel5.Controls.Add(btnCancel);
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(btnConfirm);
            panel5.Controls.Add(panel3);
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel1);
            panel5.Location = new Point(132, 70);
            panel5.Name = "panel5";
            panel5.Size = new Size(228, 289);
            panel5.TabIndex = 15;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(comboAssignee);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 105);
            panel4.Name = "panel4";
            panel4.Size = new Size(228, 35);
            panel4.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblDetails);
            panel3.Controls.Add(txtDetails);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(228, 35);
            panel3.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtOrderId);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(228, 35);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblPreparationId);
            panel1.Controls.Add(txtPrepararationId);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 35);
            panel1.TabIndex = 11;
            // 
            // formPreparationDetail
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formPreparationDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de la tarea";
            Load += formPreparationDetail_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtOrderId;
        private TextBox txtDetails;
        private ComboBox comboAssignee;
        private Label label1;
        private Label lblDetails;
        private Label label3;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtPrepararationId;
        private Label lblPreparationId;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label lblHeader;
    }
}