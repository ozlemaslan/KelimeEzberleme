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
    public class KullaniciDAL
    {
        DbHelper helper;
        Hashtable parameters;

        public KullaniciDAL()
        {
            helper = new DbHelper();
            parameters = new Hashtable();
        }

        public bool Insert(Kullanici kullanici)
        {
            bool result = false;
            string commandText = "INSERT INTO Kullanici(RolID, Ad, Soyad, Mail, Sifre, DogumTarihi, Telefon,OlusturulmaTarihi,AktifMi,GuncellenmeTarihi) VALUES(@rolID, @ad, @soyad, @mail, @sifre, @dogumTarihi, @telefon,@olusturulmaTarihi,@aktifMi,@guncellenmeTarihi)";

            parameters.Clear();
            parameters.Add("@rolID", kullanici.RolID);
            parameters.Add("@ad", kullanici.Ad);
            parameters.Add("@soyad", kullanici.Soyad);
            parameters.Add("@mail", kullanici.Mail);
            parameters.Add("@sifre", kullanici.Sifre);
            parameters.Add("@dogumTarihi", kullanici.DogumTarihi);
            parameters.Add("@telefon", kullanici.Telefon);
            parameters.Add("@olusturulmaTarihi", kullanici.OlusturulmaTarihi);
            parameters.Add("@aktifMi", kullanici.AktifMi);
            parameters.Add("@guncellenmeTarihi", kullanici.GuncellenmeTarihi);


            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kullanıcı eklenirken sorun oluştu.");
            }
            return result;
        }
        public bool Update(Kullanici kullanici)
        {
            bool result = false;
            string commandText = "UPDATE Kullanici SET RolID = @rolID, Ad = @ad, Soyad = @soyad, Mail = @mail, Sifre = @sifre, DogumTarihi = @dogumTarihi, Telefon = @telefon, AktifMi = @aktifMi, GuncellenmeTarihi = @guncellenmeTarihi WHERE KullaniciID = @kullaniciID";

            parameters.Clear();
            parameters.Add("@kullaniciID", kullanici.KullaniciID);
            parameters.Add("@rolID", kullanici.RolID);
            parameters.Add("@ad", kullanici.Ad);
            parameters.Add("@soyad", kullanici.Soyad);
            parameters.Add("@mail", kullanici.Mail);
            parameters.Add("@sifre", kullanici.Sifre);
            parameters.Add("@dogumTarihi", kullanici.DogumTarihi);
            parameters.Add("@telefon", kullanici.Telefon);
            parameters.Add("@aktifMi", kullanici.AktifMi);
            parameters.Add("@guncellenmeTarihi", kullanici.GuncellenmeTarihi);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kullanıcı güncellenirken bir hata oluştu.");
            }

            return result;
        }
        public bool Delete(int kullaniciID)
        {
            bool result = false;
            string commandText = "DELETE FROM Kullanici WHERE KullaniciID = @kullaniciID";

            parameters.Clear();
            parameters.Add("@kullaniciID", kullaniciID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kullanıcı silinirken bir hata oluştu.");
            }

            return result;
        }
        public Kullanici KullaniciGetir(int kullaniciID)
        {
            string commandText = "SELECT * FROM Kullanici WHERE KullaniciID = @kullaniciID";
            parameters.Clear();
            parameters.Add("@kullaniciID", kullaniciID);

            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                kullanici = MapKullanici(reader);
            }

            reader.Close();
            return kullanici;
        }
        public Kullanici KullaniciGetir(string mail)
        {
            string commandText = "SELECT * FROM Kullanici WHERE Mail = @mail";
            parameters.Clear();
            parameters.Add("@mail", mail);

            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                kullanici = MapKullanici(reader);
            }

            reader.Close();
            return kullanici;
        }
        public List<Kullanici> AktifKullanicilariGetir()
        {
            string commandText = "SELECT * FROM Kullanici where AktifMi=1";
            parameters.Clear();

            List<Kullanici> kullanicilar = new List<Kullanici>();
            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kullanici = MapKullanici(reader);
                kullanicilar.Add(kullanici);
            }
            reader.Close();

            return kullanicilar;
        }
        public List<Kullanici> PasifKullanicilariGetir()
        {
            string commandText = "SELECT * FROM Kullanici where AktifMi=0";
            parameters.Clear();

            List<Kullanici> kullanicilar = new List<Kullanici>();
            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kullanici = MapKullanici(reader);
                kullanicilar.Add(kullanici);
            }
            reader.Close();

            return kullanicilar;
        }
        public List<Kullanici> KisitliKullanicilariGetir()
        {
            string commandText = "SELECT * FROM Kullanici where RolID = 3";

            List<Kullanici> kullanicilar = new List<Kullanici>();
            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kullanici = MapKullanici(reader);
                kullanicilar.Add(kullanici);
            }
            reader.Close();

            return kullanicilar;
        }
        public List<Kullanici> NormalKullanicilariGetir()
        {
            string commandText = "SELECT * FROM Kullanici where RolID = 4";

            List<Kullanici> kullanicilar = new List<Kullanici>();
            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kullanici = MapKullanici(reader);
                kullanicilar.Add(kullanici);
            }
            reader.Close();

            return kullanicilar;
        }
        public List<Kullanici> KisitlidanNormale(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            string commandText = "SELECT k.* FROM KullaniciOdeme ko JOIN Kullanici k ON k.KullaniciID = ko.KullaniciID WHERE ko.OdemeTarihi BETWEEN @baslangicTarihi and @bitisTarihi";
            parameters.Clear();
            parameters.Add("@baslangicTarihi", baslangicTarihi);
            parameters.Add("@bitisTarihi", bitisTarihi);

            List<Kullanici> kullanicilar = new List<Kullanici>();
            Kullanici kullanici = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);

            while (reader.Read())
            {
                kullanici = MapKullanici(reader);
                kullanicilar.Add(kullanici);
            }
            reader.Close();
            return kullanicilar;
        }
        public Dictionary<string, object> KullaniciOdemesiGetir(int kullaniciID)
        {
            //Kullanıcının yaptığı ödeme
            string commandText = "SELECT k.KullaniciID, k.Ad, k.Soyad, k.Mail, ko.Fiyat, ko.OdemeTarihi FROM KullaniciOdeme ko JOIN Kullanici k ON ko.KullaniciID = k.KullaniciID WHERE KullaniciID = @kullaniciID";
            parameters.Clear();
            parameters.Add("@kullaniciID", kullaniciID);

            Dictionary<string, object> kullaniciOdeme = new Dictionary<string, object>();

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                kullaniciOdeme.Add("KullaniciID", reader["KullaniciID"]);
                kullaniciOdeme.Add("Ad", reader["Ad"]);
                kullaniciOdeme.Add("Soyad", reader["Soyad"]);
                kullaniciOdeme.Add("Mail", reader["Mail"]);
                kullaniciOdeme.Add("Fiyat", reader["Fiyat"]);
                kullaniciOdeme.Add("OdemeTarihi", reader["OdemeTarihi"]);
            }
            else
            {
                throw new Exception("Kullanıcıya ait ödeme bulunmamaktadır.");
            }

            reader.Close();
            return kullaniciOdeme;
        }

        Kullanici MapKullanici(SqlDataReader reader)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciID = (int)reader["KullaniciID"];
            kullanici.RolID = (int)reader["RolID"];
            kullanici.Ad = reader["Ad"].ToString();
            kullanici.Soyad = reader["Soyad"].ToString();
            kullanici.Mail = reader["Mail"].ToString();
            kullanici.Sifre = reader["Sifre"].ToString();
            if (reader["DogumTarihi"] == DBNull.Value)
            {
                kullanici.DogumTarihi = null;
            }
            else
            {
                kullanici.DogumTarihi = (DateTime)reader["DogumTarihi"];
            }
            kullanici.Telefon = reader["Telefon"] == DBNull.Value ? "Bilinmiyor" : reader["Telefon"].ToString();
            kullanici.AktifMi = (bool)reader["AktifMi"];
            kullanici.OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"];
            kullanici.GuncellenmeTarihi = (DateTime)reader["GuncellenmeTarihi"];
            kullanici.Rol = new Role() { RolID = kullanici.RolID };

            return kullanici;
        }
    }
}
