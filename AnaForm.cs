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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminGiris admn = new AdminGiris();
            admn.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserGiris usr = new UserGiris();
            usr.Show();
            this.Hide();
        }
    }
}
