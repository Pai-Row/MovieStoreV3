using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieUniversal
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private static readonly frmOrder _Instance = new frmOrder();

        public static frmOrder Instance
        {
            get { return frmOrder._Instance; }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public void Run()
        {
            frmOrder lcOrderForm = frmOrder.Instance;
            lcOrderForm.ShowDialog();
            lcOrderForm.Activate();
        }

        private async void UpdateDisplay()
        {
            try
            {
                // lstOrders.DataSource = null; // Crashes when reopening the order form?
                List<clsOrder> OrdersList = await ServiceClient.GetOrdersListAsync();
                lstOrder.DataSource = OrdersList;
                UpdateTotalOrderValue(OrdersList);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateDisplay();
            }
        }

        private void UpdateTotalOrderValue(List<clsOrder> prOrders)
        {
            int lcTotalValue = 0;

            foreach (var order in prOrders)
            {
                lcTotalValue += order.Price;
            }

            lblTotalPrice.Text = string.Format("Total Value: ${0}", lcTotalValue.ToString());
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnCompDel_Click(object sender, EventArgs e)
        {
            DialogResult lcResult = MessageBox.Show("Are you sure you want to delete this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lcResult == DialogResult.Yes)
            {
                clsOrder selectedOrder = lstOrder.SelectedValue as clsOrder;
                MessageBox.Show(await(ServiceClient.DeleteOrderAsync(selectedOrder.OrderID)));
                UpdateDisplay();
            }
        }

        private void lstOrder_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstOrder.SelectedItem);
            if (lcKey != null)
                try
                {
                    clsOrder selectedOrder = lstOrder.SelectedValue as clsOrder;
                    OrderDetail.Run(selectedOrder.OrderID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
    }
}

    

