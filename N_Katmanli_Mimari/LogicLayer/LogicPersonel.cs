using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntityPersonel P)
        {
            if (P.Ad != "" && P.Soyad != "" && P.Maas >= 3500 && P.Ad.Length >= 3)
                return DALPersonel.PersonelEkle(P);
            else
                return -1;
        }

        public static bool LLPersonelSil(int Parametre1)
        {
            if (Parametre1 >= 0)
                return DALPersonel.PersonlSil(Parametre1);
            else
                return false;
        }

        public static bool LLPersonelGuncelle(EntityPersonel Parametre2)
        {
            if (Parametre2.Ad.Length >= 3 && Parametre2.Ad != "" && Parametre2.Maas >= 4500)
                return DALPersonel.PersonelGuncelle(Parametre2);
            else
                return false;
        }
    }
}
