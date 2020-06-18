using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgMovie : Page
    {
        public pgMovie()
        {
            this.InitializeComponent();
        }

        private clsAllMovie _Movie;

        private void UpdateDisplay(clsAllMovie prMovie)
        {
            txbTitle.Text = "Title: " + prMovie.Title;
            txbPrice.Text = "Price: $" + Convert.ToString(prMovie.Price);
            txbAvailable.Text = string.Format("Available: {0}", prMovie.Available);
            txbReleaseDate.Text = string.Format("Release Date: {0}", prMovie.ReleaseDate);
            txbRentable.Text = string.Format("Rentable: {0}", prMovie.Rentable);
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                try
                {
                    _Movie = e.Parameter as clsAllMovie;
                    UpdateDisplay(_Movie);
                }
                catch (Exception ex)
                {
                    txbMessage.Text = ex.Message;
                }
            }
        }
        private clsOrder createOrder(clsAllMovie prMovie)
        {
            int discount = (int)prMovie.Discount / 100 * prMovie.Price;
            clsOrder lcOrder = new clsOrder()
            {
                MovieID = prMovie.MovieID,
                Quantity = Convert.ToInt16(txtQuantity.Text),
                Price = prMovie.Price - discount * Convert.ToInt16(txtQuantity.Text),
                Date = DateTime.Now,
                CustomerName = txtCustomerName.Text,
                CustomerAddress = txtCustomerAddress.Text
            };
            return lcOrder;
        }

        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerName.Text == string.Empty || txtCustomerAddress.Text == string.Empty || txtQuantity.Text == string.Empty)
                {
                    txbMessage.Text = "Please enter correct details";
                }
                else
                {
                    int lcAmountOrdered = Convert.ToInt16(txtQuantity.Text);
                    if (_Movie.Available)
                    {
                        txbMessage.Text = await ServiceClient.PostOrderAsync(createOrder(_Movie));
                    }
                    else
                    {
                        txbMessage.Text = "Unavailable";
                    }
                }


            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
            } 
        }

    }

}
