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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbUrunEntities dbUrunEntities = new DbUrunEntities();

        void urunlistesi()
        {
            var degerler = from x in dbUrunEntities.TblMusteri
                           select new
                           {
                               x.MusteriID,
                               x.MusteriAdi,
                               x.MusteriSoyadi,
                               x.MusteriBakiye,
                               x.MusteriSehir
                               
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            urunlistesi();
            
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dbUrunEntities.TblMusteri.ToList(); bu satır tablonun bütün elemanlarını getirir 
            urunlistesi();// istenilen elemanlar gelicek
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblMusteri tblMusteri= new TblMusteri();
            tblMusteri.MusteriAdi = tbxAd.Text;
            tblMusteri.MusteriSoyadi = tbxSoyad.Text;
            tblMusteri.MusteriBakiye = decimal.Parse(tbxBakiye.Text);
            tblMusteri.MusteriSehir = tbxSehir.Text;
            dbUrunEntities.TblMusteri.Add(tblMusteri);
            dbUrunEntities.SaveChanges();

            tbxBakiye.Clear();
            tbxAd.Clear();
            tbxSehir.Clear();
            tbxSoyad.Clear();
            tbxID.Clear();

            urunlistesi();
           

            MessageBox.Show("Kaydedildi");

            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbxID.Text);// id texti string değerden int değere aldık
            var x = dbUrunEntities.TblMusteri.Find(id);// tbxid.textte olan değerini tbl müşteri tablosudnan ıd olan değeri  x değerin
            dbUrunEntities.TblMusteri.Remove(x);// o seçilen x değeri tbl musteri tablosundan silindi
            dbUrunEntities.SaveChanges();//

            tbxBakiye.Clear();
            tbxAd.Clear();
            tbxSehir.Clear();
            tbxSoyad.Clear();
            tbxID.Clear();
            urunlistesi();
            MessageBox.Show("Ürün Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxAd.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxSoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           
            tbxBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbxSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }


        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbxID.Text);//id texti string değerden int değere aldık
            var x = dbUrunEntities.TblMusteri.Find(id);//tbx.id textte olan değeri gittik tbl musteri tablosunda bulduk ve x değerine atadık
            x.MusteriAdi = tbxAd.Text;
            x.MusteriSoyadi = tbxSoyad.Text;
            x.MusteriBakiye = decimal.Parse(tbxBakiye.Text);
            x.MusteriSehir = tbxSehir.Text;

            tbxBakiye.Clear();
            tbxAd.Clear();
            tbxSehir.Clear();
            tbxSoyad.Clear();
            tbxID.Clear();

            dbUrunEntities.SaveChanges();

            urunlistesi();
            MessageBox.Show("Güncellendi");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxBakiye.Clear();
            tbxAd.Clear();
            tbxSehir.Clear();
            tbxSoyad.Clear();
            tbxID.Clear();
        }
    }
}
