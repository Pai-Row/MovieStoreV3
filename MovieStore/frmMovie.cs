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
    public partial class frmMovie : Form
    {
        public frmMovie()
        {
            InitializeComponent();
        }

        protected clsAllMovie _Movie;

        public delegate void LoadGameFormDelegate(clsAllMovie prMovie);
        public static Dictionary<Boolean, Delegate> _MoviesForm = new Dictionary<Boolean, Delegate>
        {
            {true, new LoadGameFormDelegate(frmRentable.Run)},
            {false, new LoadGameFormDelegate(frmBuyable.Run)}
        };

        public void SetDetails(clsAllMovie prMovie)
        {
            _Movie = prMovie;
            UpdateDisplay();
            ShowDialog();
        }

        public static void DispatchWorkForm(clsAllMovie prMovie)
        {
            _MoviesForm[prMovie.Rentable].DynamicInvoke(prMovie);
        }


        protected virtual void UpdateDisplay()
        {
            txtTitle.Text = _Movie.Title;
            txtPrice.Text = Convert.ToString(_Movie.Price);
            cbAvailable.Checked = _Movie.Available;
            txtRelease.Text = Convert.ToString(_Movie.ReleaseDate);
            lblDateModified.Text = Convert.ToString(_Movie.DateTimeModified);
        }
        protected virtual void pushData()
        {
            _Movie.Title = txtTitle.Text;
            _Movie.Price = Convert.ToInt16(txtPrice.Text);
            _Movie.Available = cbAvailable.Checked;
            _Movie.ReleaseDate = Convert.ToDateTime(txtRelease.Text);
            _Movie.DateTimeModified = Convert.ToDateTime(lblDateModified.Text);

        }

        private async void checkExistingRentable()
        {
            List<string> lcTitle = await ServiceClient.GetMovieTitlesAsync(txtTitle.Text, _Movie.Rentable);
            if (!string.IsNullOrEmpty(txtTitle.Text) && lcTitle.Count <= 0)
                MessageBox.Show(await ServiceClient.PostMovieAsync(_Movie), "", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show("Invalid movie title, please use another title");
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            pushData();
            if (txtTitle.Enabled)
            {
                checkExistingRentable();
            }
            else
                MessageBox.Show(await ServiceClient.UpdateMovieAsync(_Movie), "", MessageBoxButtons.OK, MessageBoxIcon.None);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
