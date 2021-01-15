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
    public partial class Yayinevleri : Form
    {
        public Yayinevleri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.YAYİNEVİTableAdapter yed = new DataSet1TableAdapters.YAYİNEVİTableAdapter();

        void Listele()
        {
            dataGridView1.DataSource = yed.YayineviListele();
            
            
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            yed.YEEkle(txtAd.Text);

            MessageBox.Show("Veri eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void Yayinevleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            yed.YESil(byte.Parse(txtId.Text));

            MessageBox.Show("Veri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            yed.YEGunc(txtAd.Text, byte.Parse(txtId.Text));

            MessageBox.Show("Veri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
