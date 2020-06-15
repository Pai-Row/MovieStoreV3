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
    public partial class frmGenre : Form
    {

        private clsGenre _Genre;
        //private clsWorksList _WorksList;

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
            lstMovies.DataSource = null;
            if (_Genre.MovieList != null)
                lstMovies.DataSource = prGenre.MovieList;
        }

        //public void UpdateForm()
        //{
        //    lstMovies.Text = _Genre.Name;
        //    lblTags.Text = _Genre.Tags;
        //    lstMovies.Text = _Genre.Price;
        //    _lstMovies = _Genre.lstMovies;

        //    frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
        //    updateTitle(_Genre.GenreList.MovieName);
        //}

        public void SetDetails(clsGenre prGenre)
        {
            _Genre = prGenre;
            //txtName.Enabled = string.IsNullOrEmpty(_Genre.Name);
            //UpdateForm();
            UpdateDisplay(prGenre);
            frmMain.Instance.MovieNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Genre.GenreList.MovieName);
            Show();
        }

        private void pushData()
        {
            //_Artist.Name = txtName.Text;
            //_Artist.Speciality = txtSpeciality.Text;
            //_Artist.Phone = txtPhone.Text;
            //_WorksList.SortOrder = _SortOrder; // no longer required, updated with each rbByDate_CheckedChanged
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //int lcIndex = lstWorks.SelectedIndex;

            //if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    _WorksList.RemoveAt(lcIndex);
            //    UpdateDisplay();
            //    frmMain.Instance.UpdateDisplay();
            //}
        }

        private Boolean isValid()
        {
            //if (txtname.enabled && txtname.text != "")
            //    if (_artist.isduplicate(txtname.text))
            //    {
            //        messagebox.show("artist with that name already exists!", "error adding artist");
            //        return false;
            //    }
            //    else
            //        return true;
            //else
            return true;
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //_WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            //UpdateDisplay();
        }

        private void lstMovies_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //_WorksList.EditWork(lstWorks.SelectedIndex);
                // UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            {
                Hide();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply;
            InputBox inputBox = new InputBox("Rent or Buy?");
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Get answer
                lcReply = (inputBox.Answer());
                Console.WriteLine(lcReply);

                // Make new movie of corresponding type
                clsAllMovie lcMovie = new clsAllMovie();
                if (lcReply != string.Empty)
                    lcMovie.GenreID = _Genre.GenreID;
                lcMovie.Rentable = lcReply;

                // Open correct form
                frmMovie.DispatchWorkForm(lcMovie);
                refreshFormFromDB(_Genre.GenreName);
            }
            else
            {
                inputBox.Close();
                Console.WriteLine("No response");
            }
            refreshFormFromDB(_Genre.GenreName);
        }
    }
}
