using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    public partial class frmMovie : Form
    {
        public frmMovie()
        {
            InitializeComponent();
        }

        protected clsAllMovie _Movie;

        public delegate void LoadGameFormDelegate(clsAllMovie prMovie);
        public static Dictionary<string, Delegate> _MoviesForm = new Dictionary<string, Delegate>
        {
            {"Rent", new LoadGameFormDelegate(frmRentable.Run)},
            {"Buy", new LoadGameFormDelegate(frmBuyable.Run)}
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
            txtQuantity.Text = Convert.ToString(_Movie.Quantity);
            txtRelease.Text = Convert.ToString(_Movie.ReleaseDate);
            lblDateModified.Text = Convert.ToString(_Movie.DateTimeModified);
        }
    }
}
