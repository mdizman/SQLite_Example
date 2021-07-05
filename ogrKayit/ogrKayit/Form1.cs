using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace ogrKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string yol = "Data source=dbornek.db";
            SQLiteConnection baglanti = new SQLiteConnection(yol);
            baglanti.Open();

            string sql = "insert into tblOgrenciler(TcNo,AdSoyad,SinifAd,BolumAd,Tarih) values (@TcNo,@AdSoyad,@SinifAd,@BolumAd,@Tarih)";

            SQLiteCommand komutIslet = new SQLiteCommand(sql, baglanti);
            komutIslet.Parameters.AddWithValue("@TcNo", txtTC.Text);
            komutIslet.Parameters.AddWithValue("@AdSoyad", txtAD.Text);
            komutIslet.Parameters.AddWithValue("@SinifAd", cmbSınıf.Text);
            komutIslet.Parameters.AddWithValue("@BolumAd", cmnBlm.Text);
            komutIslet.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToString());

            

            komutIslet.ExecuteNonQuery();
            baglanti.Close();
            komutIslet.Dispose();
            MessageBox.Show("Kayıt başarıyla gerçekleşti");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
