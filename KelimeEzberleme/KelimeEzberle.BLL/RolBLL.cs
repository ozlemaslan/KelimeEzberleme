using KelimeEzberleDAL;
using KelimeEzberleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberle.BLL
{
    public class RolBLL
    {
        RolDAL _rolDAL;

        public RolBLL()
        {
            _rolDAL = new RolDAL();
        }

        public bool RolEkle(Role rol)
        {
            try
            {
                BosVeriKontrol(rol.RolAd);
                UzunlukKontrol(rol.RolAd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            rol.AktifMi = true;
            return _rolDAL.Insert(rol);
        }

        public bool RolGuncelle(Role rol)
        {
            try
            {
                BosVeriKontrol(rol.RolAd);
                UzunlukKontrol(rol.RolAd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _rolDAL.Update(rol);
        }

        public bool RolSil(int rolID)
        {
            Role rol = _rolDAL.RolGetir(rolID);
            if (rol != null)
            {
                return _rolDAL.Delete(rolID);
            }
            else
            {
                throw new Exception("Bu ID'li bir rol bulunmamaktadır.");
            }
        }

        public bool RolPasiflestir(Role rol)
        {
            if (rol.AktifMi)
            {
                rol.AktifMi = false;
                return _rolDAL.Update(rol);
            }
            else
            {
                throw new Exception("Rol zaten pasiftir.");
            }
        }

        public Role RolGetir(int rolID)
        {
            if (_rolDAL.RolGetir(rolID) != null)
            {
                return _rolDAL.RolGetir(rolID);
            }
            else
            {
                throw new Exception($"{rolID} ID'li bir rol bulunmamaktadır.");
            }
        }

        public Role RolGetir(string rolAdi)
        {
            if (_rolDAL.RolGetir(rolAdi) == null)
            {
                throw new Exception($"{rolAdi} isimli bir rol sistemde kayıtlı değildir.");
            }
            return _rolDAL.RolGetir(rolAdi);
        }

        public List<Role> RolleriGetir()
        {
            return _rolDAL.RolleriGetir();
        }

        void BosVeriKontrol(string ad)
        {
            if (string.IsNullOrWhiteSpace(ad))
            {
                throw new Exception("Rol adı alanı boş bırakılamaz.");
            }
        }
        void UzunlukKontrol(string ad)
        {
            if (ad.Length < 5 && ad.Length > 20)
            {
                throw new Exception("Rol adı 5 ile 20 karakter arasında olabilir.");
            }
        }
    }
}
