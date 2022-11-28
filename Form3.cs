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
    public partial class Form3 : Form
    {
        DataSet dataSet;
        public Form3(DataSet ds)
        {
            InitializeComponent();
            this.dataSet = ds;
            ViewData();
        }

        private void ViewData()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());

            ds.Tables[0].Columns.Add("XLID");
            ds.Tables[0].Columns.Add("INDEXNO");
            ds.Tables[0].Columns.Add("NAME");
            ds.Tables[0].Columns.Add("EC");
            ds.Tables[0].Columns.Add("CAS");
            ds.Tables[0].Columns.Add("CLASS");
            ds.Tables[0].Columns.Add("HSTATEMENT1");
            ds.Tables[0].Columns.Add("IMAGES");
            ds.Tables[0].Columns.Add("HSTATEMENT2");
            ds.Tables[0].Columns.Add("SHSTATEMENT");
            ds.Tables[0].Columns.Add("LIMITS");
            ds.Tables[0].Columns.Add("NOTES");
            ds.Tables[0].Columns.Add("ATP");

            
            for (int i = 6; i < dataSet.Tables[0].Rows.Count; i++)
            {
                string[] v = new string[dataSet.Tables[0].Rows[i].ItemArray.Length + 1];
                v[0] = (i-5).ToString();

                for (int j = 1; j < v.Length; j++)
                {
                    string[] temp = dataSet.Tables[0].Rows[i].ItemArray.ElementAt(j - 1).ToString().Trim().ReplaceLineEndings().Split(Environment.NewLine);
                    
                    foreach (string t in temp)
                    {
                        if (j == 7) v[j] += t.ToLower().Trim() + "|";
                        else if (j == 5) v[j] += String.Concat(t.Where(c => !Char.IsWhiteSpace(c))) + "|";
                        else v[j] += t + "|";
                    }
                    v[j] = v[j].Remove(v[j].Length-1);
                    if (v[j] == "") v[j] = "NULL";
                }

                ds.Tables[0].Rows.Add(v);
            }

            for (int i = 0; i < 7; i++) dataSet.Tables[0].Rows.RemoveAt(i);
            ExcelGridView.DataSource = ds.Tables[0];

        }

        private void AddGridToDbBtn_Click(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn c in ExcelGridView.Columns) dt.Columns.Add(c.Name);
            foreach (DataGridViewRow r in ExcelGridView.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in r.Cells) dr[cell.ColumnIndex] = cell.Value;
                dt.Rows.Add(dr);
            }
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM XLINVENTORY", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "dbo.XLINVENTORY";

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                bk.WriteToServer(dt);
                MessageBox.Show("DONE !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conn.Close();
            bk.Close();

        }
    }
}
