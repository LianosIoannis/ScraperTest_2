using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperTest_2
{
    public class Substance
    {
        public string name { get; set; }
        public string ec { get; set; }
        public string cas { get; set; }

        public string clas { get; set; }

        public string image { get; set; }

        public string source { get; set; }

        public string details { get; set; } 
        public Substance()
        {
            name = "NULL";
            ec = "NULL";
            cas = "NULL";   
            clas = "NULL"; 
            image = "NULL"; 
            source = "NULL";    
            details = "NULL";   
        }
    }
}
