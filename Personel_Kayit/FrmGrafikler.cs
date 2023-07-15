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

namespace Personel_Kayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KK1AS77\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void chart1_Click(object sender, EventArgs e)
        {
            //grafik 1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir,Count(*) from Table_1 group by Persehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //grafik 2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select permeslek,Avg(Permaas) from Table_1 group by PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
