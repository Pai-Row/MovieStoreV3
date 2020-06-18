using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MovieUniversal
{
    public partial class InputBox : Form
    {
        private Boolean _Answer;

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbBuyable.Checked || rbRentable.Checked)
            {
                _Answer = rbRentable.Checked;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public Boolean Answer()
        {
            return _Answer; }
        }
    }
