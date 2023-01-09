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
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=ogrencikayit; user ID=postgres; password=7332");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into ogrenci values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBoxId.Text));
            komut.Parameters.AddWithValue("@p2", textBoxAd.Text);
            komut.Parameters.AddWithValue("@p3", textBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p4", textBoxDers.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(textBoxAkts.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBoxNot.Text));
            komut.Parameters.AddWithValue("@p7", textBoxHarf.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt tamamlandı.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
