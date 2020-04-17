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
    public class KullaniciOdemeDAL
    {

        DbHelper helper;
        Hashtable parameters;

        public KullaniciOdemeDAL()
        {
            helper = new DbHelper();
            parameters = new Hashtable();
        }

        public bool KullaniciOdemeEkle(KullaniciOdeme kullaniciOdeme)
        {
            bool result = false;
            string commandText = "INSERT INTO KullaniciOdeme(KullaniciID,OdemeID,Fiyat,OdemeTarihi) VALUES(@kullaniciID,@odemeID,@fiyat,@odemeTarihi";

            parameters.Clear();
            parameters.Add("@kullaniciID", kullaniciOdeme.KullaniciID);
            parameters.Add("@odemeID", kullaniciOdeme.OdemeID);
            parameters.Add("@fiyat", kullaniciOdeme.Fiyat);
            parameters.Add("@odemeTarihi", kullaniciOdeme.OdemeTarihi);

            int islem = helper.ExecuteNonQuery(commandText, parameters);

            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Kullanıcı ödeme bilgisi eklenirken sorun oluştu.");
            }
            return result;
        }

        public List<KullaniciOdeme> YapilanOdemeler()
        {
            string commandText = "SELECT * FROM KullaniciOdeme";

            List<KullaniciOdeme> yapilanOdemeler = new List<KullaniciOdeme>();
            KullaniciOdeme kullaniciOdeme = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                kullaniciOdeme = MapKullaniciOdeme(reader);
                yapilanOdemeler.Add(kullaniciOdeme);
            }
            reader.Close();

            return yapilanOdemeler;
        }

        public decimal ToplamCiro()
        {
            string commandText = "select SUM(Fiyat) as Ciro from KullaniciOdeme";
            decimal ciro = (decimal)helper.ExecuteScalar(commandText);
            return ciro;
        }

        public decimal ToplamCiro(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            string commandText = "select SUM(Fiyat) from KullaniciOdeme where OdemeTarihi between @baslangicTarihi and @bitisTarihi";
            parameters.Clear();
            parameters.Add("@baslangicTarihi", baslangicTarihi);
            parameters.Add("@bitisTarihi", bitisTarihi);
            decimal ciro = (decimal)helper.ExecuteScalar(commandText, parameters);
            return ciro;
        }

        KullaniciOdeme MapKullaniciOdeme(SqlDataReader reader)
        {
            KullaniciOdeme kullaniciOdeme = new KullaniciOdeme()
            {
                KullaniciID = (int)reader["KullaniciID"],
                OdemeID = (int)reader["OdemeID"],
                Fiyat = (decimal)reader["Fiyat"],
                OdemeTarihi = (DateTime)reader["OdemeTarihi"]
            };

            return kullaniciOdeme;
        }
    }
}
