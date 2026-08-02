using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.Shared;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms.Orders
{
    public partial class formPreparations : Form
    {
        private readonly IOrderService orderService;
        private BindingList<Preparation> preparations;
        public formPreparations(IOrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.preparations = [];
            this.dgvPreparations.DataSource = preparations;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void btnEndPreparation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPreparations.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please, select a row");
                    return;
                }

                if (dgvPreparations.SelectedRows[0].DataBoundItem is not Preparation prep)
                {
                    return;
                }

                var userMessage = MessageBox.Show("Are you sure you wanna end this preparation. press 'OK' to continue. Else, press 'Cancel'", $"End Preparation #{prep.Id}", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (userMessage == DialogResult.OK)
                {
                    await orderService.EndOrderPreparationAsync(prep.Id);
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

        private void formPreparations_Load(object sender, EventArgs e)
        {
            LoadPreparations();
        }

        private async void LoadPreparations()
        {
            try
            {
                var preps = await orderService.GetUserPreparationsAsync();
                foreach (var prep in preps)
                {
                    preparations.Add(prep);
                }
                if (preparations.Count > 0)
                {
                    var firstRow = dgvPreparations.Rows[0];
                    firstRow.Selected = true;
                    dgvPreparations.CurrentCell = firstRow.Cells[0];
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

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            if (dgvPreparations.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please, select a row");
                return;
            }

            if (dgvPreparations.SelectedRows[0].DataBoundItem is not Preparation prep)
            {
                return;
            }
            var orderDetail = new formOrderDetail(orderService, prep.OrderId, true);
            orderDetail.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(preparations != null)
            {
                preparations.Clear();
                LoadPreparations();
            }
        }
    }
}
