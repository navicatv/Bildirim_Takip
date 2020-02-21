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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // griddoldur();
        }

        private void tbsListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liste liste = new Liste();
            liste.MdiParent = this;
            liste.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu özel yazılım Alışan Lojistik Ar-Ge Ekibi tarafından geliştirilmiştir.");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OleDbConnection con;
        //OleDbDataAdapter da;
        //OleDbCommand cmd;
        //DataSet ds;

        
        //void griddoldur()
        //{
        //    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");
        //    da = new OleDbDataAdapter("Select *from Bildirimler", con);
        //    ds = new DataSet();
        //    con.Open();
        //    da.Fill(ds, "Bildirimler");
        //    dataGridView1.DataSource = ds.Tables["Bildirimler"];
        //    con.Close();
        //}
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bildirimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BildirimEkle ekle = new BildirimEkle();
            ekle.MdiParent = this;
            ekle.Show();
        }
    }
}
