using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace derskayıtotomasyonu
{
    public partial class Guncelle : Form
    {
        public Guncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=ogrencikayit; user ID=postgres; password=7332");

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("select * from ogrenci where id::text like '" + textBoxId.Text + "'", baglanti);
            NpgsqlDataReader reader = komut2.ExecuteReader();

            while (reader.Read())
            {

                textBoxAd.Text = reader[1].ToString();
                textBoxSoyad.Text = reader[2].ToString();
                textBoxDers.Text = reader[3].ToString();
                textBoxAkts.Text = reader[4].ToString();
                textBoxNot.Text = reader[5].ToString();
                textBoxHarf.Text = reader[6].ToString();

            }
            baglanti.Close();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update ogrenci set \"adi\" = @p1, \"soyad\"=@p2, \"dersAdi\"=@p3, \"not\"=@p4, \"akts\"=@p5, \"harfNotu\"=@p6 where \"id\"=@p7", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBoxAd.Text);
            komut3.Parameters.AddWithValue("@p2", textBoxSoyad.Text);
            komut3.Parameters.AddWithValue("@p3", textBoxDers.Text);
            komut3.Parameters.AddWithValue("@p5", int.Parse(textBoxAkts.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBoxNot.Text));
            komut3.Parameters.AddWithValue("@p6", textBoxHarf.Text);
            komut3.Parameters.AddWithValue("@p7", int.Parse(textBoxId.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("güncelleme başarılı bir şekilde tamamlandı.");
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
