using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace projetasarım
{
    public partial class arac_kayit : Form
    {
        public arac_kayit()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\musteri.accdb");
        public string durum;
        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from araclar where plaka='" + bunifuMetroTextbox1.Text + "'", baglanti);

            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();
            if (kayitkontrol == false)
            {

                if (bunifuMetroTextbox1.Text == "")
                    bunifuCustomLabel1.ForeColor = Color.Red;
                else bunifuCustomLabel1.ForeColor = Color.Black;


                if (bunifuMetroTextbox2.Text == "")
                    bunifuCustomLabel5.ForeColor = Color.Red;
                else bunifuCustomLabel5.ForeColor = Color.Black;

                if (bunifuMetroTextbox3.Text == "")
                    bunifuCustomLabel3.ForeColor = Color.Red;
                else bunifuCustomLabel3.ForeColor = Color.Black;


                if (bunifuMetroTextbox4.Text == "")
                    bunifuCustomLabel4.ForeColor = Color.Red;
                else bunifuCustomLabel4.ForeColor = Color.Black;

                if (bunifuMetroTextbox5.Text == "")
                    bunifuCustomLabel8.ForeColor = Color.Red;
                else bunifuCustomLabel8.ForeColor = Color.Black;

                if (bunifuMetroTextbox6.Text == "")
                    bunifuCustomLabel7.ForeColor = Color.Red;
                else bunifuCustomLabel7.ForeColor = Color.Black;

                if (bunifuMetroTextbox7.Text == "")
                    bunifuCustomLabel6.ForeColor = Color.Red;
                else bunifuCustomLabel6.ForeColor = Color.Black;

                if (pictureBox1.Image == null)
                    bunifuTileButton3.ForeColor = Color.Red;
                else
                    bunifuTileButton3.ForeColor = Color.Black;


                if (bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox2.Text != "" && bunifuMetroTextbox3.Text != "" && bunifuMetroTextbox4.Text
                    != "" && bunifuMetroTextbox5.Text != "" && bunifuMetroTextbox6.Text != "" && pictureBox1.Image != null)
                {


                    try
                    {
                        baglanti.Open();
                        durum = "kiralık";
                        OleDbCommand eklekomutu = new OleDbCommand("insert into araclar values ('" + bunifuMetroTextbox1.Text + "','" + bunifuMetroTextbox2.Text + "','" + bunifuMetroTextbox3.Text + "','" + bunifuMetroTextbox4.Text + "'," +
                            "'" + bunifuMetroTextbox5.Text + "','" + bunifuMetroTextbox6.Text + "','" + bunifuMetroTextbox7.Text + "','" + "kiralık" + "')", baglanti);
                        eklekomutu.ExecuteReader();
                        baglanti.Close();
                        pictureBox1.Image.Save(Application.StartupPath + "\\arac.resimler\\" + bunifuMetroTextbox1.Text + ".jpg");
                        MessageBox.Show("Yeni araç kaydı tamamlandı!", "ARAÇ TAKİP SİSTEMİ");
                        bunifuMetroTextbox1.Text = ""; bunifuMetroTextbox2.Text = ""; bunifuMetroTextbox3.Text = ""; bunifuMetroTextbox4.Text = ""; bunifuMetroTextbox5.Text = "";
                        bunifuMetroTextbox6.Text = ""; bunifuMetroTextbox7.Text = "";
                        pictureBox1.Image = null;

                    }
                    catch (Exception hatamesaji)
                    {

                        MessageBox.Show(hatamesaji.Message);
                        baglanti.Close();

                    }
                }
                else MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz: ");

            }
            else MessageBox.Show("Girilen plaka daha önceden kayıt edilmiştir.");

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Resminizi seçiniz";
            resimsec.Filter = "JPG dosyalar(*jpg) | *.jpg";
            if (resimsec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(resimsec.OpenFile());
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
