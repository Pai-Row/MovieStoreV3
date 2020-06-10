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
    public partial class frmBuyable : Form
    {
        public frmBuyable()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select a movie from the list.", "Selection Missing",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
