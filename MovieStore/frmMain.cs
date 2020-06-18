using System;
using System.Windows.Forms;

namespace MovieUniversal
{
    public sealed partial class frmMain : Form
    {   //Singleton
        private static readonly frmMain _Instance = new frmMain();

        public delegate void Notify(string prGalleryName);

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstGenres.DataSource = null;
                lstGenres.DataSource = await ServiceClient.GetGenreNamesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void lstGenres_DoubleClick(object sender, EventArgs e)
        {
            openSelectedGenre();
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            openSelectedGenre();
        }

        private void openSelectedGenre ()
        {
            string lcKey;

            lcKey = Convert.ToString(lstGenres.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmGenre.Run(lstGenres.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrder.Instance.Run();
        }
    }
}
