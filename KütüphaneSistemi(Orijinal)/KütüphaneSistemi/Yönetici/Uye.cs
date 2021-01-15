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
    public partial class Uye : Form
    {
        public Uye()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KULLANİCİTableAdapter user = new DataSet1TableAdapters.KULLANİCİTableAdapter();
        
        
        private void Uye_Load(object sender, EventArgs e)
        {
            Button[] btn = new Button[user.KllListele().Count() + 1];
            Label[] lbl = new Label[user.KllListele().Count() + 1];
            int top = 30, left = 65;
            int btop = 37, bleft = 21;
            for (int i = 1; i <= lbl.GetUpperBound(0); i++)
            {
                lbl[i] = new Label();
                lbl[i].Text = user.KllListele().Where(x => x.KULLANİCİID == i).FirstOrDefault().ADSOYAD;
                lbl[i].AutoSize = true;
                lbl[i].ForeColor = Color.Blue;
                lbl[i].Top = top;
                lbl[i].Left = left;
                this.Controls.Add(lbl[i]);
                top += 60;

                btn[i] = new Button();
                btn[i].Name =i.ToString();
                btn[i].AutoSize = true;
                btn[i].BackgroundImageLayout = ImageLayout.Stretch;
                if (user.KllListele().Where(x=>x.KULLANİCİID==i).FirstOrDefault().DURUM==false)
                {
                    btn[i].BackgroundImage = ımageList1.Images[1];
                }
                else
                {
                    btn[i].BackgroundImage = ımageList1.Images[0];
                }
                
                btn[i].Width = 37;
                btn[i].Height = 32;
                btn[i].Top = btop;
                btn[i].Left = bleft;
                btn[i].Click += new EventHandler(dnmkb);
                this.Controls.Add(btn[i]);
                btop += 60;
            }
            
        }
        private void dnmkb(object sender,EventArgs e)
        {
            Button dnmkb = (Button)sender;
            string ad = user.KllListele().Where(x => x.KULLANİCİID == int.Parse(dnmkb.Name)).FirstOrDefault().ADSOYAD;
            if (user.KllListele().Where(x=>x.KULLANİCİID==int.Parse(dnmkb.Name)).FirstOrDefault().DURUM==true)
            {
                if (MessageBox.Show(ad + " İsimli üye banlansınmı?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    user.KllDurum(false, int.Parse(dnmkb.Name));
                    dnmkb.BackgroundImage = ımageList1.Images[1];
                }
                else
                {
                    MessageBox.Show("Banlama işlemi gerçekleşmedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                if (MessageBox.Show(ad+" İsimli üyenin banı açılsınmı?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    user.KllDurum(true, int.Parse(dnmkb.Name));
                    dnmkb.BackgroundImage = ımageList1.Images[0];
                }
                else
                {
                    MessageBox.Show("Ban Açılmadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            
        }

        
    }
}
