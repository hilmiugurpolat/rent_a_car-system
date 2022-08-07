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
    public partial class musteri_listeleleme : Form
    {
        public musteri_listeleleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\musteri.accdb");

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            musterileri_listele();
        }



        private void musterileri_listele()
        {

            try
            {


                baglanti.Open();
                OleDbDataAdapter musterileri_listele = new OleDbDataAdapter("select Tcno AS" +
                    "[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],email AS[E-MAİL],telefon AS [TELEFON] from musteriler Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                musterileri_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();


                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;



            }
            catch (Exception hatamesaji)
            {

                MessageBox.Show(hatamesaji.Message, "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
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

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (bunifuMetroTextbox1.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from musteriler where Tcno='" + bunifuMetroTextbox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\musteri.resimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");
                    }
                    catch
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\musteri.resimler\\resimyok.jpg");

                    }

                    bunifuMetroTextbox2.Text = kayitokuma.GetValue(1).ToString();
                    bunifuMetroTextbox3.Text = kayitokuma.GetValue(2).ToString();
                    bunifuMetroTextbox4.Text = kayitokuma.GetValue(3).ToString();
                    bunifuMetroTextbox5.Text = kayitokuma.GetValue(4).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayıt bulunamadı!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
            else MessageBox.Show("Lütfen 11 haneli tc kimlik numarası giriniz", "ARAÇ TAKİP SİSTEMİ");
            baglanti.Close();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text.Length != 11 || bunifuMetroTextbox1.Text == "")
                bunifuCustomLabel1.ForeColor = Color.Red;
            else
                bunifuCustomLabel1.ForeColor = Color.Black;

            if (bunifuMetroTextbox2.Text.Length < 2 || bunifuMetroTextbox2.Text == "")
                bunifuCustomLabel2.ForeColor = Color.Red;
            else
                bunifuCustomLabel2.ForeColor = Color.Black;

            if (bunifuMetroTextbox3.Text.Length < 2 || bunifuMetroTextbox3.Text == "")
                bunifuCustomLabel3.ForeColor = Color.Red;
            else
                bunifuCustomLabel3.ForeColor = Color.Black;

            if (bunifuMetroTextbox4.Text.Length < 2 || bunifuMetroTextbox4.Text == "")
                bunifuCustomLabel4.ForeColor = Color.Red;
            else
                bunifuCustomLabel4.ForeColor = Color.Black;

            if (bunifuMetroTextbox5.Text.Length != 11 || bunifuMetroTextbox5.Text == "")
                bunifuCustomLabel5.ForeColor = Color.Red;
            else
                bunifuCustomLabel5.ForeColor = Color.Black;

            if (pictureBox1.Image == null)
                bunifuTileButton3.ForeColor = Color.Red;
            else
                bunifuTileButton3.ForeColor = Color.Black;

            if (bunifuMetroTextbox1.Text.Length == 11 && bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox2.Text != "" &&
                bunifuMetroTextbox3.Text != "" && bunifuMetroTextbox4.Text != "" && bunifuMetroTextbox5.Text.Length == 11 && bunifuMetroTextbox5.Text != "")
            {

                try
                {
                    baglanti.Open();
                    OleDbCommand guncelle_komutu = new OleDbCommand("update musteriler set ad='" + bunifuMetroTextbox2.Text + "'" +
                        ",soyad='" + bunifuMetroTextbox3.Text + "',email='" + bunifuMetroTextbox4.Text + "',telefon='" + bunifuMetroTextbox5.Text + "' where Tcno='" + bunifuMetroTextbox1.Text + "'", baglanti);
                    guncelle_komutu.ExecuteReader();

                    baglanti.Close();

                    MessageBox.Show("Müşteri bilgileri güncellendi", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    musterileri_listele();

                }
                catch (Exception hatamesaj)
                {

                    MessageBox.Show(hatamesaj.Message);
                    baglanti.Close();
                }


            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text.Length == 11)
            {

                bool kayit_arama_durumu = false;
                baglanti.Open();
                OleDbCommand select_sorgu = new OleDbCommand("select * from musteriler where Tcno='" + bunifuMetroTextbox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = select_sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {

                    kayit_arama_durumu = true;
                    OleDbCommand delete = new OleDbCommand("delete from musteriler where Tcno='" + bunifuMetroTextbox1.Text + "'", baglanti);
                    delete.ExecuteReader();
                    MessageBox.Show("Kullanıcı bilgileri silindi ", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    musterileri_listele();
                    bunifuMetroTextbox1.Text = ""; bunifuMetroTextbox2.Text = ""; bunifuMetroTextbox3.Text = ""; bunifuMetroTextbox4.Text = ""; bunifuMetroTextbox5.Text = "";
                    pictureBox1.Image = null;
                    
                    break;
                }
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK);
                    baglanti.Close();
                    bunifuMetroTextbox1.Text = ""; bunifuMetroTextbox2.Text = ""; bunifuMetroTextbox3.Text = ""; bunifuMetroTextbox4.Text = ""; bunifuMetroTextbox5.Text = "";
                    pictureBox1.Image = null;
                }

                baglanti.Close();

            }
            else MessageBox.Show("Lütfen 11 haneden oluşan bir tc kimlik numarası giriniz!");
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = ""; bunifuMetroTextbox2.Text = ""; bunifuMetroTextbox3.Text = ""; bunifuMetroTextbox4.Text = ""; bunifuMetroTextbox5.Text = "";
            pictureBox1.Image = null;
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
