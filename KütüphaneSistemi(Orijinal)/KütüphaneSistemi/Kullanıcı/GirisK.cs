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
    public partial class GirisK : Form
    {
        public GirisK()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KULLANİCİTableAdapter kg = new DataSet1TableAdapters.KULLANİCİTableAdapter();
        private void GirisK_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kg.KGiris(textBox1.Text, textBox2.Text).Any())
            {
                Kitaplık ktp = new Kitaplık();
                ktp.ıd = kg.KGiris(textBox1.Text, textBox2.Text).FirstOrDefault().KULLANİCİID;
                ktp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitP kp = new KayitP();
            kp.Show();
        }
    }
}
