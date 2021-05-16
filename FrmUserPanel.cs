using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void FrmUserPanel_Load(object sender, EventArgs e)
        {
                       
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
            gncby.BAKIYEYUKLE = int.Parse(bky);
            en.SaveChanges();

            MessageBox.Show("Yüklediğiniz Tutar Admin Onayından Sonra Bakiyenize Eklenecektir !");
        }
    }
}
