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
    public class RolDAL
    {
        DbHelper helper;
        Hashtable parameters;

        public RolDAL()
        {
            helper = new DbHelper();
            parameters = new Hashtable();
        }

        public bool Insert(Role rol)
        {
            bool result = false;
            string commandText = "INSERT INTO Role(RolAd,OlusturulmaTarihi,AktifMi,GuncellenmeTarihi) VALUES(@rolAd, @olusturulmaTarihi,@aktifMi,@guncellenmeTarihi)";

            parameters.Clear();
            parameters.Add("@rolID", rol.RolID);
            parameters.Add("@rolAd", rol.RolAd);
            parameters.Add("@olusturulmaTarihi", rol.OlusturulmaTarihi);
            parameters.Add("@aktifMi", rol.AktifMi);
            parameters.Add("@guncellenmeTarihi", rol.GuncellenmeTarihi);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Rol eklenirken sorun oluştu.");
            }
            return result;
        }

        public bool Update(Role rol)
        {
            bool result = false;
            string commandText = "UPDATE Role SET RolAd=@rolAd, AktifMi = @aktifMi, GuncellenmeTarihi = @guncellenmeTarihi WHERE RolID = @rolID";

            parameters.Clear();
            parameters.Add("@rolID", rol.RolID);
            parameters.Add("@rolAd", rol.RolAd);
            parameters.Add("@aktifMi", rol.AktifMi);
            parameters.Add("@guncellenmeTarihi", rol.GuncellenmeTarihi);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Rol güncellenirken bir hata oluştu.");
            }

            return result;
        }

        public bool Delete(int rolID)
        {
            bool result = false;
            string commandText = "DELETE FROM Role WHERE RolID = @rolID";

            parameters.Clear();
            parameters.Add("@rolID", rolID);

            int islem = helper.ExecuteNonQuery(commandText, parameters);
            if (islem > 0)
            {
                result = true;
            }
            else
            {
                throw new Exception("Rol silinirken bir hata oluştu.");
            }
            return result;
        }

        public Role RolGetir(int rolID)
        {
            string commandText = "SELECT * FROM Role WHERE RolID = @rolID and AktifMi=1";
            parameters.Clear();
            parameters.Add("@rolID", rolID);

            Role rol = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                rol = MapRol(reader);
            }

            reader.Close();
            return rol;
        }

        public Role RolGetir(string ad)
        {
            string commandText = "SELECT * FROM Role WHERE RolAd = @rolAd";
            parameters.Clear();
            parameters.Add("@rolAd", ad);

            Role rol = null;

            SqlDataReader reader = helper.ExecuteReader(commandText, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                rol = MapRol(reader);
            }

            reader.Close();
            return rol;
        }

        public List<Role> RolleriGetir()
        {
            string commandText = "SELECT * FROM Role where AktifMi=1";
            parameters.Clear();

            List<Role> roller = new List<Role>();
            Role rol = null;

            SqlDataReader reader = helper.ExecuteReader(commandText);
            while (reader.Read())
            {
                rol = MapRol(reader);
                roller.Add(rol);
            }
            reader.Close();

            return roller;
        }

        Role MapRol(SqlDataReader reader)
        {
            Role rol = new Role();
            rol.RolID = (int)reader["RolID"];
            rol.RolAd = reader["RolAd"].ToString();
            rol.AktifMi = (bool)reader["AktifMi"];
            rol.OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"];
            rol.GuncellenmeTarihi = (DateTime)reader["GuncellenmeTarihi"];

            return rol;
        }
    }
}
