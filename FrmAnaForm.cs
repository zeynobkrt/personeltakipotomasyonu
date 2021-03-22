using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace personelkayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QGM91UK;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        void temizle()
        {
            TxtPerid.Text = "";
            TxtPerAd.Text = "";
            TxtPerSoyad.Text = "";
            CmbPerSehir.Text = "";
            MskPerMaas.Text = "";
            TxtPerMeslek.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtPerAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.table_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Table_Personel);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.table_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Table_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerMedeniDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPerSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbPerSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskPerMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtPerMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPerid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPerAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPerSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbPerSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskPerMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtPerMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Table_Personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", TxtPerid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bağlantı Silindi");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Table_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerMedeniDurum=@a5, PerMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", TxtPerAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtPerSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbPerSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", MskPerMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtPerMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", TxtPerid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
