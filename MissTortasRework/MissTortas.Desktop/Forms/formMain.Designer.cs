namespace MissTortas.Desktop.Forms
{
    partial class formMain
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
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            securityToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem1 = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            orderManagementToolStripMenuItem = new ToolStripMenuItem();
            preparationsToolStripMenuItem = new ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = SystemColors.ControlLightLight;
            mainMenuStrip.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, securityToolStripMenuItem, productsToolStripMenuItem, ordersToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(800, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem, logoutToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(61, 20);
            fileToolStripMenuItem.Text = "Archivo";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(169, 22);
            quitToolStripMenuItem.Text = "Salir";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(169, 22);
            logoutToolStripMenuItem.Text = "Cambiar Usuario";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // securityToolStripMenuItem
            // 
            securityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem, rolesToolStripMenuItem });
            securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            securityToolStripMenuItem.Size = new Size(77, 20);
            securityToolStripMenuItem.Text = "Seguridad";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(123, 22);
            usersToolStripMenuItem.Text = "Usuarios";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // rolesToolStripMenuItem
            // 
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(123, 22);
            rolesToolStripMenuItem.Text = "Roles";
            rolesToolStripMenuItem.Click += rolesToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriesToolStripMenuItem, productsToolStripMenuItem1 });
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(75, 20);
            productsToolStripMenuItem.Text = "Productos";
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(199, 22);
            categoriesToolStripMenuItem.Text = "Gestion de Categorias";
            categoriesToolStripMenuItem.Click += categoriesToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem1
            // 
            productsToolStripMenuItem1.Name = "productsToolStripMenuItem1";
            productsToolStripMenuItem1.Size = new Size(199, 22);
            productsToolStripMenuItem1.Text = "Gestion de Productos";
            productsToolStripMenuItem1.Click += productsToolStripMenuItem1_Click;
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { orderManagementToolStripMenuItem, preparationsToolStripMenuItem });
            ordersToolStripMenuItem.ImageTransparentColor = Color.Black;
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(67, 20);
            ordersToolStripMenuItem.Text = "Ordenes";
            // 
            // orderManagementToolStripMenuItem
            // 
            orderManagementToolStripMenuItem.Name = "orderManagementToolStripMenuItem";
            orderManagementToolStripMenuItem.Size = new Size(186, 22);
            orderManagementToolStripMenuItem.Text = "Gestion de Ordenes";
            orderManagementToolStripMenuItem.Click += orderManagementToolStripMenuItem_Click;
            // 
            // preparationsToolStripMenuItem
            // 
            preparationsToolStripMenuItem.Name = "preparationsToolStripMenuItem";
            preparationsToolStripMenuItem.Size = new Size(186, 22);
            preparationsToolStripMenuItem.Text = "Tareas";
            preparationsToolStripMenuItem.Click += preparationsToolStripMenuItem_Click;
            // 
            // formMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSalmon;
            ClientSize = new Size(800, 450);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = mainMenuStrip;
            Name = "formMain";
            Text = "MissTortas";
            WindowState = FormWindowState.Maximized;
            Shown += formMain_Shown;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem securityToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem rolesToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem1;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem orderManagementToolStripMenuItem;
        private ToolStripMenuItem preparationsToolStripMenuItem;
    }
}