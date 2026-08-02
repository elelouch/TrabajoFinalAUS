using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;
using System.Net;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formOrderDetail : Form
    {
        private readonly IOrderService orderService;
        private readonly long orderId;
        private readonly BindingList<SaleProductAsked> saleProductsAsked;
        private readonly BindingList<Preparation> preparations;
        private readonly IUserService? userService;

        public formOrderDetail(IOrderService orderService, long orderId, bool disableControls) : this(orderService, orderId, disableControls, null)
        {
        }
        public formOrderDetail(IOrderService orderService, long orderId, bool disableControls, IUserService? userService)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.orderId = orderId;
            this.Text = $"Detalles de orden: {orderId}";
            this.saleProductsAsked = [];
            this.preparations = [];
            this.dgvPreparations.DataSource = preparations;
            this.dgvAskedSaleProducts.DataSource = saleProductsAsked;
            if (disableControls)
            {
                DisableAllButtons(this);
            }
            this.userService = userService;
        }

        private void DisableAllButtons(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button && button != this.btnCancel)
                {
                    button.Enabled = false;
                }
                if (control.HasChildren)
                {
                    DisableAllButtons(control);
                }
            }
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
                    MessageBox.Show("No autorizado.");
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
            if (preparations.Count > 0)
            {
                var firstRow = dgvPreparations.Rows[0];
                firstRow.Selected = true;
                dgvPreparations.CurrentCell = firstRow.Cells[0];
            }
            if (saleProductsAsked.Count > 0)
            {
                var firstRow = dgvAskedSaleProducts.Rows[0];
                firstRow.Selected = true;
                dgvAskedSaleProducts.CurrentCell = firstRow.Cells[0];
            }
        }
        private void formOrderDetail_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void btnFinishOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var res = MessageBox.Show(
                    "Vas a finalizar una Orden, esto implica que el estado pasará a 'Finalizado' y los productos se descontarán del inventario correspondiente. Presiona 'Aceptar' para continuar o 'Cancelar' en caso contrario.",
                    "Finalizando Orden",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );
                if (res != DialogResult.OK)
                {
                    return;
                }

                await orderService.EndOrderAsync(orderId);
                MessageBox.Show("Orden finalizada correctamente.", "Orden finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
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

        private async void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var res = MessageBox.Show(
                    "Vas a cancelar una Orden, esto implica que el estado pasará a 'Cancelado', los productos se removerán de la reserva y NO se descontarán del inventario correspondiente. Presiona 'Aceptar' para continuar o 'Cancelar' en caso contrario.",
                    "Cancelando Orden",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );
                if (res != DialogResult.OK)
                {
                    return;
                }
                await orderService.CancelOrderAsync(orderId);
                MessageBox.Show("Orden cancelada correctamente", "Orden cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
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

        private void btnAddPreparation_Click(object sender, EventArgs e)
        {
            if (userService == null)
            {
                MessageBox.Show("User service no esta disponible.");
                return;
            }

            var formPreparationDetail = new formPreparationDetail(userService, orderService, orderId, 0);
            formPreparationDetail.OnPreparationUpdate += FormPreparationDetail_OnPreparationUpdate;
            formPreparationDetail.ShowDialog();
        }

        private void FormPreparationDetail_OnPreparationUpdate(object? sender, Events.PreparationUpdatedArgs e)
        {
            var newPrep = e.Preparation;
            var aux = preparations.FirstOrDefault(p => p.Id == newPrep.Id);
            if (aux == null)
            {
                preparations.Add(newPrep);
            }
            else
            {
                var ix = preparations.IndexOf(aux);
                preparations[ix] = newPrep;
            }

        }

        private void btnModifyPreparation_Click(object sender, EventArgs e)
        {
            if (dgvPreparations.SelectedRows.Count <= 0)
            {
                return;
            }

            if (userService == null)
            {
                MessageBox.Show("User service no esta disponible.");
                return;
            }

            if (dgvPreparations.SelectedRows[0].DataBoundItem is not Preparation prep)
            {
                return;
            }

            var formPreparationDetail = new formPreparationDetail(userService, orderService, orderId, prep.Id);
            formPreparationDetail.OnPreparationUpdate += FormPreparationDetail_OnPreparationUpdate;
            formPreparationDetail.ShowDialog();
            formPreparationDetail.Dispose();
        }

    }
}
