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
    public partial class KitapPanel : Form
    {
        public KitapPanel()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KİTAPTableAdapter kds = new DataSet1TableAdapters.KİTAPTableAdapter();
        
        string c;
        void Renklendir()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == true)
                {
                    renk.BackColor = Color.OrangeRed;
                }
                else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == false)
                {
                    renk.BackColor = Color.Green;
                }
                else
                {

                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }
        void Listele()
        {
            dataGridView1.DataSource = (from y in kds.KitapListele()
                                        select new
                                        {
                                            y.KİTAPID,
                                            y.KİTAPAD,
                                            y.TURAD,
                                            y.YAZAR,
                                            y.YAYINEVİAD,
                                            y.BARKODNO,
                                            y.DURUM
                                        }).ToList();
            Renklendir();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                kds.KitapEkle(txtAd.Text, byte.Parse(cmbTur.SelectedValue.ToString()), txtYazar.Text, byte.Parse(cmbYayinevi.SelectedValue.ToString()), txtBarkod.Text, false, txtPDF.Text, txtResim.Text);
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            

            MessageBox.Show("Veri eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void KitapPanel_Load(object sender, EventArgs e)
        {
            Listele();

            DataSet1TableAdapters.TURTableAdapter turc = new DataSet1TableAdapters.TURTableAdapter();
            cmbTur.DataSource = turc.TurListele();
            cmbTur.ValueMember = "ID";
            cmbTur.DisplayMember = "TURAD";

            DataSet1TableAdapters.YAYİNEVİTableAdapter yurc = new DataSet1TableAdapters.YAYİNEVİTableAdapter();
            cmbYayinevi.DataSource = yurc.YayineviListele();
            cmbYayinevi.ValueMember = "YAYINEVİID";
            cmbYayinevi.DisplayMember = "YAYINEVİAD";

            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            kds.KitapSil(int.Parse(txtId.Text));

            MessageBox.Show("Veri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kds.KitapGunc(txtAd.Text, byte.Parse(cmbTur.SelectedValue.ToString()), txtYazar.Text, byte.Parse(cmbYayinevi.SelectedValue.ToString()), txtBarkod.Text,int.Parse(txtId.Text));

            MessageBox.Show("Veri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = kds.KitapListele().DefaultView;
            dv.RowFilter = c + " like ('" + txtAra.Text + "%')";
            dataGridView1.DataSource = dv;
            //Renklendir();
        }

        private void cmbAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = cmbAra.SelectedItem.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbTur.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtYazar.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbYayinevi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtBarkod.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtResim.Text = kds.KitapListele().Where(x => x.KİTAPID == int.Parse(txtId.Text)).FirstOrDefault().RESİM;
            txtPDF.Text= kds.KitapListele().Where(x => x.KİTAPID == int.Parse(txtId.Text)).FirstOrDefault().PDF;
            pictureBox1.ImageLocation = txtResim.Text;

        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            openFileDialog1.InitialDirectory = @"D:\Ömer Faruk\Diğer\C#\C Sharp Projeler\FORM APPS\VERİTABANLI\VERİ KAYNAKLARI\KitapKaynak\Resim";
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = openFileDialog1.FileName;

            //OpenFileDialog file = new OpenFileDialog();
            //file.ShowDialog();
            //file.Title = "PDF Seç";
            //file.Filter = "PDF Dosyası |*.pdf";
            //txtPDF.Text = file.FileName;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = null;
            openFileDialog2.InitialDirectory = @"D:\Ömer Faruk\Diğer\C#\C Sharp Projeler\FORM APPS\VERİTABANLI\VERİ KAYNAKLARI\KitapKaynak\PDF";
            openFileDialog2.ShowDialog();
            txtPDF.Text = openFileDialog2.FileName;
        }

        private void txtResim_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
            GirisPaneli gp = new GirisPaneli();
            gp.Show();
        }
    }
}
