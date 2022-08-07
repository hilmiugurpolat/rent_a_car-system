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
    public partial class arac_listeleme : Form
    {
        public arac_listeleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\musteri.accdb");


        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            araclari_listele();
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

        private void araclari_listele()
        {

            try
            {
                baglanti.Open();
                OleDbDataAdapter araclari_listele = new OleDbDataAdapter("select plaka AS[PLAKA],marka AS[MARKA],seri AS[SERİ],model AS[MODEL],renk AS[RENK],km AS[ARAÇ KM],ucret AS[ÜCRET],durumu AS[DURUMU]  from araclar", baglanti);
                DataSet dshafiza = new DataSet();
                araclari_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[7].Width = 150;




            }
            catch (Exception hatamesaji)
            {

                MessageBox.Show(hatamesaji.Message, "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (bunifuMaterialTextbox1.Text != "")
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from araclar where plaka='" + bunifuMaterialTextbox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {

                    kayit_arama_durumu = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\arac.resimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");

                    }
                    catch
                    {

                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\arac.resimler\\resimyok.jpg");
                    }

                    bunifuMaterialTextbox2.Text = kayitokuma.GetValue(1).ToString();
                    bunifuMaterialTextbox3.Text = kayitokuma.GetValue(2).ToString();
                    bunifuMaterialTextbox4.Text = kayitokuma.GetValue(3).ToString();
                    bunifuMaterialTextbox5.Text = kayitokuma.GetValue(4).ToString();
                    bunifuMaterialTextbox6.Text = kayitokuma.GetValue(5).ToString();
                    bunifuMaterialTextbox7.Text = kayitokuma.GetValue(6).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)


                    MessageBox.Show("Aranan kayıt bulunamadı!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();




            }

            else
                MessageBox.Show("Lütfen araç plakasını giriniz!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            baglanti.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
                bunifuCustomLabel1.ForeColor = Color.Red;
            else bunifuCustomLabel1.ForeColor = Color.Black;

            if (bunifuMaterialTextbox2.Text == "")
                bunifuCustomLabel2.ForeColor = Color.Red;
            else
                bunifuCustomLabel2.ForeColor = Color.Black;

            if (bunifuMaterialTextbox3.Text == "")
                bunifuCustomLabel3.ForeColor = Color.Red;
            else bunifuCustomLabel3.ForeColor = Color.Black;

            if (bunifuMaterialTextbox4.Text == "")
                bunifuCustomLabel4.ForeColor = Color.Red;
            else bunifuCustomLabel4.ForeColor = Color.Black;

            if (bunifuMaterialTextbox5.Text == "")
                bunifuCustomLabel5.ForeColor = Color.Red;
            else bunifuCustomLabel5.ForeColor = Color.Black;

            if (bunifuMaterialTextbox6.Text == "")
                bunifuCustomLabel6.ForeColor = Color.Red;
            else bunifuCustomLabel6.ForeColor = Color.Black;

            if (bunifuMaterialTextbox7.Text == "")
                bunifuCustomLabel7.ForeColor = Color.Red;
            else bunifuCustomLabel7.ForeColor = Color.Black;

            if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text != "" && bunifuMaterialTextbox4.Text != "" && bunifuMaterialTextbox5.Text != "" +
                "" && bunifuMaterialTextbox6.Text != "" && bunifuMaterialTextbox7.Text != "")
            {


                try
                {
                    baglanti.Open();
                    OleDbCommand guncelle_komutu = new OleDbCommand("update araclar set marka='" + bunifuMaterialTextbox2.Text + "'" +
                        ",seri='" + bunifuMaterialTextbox3.Text + "',model='" + bunifuMaterialTextbox4.Text + "',renk='" + bunifuMaterialTextbox5.Text
                        + "',km='" + bunifuMaterialTextbox6.Text + "',ucret='" + bunifuMaterialTextbox7.Text + "' where plaka='" + bunifuMaterialTextbox1.Text + "'", baglanti);
                    guncelle_komutu.ExecuteReader();

                    baglanti.Close();

                    MessageBox.Show("Araç  bilgileri güncellendi", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    araclari_listele();
                }
                catch (Exception hatamesaj)
                {

                    MessageBox.Show(hatamesaj.Message);
                    baglanti.Close();
                }
            }

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text!= "")
            {

                bool kayit_arama_durumu = false;
                baglanti.Open();
                OleDbCommand select_sorgu = new OleDbCommand("select * from araclar where plaka='" + bunifuMaterialTextbox1.Text + "'", baglanti);
                OleDbDataReader kayit_okuma = select_sorgu.ExecuteReader();

                while (kayit_okuma.Read())
                {

                    kayit_arama_durumu = true;
                    OleDbCommand delete = new OleDbCommand("delete from araclar where plaka='" + bunifuMaterialTextbox1.Text + "'", baglanti);
                    delete.ExecuteReader();
                    MessageBox.Show("Araç bilgileri silindi", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    araclari_listele();
                    bunifuMaterialTextbox1.Text = ""; bunifuMaterialTextbox2.Text = ""; bunifuMaterialTextbox3.Text = ""; bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = ""; bunifuMaterialTextbox6.Text = ""; bunifuMaterialTextbox7.Text = "";
                    pictureBox1.Image = null;
                    break;
                }

                if (kayit_arama_durumu == false)
                {

                    MessageBox.Show("Silinecek kayıt bulunamadı.", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMaterialTextbox1.Text = ""; bunifuMaterialTextbox2.Text = ""; bunifuMaterialTextbox3.Text = ""; bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = ""; bunifuMaterialTextbox6.Text = ""; bunifuMaterialTextbox7.Text = "";
                    pictureBox1.Image = null;
                    
                }
                baglanti.Close();
            }

            else MessageBox.Show("Lütfen plaka giriniz!");
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = ""; bunifuMaterialTextbox2.Text = ""; bunifuMaterialTextbox3.Text = ""; bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox5.Text = ""; bunifuMaterialTextbox6.Text = ""; bunifuMaterialTextbox7.Text = "";
            pictureBox1.Image = null;
        }
    }
}
