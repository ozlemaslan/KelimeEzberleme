using KelimeEzberle.BLL;
using KelimeEzberleEntity;
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
    public partial class frmKullaniciGuncelle : Form
    {
        Kullanici _kullanici;
        frmKullaniciListele kullaniciListele;
        KullaniciBLL _kullaniciBLL;
        RolBLL _rol;
        public frmKullaniciGuncelle(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            kullaniciListele = this.Owner as frmKullaniciListele;
            _kullaniciBLL = new KullaniciBLL();
            _rol = new RolBLL();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _kullanici.Ad = txtAd.Text;
            _kullanici.Soyad = txtSoyad.Text;
            _kullanici.Mail = txtMail.Text;
            _kullanici.Telefon = txtTelefon.Text;
            if (dtpDogumTarihi.Value != DateTime.Now)
            {
                _kullanici.DogumTarihi = dtpDogumTarihi.Value;
            }
            else
            {
                _kullanici.DogumTarihi = null;
            }
            _kullanici.RolID = (int)cmbRol.SelectedValue;
            _kullaniciBLL.KullaniciGuncelle(_kullanici);
            kullaniciListele.FillList();
        }

        private void frmKullaniciGuncelle_Load(object sender, EventArgs e)
        {
            ComboBoxDoldur();

            txtAd.Text = _kullanici.Ad;
            txtSoyad.Text = _kullanici.Soyad;
            txtMail.Text = _kullanici.Mail;
            txtTelefon.Text = _kullanici.Telefon;
            dtpDogumTarihi.Value = _kullanici.DogumTarihi.Value;
            cmbRol.SelectedValue = _rol.RolGetir(_kullanici.RolID).RolID;
        }

        private void ComboBoxDoldur()
        {
            cmbRol.DisplayMember = "RolAd";
            cmbRol.ValueMember = "RolID";
            cmbRol.DataSource = _rol.RolleriGetir();
        }
    }
}
