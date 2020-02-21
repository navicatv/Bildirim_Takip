using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Bilgi_Takip
{
    public partial class Liste : Form
    {
        
        private MySqlConnection conn;
        private OleDbConnectionStringBuilder sb;
        private OleDbConnection con;
        private OleDbDataAdapter da;
        private DataSet ds;

        public Liste()
        {
            InitializeComponent();
            //Load grid
            Yenile();
        }

        public void Yenile()
        {
            sb = new OleDbConnectionStringBuilder();
            sb.Provider = "Microsoft.Jet.OLEDB.4.0";
            sb.DataSource = Path.Combine(Environment.CurrentDirectory, "", "Bilgi_Takip.mdb");
            conn = new OleDbConnection(sb.ConnectionString);
            dataGridView1.DataSource = FillTable("SELECT * FROM Bildirimler");
        }

        bool drag = false;
        Point start_point = new Point(0, 0);
        private void Liste_Load(object sender, EventArgs e)
        {
         
        }
        private void panel_header_MouseDown(Object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }
        private void panel_header_MouseMove(Object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel_header_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private DataTable FillTable(String sql)
        {
            DataTable table = new DataTable();
            using (OleDbDataAdapter da = new OleDbDataAdapter(sql, conn))
            {
                da.Fill(table);
            }
            return table;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");
            da = new OleDbDataAdapter("Select * from Bildirimler where Tbskod like '" + txtAra.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Bildirimler");
            dataGridView1.DataSource = ds.Tables["Bildirimler"];
            con.Close();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btndelete")
            {
                
                    

                id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                OleDbCommand cmd = new OleDbCommand();
                
                cmd.CommandText = @"delete from Bildirimler where Id=" + id;
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted.");
                Yenile();
                
            }
            
        }

       
        private void btnekle1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Bilgi_Takip.mdb");
            //con.Open();
        }
    }
}
