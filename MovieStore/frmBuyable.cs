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
    }
}
