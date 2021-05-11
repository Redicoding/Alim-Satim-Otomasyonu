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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void btnGiris_Click(object sender, EventArgs e)
        {
            YazilimYapimiEntities en = new YazilimYapimiEntities();

            var sorgu = from x in en.Tbl_admin
                        where x.adminisim == txtKullanici.Text && x.sifre == txtSifre.Text
                        select x;

            if (sorgu.Any())
            {
                FrmAdminPanel frma = new FrmAdminPanel();
                frma.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı !", "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
