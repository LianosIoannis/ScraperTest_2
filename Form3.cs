using ExcelDataReader;
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
        DataSet excelDataSet;
        public Form3(DataSet ds)
        {
            InitializeComponent();
            excelDataSet = ds;
            ViewData1();
        }

        private void ViewData1() 
        { 
            DataTable showDt = new DataTable();
            showDt.Columns.Add("XLID");
            showDt.Columns.Add("INDEXNO");
            showDt.Columns.Add("NAME");
            showDt.Columns.Add("EC");
            showDt.Columns.Add("CAS");
            showDt.Columns.Add("CLASS");
            showDt.Columns.Add("HSTATEMENT1");
            showDt.Columns.Add("IMAGES");
            showDt.Columns.Add("HSTATEMENT2");
            showDt.Columns.Add("SHSTATEMENT");
            showDt.Columns.Add("LIMITS");
            showDt.Columns.Add("NOTES");
            showDt.Columns.Add("ATP");

            DataTable excelDt = excelDataSet.Tables[0];
            

            int count = -5;

            foreach(DataRow dr in excelDt.Rows)
            {
                string[] cell= new string[excelDt.Columns.Count + 1];

                cell[0] = count.ToString(); //XLID

                cell[1] = dr.ItemArray.GetValue(0).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// INDEXNO

                cell[2] = dr.ItemArray.GetValue(1).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// NAME

                cell[3] = dr.ItemArray.GetValue(2).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// EC
                if (cell[3] == "" || cell[3] == "-") cell[3] = "NULL";

                cell[4] = dr.ItemArray.GetValue(3).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// CAS
                if (cell[4] == "" || cell[4] == "-") cell[4] = "NULL";



                string[] temp = dr.ItemArray.GetValue(4).ToString().ReplaceLineEndings().Split(Environment.NewLine);
                foreach(string tmp in temp)
                {
                    string add = tmp.Trim();
                    if (add == "") add = "NULL";
                    cell[5] += add + "|";
                }
                cell[5] = cell[5].Remove(cell[5].Length-1);// CLAS
                


                temp = dr.ItemArray.GetValue(5).ToString().ReplaceLineEndings().Split(Environment.NewLine);
                foreach (string tmp in temp)
                {
                    string add = tmp.Trim();
                    if (add == "") add = "NULL";
                    cell[6] += add + "|";
                }
                cell[6] = cell[6].Remove(cell[6].Length - 1);// GHS


                temp = dr.ItemArray.GetValue(6).ToString().ReplaceLineEndings().Split(Environment.NewLine);
                foreach (string tmp in temp)
                {
                    string add = tmp.Trim().ToLower();
                    if (add == "") add = "NULL";
                    cell[7] += add + "|";
                }
                cell[7] = cell[7].Remove(cell[7].Length - 1);// IMAGES


                temp = dr.ItemArray.GetValue(7).ToString().ReplaceLineEndings().Split(Environment.NewLine);
                foreach (string tmp in temp)
                {
                    string add = tmp.Trim();
                    if (add == "") add = "NULL";
                    cell[8] += add + "|";
                }
                cell[8] = cell[8].Remove(cell[8].Length - 1);// LHS

                cell[9] = dr.ItemArray.GetValue(8).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// SHS
                if (cell[9] == "" || cell[9] == "-") cell[9] = "NULL";


                temp = dr.ItemArray.GetValue(9).ToString().ReplaceLineEndings().Split(Environment.NewLine);
                foreach (string tmp in temp)
                {
                    string add = tmp.Trim();
                    if (add == "") add = "NULL";
                    cell[10] += add + "|";
                }
                cell[10] = cell[10].Remove(cell[10].Length - 1);// LIMITS

                cell[11] = dr.ItemArray.GetValue(10).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// NOTES
                if (cell[11] == "" || cell[11] == "-") cell[11] = "NULL";


                cell[12] = dr.ItemArray.GetValue(11).ToString().ReplaceLineEndings().Replace(Environment.NewLine, "").Trim();// ATP
                if (cell[12] == "" || cell[12] == "-") cell[12] = "NULL";


                if (count >= 1)showDt.Rows.Add(cell);

                count++;
            }
            ExcelGridView.DataSource = showDt;
            
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

            
            for (int i = 6; i < excelDataSet.Tables[0].Rows.Count; i++)
            {
                string[] v = new string[excelDataSet.Tables[0].Rows[i].ItemArray.Length + 1];
                v[0] = (i-5).ToString();

                for (int j = 1; j < v.Length; j++)
                {
                    string[] temp = excelDataSet.Tables[0].Rows[i].ItemArray.ElementAt(j - 1).ToString().Trim().ReplaceLineEndings().Split(Environment.NewLine);
                    
                    foreach (string t in temp)
                    {
                        //MessageBox.Show(t);
                        if (j == 7) v[j] += t.ToLower().Trim() + "|";
                        else if (j == 5) v[j] += String.Concat(t.Where(c => !Char.IsWhiteSpace(c))) + "|";
                        else v[j] += t + "|";
                    }
                    v[j] = v[j].Remove(v[j].Length-1);
                    if (v[j] == null || v[j] == "") v[j] = "NULL";
                }

                ds.Tables[0].Rows.Add(v);
            }

            //for (int i = 0; i < 7; i++) dataSet.Tables[0].Rows.RemoveAt(i);
            ExcelGridView.DataSource = ds.Tables[0];

        }

        private void AddGridToDbBtn_Click(object sender, EventArgs e)
        {
            //string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //DataTable dt = new DataTable();

            //foreach (DataGridViewColumn c in ExcelGridView.Columns) dt.Columns.Add(c.Name);
            //foreach (DataGridViewRow r in ExcelGridView.Rows)
            //{
            //    DataRow dr = dt.NewRow();
            //    foreach (DataGridViewCell cell in r.Cells) dr[cell.ColumnIndex] = cell.Value;
            //    dt.Rows.Add(dr);
            //}

            DataTable test = (DataTable)ExcelGridView.DataSource;
            DTtoTable(test, "cccXLSchemicals");
            MessageBox.Show("DONE !");
            //SqlConnection conn = new SqlConnection(cstr);
            //SqlCommand cmd = new SqlCommand("DELETE FROM XLSINVENTORY", conn);
            //SqlBulkCopy bk = new SqlBulkCopy(conn);

            //bk.DestinationTableName = "dbo.XLSINVENTORY";

            //conn.Open();
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    bk.WriteToServer(dt);
            //    MessageBox.Show("DONE !");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //conn.Close();
            //bk.Close();

        }

        private void IdStBtn_Click(object sender, EventArgs e)
        {
            ghsPerChem();
            lhsPerChem();   
            shsPerChem();
            MessageBox.Show("DONE !");
            /*DataTable dt= new DataTable();

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
            bk.Close();*/
        }

        private void IdImgBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CHEMID");
            dt.Columns.Add("IMAGE");

            foreach (DataGridViewRow dr in ExcelGridView.Rows)
            {
                string[] h1;
                if (dr.Cells[0].Value is not null) h1 = (dr.Cells[7].Value.ToString()).Split("|");
                else h1 = new string[] { "NULL" };

                foreach (string h in h1)
                {
                    if (h != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
                }                
            }

            DTtoTable(dt, "cccImagePerChem");
            MessageBox.Show("DONE !");
        }

        private void IdClasBtn_Click(object sender, EventArgs e)
        {
            buildTablefrom(5, "cccClasPerChem", new string[] { "CHEMID", "CLAS" });

            //DataTable dt = new DataTable();

            //dt.Columns.Add("CHEMID");
            //dt.Columns.Add("CLAS");

            //foreach (DataGridViewRow dr in ExcelGridView.Rows)
            //{
            //    string[] h1;
            //    if (dr.Cells[0].Value is not null) h1 = (dr.Cells[5].Value.ToString()).Split("|");
            //    else h1 = new string[] { "NULL" };


            //    foreach (string h in h1)
            //    {
            //        if (h != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
            //    }
            //}

            //DTtoTable(dt, "cccClasPerChem");
            MessageBox.Show("DONE !");
        }

        private void IdLimitsBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CHEMID");
            dt.Columns.Add("LIMITS");

            foreach (DataGridViewRow dr in ExcelGridView.Rows)
            {
                string h1;
                if (dr.Cells[0].Value is not null) h1 = dr.Cells[10].Value.ToString().Trim();
                else h1 = "NULL";
                if (h1 != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h1 });
            }

            DTtoTable(dt, "cccLimitsPerChem");
            MessageBox.Show("DONE !");
        }

        private void ghsPerChem()
        {
            buildTablefrom(6, "cccGHSPerChem", new string[] { "CHEMID", "GHS" });

            //DataTable dt = new DataTable();
            //dt.Columns.Add("CHEMID");
            //dt.Columns.Add("GHS");

            //string[] hs;
            //foreach (DataGridViewRow dr in ExcelGridView.Rows)
            //{
            //    if (dr.Cells[0].Value is not null) hs = (dr.Cells[6].Value.ToString()).Split("|");
            //    else hs = new string[] { "NULL" };

            //    foreach (string h in hs)
            //    {
            //        if (h != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
            //    }
            //}

            //DTtoTable(dt, "cccGHSPerChem");

        }
        private void lhsPerChem()
        {
            buildTablefrom(9, "cccLHSPerChem", new string[] { "CHEMID", "LHS" });

            //DataTable dt = new DataTable();
            //dt.Columns.Add("CHEMID");
            //dt.Columns.Add("LHS");

            //string[] hs;
            //foreach (DataGridViewRow dr in ExcelGridView.Rows)
            //{
            //    if (dr.Cells[0].Value is not null) hs = (dr.Cells[8].Value.ToString()).Split("|");
            //    else hs = new string[] { "NULL" };

            //    foreach (string h in hs)
            //    {
            //        if (h != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
            //    }
            //}

            //DTtoTable(dt, "cccLHSPerChem");
        }
        private void shsPerChem()
        {
            buildTablefrom(9, "cccSHSPerChem",new string[]{ "CHEMID", "SHS" });

            //DataTable dt = new DataTable();
            //dt.Columns.Add("CHEMID");
            //dt.Columns.Add("SHS");

            //string[] hs;
            //foreach (DataGridViewRow dr in ExcelGridView.Rows)
            //{
            //    if (dr.Cells[0].Value is not null) hs = (dr.Cells[9].Value.ToString()).Split("|");
            //    else hs = new string[] { "NULL" };

            //    foreach (string h in hs)
            //    {
            //        if (h != "NULL") dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), h });
            //    }
            //}

            //DTtoTable(dt, "cccSHSPerChem");
        }

        private void buildTablefrom(int cell, string tbname, string[] columns)
        {
            DataTable dt = new DataTable();
            foreach(var col in columns) dt.Columns.Add(col);

            foreach(DataGridViewRow dr in ExcelGridView.Rows)
            {
                string[] str = dr.Cells[cell].Value.ToString().Split("|");
                foreach(var s in str) dt.Rows.Add(new string[] { dr.Cells[0].Value.ToString(), s });
            }
            DTtoTable(dt, tbname);
        }

        private void DTtoTable(DataTable dt, string tbName)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            SqlCommand cmd = new SqlCommand("DELETE FROM [" + tbName + "]", conn);
            SqlBulkCopy bk = new SqlBulkCopy(conn);

            bk.DestinationTableName = "[" + tbName + "]";

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                bk.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conn.Close();
            bk.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string xlpath = "C:\\Users\\User\\Desktop\\Hphrases.xlsx";
            var stream = File.Open(xlpath, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);


            var result = reader.AsDataSet();
            DataTable dt = new DataTable();
            excelDataSet.Tables[0].Columns[0].ColumnName = "HCODE";
            excelDataSet.Tables[0].Columns[0].ColumnName = "GRPHRASE";
            excelDataSet.Tables[0].Columns[0].ColumnName = "ENPHRASE";

            dt = result.Tables[0];

            DTtoTable(dt, "cccPhrasePerH");
            
            stream.Dispose();
            reader.Dispose();
            MessageBox.Show("DONE !");
        }
    }
}
