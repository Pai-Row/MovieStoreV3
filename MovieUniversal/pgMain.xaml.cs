using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                lstGenres.ItemsSource = await ServiceClient.GetGenreNamesAsync();
            }
            catch (Exception ex)

            {
                txbMessage.Text = "Message: " + ex.Message;
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            if (lstGenres.SelectedItem != null)
                Frame.Navigate(typeof(pgGenre), lstGenres.SelectedItem);
        }
    }
}
