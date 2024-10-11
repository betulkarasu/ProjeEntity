using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDepartman;
using System.Data;

namespace Data_Accsess_Layer_Departman
{
    public class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection(@"Data Source=BETšSPC\SQLEXPRESS;Initial Catalog=DbPersonel;Integrated Security=True");

    }
    public class DEPARTMAN
    {
        public static List<EntityDEP> Departman()
        {
            List<EntityDEP> EntityDepartmanı = new List<EntityDEP>();
            SqlCommand komutdepartman = new SqlCommand("SELECT * FROM TBL_DEPARTMAN",Baglanti.bgl);
            if (komutdepartman.Connection.State != ConnectionState.Open)
                komutdepartman.Connection.Open();

            SqlDataReader dr = komutdepartman.ExecuteReader();
            while (dr.Read())
            {
                EntityDEP EntGetir = new EntityDEP();
                EntGetir.Depad1 = dr["AD"].ToString();
                EntGetir.Depid1 = int.Parse(dr["ID"].ToString());
                EntGetir.Depaciklama1 = dr["ACIKLAMA"].ToString();

                EntityDepartmanı.Add(EntGetir);
            } 
            dr.Close();
            return EntityDepartmanı;
        }
        

    }
}
