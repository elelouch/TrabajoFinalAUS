namespace MissTortas.Desktop.Forms.Products
{
    partial class formCreateCategory
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
            txtCategoryName = new TextBox();
            chkFinalCategory = new CheckBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(279, 87);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(117, 15);
            lblCategoryName.TabIndex = 0;
            lblCategoryName.Text = "New Category Name";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(417, 84);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(100, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // chkFinalCategory
            // 
            chkFinalCategory.AutoSize = true;
            chkFinalCategory.Location = new Point(417, 168);
            chkFinalCategory.Name = "chkFinalCategory";
            chkFinalCategory.Size = new Size(102, 19);
            chkFinalCategory.TabIndex = 2;
            chkFinalCategory.Text = "Final Category";
            chkFinalCategory.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(304, 256);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(427, 256);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // formCreateCategory
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(chkFinalCategory);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Name = "formCreateCategory";
            Text = "Create Category";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private CheckBox chkFinalCategory;
        private Button btnConfirm;
        private Button btnCancel;
    }
}