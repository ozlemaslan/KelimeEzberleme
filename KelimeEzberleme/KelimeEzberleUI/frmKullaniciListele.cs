using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KelimeEzberle.BLL;
using KelimeEzberleEntity;

namespace KelimeEzberleUI
{
    public partial class frmKullaniciListele : Form
    {
        KullaniciBLL _kullaniciBLL;
        frmKullaniciListele kullaniciListele;
        Kullanici kullanici;
        public frmKullaniciListele()
        {
            InitializeComponent();
            _kullaniciBLL = new KullaniciBLL();
        }

        private void frmKullaniciListele_Load(object sender, EventArgs e)
        {
            cmbKullanicilar.DataSource = Enum.GetNames(typeof(KullaniciListele));
            kullaniciListele = this.MdiParent as frmKullaniciListele;
        }

        private void cmbKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillList();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = dgvKullanicilar.SelectedRows.Count;
                if (selected > 0)
                {
                    KullaniciAl();
                    if (kullanici.KullaniciID != 0)
                    {
                        if (!(_kullaniciBLL.KullaniciSil(kullanici.KullaniciID)))
                        {
                            throw new Exception("Kullanıcı silinemedi.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Lütfen bir kullanıcı seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FillList();
        }
        public void FillList()
        {
            switch (cmbKullanicilar.SelectedItem)
            {
                case "AktifKullanicilar":
                    dgvKullanicilar.DataSource = _kullaniciBLL.AktifKullanicilariGetir();
                    dgvKullanicilar.Columns["Rol"].Visible = false;
                    dgvKullanicilar.Columns["KullaniciOdeme"].Visible = false;
                    dgvKullanicilar.Columns["AktifMi"].Visible = false;
                    cmsIslemler.Items[3].Enabled = false;
                    cmsIslemler.Items[2].Enabled = true;
                    dgvKullanicilar.ClearSelection();
                    break;
                case "PasifKullanicilar":
                    dgvKullanicilar.DataSource = _kullaniciBLL.PasifKullanicilariGetir();
                    cmsIslemler.Items[3].Enabled = true;
                    cmsIslemler.Items[2].Enabled = false;
                    dgvKullanicilar.Columns["Rol"].Visible = false;
                    dgvKullanicilar.Columns["KullaniciOdeme"].Visible = false;
                    dgvKullanicilar.Columns["AktifMi"].Visible = false;
                    dgvKullanicilar.ClearSelection();
                    break;
                case "NormalKullanicilar":
                    dgvKullanicilar.DataSource = _kullaniciBLL.NormalKullanicilariGetir();
                    cmsIslemler.Items[3].Enabled = false;
                    cmsIslemler.Items[2].Enabled = true;
                    dgvKullanicilar.Columns["Rol"].Visible = false;
                    dgvKullanicilar.Columns["KullaniciOdeme"].Visible = false;
                    dgvKullanicilar.Columns["AktifMi"].Visible = false;
                    dgvKullanicilar.ClearSelection();
                    break;
                case "KisitliKullanicilar":
                    dgvKullanicilar.DataSource = _kullaniciBLL.KisitliKullanicilariGetir();
                    cmsIslemler.Items[3].Enabled = false;
                    cmsIslemler.Items[2].Enabled = true;
                    dgvKullanicilar.Columns["Rol"].Visible = false;
                    dgvKullanicilar.Columns["KullaniciOdeme"].Visible = false;
                    dgvKullanicilar.Columns["AktifMi"].Visible = false;
                    dgvKullanicilar.ClearSelection();
                    break;
            }
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected = dgvKullanicilar.SelectedRows.Count;
            if (selected > 0)
            {
                KullaniciAl();

                if (kullanici != null)
                {
                    frmKullaniciGuncelle kullaniciGuncelle = new frmKullaniciGuncelle(kullanici);
                    kullaniciGuncelle.Owner = this;
                    kullaniciGuncelle.Show();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
        }
        private void KullaniciAl()
        {
            kullanici = new Kullanici();
            int kullaniciID = (int)dgvKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value;
            //kullanici.Ad = dgvKullanicilar.SelectedRows[0].Cells["Ad"].Value.ToString();
            //kullanici.Soyad = dgvKullanicilar.SelectedRows[0].Cells["Soyad"].Value.ToString();
            //kullanici.Mail = dgvKullanicilar.SelectedRows[0].Cells["Mail"].Value.ToString();
            //kullanici.Telefon = dgvKullanicilar.SelectedRows[0].Cells["Telefon"].Value.ToString();
            //if ((DateTime?)dgvKullanicilar.SelectedRows[0].Cells["DogumTarihi"].Value != null)
            //{
            //    kullanici.DogumTarihi = (DateTime)dgvKullanicilar.SelectedRows[0].Cells["DogumTarihi"].Value;
            //}
            //else
            //{
            //    kullanici.DogumTarihi = DateTime.Now;
            //}
            //kullanici.Sifre = kullanici.Sifre;
            //kullanici.RolID = (int)dgvKullanicilar.SelectedRows[0].Cells["RolID"].Value;
            //kullanici.OlusturulmaTarihi = (DateTime)dgvKullanicilar.SelectedRows[0].Cells["OlusturulmaTarihi"].Value;
            //kullanici.AktifMi = (bool)dgvKullanicilar.SelectedRows[0].Cells["AktifMi"].Value;
            //kullanici.GuncellenmeTarihi = (DateTime)dgvKullanicilar.SelectedRows[0].Cells["GuncellenmeTarihi"].Value;
            kullanici = _kullaniciBLL.KullaniciGetir(kullaniciID);
        }

        private void pasifleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected = dgvKullanicilar.SelectedRows.Count;
            if (selected > 0)
            {
                KullaniciAl();
                try
                {
                    _kullaniciBLL.KullanıcıPasiflestir(kullanici);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
        }

        private void aktifleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected = dgvKullanicilar.SelectedRows.Count;
            if (selected > 0)
            {
                KullaniciAl();
                try
                {
                    _kullaniciBLL.KullaniciAktiflestir(kullanici);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
            }
        }
    }
}
