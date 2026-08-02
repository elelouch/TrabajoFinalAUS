using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.DTO;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.Net;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formPreparationDetail : Form
    {
        public event EventHandler<PreparationUpdatedArgs> OnPreparationUpdate;
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

        private async void CreatePreparation()
        {
            try
            {
                var newPrep = FromFormToCreateRequest();
                var prep = await orderService.CreateOrderPreparationAsync(newPrep);
                MessageBox.Show("Tarea creada exitosamente.");
                RaisePreparationUpdate(prep);
                Dispose();
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == HttpStatusCode.Forbidden || exc.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("No autorizado");
                    Dispose();
                }
            }
        }

        private async void UpdatePreparation()
        {
            try
            {
                var newPrep = FromFormToUpdateRequest();
                var prep = await orderService.UpdateOrderPreparationAsync(preparationId, newPrep);
                MessageBox.Show("Tarea actualizada exitosamente.");
                RaisePreparationUpdate(prep);
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

        private void RaisePreparationUpdate(Preparation prep)
        {
            var handler = OnPreparationUpdate;
            if (handler == null)
            {
                return;
            }
            handler(this, new PreparationUpdatedArgs(prep));
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (preparationId == 0)
                {
                    CreatePreparation();
                }
                else
                {
                    UpdatePreparation();
                }

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

        private void formPreparationDetail_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private async void LoadForm()
        {
            try
            {
                var users = await this.userService.GetAllUsersAsync();
                var newUsers = users.Prepend(new User { Username = "-- Seleccione un usuario --" }).ToList();
                this.comboAssignee.DataSource = newUsers;
                comboAssignee.DisplayMember = nameof(User.Username);
                comboAssignee.ValueMember = nameof(User.UserId);

                if (preparationId == 0)
                {
                    this.txtOrderId.Text = orderId.ToString();
                    this.txtPrepararationId.Text = preparationId.ToString();
                    this.lblHeader.Text = "Creando nueva tarea.";
                }
                else
                {
                    var preparation = await orderService.GetPreparationAsync(preparationId);
                    var userFound = newUsers.Find(u => u.Username == preparation.AssigneeId);
                    comboAssignee.SelectedIndex = userFound == null ? 0 : newUsers.IndexOf(userFound);
                    FromPreparationToForm(preparation);
                    this.lblHeader.Text = $"Modificando tarea con identificador: {preparation.Id}.";
                }
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
            this.txtPrepararationId.Text = preparation.Id.ToString();
        }

        public UpdateOrderPreparationRequest FromFormToUpdateRequest()
        {
            var user = (User?)this.comboAssignee.SelectedItem;
            var userId = user?.UserId ?? Guid.Empty;
            var dto = new UpdateOrderPreparationRequest
            {
                Detail = this.txtDetails.Text,
                AssigneeId = userId.ToString()
            };
            return dto;
        }

        private CreatePreparationRequest FromFormToCreateRequest()
        {
            var dto = new CreatePreparationRequest
            {
                Detail = this.txtDetails.Text,
                OrderId = int.Parse(this.txtOrderId.Text),
                AssigneeId = ((Guid)(this.comboAssignee.SelectedValue ?? "")).ToString(),
            };
            if(dto.AssigneeId.DefaultIfEmpty() == null)
            {
                MessageBox.Show("No se designo un responsable de la tarea.");
            }
            return dto;
        }
    }
}
