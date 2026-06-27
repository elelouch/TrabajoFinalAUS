using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.UserService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            var authService = new AuthService();
            formLogin appLogin = new(authService);
            mainMenuStrip.Visible = false;
            var dialogRes = appLogin.ShowDialog();
            if (dialogRes != DialogResult.OK)
            {
                this.Dispose();
            }
            mainMenuStrip.Visible = true;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var usersService = new UserService();
            var usersForm = new formUsers(usersService);
            usersForm.MdiParent = this;
            usersForm.Show();
        }
    }
}
