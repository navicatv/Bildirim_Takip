using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgi_Takip
{
    public partial class BildirimEkle : Form
    {

        OleDbConnection con;
        OleDbCommand cmd;
        public BildirimEkle()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Bildirimler (TbsKod,Tarih,BildirimTipi,Musteri,IslemSonucu,Notlar) values ('" + txtTbs.Text + "','" + txtTarih.Text + "','" + txtBildirim.Text + "','" + txtMusteri.Text + "','" + txtislemsonucu.Text + "','" + txtnotlar.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                temizle();
                MessageBox.Show("Kayıt Eklendi");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sorun var..." + ex.Message);
            }
            
        
        }

        public void temizle()
        {
            txtBildirim.Text = "";

        }
        
        private void BildirimEkle_Load(object sender, EventArgs e)
        {
           
         }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");
            OleDbCommand cmd = new OleDbCommand("Select TbsKod, Tarih, BildirimTipi, Musteri, IslemSonucu, Notlar from Bildirimler where TbsKod='" + txtTbs.Text+"'", con);
            con.Open();
            OleDbDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                txtTbs.Text = dr["TbsKod"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtBildirim.Text = dr["BildirimTipi"].ToString();
                txtMusteri.Text = dr["Musteri"].ToString();
                txtislemsonucu.Text = dr["IslemSonucu"].ToString();
                txtnotlar.Text = dr["Notlar"].ToString();

                //Or
                //textBox1.Text = dr.GetString(0);

            }
            con.Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {


            con = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=bilgi_takip.mdb");
            OleDbCommand oledbcommand = new OleDbCommand();
            oledbcommand.CommandText = "update Bildirimler set TbsKod='" + txtnotlar.Text + "', Tarih='" + txtTarih.Text + "', BildirimTipi='"+txtBildirim.Text+ "', Musteri='" + txtMusteri.Text + "', IslemSonucu='" + txtislemsonucu.Text + "',  Notlar='" + txtnotlar.Text+"'  where TbsKod ='" + txtTbs.Text+"'";


            con.Open();
            oledbcommand.Connection = con;
            oledbcommand.ExecuteNonQuery();
            MessageBox.Show("Veriler Güncellendi",  "Bilgilendirme Mesajı");
            con.Close();

        }
    }
}
 