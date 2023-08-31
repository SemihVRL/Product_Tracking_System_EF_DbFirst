using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Tracking_System
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        DbUrunEntities dbUrunEntities = new DbUrunEntities();

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugün =DateTime.Today;
            label2.Text=dbUrunEntities.TblMusteri.Count().ToString();//toplam müşteri tablosundaki elemanları saydı

           label3.Text = dbUrunEntities.TblKategori.Count().ToString();//toplam kategori tablosundaki elemanları saydı

           label5.Text=dbUrunEntities.TblUrunler.Count().ToString();//ürünler tablosundaki verileri saydı

           label7.Text=dbUrunEntities.TblUrunler.Count(x=>x.Kategori==1).ToString();

           label15.Text = dbUrunEntities.TblUrunler.Sum(x=>x.Stok).ToString();//toplam stok sayısnı topluyor

            label13.Text=dbUrunEntities.TblSatıslar.Count(x=>x.SatisTarihi==bugün).ToString();

            label11.Text = dbUrunEntities.TblSatıslar.Where(x => x.SatisTarihi == bugün).Sum(x => x.ToplamTutar).ToString() + " $";

            label24.Text = dbUrunEntities.TblSatıslar.Sum(x => x.ToplamTutar).ToString() + " $";

            label22.Text = (from x in dbUrunEntities.TblUrunler
                           orderby x.SatisFiyat descending
                           select x.UrunAdi).FirstOrDefault();



            label18.Text = (from x in dbUrunEntities.TblUrunler
                            orderby x.SatisFiyat ascending
                            select x.UrunAdi).FirstOrDefault();

            label20.Text = (from x in dbUrunEntities.TblUrunler
                            orderby x.Stok descending
                            select x.UrunAdi).FirstOrDefault();

            label10.Text = (from x in dbUrunEntities.TblUrunler
                            orderby x.Stok ascending
                            select x.UrunAdi).FirstOrDefault();

        }
    }
}
