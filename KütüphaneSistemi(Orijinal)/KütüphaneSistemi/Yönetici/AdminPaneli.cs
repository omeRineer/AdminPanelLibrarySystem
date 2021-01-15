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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }
        
        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapPanel kp = new KitapPanel();
            kp.Show();
        }

        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            TurPanel tp = new TurPanel();
            tp.Show();

           
        }

        private void btnYayıneviEkle_Click(object sender, EventArgs e)
        {
            Yayinevleri ye = new Yayinevleri();
            ye.Show();

            
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            İstatistik ist = new İstatistik();
            ist.Show();
        }


        int move, movex, movey;

        private void AdminPaneli_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movex = e.X;
            movey = e.Y;
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            Uye uye = new Uye();
            uye.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            GirisPaneli gp = new GirisPaneli();
            gp.Show();
            this.Close();
        }

        private void AdminPaneli_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }
        private void AdminPaneli_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }
        }

    }
}
