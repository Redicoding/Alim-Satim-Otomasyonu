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
    public partial class UserGiris : Form
    {
        public UserGiris()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        YazilimYapimiEntities en = new YazilimYapimiEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var sorgu = from x in en.Tbl_User
                        where x.KAd == txtKullanici.Text && x.Password == txtSifre.Text
                        select x;

            if (sorgu.Any())
            {
                FrmUserPanel frmu = new FrmUserPanel();
                frmu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı !", "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUserKayit frmk = new FrmUserKayit();
            frmk.Show();            
        }
    }
}
