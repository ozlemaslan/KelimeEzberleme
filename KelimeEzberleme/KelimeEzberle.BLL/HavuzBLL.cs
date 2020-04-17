using KelimeEzberleDAL;
using KelimeEzberleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberle.BLL
{
    public class HavuzBLL
    {

        HavuzDAL _havuzDAL;

        public HavuzBLL()
        {
            _havuzDAL = new HavuzDAL();
        }

        public bool HavuzEkle(Havuz havuz)
        {
            try
            {
                UzunlukKontrol(havuz.HavuzAdi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            havuz.AktifMi = true;
            return _havuzDAL.Insert(havuz);
        }
        public bool HavuzGuncelle(Havuz havuz)
        {
            try
            {
                UzunlukKontrol(havuz.HavuzAdi);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _havuzDAL.Update(havuz);
        }
        public bool HavuzPasiflestir(Havuz havuz)
        {
            if (havuz.AktifMi)
            {
                havuz.AktifMi = false;
                return _havuzDAL.Update(havuz);
            }
            else
            {
                throw new Exception($"{havuz.HavuzAdi} isimli havuz zaten pasiftir.");
            }
        }
        public bool HavuzSil(int havuzID)
        {
            Havuz havuz = _havuzDAL.HavuzGetir(havuzID);
            if (havuz != null)
            {
                return _havuzDAL.Delete(havuzID);
            }
            else
            {
                throw new Exception($"{havuzID} ID'li havuz yoktur.");
            }
        }
        public Havuz HavuzGetir(int havuzID)
        {
            Havuz havuz = _havuzDAL.HavuzGetir(havuzID);
            if (havuz != null)
            {
                return havuz;
            }
            else
            {
                throw new Exception($"{havuzID} ID'li bir havuz bulunmamaktadır.");
            }
        }
        public Havuz HavuzGetir(string havuzAdi)
        {
            Havuz havuz = _havuzDAL.HavuzGetir(havuzAdi);
            if (havuz != null)
            {
                return havuz;
            }
            else
            {
                throw new Exception($"{havuzAdi} isimli bir havuz bulunmamaktadır.");
            }
        }
        public List<Havuz> HavuzlariGetir()
        {
            return _havuzDAL.HavuzlariGetir();
        }
        public List<Havuz> KullaniciHavuzlari(int kullaniciID)
        {
            return _havuzDAL.KullaniciHavuzlari(kullaniciID);
        }
        public bool HavuzaKelimeEkle(int kelimeID, int havuzID)
        {
            try
            {
                HavuzVarligi(havuzID);
                HavuzdaKelimeVarligi(havuzID, kelimeID);

                if (_havuzDAL.HavuzGetir(havuzID) != null)
                {
                    try
                    {
                        return _havuzDAL.HavuzaKelimeEkle(kelimeID, havuzID);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    throw new Exception($"{havuzID} ID'li bir havuz bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool HavuzdanKelimeSil(int kelimeID, int havuzID)
        {
            try
            {

                HavuzVarligi(havuzID);
                HavuzdaKelimeVarligi(havuzID, kelimeID);

                if (_havuzDAL.HavuzGetir(havuzID) != null)
                {
                    try
                    {
                        return _havuzDAL.HavuzdanKelimeSil(kelimeID, havuzID);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    throw new Exception($"{havuzID} ID'li bir havuz bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void UzunlukKontrol(string havuzAdi)
        {
            if (havuzAdi.Length < 20)
            {
                throw new Exception($"{havuzAdi} ismi 20 karakterden uzundur.");
            }
        }
        private void HavuzVarligi(int havuzID)
        {
            if (_havuzDAL.HavuzGetir(havuzID) == null)
            {
                throw new Exception("Aradığınız havuz sistemde bulunmamaktadır.");
            }
        }
        private void HavuzdaKelimeVarligi(int havuzID, int kelimeID)
        {
            KelimeDAL _kelime = new KelimeDAL();
            List<Kelime> kelimeler = _kelime.HavuzunKelimeleri(havuzID);
            foreach (Kelime item in kelimeler)
            {
                if (item.KelimeID == kelimeID)
                {
                    throw new Exception("Kelime havuzda vardır.");
                }
            }
        }
    }
}
