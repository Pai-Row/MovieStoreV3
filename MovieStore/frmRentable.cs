using System;
using System.Windows.Forms;

namespace MovieUniversal
{
    public partial class frmRentable : frmMovie
    {
        public frmRentable()
        {
            InitializeComponent();
        }

        public static readonly frmRentable _Instance = new frmRentable();
        public static frmRentable Instance
        {
            get { return frmRentable._Instance; }
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
            txtReturn.Text = Convert.ToString(_Movie.ReturnDate);
        }
        protected override void pushData()
        {
            _Movie.Title = txtTitle.Text;
            _Movie.Price = Convert.ToInt16(txtPrice.Text);
            _Movie.Available = cbAvailable.Checked;
            _Movie.ReleaseDate = Convert.ToDateTime(txtRelease.Text);
            _Movie.DateTimeModified = DateTime.Now;
            _Movie.ReturnDate = Convert.ToDateTime(txtReturn.Text);
            _Movie.Discount = 0; // Set Default Discount because it will break otherwise
        }
    }
}
