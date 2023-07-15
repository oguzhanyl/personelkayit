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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KK1AS77\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            Txtid.Text= string.Empty;
            Txtad.Text = string.Empty;
            Txtsoyad.Text = string.Empty;
            Txtmeslek.Text = string.Empty;
            Cmbsehir.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Mtbmaas.Text = string.Empty;
            Txtad.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.personelVeriTabaniDataSet.Table_1);
            label8.Visible = true;
        }

        private void Btnlistele_Click(object sender, EventArgs e)
        {
            this.table_1TableAdapter.Fill(this.personelVeriTabaniDataSet.Table_1);
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand ("insert into Table_1 (PerAd, PerSoyad, PerSehir, PerMaas, PerMeslek, PerDurum) values (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", Cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", Mtbmaas.Text);
            komut.Parameters.AddWithValue("@p5", Txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kaydedildi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label8.Text == "False")
            {
                radioButton1.Checked = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton2.Checked = true;
            }
        }
        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "False")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "True")
            {
                radioButton2.Checked = true;
            }
        }
        private void Btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Mtbmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        

        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Table_1 Where PerId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kaydı silindi.");
        }

        private void Btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Table_1 Set Perad=@k1, PerSoyad =@k2, PerSehir =@k3, PerMaas =@k4, PerDurum = @k5, PerMeslek =@k6 where PerId =@k7", baglanti);
            komutguncelle.Parameters.AddWithValue("@k1", Txtad.Text);
            komutguncelle.Parameters.AddWithValue("@k2", Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@k3", Cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@k4", Mtbmaas.Text);
            komutguncelle.Parameters.AddWithValue("@k5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@k6", Txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@k7", Txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kaydı güncellenmiştir.");
        }

        private void Btnistatisik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void Btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnRapor_Click(object sender, EventArgs e)
        {
            FrmRaporlar frr = new FrmRaporlar();
            frr.Show();
        }
    }
}
