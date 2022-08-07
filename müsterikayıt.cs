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
    public partial class müsterikayıt : Form
    {
        public müsterikayıt()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\musteri.accdb");


        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

            bool kayitkonrol = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from musteriler where Tcno ='" + bunifuMaterialTextbox1.Text + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkonrol = true;
                break;
            }
            baglanti.Close();
            if (kayitkonrol == false)
            {

                if (bunifuMaterialTextbox1.Text.Length < 11 || bunifuMaterialTextbox1.Text == "")
                    bunifuCustomLabel1.ForeColor = Color.Red;
                else
                    bunifuCustomLabel1.ForeColor = Color.Black;

                if (bunifuMaterialTextbox2.Text.Length < 2 || bunifuMaterialTextbox2.Text == "")
                    bunifuCustomLabel2.ForeColor = Color.Red;
                else
                    bunifuCustomLabel2.ForeColor = Color.Black;

                if (bunifuMaterialTextbox3.Text.Length < 2 || bunifuMaterialTextbox3.Text == "")
                    bunifuCustomLabel3.ForeColor = Color.Red;
                else bunifuCustomLabel3.ForeColor = Color.Black;

                if (bunifuMaterialTextbox4.Text.Length < 2 || bunifuMaterialTextbox4.Text == "")
                    bunifuCustomLabel4.ForeColor = Color.Red;
                else bunifuCustomLabel4.ForeColor = Color.Black;

                if (bunifuMaterialTextbox5.Text.Length < 11 || bunifuMaterialTextbox5.Text == "")
                    bunifuCustomLabel5.ForeColor = Color.Red;
                else
                    bunifuCustomLabel5.ForeColor = Color.Black;

                if (pictureBox1.Image == null)
                    bunifuTileButton1.ForeColor = Color.Red;
                else
                    bunifuTileButton1.ForeColor = Color.Black;


                if (bunifuMaterialTextbox1.Text.Length == 11 && bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text!= "" &&
                    bunifuMaterialTextbox4.Text != "" && bunifuMaterialTextbox5.Text.Length == 11 && bunifuMaterialTextbox5.Text != "" && pictureBox1.Image != null)
                {


                    try
                    {
                        baglanti.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("insert into musteriler values ('" + bunifuMaterialTextbox1.Text + "', '" + bunifuMaterialTextbox2.Text + "','" +
                            "" + bunifuMaterialTextbox3.Text + "','" + bunifuMaterialTextbox4.Text + "','" + bunifuMaterialTextbox5.Text + "')", baglanti);
                        eklekomutu.ExecuteReader();
                        baglanti.Close();
                        pictureBox1.Image.Save(Application.StartupPath + "\\musteri.resimler\\" + bunifuMaterialTextbox1.Text + ".jpg");
                        MessageBox.Show("Yeni müşteri kaydı başarıyla tamamlandı!", "ARAÇ TAKİP SİSTEMİ");
                       
                        bunifuMaterialTextbox1.Text = "";
                        bunifuMaterialTextbox2.Text = "";
                        bunifuMaterialTextbox3.Text = "";
                        bunifuMaterialTextbox4.Text = "";
                        bunifuMaterialTextbox5.Text = "";
                       

                    }
                    catch (Exception hatamesaji)
                    {

                        MessageBox.Show(hatamesaji.Message);
                        baglanti.Close();
                    }

                }
                else MessageBox.Show("Yazı rengi kırmızı olanları yeniden gözden geçiriniz! ", "ARAÇ TAKİP SİSTEMİ");


            }
            else
                MessageBox.Show("Girilen tc kimlik numarası önceden kayıt edilmiştir! ", "ARAÇ TAKİP SİSTEMİ");
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

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
