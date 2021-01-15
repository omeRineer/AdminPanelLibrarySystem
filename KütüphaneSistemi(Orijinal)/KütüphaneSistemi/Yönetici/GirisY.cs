using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneSistemi
{
    public partial class GirisY : Form
    {
        public GirisY()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.ADMİNTableAdapter admin = new DataSet1TableAdapters.ADMİNTableAdapter();
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (admin.Giris(textBox1.Text,textBox2.Text).Any())
            {
                AdminPaneli ap = new AdminPaneli();
                ap.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
