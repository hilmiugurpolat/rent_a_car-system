using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
namespace projetasarım
{
    public partial class arac_kiralama : Form
    {
        public arac_kiralama()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\musteri.accdb");
        OleDbConnection baglanti2 = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\kiralanan_araclar.accdb");


        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            kiralanan_araclari_listele();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (bunifuMaterialTextbox1.Text != "")
            {

                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from musteriler where Tcno='" + bunifuMaterialTextbox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;


                    bunifuMaterialTextbox2.Text = kayitokuma.GetValue(1).ToString();
                    bunifuMaterialTextbox3.Text = kayitokuma.GetValue(2).ToString();
                    bunifuMaterialTextbox4.Text = kayitokuma.GetValue(3).ToString();
                    bunifuMaterialTextbox5.Text = kayitokuma.GetValue(4).ToString();

                    break;
                }

                if (bunifuMaterialTextbox1.Text.Length == 11)
                {
                    if (kayit_arama_durumu == false)
                        MessageBox.Show("Aranan kayıt bulunamadı!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    baglanti.Close();

                }

                else MessageBox.Show("Lütfen 11 haneli tc kimlik no giriniz!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;

            if (bunifuMaterialTextbox6.Text != "")
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from araclar where plaka='" + bunifuMaterialTextbox6.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;


                    bunifuMaterialTextbox7.Text = kayitokuma.GetValue(1).ToString();
                    bunifuMaterialTextbox8.Text = kayitokuma.GetValue(2).ToString();
                    bunifuMaterialTextbox9.Text = kayitokuma.GetValue(3).ToString();
                    bunifuMaterialTextbox10.Text = kayitokuma.GetValue(4).ToString();
                    bunifuMaterialTextbox11.Text = kayitokuma.GetValue(6).ToString();

                    break;
                }

            }

            else MessageBox.Show("Lütfen araç plakasını giriniz!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            baglanti.Close();

            if (kayit_arama_durumu == false)
                MessageBox.Show("Aranan kayıt bulunamadı!", "ARAÇ TAKİP SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);


            baglanti.Close();
        }

        private void kiralanan_araclari_listele()
        {
            try
            {
                baglanti2.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select tcno AS[TC KİMLİK NO],ad AS[AD],soyad AS[SOYAD],email AS[E-MAİL]," +
                    "telefon AS [TELEFON],plaka AS[PLAKA],marka AS[MARKA],seri AS[SERİ],model AS [MODEL],renk AS[RENK],kira AS[KİRA ÜCRETİ]" +
                    ",kirabaslangic AS [KİRA BAŞLANGIÇ TARİHİ],kirabitis AS [KİRA BİTİŞ TARİHİ],toplamtutar AS[TOPLAM ÖDENECEK TUTAR],durumu AS [ARAÇ DURUMU] from kiralik_araclar where durumu='" + "kiralik" + "'", baglanti2);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti2.Close();

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[7].Width = 150;
                dataGridView1.Columns[8].Width = 150;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[11].Width = 150;
                dataGridView1.Columns[12].Width = 150;
                dataGridView1.Columns[13].Width = 150;
                dataGridView1.Columns[14].Width = 150;

            }
            catch (Exception hatamesaj)
            {

                MessageBox.Show(hatamesaj.Message);
                baglanti2.Close();
            }
        }

        private void bunifuMaterialTextbox11_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox12_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
            int gun2 = gun.Days;
           bunifuMaterialTextbox12.Text = (gun2 * int.Parse(bunifuMaterialTextbox11.Text)).ToString();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti2.Open();
                OleDbCommand ekle_komutu = new OleDbCommand("insert into kiralik_araclar values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox2.Text + "','" + bunifuMaterialTextbox3.Text + "','" + bunifuMaterialTextbox4.Text + "','" + bunifuMaterialTextbox5.Text + "'" +
                    ",'" + bunifuMaterialTextbox6.Text + "','" + bunifuMaterialTextbox7.Text + "','" +  bunifuMaterialTextbox8.Text + "','" + bunifuMaterialTextbox9.Text + "','" + bunifuMaterialTextbox10.Text + "'" +
                    ",'" + bunifuMaterialTextbox11.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + bunifuMaterialTextbox12.Text + "','" + "kiralik" + "')", baglanti2);
                ekle_komutu.ExecuteReader();

                baglanti2.Close();
                kiralanan_araclari_listele();
            }
            catch (Exception hatamesaji)
            {

                MessageBox.Show(hatamesaji.Message);
                baglanti2.Close();

            }
        }
    }
}
