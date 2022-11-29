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
                    if (v[j] == null || v[j] == "") v[j] = "NULL";
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
            SqlCommand cmd = new SqlCommand("DELETE FROM XLSINVENTORY", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "dbo.XLSINVENTORY";

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

        private void IdStBtn_Click(object sender, EventArgs e)
        {
            DataTable dt= new DataTable();

            dt.Columns.Add("CHEMID");
            dt.Columns.Add("HSTATEMENT");

            foreach (DataGridViewRow dr in ExcelGridView.Rows)
            {
                string[] h1, h2, h3;
                if (dr.Cells[0].Value is not null)
                {
                    h1 = (dr.Cells[6].Value.ToString()).Split("|");
                    h2 = (dr.Cells[8].Value.ToString()).Split("|");
                    h3 = (dr.Cells[9].Value.ToString()).Split("|");
                }
                else
                {
                    h1 = new string[] { "NULL" };
                    h2 = new string[] { "NULL" };
                    h3 = new string[] { "NULL" };
                }

                foreach (string h in h1)
                {
                    if (h != "NULL")
                    {
                        dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                        //MessageBox.Show(dr.Cells[0].Value.ToString() + "  " + h);
                    }
                }
                foreach (string h in h2)
                {
                    if (h != "NULL")
                    {
                        dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                        //MessageBox.Show(dr.Cells[0].Value.ToString() + "  " + h);
                    }
                }
                foreach (string h in h3)
                {
                    if (h != "NULL")
                    {
                        dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                        //MessageBox.Show(dr.Cells[0].Value.ToString() + "  " + h);
                    }
                }
            }

            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM XLSIDSTM", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "dbo.XLSIDSTM";

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

        private void IdImgBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CHEMID");
            dt.Columns.Add("IMAGE");

            foreach (DataGridViewRow dr in ExcelGridView.Rows)
            {
                string[] h1;
                if (dr.Cells[0].Value is not null)
                {
                    h1 = (dr.Cells[7].Value.ToString()).Split("|");                 
                }
                else
                {
                    h1 = new string[] { "NULL" };
                }

                foreach (string h in h1)
                {
                    if (h != "NULL")
                    {
                        dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                        //MessageBox.Show(dr.Cells[0].Value.ToString() + "  " + h);
                    }
                }                
            }

            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM XLSIDIMG", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "dbo.XLSIDIMG";

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

        private void IdClasBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CHEMID");
            dt.Columns.Add("CLAS");

            foreach (DataGridViewRow dr in ExcelGridView.Rows)
            {
                string[] h1;
                if (dr.Cells[0].Value is not null)
                {
                    h1 = (dr.Cells[5].Value.ToString()).Split("|");
                }
                else
                {
                    h1 = new string[] { "NULL" };
                }

                foreach (string h in h1)
                {
                    if (h != "NULL")
                    {
                        dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                        //MessageBox.Show(dr.Cells[0].Value.ToString() + "  " + h);
                    }
                }
            }

            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM XLSIDCLS", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "dbo.XLSIDCLS";

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
