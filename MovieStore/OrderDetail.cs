using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieUniversal
{
    public partial class OrderDetail : Form
    {
        private clsOrder _Order;
        public OrderDetail()
        {
            InitializeComponent();
        }

        private static readonly OrderDetail _Instance = new OrderDetail();

        public static OrderDetail Instance
        {
            get { return OrderDetail._Instance; }
        }

        public static void Run(int prID)
        {
            OrderDetail lcOrderDetailForm = OrderDetail.Instance;
            lcOrderDetailForm.refreshFormFromDB(prID);
            lcOrderDetailForm.ShowDialog();
            lcOrderDetailForm.Activate();
        }

        private async void refreshFormFromDB(int prID)
        {
            SetDetails(await ServiceClient.GetOrderDetailsAsync(prID));
        }

        public void SetDetails(clsOrder prOrder)
        {
            _Order = prOrder;
            UpdateDisplay(prOrder);
        }

        private void UpdateDisplay(clsOrder prOrder)
        {
            lblDetail.Text = string.Format(
                "OrderID: {0}\nMovieID: {1}\n\nQuantity: {2}\nPrice: ${3}\n\nDate: {4}\nCustomer Name: {5}\nCustomer Address: {6}",
                prOrder.OrderID, prOrder.MovieID, prOrder.Quantity, prOrder.Price, prOrder.Date, prOrder.CustomerName, prOrder.CustomerAddress
                );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
