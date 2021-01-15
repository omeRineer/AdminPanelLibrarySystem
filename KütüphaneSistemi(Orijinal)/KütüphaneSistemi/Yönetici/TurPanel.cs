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
    public partial class TurPanel : Form
    {
        public TurPanel()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TURTableAdapter turs = new DataSet1TableAdapters.TURTableAdapter();

        void Listele()
        {
            dataGridView1.DataSource = turs.TurListele();

        }
        private void TurPanel_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            turs.TurEkle(txtAd.Text);

            MessageBox.Show("Veri eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            turs.TurSil(byte.Parse(txtId.Text));

            MessageBox.Show("Veri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            turs.TurGunc(txtAd.Text, byte.Parse(txtId.Text));

            MessageBox.Show("Veri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
