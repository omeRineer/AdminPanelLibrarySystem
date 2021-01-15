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
    public partial class GirisPaneli : Form
    {
        public GirisPaneli()
        {
            InitializeComponent();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            GirisK kllncg = new GirisK();
            kllncg.Show();
            this.Hide();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            GirisY yg = new GirisY();
            yg.Show();
            this.Hide();
        }
        
        private void GirisPaneli_Load(object sender, EventArgs e)
        {

        }
        int move, movex, movey;
        private void GirisPaneli_MouseMove(object sender, MouseEventArgs e)
        {
            if (move==1)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }
        }

        private void GirisPaneli_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void GirisPaneli_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movex = e.X;
            movey = e.Y;
        }
    }
}
