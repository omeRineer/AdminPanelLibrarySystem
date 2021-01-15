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
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.KİTAPTableAdapter ktp = new DataSet1TableAdapters.KİTAPTableAdapter();
        DataSet1TableAdapters.KULLANİCİTableAdapter kll = new DataSet1TableAdapters.KULLANİCİTableAdapter();
        private void İstatistik_Load(object sender, EventArgs e)
        {
            lblToplamKitap.Text = ktp.KitapListele().Count().ToString();
            lblEmanetSayi.Text = ktp.KitapListele().Where(x => x.DURUM == true).Count().ToString();
            lblMevcutKitap.Text = ktp.KitapListele().Where(x => x.DURUM == false).Count().ToString();
            lblUyeSayi.Text = kll.KllListele().Count().ToString();
            lblEnCokBegenilen.Text = ktp.KitapListele().OrderByDescending(x => x.BEGENİ).FirstOrDefault().KİTAPAD;
        }

        private void lblEnCokBegenilen_Click(object sender, EventArgs e)
        {

        }
    }
}
