using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace MovieStore
{
    public partial class frmBuyable : frmMovie
    {
        public frmBuyable()
        {
            InitializeComponent();
        }

        public static readonly frmBuyable _Instance = new frmBuyable();
        public static frmBuyable Instance
        {
            get { return frmBuyable._Instance; }
        }

        public static void Run(clsAllMovie prMovie)
        {
            Instance.SetDetails(prMovie);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select a movie from the list.", "Selection Missing",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override void UpdateDisplay()
        {
            txtTitle.Enabled = string.IsNullOrEmpty(_Movie.Title);
            txtTitle.Text = _Movie.Title;
            txtPrice.Text = Convert.ToString(_Movie.Price);
            cbAvailable.Checked = _Movie.Available;
            txtRelease.Text = Convert.ToString(_Movie.ReleaseDate);
            lblDateModified.Text = Convert.ToString(_Movie.DateTimeModified);
            txtDiscount.Text = Convert.ToString(_Movie.Discount);
        }
        protected override void pushData()
        {
            _Movie.Title = txtTitle.Text;
            _Movie.Price = Convert.ToInt16(txtPrice.Text);
            _Movie.Available = cbAvailable.Checked;
            _Movie.ReleaseDate = Convert.ToDateTime(txtRelease.Text);
            _Movie.DateTimeModified = DateTime.Now;
            _Movie.Discount = Convert.ToInt16(txtDiscount.Text);
            _Movie.ReturnDate = DateTime.Now; // Needs default otherwise ded
        }
    }
}
