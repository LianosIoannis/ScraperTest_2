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

                    foreach (var cell in d.DocumentNode.SelectNodes("//a[@class='substanceNameLink']"))
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

                var s = d.DocumentNode.SelectNodes("//a[@class='details']");
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

        private void find_AllRow()
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
                        var a = cell.Descendants("td").ToList();

                        var b = a.Count();

                        for (int i = 0; i < b; i++)
                        {
                            MessageBox.Show(a[i].InnerText.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

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
        }
    }
}