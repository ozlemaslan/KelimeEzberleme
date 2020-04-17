using KelimeEzberleDAL;
using KelimeEzberleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberle.BLL
{
    public class KelimeBLL
    {
        KelimeDAL _kelimeDAL;

        public KelimeBLL()
        {
            _kelimeDAL = new KelimeDAL();
        }
        public bool KelimeEkle(Kelime kelime)
        {
            try
            {
                KelimeninVarligi(kelime.Ingilizce);
                UzunlukKontrol(kelime.Turkce, kelime.Ingilizce);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            kelime.AktifMi = true;
            return _kelimeDAL.Insert(kelime);
        }
        public bool KelimeGuncelle(Kelime kelime)
        {
            try
            {
                KelimeninVarligi(kelime.Ingilizce);
                UzunlukKontrol(kelime.Turkce, kelime.Ingilizce);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _kelimeDAL.Update(kelime);
        }
        public bool KelimePasiflestir(Kelime kelime)
        {
            if (kelime.AktifMi)
            {
                kelime.AktifMi = false;
                return _kelimeDAL.Update(kelime);
            }
            else
            {
                throw new Exception($"{kelime.Ingilizce} kelimesi zaten pasiftir.");
            }
        }
        public bool KelimeSil(int kelimeID)
        {
            Kelime kelime = _kelimeDAL.KelimeGetir(kelimeID);
            if (kelime != null)
            {
                return _kelimeDAL.Delete(kelimeID);
            }
            else
            {
                throw new Exception($"{kelimeID} ID'li kelime sistemde yoktur.");
            }
        }
        public Kelime KelimeGetir(int kelimeID)
        {
            Kelime kelime = _kelimeDAL.KelimeGetir(kelimeID);
            if (kelime != null)
            {
                return kelime;
            }
            else
            {
                throw new Exception($"{kelimeID} ID'li bir havuz bulunmamaktadır.");
            }
        }
        public Kelime KelimeGetir(string kelimeIng)
        {
            Kelime kelime = _kelimeDAL.KelimeGetir(kelimeIng);
            if (kelime != null)
            {
                return kelime;
            }
            else
            {
                throw new Exception($"{kelimeIng} kelimesi sistemde bulunmamaktadır.");
            }
        }
        public List<Kelime> KelimeleriGetir()
        {
            return _kelimeDAL.KelimeleriGetir();
        }
        public List<Kelime> HavuzunKelimeleri(int havuzID)
        {
            return _kelimeDAL.HavuzunKelimeleri(havuzID);
        }
        public void KelimeninVarligi(string kelime)
        {
            if (_kelimeDAL.KelimeGetir(kelime) != null)
            {
                throw new Exception("Kelime, sistemde kayıtlıdır.");
            }
        }
        public Dictionary<int, Dictionary<string, string>> MaksimumTercihKelimeleri(int gosterimSayisi)
        {
            return _kelimeDAL.MaksimumTercihKelimesi(gosterimSayisi);
        }


        private void UzunlukKontrol(string turkce,string ingilizce)
        {
            if (turkce.Length < 50)
            {
                throw new Exception($"{turkce} kelimesi 50 karakterden uzundur.");
            }

            if (ingilizce.Length < 50)
            {
                throw new Exception($"{ingilizce} kelimesi 50 karakterden uzundur.");
            }
        }

    }
}
