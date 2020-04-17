using KelimeEzberleDAL;
using KelimeEzberleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberle.BLL
{
    public class KullaniciBLL
    {
        KullaniciDAL _kullaniciDAL;

        public KullaniciBLL()
        {
            _kullaniciDAL = new KullaniciDAL();
        }

        public bool KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                BosVeriKontrol(kullanici.Ad, kullanici.Soyad);
                UzunlukKontrol(kullanici.Ad, kullanici.Soyad);
                TelefonKontrol(kullanici.Telefon);
                MailKontrol(kullanici.Mail);
                MailDogrulama(kullanici.Mail);
                SifreKontrol(kullanici.Sifre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            kullanici.AktifMi = false;
            kullanici.RolID = 3;
            return _kullaniciDAL.Insert(kullanici);
        }
        public bool KullaniciGuncelle(Kullanici kullanici)
        {
            try
            {
                BosVeriKontrol(kullanici.Ad, kullanici.Soyad);
                UzunlukKontrol(kullanici.Ad, kullanici.Soyad);
                MailKontrol(kullanici.Mail);
                SifreKontrol(kullanici.Sifre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _kullaniciDAL.Update(kullanici);
        }
        public bool KullaniciAktiflestir(Kullanici kullanici)
        {
            if (!kullanici.AktifMi)
            {
                kullanici.AktifMi = true;
                return _kullaniciDAL.Update(kullanici);
            }
            else
            {
                throw new Exception("Kullanıcı zaten aktiftir.");
            }
        }
        public bool KullaniciSil(int kullaniciID)
        {
            Kullanici kullanici = _kullaniciDAL.KullaniciGetir(kullaniciID);
            if (kullanici != null)
            {
                return _kullaniciDAL.Delete(kullaniciID);
            }
            else
            {
                throw new Exception("Bu ID'li bir kullanıcı bulunmamaktadır.");
            }
        }
        public bool KullanıcıPasiflestir(Kullanici kullanici)
        {
            if (kullanici.AktifMi)
            {
                kullanici.AktifMi = false;
                return _kullaniciDAL.Update(kullanici);
            }
            else
            {
                throw new Exception("Kullanıcı zaten pasiftir.");
            }
        }
        public Kullanici KullaniciGetir(int kullaniciID)
        {
            if (_kullaniciDAL.KullaniciGetir(kullaniciID) != null)
            {
                return _kullaniciDAL.KullaniciGetir(kullaniciID);
            }
            else
            {
                throw new Exception($"{kullaniciID} ID'li bir kullanıcı bulunmamaktadır.");
            }
        }
        public Kullanici KullaniciGetir(string mail)
        {
            if (_kullaniciDAL.KullaniciGetir(mail) == null)
            {
                throw new Exception($"{mail} adresi sistemde kayıtlı değildir.");
            }
            return _kullaniciDAL.KullaniciGetir(mail);
        }
        public List<Kullanici> AktifKullanicilariGetir()
        {
            return _kullaniciDAL.AktifKullanicilariGetir();
        }
        public List<Kullanici> PasifKullanicilariGetir()
        {
            return _kullaniciDAL.PasifKullanicilariGetir();
        }
        public Dictionary<string, object> KullaniciOdemesiGetir(int kullaniciID)
        {
            Dictionary<string, object> kullaniciOdeme = new Dictionary<string, object>();

            if (_kullaniciDAL.KullaniciGetir(kullaniciID) != null)
            {
                kullaniciOdeme = _kullaniciDAL.KullaniciOdemesiGetir(kullaniciID);
                return kullaniciOdeme;
            }
            else
            {
                throw new Exception("Kullanıcı sistemde kayıtlı değildir.");
            }
        }
        public List<Kullanici> KisitliKullanicilariGetir()
        {
            return _kullaniciDAL.KisitliKullanicilariGetir();
        }
        public List<Kullanici> NormalKullanicilariGetir()
        {
            return _kullaniciDAL.NormalKullanicilariGetir();
        }
        public List<Kullanici> KisitlidanNormale(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            try
            {
                TarihKontrol(baslangicTarihi, bitisTarihi);
                return _kullaniciDAL.KisitlidanNormale(baslangicTarihi, bitisTarihi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void BosVeriKontrol(string ad, string soyad)
        {
            if (string.IsNullOrWhiteSpace(ad))
            {
                throw new Exception("Ad alanı boş bırakılamaz.");
            }

            if (string.IsNullOrWhiteSpace(soyad))
            {
                throw new Exception("Soyad alanı boş bırakılamaz.");
            }
        }
        void MailKontrol(string mail)
        {
            if (!string.IsNullOrWhiteSpace(mail))
            {
                try
                {
                    MailAddress address = new MailAddress(mail);

                    if (mail.Length > 50)
                    {
                        throw new Exception("Mail adresi 50 karakterden uzun olamaz.");
                    }
                }
                catch
                {
                    throw new Exception("Mail düzgün formatta değil");
                }
            }
            else
            {
                throw new Exception("Mail adresi boş bırakılamaz.");
            }
        }
        void MailDogrulama(string mail)
        {
            if (_kullaniciDAL.KullaniciGetir(mail) != null)
            {
                throw new Exception("Bu mail adresi sistemde kayıtlıdır.");
            }
        }
        void UzunlukKontrol(string ad, string soyad)
        {
            if (ad.Length > 20)
            {
                throw new Exception("Ad alanı 20 karakterden fazla olamaz");
            }
            if (soyad.Length > 30)
            {
                throw new Exception("Soyad alanı 30 karakterden fazla olamaz");
            }
        }
        void SifreKontrol(string sifre)
        {
            if (sifre.Length < 8 && sifre.Length > 20)
            {
                throw new Exception("Şifre 8 ile 20 karakter arasında olabilir.");
            }
        }
        void TarihKontrol(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            if (bitisTarihi < baslangicTarihi)
            {
                throw new Exception("Bitiş tarihi, başlangıç tarihinden önceki bir tarihi gösteremez.");
            }
        }
        public void KullaniciDogrulama(string mail, string sifre)
        {
            try
            {
                Kullanici kullanici = _kullaniciDAL.KullaniciGetir(mail);
                if (kullanici != null)
                {
                    if (kullanici.Sifre != sifre)
                    {
                        throw new Exception("Mail ve şifre uyuşmamaktadır.");
                    }
                }
                else
                {
                    throw new Exception("Mail adresi sistemde bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void TelefonKontrol(string telefon)
        {
            if (telefon.Length != 15)
            {
                throw new Exception("Telefon numarası eksik veya fazladır.");
            }
        }
    }
}
