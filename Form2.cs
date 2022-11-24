using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScraperTest_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            View_Data();
        }

        private void View_Data()
        {
            var names = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\NAMES.txt");
            var ec = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\EC.txt");
            var cas = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\CAS.txt");
            var clas = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\CLASS.txt");
            var images = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\IMAGES.txt");
            var source = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\SOURCE.txt");
            var details = File.ReadAllLines("C:\\Users\\User\\Desktop\\s\\DETAILS.txt");

            dataGridView1.ColumnCount= 8;
            dataGridView1.Columns[0].Name = "INDEX";
            dataGridView1.Columns[1].Name = "NAME";
            dataGridView1.Columns[2].Name = "EC";
            dataGridView1.Columns[3].Name = "CAS";
            dataGridView1.Columns[4].Name = "CLASS";
            dataGridView1.Columns[5].Name = "IMAGES";
            dataGridView1.Columns[6].Name = "SOURCE";
            dataGridView1.Columns[7].Name = "DETAILS";


            //MessageBox.Show(names.Length.ToString());
            dataGridView1.RowCount= names.Length;   

            for (int i = 0; i < names.Length; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i+1).ToString();
                dataGridView1.Rows[i].Cells[1].Value = names[i];
                dataGridView1.Rows[i].Cells[2].Value = ec[i];
                dataGridView1.Rows[i].Cells[3].Value = cas[i];
                dataGridView1.Rows[i].Cells[4].Value = clas[i];
                dataGridView1.Rows[i].Cells[5].Value = images[i];
                dataGridView1.Rows[i].Cells[6].Value = source[i];
                dataGridView1.Rows[i].Cells[7].Value = details[i];
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn c in dataGridView1.Columns) dt.Columns.Add(c.Name);  
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in r.Cells) dr[cell.ColumnIndex] = cell.Value;
                dt.Rows.Add(dr);    
            }
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM ECHA", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);
            
            bk.DestinationTableName = "dbo.ECHA";

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                bk.WriteToServer(dt);
                MessageBox.Show("DONE !");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conn.Close();
            bk.Close();
        }

        //string s = c.Attributes["title"].Value.Trim().ToLower() + ".png";

    }
}
