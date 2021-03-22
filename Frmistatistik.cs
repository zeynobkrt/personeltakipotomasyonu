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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QGM91UK;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        private void Frmistatistik2_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Table_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPer.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Table_Personel where PerMedeniDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPer.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Table_Personel where PerMedeniDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPer.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //sehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct (PerSehir)) From Table_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSay.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Table_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblTopMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Table_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
