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
    public partial class KayitP : Form
    {
        public KayitP()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KULLANİCİTableAdapter klt = new DataSet1TableAdapters.KULLANİCİTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            klt.KullaniciEkle(textBox1.Text, textBox2.Text,txtAdSoyad.Text);

            MessageBox.Show("Üye olma işlemi başarılı \n \n Giriş paneline yönlendiriliyorsunuz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
