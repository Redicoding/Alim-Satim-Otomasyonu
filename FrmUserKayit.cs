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
    public partial class FrmUserKayit : Form
    {
        public FrmUserKayit()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            YazilimYapimiEntities en = new YazilimYapimiEntities();

            Tbl_User u = new Tbl_User();
            u.Ad = txtAd.Text;
            u.Soyad = txtSoyad.Text;
            u.KAd = txtKullanici.Text;
            u.Password = txtSifre.Text;
            u.TC = txtTC.Text;
            u.Tel = txtTel.Text;
            u.Mail = txtMail.Text;
            u.Bakiye = 0;

            en.Tbl_User.Add(u);
            en.SaveChanges();

            MessageBox.Show("Kayıt Başarılı Sisteme Giriş Yapabilirsiniz...");

        }
    }
}
