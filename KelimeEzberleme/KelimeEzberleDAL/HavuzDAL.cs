using KelimeEzberleEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleDAL
{
    public class HavuzDAL
    {
        DbHelper helper;
        Hashtable parameters;

        public HavuzDAL()
        {
            helper = new DbHelper();
            parameters = new Hashtable();
        }

        public bool Insert(Havuz havuz)
        {
            bool result = false;
            string commandText = "INSERT INTO Havuz(HavuzAdi,KullaniciID,OlusturulmaTarihi,AktifMi,GuncellenmeTarihi) VALUES(@havuzAdi, @kullaniciID, @olusturulmaTarihi, @aktifMi, @guncellenmeTarihi)";

            parameters.Clear();
            parameters.Add("@havuzAdi", havuz.HavuzAdi);
            parameters.Add("@kullaniciID", havuz.KullaniciID);
            parameters.Add("@olusturulmaTarihi", havuz.OlusturulmaTarihi);
            parameters.Add("@aktifMi", havuz.AktifMi);
            parameters.Add("@guncellenmeTarihi", havuz.GuncellenmeTarihi);


            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Havuz eklenirken sorun oluştu.");
            }
            return result;
        }
        public bool Update(Havuz havuz)
        {
            bool result = false;
            string commandText = "UPDATE Havuz SET HavuzAdi = @havuzAdi, KullaniciID = @kullaniciID,  AktifMi = @aktifMi, GuncellenmeTarihi = @guncellenmeTarihi WHERE HavuzID = @havuzID";

            parameters.Clear();
            parameters.Add("@havuzID", havuz.HavuzID);
            parameters.Add("@havuzAdi", havuz.HavuzAdi);
            parameters.Add("@kullaniciID", havuz.KullaniciID);
            parameters.Add("@aktifMi", havuz.AktifMi);
            parameters.Add("@guncellenmeTarihi", havuz.GuncellenmeTarihi);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Havuz güncellenirken bir hata oluştu.");
            }

            return result;
        }
        public bool Delete(int havuzID)
        {
            bool result = false;
            string commandText = "DELETE FROM Havuz WHERE HavuzID = @havuzID ";

            parameters.Clear();
            parameters.Add("@havuzID", havuzID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Havuz silinirken bir hata oluştu.");
            }

            return result;
        }
        public Havuz HavuzGetir(int havuzID)
        {
            string commandText = "SELECT * FROM Havuz WHERE HavuzID = @havuzID and AktifMi=1";
            parameters.Clear();
            parameters.Add("@havuzID", havuzID);

            Havuz havuz = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                havuz = MapHavuz(reader);
            }

            reader.Close();
            return havuz;
        }
        public Havuz HavuzGetir(string havuzAdi)
        {
            string commandText = "SELECT * FROM Havuz WHERE HavuzAdi = @havuzAdi and AktifMi=1";
            parameters.Clear();
            parameters.Add("@havuzAdi", havuzAdi);

            Havuz havuz = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                havuz = MapHavuz(reader);
            }

            reader.Close();
            return havuz;
        }
        public List<Havuz> HavuzlariGetir()
        {
            string commandText = "SELECT * FROM Havuz WHERE AktifMi=1";
            parameters.Clear();

            List<Havuz> havuzlar = new List<Havuz>();
            Havuz havuz = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                havuz = MapHavuz(reader);
                havuzlar.Add(havuz);
            }
            reader.Close();

            return havuzlar;
        }
        public List<Havuz> KullaniciHavuzlari(int kullaniciID)
        {
            string commandText = "SELECT h.HavuzID, h.HavuzAdi, h.KullaniciID, h.AktifMi, h.OlusturulmaTarihi, h.GuncellenmeTarihi FROM Havuz h JOIN Kullanici k ON k.KullaniciID = h.KullaniciID WHERE h.KullaniciID = @kullaniciID AND h.AktifMi = 1";
            parameters.Clear();
            parameters.Add("@kullaniciID", kullaniciID);

            Havuz havuz = null;
            List<Havuz> kullaniciHavuzlari = new List<Havuz>();
            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);

            while (reader.Read())
            {
                havuz = MapHavuz(reader);
                kullaniciHavuzlari.Add(havuz);
            }
            return kullaniciHavuzlari;
        }
        public bool HavuzaKelimeEkle(int kelimeID, int havuzID)
        {
            bool result = false;
            string commandText = "INSERT INTO HavuzDetay(KelimeID, HavuzID) VALUES(@kelimeID,@havuzID)";
            parameters.Clear();
            parameters.Add("@kelimeID", kelimeID);
            parameters.Add("@havuzID", havuzID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Havuza kelime eklenemedi.");
            }
            return result;
        }
        public bool HavuzdanKelimeSil(int kelimeID, int havuzID)
        {
            bool result = false;
            string commandText = "delete from HavuzDetay where HavuzID = @havuzID and KelimeID = @kelimeID";
            parameters.Clear();
            parameters.Add("@havuzID", havuzID);
            parameters.Add("@kelimeID", kelimeID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Havuzdan kelime silinemedi.");
            }
            return result;
        }


        Havuz MapHavuz(SqlDataReader reader)
        {
            Havuz havuz = new Havuz()
            {
                HavuzID = (int)reader["HavuzID"],
                HavuzAdi = reader["HavuzAdi"] == DBNull.Value ? "Bilinmiyor": reader["HavuzAdi"].ToString(),
                KullaniciID = (int)reader["KullaniciID"],
                AktifMi = (bool)reader["AktifMi"],
                OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"],
                GuncellenmeTarihi = (DateTime)reader["GuncellenmeTarihi"]
            };

            return havuz;
        }
    }
}
