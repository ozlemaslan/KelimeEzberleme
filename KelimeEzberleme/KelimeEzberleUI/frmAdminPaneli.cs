using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeEzberleUI
{
    public partial class frmAdminPaneli : Form
    {
        public frmAdminPaneli()
        {
            InitializeComponent();
        }

        private void kullaniciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullaniciListele kullaniciListele = new frmKullaniciListele();
            kullaniciListele.MdiParent = this;
            kullaniciListele.Show();
        }
    }
}
