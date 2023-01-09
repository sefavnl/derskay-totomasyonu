using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derskayıtotomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            this.Hide();
            guncelle.Show();
        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            kayıt Kayıt = new kayıt();
            this.Hide();
            Kayıt.Show();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=ogrencikayit; user ID=postgres; password=7332");
        private void btnGoster_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ogrenci";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ders = "select * from ders";
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(ders, baglanti);
            DataSet set = new DataSet();
            data.Fill(set);
            dataGridView2.DataSource = set.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ders ders = new Ders();
            this.Hide();
            ders.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersGuncelle dersguncelle = new DersGuncelle();
            this.Hide();
            dersguncelle.Show();
        }
    }
}
