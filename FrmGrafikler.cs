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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QGM91UK;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //sehirlerde bulunan kişi sayısı
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir, Count(*) From Table_Personel Group By PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //ortalama maaslar
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek, Avg(PerMaas) From Table_Personel Group By PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();

        }
    }
}
