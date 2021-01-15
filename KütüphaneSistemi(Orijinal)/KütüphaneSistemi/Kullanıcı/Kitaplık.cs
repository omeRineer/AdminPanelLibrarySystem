using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KütüphaneSistemi
{
    public partial class Kitaplık : Form
    {
        public Kitaplık()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KİTAPTableAdapter dk = new DataSet1TableAdapters.KİTAPTableAdapter();
        DataSet1TableAdapters.KULLANİCİTableAdapter kl = new DataSet1TableAdapters.KULLANİCİTableAdapter();
        public int ıd;
        string o;
        
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
            dataGridView1.DataSource = (from y in dk.KitapListele()
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
            dataGridView2.DataSource = dk.KisiKitap(ıd).Select(g => new
            {
                g.KİTAPID,
                g.KİTAPAD
            }).ToList();
            dataGridView2.Columns[0].Width = 70;
            Renklendir();
        }
        private void Kitaplık_Load(object sender, EventArgs e)
        {
            Listele();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTeslim.Enabled = false;
            label9.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value)==true)
            {
                label5.Text = "ALINMIŞ";
            }
            else
            {
                label5.Text = "ALINMAMIŞ";
            }
            
        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            if (kl.KllListele().Where(x => x.KULLANİCİID == ıd).FirstOrDefault().DURUM == true)
            {
                dk.KitapAl(true, ıd, DateTime.Parse(DateTime.Now.ToShortDateString().ToString()), int.Parse(label9.Text));
                Listele();
                MessageBox.Show("Kitap alım işlemi gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Banlandığınız için kitap alım işlemi gerçekleşmedi \n Lütfen kurallara uyunuz!!", "BANNED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            if (label5.Text=="ALINMAMIŞ")
            {
                btnAl.Enabled = true;
            }
            else
            {
                btnAl.Enabled = false;
            }
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Visible = true;
            label11.Visible = true;
            btnTeslim.Enabled = true;
            button2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value + "- PDF";
            label5.Text = "KÜTÜPHANEDE";
            label9.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            label10.Text = dk.KitapListele().Where(x => x.KİTAPID == int.Parse(label9.Text)).FirstOrDefault().PDF;
        }

        private void btnTeslim_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kitabı teslim etmek istiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                dk.KitapAl(false, null, null, int.Parse(label9.Text));
                Listele();
            }
            else
            {
                MessageBox.Show("Kitap teslim edilmedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PDFEkrani pdfe = new PDFEkrani();
            pdfe.pdfyolu = label10.Text;
            pdfe.Show();
        }

        

        private void cmbAra_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            o = cmbAra.SelectedItem.ToString();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
            GirisPaneli gp = new GirisPaneli();
            gp.Show();
        }

        private void txtAra_TextChanged_1(object sender, EventArgs e)
        {
            DataView dw = dk.KitapListele().DefaultView;
            dw.RowFilter = o + " like ('" + txtAra.Text + "%')";
            dataGridView1.DataSource = dw;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            Renklendir();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dk.BegeniGunc(int.Parse(label9.Text));
        }
    }
}
