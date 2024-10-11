using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace N_Katmanli_Mimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel Ent = new EntityPersonel();
            Ent.Ad = txtAD.Text;
            Ent.Soyad = txtSoyad.Text;
            Ent.Sehir = txtSehir.Text;
            Ent.Gorev = txtGorev.Text;
            Ent.Maas = short.Parse(txtMaas.Text);
            LogicPersonel.LLPersonelEkle(Ent);

          
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ENT = new EntityPersonel();

            ENT.Id = Convert.ToInt32(txtID.Text);
            LogicPersonel.LLPersonelSil(ENT.Id);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ENT = new EntityPersonel();
            ENT.Id = Convert.ToInt32(txtID.Text);
            ENT.Ad = txtAD.Text;
            ENT.Soyad = txtSoyad.Text;
            ENT.Maas = short.Parse(txtMaas.Text);
            ENT.Sehir = txtSehir.Text;
            ENT.Gorev = txtGorev.Text;

            LogicPersonel.LLPersonelGuncelle(ENT);

        }

        private void BtnDep_Click(object sender, EventArgs e)
        {
        }
    }
}
