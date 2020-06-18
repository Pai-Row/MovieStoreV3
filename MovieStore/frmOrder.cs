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
        private static clsOrder _Order;
        // private static Dictionary<int, clsOrder> _OrderList = new Dictionary<int, clsOrder>();

        public static frmOrder Instance
        {
            get { return frmOrder._Instance; }
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public void Run()
        {
            frmOrder lcOrderForm = frmOrder.Instance;
            lcOrderForm.ShowDialog();
            lcOrderForm.Activate();
        }

        private async void RefreshformFromDB()
        {
            //SetDetails(await ServiceClient.GetOrderDetailsAsync(Convert.ToInt16(lstOrder.SelectedItem)));
            //UpdateTotalOrderValue();
        }

        //private async void SetDetails(clsOrder prOrder)
        //{
        //    _Order = prOrder;
        //    List<string> lcOrderTitle = await (ServiceClient.GetMovieTitleAsync(prOrder.MovieID));
        //    lstOrder.Text = string.Format("Title: {0}\nPrice: ${1}\n\nQuantity: {2}\nDate: {3}\n\nCustomer Name: {4}\nCustomer Address: {5}",
        //        lcOrderTitle[0], Convert.ToString(prOrder.Price), prOrder.Quantity, prOrder.Date, prOrder.CustomerName, prOrder.CustomerAddress);
        //}

        private async void UpdateDisplay()
        {
            try
            {
                // lstOrders.DataSource = null; // Crashes when reopening the order form?
                lstOrder.DataSource = await ServiceClient.GetOrdersListAsync();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateDisplay();
            }
            
            RefreshformFromDB();
        }

        //private async void UpdateTotalOrderValue()
        //{
        //    double lcTotalValue = 0;
        //    List<double> lcPrice = new List<double>();

        //    try
        //    {
        //        lcPrice = await ServiceClient.GetTotalOrdersValueAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        DialogResult result = MessageBox.Show(ex.Message + " Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
        //        if (result == DialogResult.Retry)
        //            UpdateTotalOrderValue();
        //    }

        //    foreach (var price in lcPrice)
        //    {
        //        lcTotalValue += price;
        //    }

        //    lblTotalPrice.Text = string.Format("Total Value: ${0}", lcTotalValue.ToString());
        //}

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshformFromDB();
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
                MessageBox.Show(await(ServiceClient.DeleteOrderAsync(_Order.OrderID)));
                UpdateDisplay();
            }
        }
    }
}

    

