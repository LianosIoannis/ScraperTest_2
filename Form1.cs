using HtmlAgilityPack;
using Kuto;
using System.IO;
using System.Text.RegularExpressions;
using ScrapySharp;
using System.Linq;
using ScrapySharp.Extensions;

namespace ScraperTest_2
{
    public partial class Form1 : Form
    {

        string url = "https://echa.europa.eu/el/information-on-chemicals/cl-inventory-database?p_p_id=dissclinventory_WAR_dissclinventoryportlet&p_p_lifecycle=0&p_p_state=normal&p_p_mode=view&_dissclinventory_WAR_dissclinventoryportlet_jspPage=%2Fhtml%2Fsearch%2Fsearch.jsp&_dissclinventory_WAR_dissclinventoryportlet_searching=true&_dissclinventory_WAR_dissclinventoryportlet_iterating=true&_dissclinventory_WAR_dissclinventoryportlet_criteriaParam=_dissclinventory_WAR_dissclinventoryportlet_criteriaKeytcZP&_dissclinventory_WAR_dissclinventoryportlet_delta=50&_dissclinventory_WAR_dissclinventoryportlet_orderByCol=&_dissclinventory_WAR_dissclinventoryportlet_orderByType=asc&_dissclinventory_WAR_dissclinventoryportlet_resetCur=false&_dissclinventory_WAR_dissclinventoryportlet_cur=1";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlWeb web= new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

            var mylist = from table in d.DocumentNode.SelectNodes("//tbody").Cast<HtmlNode>()
                         from row in table.SelectNodes("//tr").Cast<HtmlNode>()
                         from cell in row.SelectNodes("//td[2]").Cast<HtmlNode>()
                         select new { ct = cell.InnerText.Trim() };
            
            
            

            foreach (var cell in mylist)
            {
                StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\c.txt", true);
                writer.Write(cell.ct + Environment.NewLine);
                writer.Close();    
                //MessageBox.Show(item.InnerText.Trim());
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            //var lines = File.ReadAllLines("C:\\Users\\User\\Desktop\\d.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            //File.WriteAllLines("C:\\Users\\User\\Desktop\\e.txt", lines);

            string text = File.ReadAllText("C:\\Users\\User\\Desktop\\d.txt");
            string result = Regex.Replace(text, @"^\s+$[\r\n]*", "\r\n", RegexOptions.Multiline);
            File.WriteAllText("C:\\Users\\User\\Desktop\\d.txt", result);


            //StreamReader r = new StreamReader("C:\\Users\\User\\Desktop\\c.txt"); 
            //string line;

            //while (r.Peek() >= 0)
            //{
            //    line = r.ReadLine().Trim();
            //    if (line == null)
            //    {
            //        MessageBox.Show(line);
            //    }
            //    else
            //    {
            //        StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\d.txt", true);                    
            //        writer.Write(line + Environment.NewLine);
            //        if (line == "View details") writer.Write(Environment.NewLine);  
            //        writer.Close();
            //    }

            //    //MessageBox.Show(line);
            //}
            //r.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //HtmlWeb web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument d = web.Load(url);

            //foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
            //{
            //    var a = cell.Descendants("span");

            //    MessageBox.Show("============================");
            //    foreach (var c in a)
            //    {
            //        MessageBox.Show(c.InnerText.Trim());
            //    }
            //}

            //find_Names();
            //find_EC();
            //find_CAS();
            //find_CLASS();
            //find_IMAGES();  
            find_SOURCE();
        }  
        
        private void find_Names()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

            try
            {
                StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\NAMES.txt", true);

                foreach (var cell in d.DocumentNode.SelectNodes("//a[@class='substanceNameLink']"))
                {
                    //MessageBox.Show(cell.InnerText.Trim());
                    writer.WriteLine(cell.InnerText.Trim());
                }

                writer.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("NAMES FOUND !");

        }

        private void find_EC()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("EC FOUND !");
        }

        private void find_CAS()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("CAS FOUND !");
        }

        private void find_CLASS()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

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
                        if (c.InnerText.Trim() != "") line += c.InnerText.Trim() ;
                        if (i != a.Count() && c.InnerText.Trim() != "") line += "|";
                        i++;
                    }
                    if (line == "") line = "NULL";
                    writer.WriteLine(line);
                    writer.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("CLASS FOUND !");
        }

        private void find_IMAGES()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);

            try
            {
                foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                {
                    var a = cell.Descendants("img");

                    StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\IMAGES.txt", true);

                    string line = "";
                    int i = 1;
                    foreach (var c in a)
                    {
                        string s = c.Attributes["src"].Value.Trim();
                        if (s != "") line += "https://echa.europa.eu/" + s;
                        if (i != a.Count() && s != "") line += "|";
                        i++;
                    }
                    if (line == "") line = "NULL";
                    writer.WriteLine(line);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("IMAGES FOUND !");
        }

        private void find_SOURCE()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);
            //MessageBox.Show(d.DocumentNode.SelectNodes("//tr[@class='   ']").Count.ToString());


            //MessageBox.Show(d.DocumentNode.SelectSingleNode("//*[@id=\"_dissclinventory_WAR_dissclinventoryportlet_ocerSearchContainerSearchContainer\"]/table/tbody/tr[3]/td[5]").InnerText.Trim());
            try
            {
                foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                {
                    var a = cell.Descendants("td").Where(d => d.Descendants().Count() == 0).ToList();
                    
                    var b = a.Count;

                    for (int i = 0; i < b; i++)
                    {
                        MessageBox.Show(a[i].InnerText.Trim());
                    }
                    
                    //string line = b.InnerText.Trim();
                    //string line = a.Count().ToString();
                    

                    //StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\SOURCE.txt", true);
                    //writer.Write(line + Environment.NewLine);
                    //writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("SOURCE FOUND !");
        }

        private void find_AllRow()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument d = web.Load(url);


            try
            {
                foreach (var cell in d.DocumentNode.SelectNodes("//tr[@class='   ']"))
                {
                    var a = cell.Descendants("td").ToList();

                    var b = a.Count();

                    for (int i = 0; i < b; i++)
                    {
                        MessageBox.Show(a[i].InnerText.Trim());
                    }

                    //string line = b.InnerText.Trim();
                    //string line = a.Count().ToString();


                    //StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\SOURCE.txt", true);
                    //writer.Write(line + Environment.NewLine);
                    //writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("SOURCE FOUND !");
        }

    }
}