using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formOrderDetail : Form
    {
        private readonly IOrderService orderService;
        private readonly long orderId;
        private BindingList<SaleProductAsked> saleProductsAsked;
        private BindingList<Preparation> preparations;
        public formOrderDetail(IOrderService orderService, long orderId)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.orderId = orderId;
            this.Text = $"Order {orderId} details";
            this.saleProductsAsked = [];
            this.preparations = [];
            this.dgvPreparations.DataSource = preparations;
            this.dgvAskedSaleProducts.DataSource = saleProductsAsked;
        }
        private async void LoadForm()
        {
            try
            {

                var order = await orderService.GetOrderByIdAsync(orderId);
                preparations.Clear();
                saleProductsAsked.Clear();
                fillFormFromOrder(order);
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == HttpStatusCode.Forbidden || exc.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized");
                    this.Dispose();
                }
            }

        }
        private void fillFormFromOrder(Order order)
        {
            txtClientUsername.Text = order.ClientUserId;
            txtCreationTime.Text = order.CreatedAt;
            txtOrderId.Text = order.Id.ToString();
            txtPaymentStatus.Text = order.PaymentStatus;
            txtOrderStatus.Text = order.Status;
            foreach (var prep in order.Preparations)
            {
                preparations.Add(prep);
            }
            foreach (var spa in order.SaleProducts)
            {
                saleProductsAsked.Add(spa);
            }
        }
        private void formOrderDetail_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
