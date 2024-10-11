using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;
using System.Security.Cryptography.X509Certificates;


namespace DataAccessLayer
{
    public class DALPersonel
    {  
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> DEGERLER = new List<EntityPersonel>();
            SqlCommand Komut = new SqlCommand("Select * from Tbl_Bilgi", Baglanti.bgl);
          if (Komut.Connection.State != ConnectionState.Open)
            {
                Komut.Connection.Open();
            }
            SqlDataReader dr = Komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                ent.Sehir = dr["SEHİR"].ToString();
                DEGERLER.Add(ent);
            }
            dr.Close();
            return DEGERLER;

          }

        
       

        public static int PersonelEkle(EntityPersonel P)
        {
            SqlCommand komut2 = new SqlCommand("insert into tbl_bilgi (AD, SOYAD, GOREV, " +
                "SEHİR,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", P.Ad);
            komut2.Parameters.AddWithValue("@P2", P.Soyad);
            komut2.Parameters.AddWithValue("@P3", P.Gorev);
            komut2.Parameters.AddWithValue("@P4", P.Sehir);
            komut2.Parameters.AddWithValue("@P5", P.Maas);
            return komut2.ExecuteNonQuery();
        }

        public static bool PersonlSil(int Parametre)
        {
            SqlCommand komut3 = new SqlCommand("Delete from tbl_Bilgi where ID=@p1", Baglanti.bgl);

            if (komut3.Connection.State != ConnectionState.Open)
                komut3.Connection.Open();

            komut3.Parameters.AddWithValue("@p1", Parametre);
            return komut3.ExecuteNonQuery() > 0;
                
            
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("Update tbl_bilgi set  AD=@P1, SOYAD=@P2, SEHİR=@P3, GOREV=@P4, MAAS=@P5  where ID=@P6", Baglanti.bgl);

            if (komut4.Connection.State != ConnectionState.Open)
                komut4.Connection.Open();

            komut4.Parameters.AddWithValue("@P1", ent.Ad);
            komut4.Parameters.AddWithValue("@P2", ent.Soyad);
            komut4.Parameters.AddWithValue("@P3", ent.Sehir);
            komut4.Parameters.AddWithValue("@P4", ent.Gorev);
            komut4.Parameters.AddWithValue("@P5", ent.Maas);
            komut4.Parameters.AddWithValue("@P6", ent.Id);

            return komut4.ExecuteNonQuery() > 0;
        }

            
        
    }
}
