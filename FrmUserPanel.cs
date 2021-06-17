using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Yazılım_Yapımı_Project
{
    public partial class FrmUserPanel : Form
    {
        public FrmUserPanel()
        {
            InitializeComponent();
        }

        YazilimYapimiEntities en = new YazilimYapimiEntities();
        public string kullaniciadi;
        
        void SatısEmir()
        {
            double fiyat = Convert.ToDouble((from x in en.Tbl_Emir
                                             from y in en.Tbl_Urun
                                             where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                             select x.EmirFiyat * x.EmirKilo).FirstOrDefault());

            double kilo = Convert.ToDouble((from x in en.Tbl_Emir
                                            from y in en.Tbl_Urun
                                            where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                            select x.EmirKilo).FirstOrDefault());

            int idalici = Convert.ToInt32((from x in en.Tbl_Emir
                                       from y in en.Tbl_Urun
                                       where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                       select x.EmirUser).FirstOrDefault());

            int idsatici = Convert.ToInt32((from x in en.Tbl_Emir
                                            from y in en.Tbl_Urun
                                            where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                            select y.KULLANICI).FirstOrDefault());

            int idurun  = Convert.ToInt32((from x in en.Tbl_Emir
                                           from y in en.Tbl_Urun
                                           where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                           select y.Urunid).FirstOrDefault());

            int idsatıs = Convert.ToInt32((from x in en.Tbl_Emir
                                           from y in en.Tbl_Urun
                                           where x.EmirUrun == y.URUNAD && x.EmirFiyat == y.URUNFIYAT && x.EmirDurum == false && x.EmirKilo <= y.URUNSTOK
                                           select x.EmirId).FirstOrDefault());

            var komisyon = en.Tbl_admin.Find(1);
            komisyon.komisyon += (fiyat * (0.01));
            en.SaveChanges();

            double fiyatk = fiyat + (fiyat * (0.01));

            if (fiyat != 0)
            {
                var musteri = en.Tbl_User.Find(idalici);
                musteri.Bakiye -= Convert.ToInt32(fiyatk);
                en.SaveChanges();

                var satici = en.Tbl_User.Find(idsatici);
                satici.Bakiye += Convert.ToInt32(fiyat);
                en.SaveChanges();

                var urun = en.Tbl_Urun.Find(idurun);
                urun.URUNSTOK -= kilo;
                en.SaveChanges();

                var durum = en.Tbl_Emir.Find(idsatıs);
                durum.EmirDurum = true;
                en.SaveChanges();
            }

           
        }

        private void FrmUserPanel_Load(object sender, EventArgs e)
        {

            SatısEmir();


            var isim = from x in en.Tbl_User where x.KAd == kullaniciadi select x.Ad+ " " + x.Soyad;
            var bakiye = from x in en.Tbl_User where x.KAd == kullaniciadi select x.Bakiye;
            lblAd.Text = isim.FirstOrDefault();
            lblbakiye.Text = bakiye.FirstOrDefault().ToString();

            txtUyari.Text = "BAKİYE yükleme ve ÜRÜN ekleme işlemlerinin ADMİN tarafından onaylanması gerekmektedir.                Buna göre işlem yapınız!!!!";


            dataGridView1.DataSource = (from x in en.Tbl_Urun where x.URUNDURUM == true
                                        select new
                                        {
                                            x.Urunid,
                                            x.URUNAD,
                                            x.URUNFIYAT,
                                            x.URUNSTOK

                                        }).ToList();

            string kurlar = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(kurlar);

            string usd = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblUSD.Text = usd;

            string str = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            lblSTR.Text = str;

            string jpy = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='JPY']/BanknoteSelling").InnerXml;
            lblJPY.Text = jpy;


            
            
        }

        private void btnSatıs_Click(object sender, EventArgs e)
        {
            Tbl_Urun ur = new Tbl_Urun();

            ur.URUNAD = txtUrunAd.Text;
            ur.URUNFIYAT = Convert.ToInt32(txtUrunFiyat.Text);
            ur.URUNSTOK = Convert.ToInt32(txtUrunStok.Text);
            ur.KULLANICI = (from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault();
            ur.URUNDURUM = false;
            en.Tbl_Urun.Add(ur);
            en.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Eklendi Admin Onayından Sonra Satışa Çıkacaktır...","Ekleme Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            
        }

        private void btnSatınAl_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            int idmusteri = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault());
            int idsatici = Convert.ToInt32((from x in en.Tbl_Urun where x.Urunid == id select x.KULLANICI).FirstOrDefault());
            int kg = Convert.ToInt32(txtKG.Text);
            int kgfiyat = Convert.ToInt32((from x in en.Tbl_Urun where x.Urunid == id select x.URUNFIYAT).FirstOrDefault());
            int urunkg = Convert.ToInt32((from x in en.Tbl_Urun where x.Urunid == id select x.URUNSTOK).FirstOrDefault());
            int bakiye = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Bakiye).FirstOrDefault());
            int fiyat = kg * kgfiyat;

            bakiye = bakiye - fiyat;
            urunkg = urunkg - kg;

            
            var gnc = en.Tbl_User.Find(idmusteri);
            gnc.Bakiye = bakiye;
            en.SaveChanges();

            var gnc2 = en.Tbl_Urun.Find(id);
            gnc2.URUNSTOK = urunkg;
            en.SaveChanges();

            var gnc3 = en.Tbl_User.Find(idsatici);
            gnc3.Bakiye += fiyat;
            en.SaveChanges();


            var yenile = from x in en.Tbl_User where x.KAd == kullaniciadi select x.Bakiye;
            lblbakiye.Text = yenile.FirstOrDefault().ToString();

            dataGridView1.DataSource = (from x in en.Tbl_Urun
                                        where x.URUNDURUM == true
                                        select new
                                        {
                                            x.Urunid,
                                            x.URUNAD,
                                            x.URUNFIYAT,
                                            x.URUNSTOK

                                        }).ToList();

            MessageBox.Show("Satın Alma İşlemi Başarılı Bakiyenizi Kontrol Ediniz !");

        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            int idmusteri = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault());
            var bky = txtBakiye.Text;
            var gncby = en.Tbl_User.Find(idmusteri);           
            gncby.BAKIYEYUKLE = Convert.ToInt32(bky);              
            en.SaveChanges();

            MessageBox.Show("Yüklediğiniz Tutar Admin Onayından Sonra Bakiyenize Eklenecektir !");
        }
        
        private void btnUSD_Click(object sender, EventArgs e)
        {
            double usd = Convert.ToDouble(lblUSD.Text);
            int idmusteri = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault());
            var bky = txtBakiye.Text;
            var gncby = en.Tbl_User.Find(idmusteri);
            double a = Convert.ToDouble(bky) * usd;
            gncby.BAKIYEYUKLE = Convert.ToInt32(a);
            en.SaveChanges();

            MessageBox.Show("Yüklediğiniz Tutar Admin Onayından Sonra Bakiyenize Eklenecektir !");
        }
     
        private void btnSTR_Click(object sender, EventArgs e)
        {
            double str = Convert.ToDouble(lblSTR.Text);
            int idmusteri = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault());
            var bky = txtBakiye.Text;
            var gncby = en.Tbl_User.Find(idmusteri);
            double a = Convert.ToDouble(bky) * str;
            gncby.BAKIYEYUKLE = Convert.ToInt32(a);
            en.SaveChanges();

            MessageBox.Show("Yüklediğiniz Tutar Admin Onayından Sonra Bakiyenize Eklenecektir !");
        }

        private void btnJpy_Click(object sender, EventArgs e)
        {

            double jpy = Convert.ToDouble(lblJPY.Text);
            int idmusteri = Convert.ToInt32((from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault());
            var bky = txtBakiye.Text;
            var gncby = en.Tbl_User.Find(idmusteri);
            double a = Convert.ToDouble(bky) * jpy;
            gncby.BAKIYEYUKLE = Convert.ToInt32(a);
            en.SaveChanges();

            MessageBox.Show("Yüklediğiniz Tutar Admin Onayından Sonra Bakiyenize Eklenecektir !");
        }

        private void btnEmir_Click(object sender, EventArgs e)
        {
            Tbl_Emir em = new Tbl_Emir();
            em.EmirUrun = txtAD.Text;
            em.EmirKilo = Convert.ToDouble(txtKG.Text);
            em.EmirFiyat = Convert.ToDouble(txtFIYAT.Text);
            em.EmirTarih = "16/06/2021";
            em.EmirDurum = false;
            em.EmirUser = (from x in en.Tbl_User where x.KAd == kullaniciadi select x.Kid).FirstOrDefault();
            en.Tbl_Emir.Add(em);
            en.SaveChanges();

            MessageBox.Show("Ürün Fiyat Emri Başarıyla Eklendi.. (Alım işlemi gerçekleşirse %1 komisyon ücreti alınacaktır)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRapor frmr = new FrmRapor();
            frmr.Show();
        }
    }
}
