using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formPreparationDetail : Form
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly long orderId;
        private readonly long preparationId;

        public formPreparationDetail(IUserService userService, IOrderService orderService, long orderId, long preparationId)
        {
            InitializeComponent();
            this.userService = userService;
            this.orderService = orderService;
            this.orderId = orderId;
            this.preparationId = preparationId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void formPreparationDetail_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private async void LoadForm()
        {
            try
            {
                if(preparationId != 0)
                {
                    var preparation = await orderService.GetPreparationAsync(preparationId);
                    FromPreparationToForm(preparation);
                }

                var users = await this.userService.GetAllUsersAsync();
                this.comboAssignee.DataSource = users;
                comboAssignee.DisplayMember = nameof(User.Username);
                comboAssignee.ValueMember = nameof(User.UserId);
                this.txtOrderId.Text = orderId.ToString();
                this.txtPrepararationId.Text = preparationId.ToString();
            }
            catch (ApiException ex)
            {
                ErrorDisplay.Show(this, ex);
                if (ex.StatusCode == System.Net.HttpStatusCode.Forbidden || ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
        }

        private void FromPreparationToForm(Preparation preparation)
        {
            this.txtDetails.Text = preparation.Detail;
            this.txtOrderId.Text = preparation.OrderId.ToString();
            this.comboAssignee.DataSource = preparation.AssigneeId;
            this.txtPrepararationId.Text = preparation.Id.ToString();
        }
    }
}
