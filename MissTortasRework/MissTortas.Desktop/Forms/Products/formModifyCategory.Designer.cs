namespace MissTortas.Desktop.Forms.Products
{
    partial class formModifyCategory
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
            lblCategoryName = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtCategoryName = new TextBox();
            comboMoveParent = new ComboBox();
            lblSelectParent = new Label();
            chkEnabled = new CheckBox();
            SuspendLayout();
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(237, 95);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(90, 15);
            lblCategoryName.TabIndex = 0;
            lblCategoryName.Text = "Category Name";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(281, 276);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(426, 276);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(363, 92);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(121, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // comboMoveParent
            // 
            comboMoveParent.FormattingEnabled = true;
            comboMoveParent.Location = new Point(363, 158);
            comboMoveParent.Name = "comboMoveParent";
            comboMoveParent.Size = new Size(121, 23);
            comboMoveParent.TabIndex = 4;
            // 
            // lblSelectParent
            // 
            lblSelectParent.AutoSize = true;
            lblSelectParent.Location = new Point(237, 158);
            lblSelectParent.Name = "lblSelectParent";
            lblSelectParent.Size = new Size(74, 15);
            lblSelectParent.TabIndex = 5;
            lblSelectParent.Text = "Move Parent";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Location = new Point(363, 227);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(68, 19);
            chkEnabled.TabIndex = 6;
            chkEnabled.Text = "Enabled";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // formModifyCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkEnabled);
            Controls.Add(lblSelectParent);
            Controls.Add(comboMoveParent);
            Controls.Add(txtCategoryName);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblCategoryName);
            Name = "formModifyCategory";
            Text = "Form1";
            Load += formModifyCategory_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryName;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtCategoryName;
        private ComboBox comboMoveParent;
        private Label lblSelectParent;
        private CheckBox chkEnabled;
    }
}