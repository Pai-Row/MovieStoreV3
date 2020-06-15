using System;
using System.Windows.Forms;

namespace MovieStore
{
    public partial class InputBox : Form
    {
        private string _Answer;

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Answer()
        {
            return _Answer; }
        }
    }
