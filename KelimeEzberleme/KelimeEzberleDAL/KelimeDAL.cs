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
    public class KelimeDAL
    {
        DbHelper helper;
        Hashtable parameters;

        public KelimeDAL()
        {
            helper = new DbHelper();
            parameters = new Hashtable();
        }

        public bool Insert(Kelime kelime)
        {
            bool result = false;
            string commandText = "INSERT INTO Kelime(Turkce,Ingilizce,OlusturulmaTarihi,AktifMi,GuncellenmeTarihi) VALUES(@turkce, @ingilizce,@olusturulmaTarihi,@aktifMi,@guncellenmeTarihi)";

            parameters.Clear();
            parameters.Add("@turkce", kelime.Turkce);
            parameters.Add("@ingilizce", kelime.Ingilizce);
            parameters.Add("@olusturulmaTarihi", kelime.OlusturulmaTarihi);
            parameters.Add("@aktifMi", kelime.AktifMi);
            parameters.Add("@guncellenmeTarihi", kelime.GuncellenmeTarihi);


            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kelime eklenirken sorun oluştu.");
            }
            return result;
        }

        public bool Update(Kelime kelime)
        {
            bool result = false;
            string commandText = "UPDATE Kelime SET Turkce = @turkce, Ingilizce = @ingilizce, AktifMi = @aktifMi, GuncellenmeTarihi = @guncellenmeTarihi WHERE KelimeID = @kelimeID";

            parameters.Clear();
            parameters.Add("@kelimeID", kelime.KelimeID);
            parameters.Add("@turkce", kelime.Turkce);
            parameters.Add("@ingilizce", kelime.Ingilizce);
            parameters.Add("@aktifMi", kelime.AktifMi);
            parameters.Add("@guncellenmeTarihi", kelime.GuncellenmeTarihi);


            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kelime güncellenirken bir hata oluştu.");
            }

            return result;
        }

        public bool Delete(int kelimeID)
        {
            bool result = false;
            string commandText = "DELETE FROM Kelime WHERE KelimeID = @kelimeID";

            parameters.Clear();
            parameters.Add("@kelimeID", kelimeID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kelime silinirken bir hata oluştu.");
            }

            return result;
        }

        public Kelime KelimeGetir(int kelimeID)
        {
            string commandText = "SELECT * FROM Kelime WHERE KelimeID = @kelimeID and AktifMi=1";
            parameters.Clear();
            parameters.Add("@kelimeID", kelimeID);

            Kelime kelime = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                kelime = MapKelime(reader);
            }

            reader.Close();
            return kelime;
        }

        public Kelime KelimeGetir(string ingilizceKelime)
        {
            string commandText = "SELECT * FROM Kelime WHERE Ingilizce = @ingKelime and AktifMi=1";
            parameters.Clear();
            parameters.Add("@ingKelime", ingilizceKelime);

            Kelime kelime = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                kelime = MapKelime(reader);
            }

            reader.Close();
            return kelime;
        }
        public List<Kelime> KelimeleriGetir()
        {
            string commandText = "SELECT * FROM Kelime where AktifMi=1";
            parameters.Clear();

            List<Kelime> kelimeler = new List<Kelime>();
            Kelime kelime = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kelime = MapKelime(reader);
                kelimeler.Add(kelime);
            }
            reader.Close();

            return kelimeler;
        }

        public List<Kelime> HavuzunKelimeleri(int havuzID)
        {
            string commandText = "SELECT k.KelimeID, k.Turkce, k.Ingilizce, k.AktifMi, k.OlusturulmaTarihi, k.GuncellenmeTarihi FROM HavuzDetay hd JOIN Havuz h ON hd.HavuzID = h.HavuzID JOIN Kelime k ON k.KelimeID = hd.KelimeID WHERE hd.HavuzID = @havuzID";
            parameters.Clear();
            parameters.Add("@havuzID", havuzID);

            List<Kelime> havuzKelimeleri = new List<Kelime>();
            Kelime kelime = null;
            SqlDataReader reader = helper.ExecuteReader(commandText,parameters);

            while (reader.Read())
            {
                kelime = MapKelime(reader);
                havuzKelimeleri.Add(kelime);
            }
            return havuzKelimeleri;
        }

        public Dictionary<int,Dictionary<string, string>> MaksimumTercihKelimesi(int gosterimSayisi)
        {
            string commandText = "sp_EnCokTercihEdilenKelime";
            parameters.Clear();
            parameters.Add("@tercihSayisi", gosterimSayisi);

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters,System.Data.CommandType.StoredProcedure);
            Dictionary<int, Dictionary<string, string>> kelimeler = new Dictionary<int, Dictionary<string, string>>();
            while (reader.Read())
            {
                Dictionary<string, string> kelime = new Dictionary<string, string>();
                kelime.Add(reader["IngilizceKelime"].ToString(), reader["TurkceKelime"].ToString());
                kelimeler.Add((int)reader["TercihSayisi"], kelime);
            }
            return kelimeler;
        }

        Kelime MapKelime(SqlDataReader reader)
        {
            Kelime kelime = new Kelime()
            {
                KelimeID = (int)reader["KelimeID"],
                Turkce = reader["Turkce"].ToString(),
                Ingilizce=reader["Ingilizce"].ToString(),
                AktifMi = (bool)reader["AktifMi"],
                OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"],
                GuncellenmeTarihi = (DateTime)reader["GuncellenmeTarihi"]
            };

            return kelime;
        }
    }
}
