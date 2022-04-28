using System;
using System.Collections.Generic;
using System.Text;

namespace SmallTool.Models
{
    public class Parameters
    {
        public string Category { get; set; }


        public Parameters Initialize()
        {
            Parameters para = new Parameters();

            para.Category = "MSIPC";

            return para;
        }

        public void Print()
        {
            Console.WriteLine("Category: " + Category);
        }

    }
}
