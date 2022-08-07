using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetasarım
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            müsterikayıt musteri = new müsterikayıt();
            musteri.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            musteri_listeleleme listeleme = new musteri_listeleleme();
            listeleme.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            arac_kayit kayit = new arac_kayit();
            kayit.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            arac_listeleme listeleme = new arac_listeleme();
            listeleme.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            arac_kiralama kiralama = new arac_kiralama();
            kiralama.Show();
        }
    }
}
