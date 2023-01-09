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
    public partial class DersGuncelle : Form
    {
        public DersGuncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=ogrencikayit; user ID=postgres; password=7332");
        private void textBoxDers_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("select * from ders where \"dersAdi\" like '" + textBoxDers.Text + "'", baglanti);
            NpgsqlDataReader reader = komut2.ExecuteReader();

            while (reader.Read())
            {

                textBoxAkts.Text = reader[1].ToString();
                textBoxNotu.Text = reader[2].ToString();
                textBoxOgrenim.Text = reader[3].ToString();
                textBoxHarf.Text = reader[4].ToString();
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update ders set \"akts\" = @p1, \"notu\"=@p2, \"ogrenimUyesi\"=@p3, \"harfNotu\"=@p4 where \"dersAdi\"=@p5", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBoxAkts.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBoxNotu.Text));
            komut3.Parameters.AddWithValue("@p3", textBoxOgrenim.Text);
            komut3.Parameters.AddWithValue("@p4", textBoxHarf.Text);
            komut3.Parameters.AddWithValue("@p5", textBoxDers.Text);
            komut3.ExecuteNonQuery();
            MessageBox.Show("güncelleme başarılı bir şekilde tamamlandı.");
            baglanti.Close();
        }
    }
}
