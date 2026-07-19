using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formOrders : Form
    {
        private readonly IOrderService orderService;
        //private formOrderDetail? formOrderDetail;
        private readonly BindingList<Order> orders;
        public formOrders(IOrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.orders = [];
            this.dgvOrders.DataSource = orders;
        }

        private async void LoadDataGrid()
        {
            try
            {
                var all = await orderService.GetOrdersAsync();
                orders.Clear();
                foreach (var order in all)
                {
                    this.orders.Add(order);
                }
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }

        }

        private void formOrders_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(dgvOrders.SelectedRows.Count <= 0)
            {
                return;
            }
            if (dgvOrders.SelectedRows[0].DataBoundItem is not Order order)
            {
                return;
            }
            
            var formOrderDetail = new formOrderDetail(orderService, order.Id);
            formOrderDetail.ShowDialog();
        }
    }
}
