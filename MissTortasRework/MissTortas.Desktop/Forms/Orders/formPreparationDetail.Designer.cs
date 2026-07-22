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
            SuspendLayout();
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(394, 95);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.ReadOnly = true;
            txtOrderId.Size = new Size(175, 23);
            txtOrderId.TabIndex = 0;
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(394, 142);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.Size = new Size(175, 23);
            txtDetails.TabIndex = 1;
            // 
            // comboAssignee
            // 
            comboAssignee.FormattingEnabled = true;
            comboAssignee.Location = new Point(394, 200);
            comboAssignee.Name = "comboAssignee";
            comboAssignee.Size = new Size(175, 23);
            comboAssignee.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 98);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "Order Id";
            // 
            // lblDetails
            // 
            lblDetails.AutoSize = true;
            lblDetails.Location = new Point(305, 145);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(42, 15);
            lblDetails.TabIndex = 4;
            lblDetails.Text = "Details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 203);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 5;
            label3.Text = "Assignee";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(323, 260);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(437, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPrepararationId
            // 
            txtPrepararationId.Location = new Point(394, 53);
            txtPrepararationId.Name = "txtPrepararationId";
            txtPrepararationId.ReadOnly = true;
            txtPrepararationId.Size = new Size(175, 23);
            txtPrepararationId.TabIndex = 8;
            // 
            // lblPreparationId
            // 
            lblPreparationId.AutoSize = true;
            lblPreparationId.Location = new Point(305, 53);
            lblPreparationId.Name = "lblPreparationId";
            lblPreparationId.Size = new Size(81, 15);
            lblPreparationId.TabIndex = 9;
            lblPreparationId.Text = "Preparation Id";
            // 
            // formPreparationDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPreparationId);
            Controls.Add(txtPrepararationId);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(label3);
            Controls.Add(lblDetails);
            Controls.Add(label1);
            Controls.Add(comboAssignee);
            Controls.Add(txtDetails);
            Controls.Add(txtOrderId);
            Name = "formPreparationDetail";
            Text = "formPreparationDetail";
            Load += formPreparationDetail_Load;
            ResumeLayout(false);
            PerformLayout();
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
    }
}