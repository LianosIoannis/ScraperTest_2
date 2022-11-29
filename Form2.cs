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
        //BackgroundWorker bgw = new BackgroundWorker();
        string folder = "C:\\Users\\User\\Desktop\\IMAGES\\s";
        public Form2()
        {
            InitializeComponent();
            //bgw.DoWork += new DoWorkEventHandler(View_Data);
            //bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(data_loaded);
            //bgw.RunWorkerAsync();
            View_Data();
        }

        private void View_Data()
        {
            var names = File.ReadAllLines(folder + "\\NAMES.txt");
            var ec = File.ReadAllLines(folder + "\\EC.txt");
            var cas = File.ReadAllLines(folder + "\\CAS.txt");
            var clas = File.ReadAllLines(folder + "\\CLASS.txt");
            var images = File.ReadAllLines(folder + "\\IMAGES.txt");
            var source = File.ReadAllLines(folder + "\\SOURCE.txt");
            var details = File.ReadAllLines(folder + "\\DETAILS.txt");
            
            CLGridView.ColumnCount= 8;
            CLGridView.Columns[0].Name = "ECHAID";
            CLGridView.Columns[1].Name = "NAME";
            CLGridView.Columns[2].Name = "EC";
            CLGridView.Columns[3].Name = "CAS";
            CLGridView.Columns[4].Name = "CLASS";
            CLGridView.Columns[5].Name = "IMAGES";
            CLGridView.Columns[6].Name = "SOURCE";
            CLGridView.Columns[7].Name = "DETAILS";


            //MessageBox.Show(names.Length.ToString());
            CLGridView.RowCount = new[] {names.Length, ec.Length, cas.Length, clas.Length, images.Length, source.Length, details.Length}.Max();   

            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                CLGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                string cell;
                if (i >= names.Length) cell = "NULL";
                else if (names[i] == "") cell = "NULL";
                else cell = names[i];
                CLGridView.Rows[i].Cells[1].Value = cell;
            }
            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= ec.Length) cell = "NULL";
                else if (ec[i] == "") cell = "NULL";
                else cell = ec[i];
                CLGridView.Rows[i].Cells[2].Value = cell;
            }

            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= cas.Length) cell = "NULL";
                else if (cas[i] == "") cell = "NULL";
                else cell = cas[i];
                CLGridView.Rows[i].Cells[3].Value = cell;
            }
            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= clas.Length) cell = "NULL";
                else if (clas[i] == "") cell = "NULL";
                else cell = clas[i];
                CLGridView.Rows[i].Cells[4].Value = cell;
            }
            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= images.Length) cell = "NULL";
                else if (images[i] == "") cell = "NULL";
                else cell = images[i];
                CLGridView.Rows[i].Cells[5].Value = cell;
            }
            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= source.Length) cell = "NULL";
                else if (source[i] == "") cell = "NULL";
                else cell = source[i];
                CLGridView.Rows[i].Cells[6].Value = cell;
            }
            for (int i = 0; i < CLGridView.RowCount; i++)
            {
                string cell;
                if (i >= details.Length) cell = "NULL";
                else if (details[i] == "") cell = "NULL";
                else cell = details[i];
                CLGridView.Rows[i].Cells[7].Value = cell;
            }

        }

        private void data_loaded(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("DATA LOADED SUCCESFULLY !");
        }

        private void AddGridToDbBtn_Click(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn c in CLGridView.Columns) dt.Columns.Add(c.Name);  
            foreach (DataGridViewRow r in CLGridView.Rows)
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
