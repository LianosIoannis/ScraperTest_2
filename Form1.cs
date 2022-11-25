using HtmlAgilityPack;
using IronWebScraper;
using IronWebScraper.Urls;
using Kuto;
using System.IO;
using System.Text.RegularExpressions;
using ScrapySharp;
using System.Linq;
using ScrapySharp.Extensions;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace ScraperTest_2
{


    public partial class Form1 : Form
    {

        string url = "https://echa.europa.eu/el/information-on-chemicals/cl-inventory-database?p_p_id=dissclinventory_WAR_dissclinventoryportlet&p_p_lifecycle=0&p_p_state=normal&p_p_mode=view&_dissclinventory_WAR_dissclinventoryportlet_jspPage=%2Fhtml%2Fsearch%2Fsearch.jsp&_dissclinventory_WAR_dissclinventoryportlet_searching=true&_dissclinventory_WAR_dissclinventoryportlet_iterating=true&_dissclinventory_WAR_dissclinventoryportlet_criteriaParam=_dissclinventory_WAR_dissclinventoryportlet_criteriaKeytcZP&_dissclinventory_WAR_dissclinventoryportlet_delta=50&_dissclinventory_WAR_dissclinventoryportlet_orderByCol=&_dissclinventory_WAR_dissclinventoryportlet_orderByType=asc&_dissclinventory_WAR_dissclinventoryportlet_resetCur=false&_dissclinventory_WAR_dissclinventoryportlet_cur=";
        int max = 1;
        public Form1()
        {
            InitializeComponent();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            NamesProgress.Maximum = max * 50;
            EcProgress.Maximum = max * 50;
            CasProgress.Maximum = max * 50;
            ClassProgress.Maximum = max * 50;
            ImagesProgress.Maximum = max * 50;
            SourceProgress.Maximum = max * 50;
            DetailsProgress.Maximum = max * 50;

            NamesProgress.Value = 0;
            EcProgress.Value = 0;
            CasProgress.Value = 0;
            ClassProgress.Value = 0;
            ImagesProgress.Value = 0;
            SourceProgress.Value = 0;
            DetailsProgress.Value = 0;

            NamesText.Text = "...";
            EcText.Text = "...";
            CasText.Text = "...";
            ClassText.Text = "...";
            ImagesText.Text = "...";
            SourceText.Text = "...";
            DetailsText.Text = "...";


            find_Names();
            find_EC();
            find_CAS();
            find_CLASS();
            find_IMAGES();
            find_SOURCE();
            find_DETAILS();

            //Parallel.Invoke(find_Names, find_EC, find_CAS, find_DETAILS, find_CLASS,find_IMAGES, find_DETAILS, find_SOURCE);    
        }  
        
        private void find_Names()
        {
            string new_url;

            for (int i = 0; i < max; i++)
            {
                new_url = url + (i+1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                try
                {
                    StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\NAMES.txt", true);
                    var k = from a in d.DocumentNode.SelectNodes("//a[@class='substanceNameLink']")
                            where a.GetAttributeValue("href") != ""
                            select a;

                    foreach (var cell in k)
                    {
                        //MessageBox.Show(cell.InnerText.Trim());
                        writer.WriteLine(cell.InnerText.Trim());
                        NamesProgress.Value += 1;
                    }

                    writer.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


            //MessageBox.Show("NAMES FOUND !");
            NamesText.Text = "OK";
        }

        private void find_EC()
        {

            string new_url;

            for (int i = 0; i < max; i++)
            {
                new_url = url + (i + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                try
                {
                    foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                    {
                        var a = cell.ChildNodes;
                        var b = a[3];

                        string line = b.InnerText.Trim();
                        //MessageBox.Show(line);

                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\EC.txt", true);
                        writer.Write(line + Environment.NewLine);
                        writer.Close();
                        EcProgress.Value += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
            //MessageBox.Show("EC FOUND !");
            EcText.Text = "OK";

        }

        private void find_CAS()
        {
            string new_url;

            for (int i = 0; i < max; i++)
            {
                new_url = url + (i + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                try
                {
                    foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                    {
                        var a = cell.ChildNodes;
                        var b = a[5];

                        string line = b.InnerText.Trim();
                        //MessageBox.Show(line);

                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\CAS.txt", true);
                        writer.Write(line + Environment.NewLine);
                        writer.Close();
                        CasProgress.Value += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            //MessageBox.Show("CAS FOUND !");
            CasText.Text = "OK";
        }

        private void find_CLASS()
        {
            string new_url;

            for (int j = 0; j < max; j++)
            {
                new_url = url + (j + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                try
                {
                    foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                    {
                        var a = cell.Descendants("span");

                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\CLASS.txt", true);

                        string line = "";
                        int i = 1;
                        foreach (var c in a)
                        {
                            //MessageBox.Show(c.InnerText.Trim());
                            if (c.InnerText.Trim() != "") line += c.InnerText.Trim();
                            if (i != a.Count() && c.InnerText.Trim() != "") line += "|";
                            i++;
                        }
                        if (line == "") line = "NULL";
                        writer.WriteLine(line);
                        writer.Close();
                        ClassProgress.Value += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            //MessageBox.Show("CLASS FOUND !");
            ClassText.Text = "OK";
        }

        private void find_IMAGES()
        {
            string new_url;

            for (int j = 0; j < max; j++)
            {
                new_url = url + (j + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                try
                {
                    foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                    {
                        var k = from c in cell.Descendants("img")
                                where c.GetAttributeValue("title", "") != ""
                                select c;

                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\IMAGES.txt", true);

                        string line = "";
                        int i = 1;
                        foreach (var c in k)
                        {
                            string v = c.GetAttributeValue("title", "").Trim().ToLower();
                            if (v != "")
                            {
                                line += v;
                                if (i != k.Count()) line += "|";
                                i++;
                            }                           
                        }
                        if (line == "") line = "NULL";
                        writer.WriteLine(line);
                        writer.Close();
                        ImagesProgress.Value += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            //MessageBox.Show("IMAGES FOUND !");
            ImagesText.Text = "OK";
        }

        private void find_SOURCE()
        {

            string new_url;

            for (int j = 0; j < max; j++)
            {
                new_url = url + (j + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                var s = d.DocumentNode.SelectNodes("//td[@class='table-cell  text-top']");
                int count = s.ToList().Count();

                StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\SOURCE.txt", true);

                for (int i = 3; i < count; i += 4)
                {
                    writer.WriteLine(s.ElementAt(i).InnerText.Trim());
                    SourceProgress.Value += 1;
                }
                writer.Close();
            }

            //MessageBox.Show("SOURCE FOUND !");
            SourceText.Text = "OK";
        }

        private void find_DETAILS()
        {
            string new_url;

            for (int j = 0; j < max; j++)
            {
                new_url = url + (j + 1).ToString();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(new_url);

                var s = from k in d.DocumentNode.SelectNodes("//a[@class='details']")
                        where k.GetAttributeValue("title") == "View notifications"
                        select k;

                int count = s.ToList().Count();

                StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\DETAILS.txt", true);

                for (int i = 0; i < count; i++) 
                {
                    writer.WriteLine(s.ElementAt(i).GetAttributeValue("href").Trim());
                    DetailsProgress.Value += 1;
                }
                writer.Close();
            }

            //MessageBox.Show("DETAILS FOUND !");
            DetailsText.Text = "OK";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\User\\Desktop\\NAMES.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\EC.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\CAS.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\CLASS.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\IMAGES.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\SOURCE.txt", String.Empty);
            File.WriteAllText("C:\\Users\\User\\Desktop\\DETAILS.txt", String.Empty);
            MessageBox.Show("CLEAR DONE !");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            string path = fd.SelectedPath;

            if (path != null)
            {
                string url = "https://echa.europa.eu/o/com.ed.echa.portlet.dissclinventory/images/pictograms/";

                for (int i = 0; i < 9; i++)
                {
                    using (WebClient w = new WebClient())
                    {
                        try
                        {
                            string img_path = path + "\\ghs0" + (i + 1).ToString() + ".png";
                            string img_url = url + "ghs0" + (i + 1).ToString() + ".png";
                            w.DownloadFile(new Uri(img_url), img_path);
                            Store_ImgToDB(img_path);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString() + "Image : " + (i+1).ToString());
                        }
                        w.Dispose();
                    } 
                    
                }
                MessageBox.Show("DOWNLOAD COMPLETED !");
            }
        }

        private void Store_ImgToDB(string image_path)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            string sql = "INSERT INTO [IMAGES](NAME, IMAGE) VALUES (@NAME, @IMAGE)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            string name = System.IO.Path.GetFileName(image_path);

            byte[] img = GetImg(image_path);
            cmd.Parameters.Add("@NAME", SqlDbType.Text).Value = name;
            cmd.Parameters.Add("@IMAGE", SqlDbType.Image).Value = img;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            conn.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            string sql = "INSERT INTO [IMAGES](NAME, IMAGE) VALUES (@NAME, @IMAGE)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            string path = "C:\\Users\\User\\Desktop\\IMAGES\\ghs01.png";
            string name = System.IO.Path.GetFileName(path);

            byte[] img = GetImg(path);
            cmd.Parameters.Add("@NAME", SqlDbType.Text).Value = name;
            cmd.Parameters.Add("@IMAGE", SqlDbType.Image).Value = img;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            conn.Close();
        }

        private static byte[] GetImg(string filePath)
        {
            FileStream stream = new FileStream(
            filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string m = Interaction.InputBox("Input Urls Count", "Input", "1");
            if (int.TryParse(m, out int v))
            {
                if (v > 0 && v <= 4279) max = v;
                else MessageBox.Show("WRONG NUMBER !");
            }
            else MessageBox.Show("WRONG FORMAT !");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("C:\\Users\\User\\Desktop\\DETAILS.txt");
            string details_url;
            while ((details_url = reader.ReadLine()) != null)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(details_url);

                var h = from k in d.DocumentNode.SelectNodes("//table")
                        where k.GetAttributeValue("class") == "CLPtable taglib-search-iterator"
                        select k;
                var t = from l in h.ElementAt(0).Descendants("tr")
                        where l.GetAttributeValue("class") == "results-row" || l.GetAttributeValue("class") == "results-row-alt"
                        select l;


                foreach (var c in t)
                {
                    string line = "";
                    var v = c.Descendants("td").ElementAt(0).InnerText.Trim();

                    line += String.Concat(v.Where(c => !Char.IsWhiteSpace(c)));

                    if (v != "")
                    {
                        try
                        {
                            string temp = c.Descendants("td").ElementAt(1).Descendants("span").ElementAt(0).InnerText.Trim();
                            line += "|" + String.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));
                        }
                        catch (Exception ex)
                        {
                            line = "";
                        }
                    }
                    if (line != "")
                    {
                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\HAZARDS.txt", true);
                        writer.WriteLine(details_url.Split('/').Last() + "|" + line);
                        writer.Close();
                    }
                }
            }

            reader.Close();
            MessageBox.Show("DONE !");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("C:\\Users\\User\\Desktop\\DETAILS.txt");
            string details_url;

            while ((details_url = reader.ReadLine()) != null)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument d = web.Load(details_url);

                var h = from k in d.DocumentNode.SelectNodes("//table")
                        where k.GetAttributeValue("class") == "CLPtable taglib-search-iterator"
                        select k;
                var t = from l in h.ElementAt(0).Descendants("tr")
                        where l.GetAttributeValue("class") == "results-row" || l.GetAttributeValue("class") == "results-row-alt"
                        select l;


                foreach (var c in t)
                {
                    string line = "";
                    var v = c.Descendants("td").ElementAt(0).InnerText.Trim();

                    if (v == "") v = "NULL";
                    line += String.Concat(v.Where(c => !Char.IsWhiteSpace(c)));


                    try
                    {
                        string temp = c.Descendants("td").ElementAt(1).Descendants("span").ElementAt(0).InnerText.Trim();
                        if (temp == "") temp = "NULL";
                        line += "|" + String.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));
                    }
                    catch (Exception ex)
                    {
                        line += "|NULL";
                    }

                    try
                    {
                        string temp = c.Descendants("td").ElementAt(2).Descendants("span").ElementAt(0).InnerText.Trim();
                        if (temp == "") temp = "NULL";
                        line += "|" + String.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));
                    }
                    catch (Exception ex)
                    {
                        line += "|NULL";
                    }

                    if (line != "")
                    {
                        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\HAZARDS1.txt", true);
                        writer.WriteLine(details_url.Split('/').Last() + "|" + line);
                        writer.Close();
                    }
                }
            }

            reader.Close();
            MessageBox.Show("DONE !");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            string sql = "INSERT INTO [HAZARDS](URL, HCATEGORY, HSTATEMENT) VALUES (@URL, @HCATEGORY, @HSTATEMENT)";

            StreamReader reader = new StreamReader("C:\\Users\\User\\Desktop\\HAZARDS.txt");
            string line;
            conn.Open();
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split("|");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@URL", split[0]);
                cmd.Parameters.AddWithValue("@HCATEGORY", split[1]);
                cmd.Parameters.AddWithValue("@HSTATEMENT", split[2]);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
            MessageBox.Show("DONE !");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cstr = "Data Source=DESKTOP-HFR3D87\\SQLEXPRESS;Initial Catalog=Ecig_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cstr);
            string sql = "INSERT INTO [HAZARDS1](URL, HCATEGORY, HSTATEMENT1, HSTATEMENT2) VALUES (@URL, @HCATEGORY, @HSTATEMENT1, @HSTATEMENT2)";

            StreamReader reader = new StreamReader("C:\\Users\\User\\Desktop\\HAZARDS1.txt");
            string line;
            conn.Open();
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split("|");
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@URL", split[0]);
                cmd.Parameters.AddWithValue("@HCATEGORY", split[1]);
                cmd.Parameters.AddWithValue("@HSTATEMENT1", split[2]);
                cmd.Parameters.AddWithValue("@HSTATEMENT2", split[3]);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
            MessageBox.Show("DONE !");
        }
    }
}