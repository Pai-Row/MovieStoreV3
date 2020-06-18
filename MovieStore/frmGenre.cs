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
    public partial class frmGenre : Form
    {

        private clsGenre _Genre;

        private static Dictionary<string, frmGenre> _GenreFormList =
            new Dictionary<string, frmGenre>();
        public frmGenre()
        {
            InitializeComponent();
        }

        public static void Run(string prGenreName)
        {
            frmGenre lcGenreForm;
            if (string.IsNullOrEmpty(prGenreName) ||
                !_GenreFormList.TryGetValue(prGenreName, out lcGenreForm))
            {
                lcGenreForm = new frmGenre();
                if (string.IsNullOrEmpty(prGenreName))
                    lcGenreForm.SetDetails(new clsGenre());
                else
                {
                    _GenreFormList.Add(prGenreName, lcGenreForm);
                    lcGenreForm.refreshFormFromDB(prGenreName);
                }
            }
            else
            {
                lcGenreForm.Show();
                lcGenreForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prGenreName)
        {
            SetDetails(await ServiceClient.GetGenreAsync(prGenreName));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        private void UpdateDisplay(clsGenre prGenre)
        {
            lblTags.Text = "Tags: " + prGenre.Tags;
            lstMovies.DataSource = null;
            if (_Genre.MovieList != null)
                lstMovies.DataSource = prGenre.MovieList;
        }

        public void SetDetails(clsGenre prGenre)
        {
            _Genre = prGenre;
            UpdateDisplay(prGenre);
            frmMain.Instance.MovieNameChanged += new frmMain.Notify(updateTitle);
            Show();
        }

        private void lstMovies_DoubleClick(object sender, EventArgs e)
        {
            frmMovie.DispatchWorkForm(lstMovies.SelectedValue as clsAllMovie);
            refreshFormFromDB(_Genre.Name);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            {
                Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean lcReply;
            InputBox inputBox = new InputBox("Rent or Buy?");
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Get answer
                lcReply = (inputBox.Answer());
                Console.WriteLine(lcReply);

                // Make new movie of corresponding type
                clsAllMovie lcMovie = new clsAllMovie();
                if (lcReply)
                    lcMovie.GenreID = _Genre.GenreID;
                lcMovie.Rentable = lcReply;

                // Open correct form
                frmMovie.DispatchWorkForm(lcMovie);
                refreshFormFromDB(_Genre.Name);
            }
            else
            {
                inputBox.Close();
                Console.WriteLine("No response");
            }
            refreshFormFromDB(_Genre.Name);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult lcResult = MessageBox.Show("Are you sure you want to delete this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lcResult == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteMovieAsync(lstMovies.SelectedItem as clsAllMovie));
                refreshFormFromDB(_Genre.Name);
            }
        }

        private void lblEdit_Click(object sender, EventArgs e)
        {
            frmMovie.DispatchWorkForm(lstMovies.SelectedValue as clsAllMovie);
            refreshFormFromDB(_Genre.Name);
        }

        private void frmGenre_Enter(object sender, EventArgs e)
        {
            refreshFormFromDB(_Genre.Name);
        }
    }
}
