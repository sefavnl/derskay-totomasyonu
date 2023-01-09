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
    public partial class Ders : Form
    {
        public Ders()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=ogrencikayit; user ID=postgres; password=7332");
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("insert into ders values (@p1, @p2, @p3, @p4, @p5)", baglanti);
            komut4.Parameters.AddWithValue("@p1", textBoxDers.Text);
            komut4.Parameters.AddWithValue("@p2", int.Parse(textBoxAkts.Text));
            komut4.Parameters.AddWithValue("@p3", int.Parse(textBoxNot.Text));
            komut4.Parameters.AddWithValue("@p4", textBoxOgrenim.Text);
            komut4.Parameters.AddWithValue("@p5", textBoxHarf.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders Eklendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("delete from ders where \"dersAdi\" = @p1", baglanti);
            komut5.Parameters.AddWithValue("@p1", textBox4.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("silme işelmi başarılı bir şekilde gerçekleşmiştir.");
        }
    }
}
