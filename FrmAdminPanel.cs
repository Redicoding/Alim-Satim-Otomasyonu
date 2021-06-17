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
    public partial class FrmAdminPanel : Form
    {
        public FrmAdminPanel()
        {
            InitializeComponent();
        }

        YazilimYapimiEntities en = new YazilimYapimiEntities();
        
        private void FrmAdminPanel_Load(object sender, EventArgs e)
        {
            datagridurun.DataSource = (from x in en.Tbl_Urun
                                       where x.URUNDURUM == false
                                       select new
                                       {
                                           x.Urunid,
                                           x.URUNAD,
                                           x.URUNFIYAT,
                                           x.URUNSTOK

                                       }).ToList();

            datagridbakiye.DataSource = (from x in en.Tbl_User
                                       where x.BAKIYEYUKLE != null
                                       select new
                                       {
                                           x.Ad,
                                           x.Soyad,
                                           x.BAKIYEYUKLE

                                       }).ToList();

            lblKomisyon.Text = (from x in en.Tbl_admin select x.komisyon).FirstOrDefault().ToString() + " TL ";
                                
        }

        private void datagridurun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagridurun.SelectedCells[0].RowIndex;
            txtID.Text = datagridurun.Rows[secilen].Cells[0].Value.ToString();
            txtURUNAD.Text = datagridurun.Rows[secilen].Cells[1].Value.ToString();

        }

        private void datagridbakiye_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagridbakiye.SelectedCells[0].RowIndex;
            txtISIM.Text = datagridbakiye.Rows[secilen].Cells[0].Value.ToString();
            txtBAKIYE.Text = datagridbakiye.Rows[secilen].Cells[2].Value.ToString();

        }

        private void btnUrunOnayla_Click(object sender, EventArgs e)
        {
            int id = int.Parse (txtID.Text);
            var gncu = en.Tbl_Urun.Find(id);
            gncu.URUNDURUM = true;
            en.SaveChanges();

            datagridurun.DataSource = (from x in en.Tbl_Urun
                                       where x.URUNDURUM == false
                                       select new
                                       {
                                           x.Urunid,
                                           x.URUNAD,
                                           x.URUNFIYAT,
                                           x.URUNSTOK

                                       }).ToList();

            MessageBox.Show("ÜRÜN PAZARA BAŞARIYLA EKLENDİ !!!");

        }

        private void btnBakiyeOnayla_Click(object sender, EventArgs e)
        {
            var id = (from x in en.Tbl_User where x.Ad == txtISIM.Text select x.Kid).FirstOrDefault();
            int bakiye =Convert.ToInt32((from x in en.Tbl_User where x.Ad == txtISIM.Text select x.Bakiye).FirstOrDefault());
            int ybakiye = int.Parse(txtBAKIYE.Text);

            int toplambakiye = bakiye + ybakiye;

            var gncb = en.Tbl_User.Find(id);
            gncb.Bakiye = toplambakiye;
            gncb.BAKIYEYUKLE = null;
            en.SaveChanges();

            datagridbakiye.DataSource = (from x in en.Tbl_User
                                         where x.BAKIYEYUKLE != null
                                         select new
                                         {
                                             x.Ad,
                                             x.Soyad,
                                             x.BAKIYEYUKLE

                                         }).ToList();


            MessageBox.Show("BAKİYE KULLANICININ HESABINA BAŞARIYLA GÖNDERİLDİ !");
        }
    }
}
