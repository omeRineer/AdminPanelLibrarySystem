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
    public partial class PDFEkrani : Form
    {
        public PDFEkrani()
        {
            InitializeComponent();
        }
        public string pdfyolu;
        private void PDFEkrani_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(pdfyolu);
        }
    }
}
