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
    public sealed partial class pgGenre : Page
    {
        public pgGenre()
        {
            this.InitializeComponent();
        }

        private clsGenre _Genre;

        private void UpdateDisplay(clsGenre prGenre)
        {
            lstMovies.ItemsSource = null;
            if (_Genre.MovieList != null)
                lstMovies.ItemsSource = prGenre.MovieList;

            txbGenre.Text = string.Format("Genre: {0}", prGenre.Name);
            txbTags.Text = string.Format("Tags: {0}", prGenre.Tags);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                try
                {
                    string lcGenreName = e.Parameter.ToString();
                    _Genre = await ServiceClient.GetGenreAsync(lcGenreName);
                    UpdateDisplay(_Genre);
                }
                catch (Exception ex)
                {
                    txbMessage.Text = ex.Message;
                }

            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lstMovies.SelectedItem != null)
            {
                Frame.Navigate(typeof(pgMovie), _Genre.MovieList[lstMovies.SelectedIndex]);
            }
        }
    }
}
