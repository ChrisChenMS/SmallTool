using System;
using SmallTool_MSIPC;
using SmallTool_MSIPC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using SmallTool.Models;

namespace SmallTool
{
    class Program
    {
        static void Main()
        {
            List<string> SupportedCategory = ConfigurationManager.AppSettings["SupportedCategory"].Split(',').ToList();
            Parameters para = new Parameters().Initialize();
            bool FirstOpen = true;

            while (true)
            {
                if (FirstOpen)
                {
                    Console.WriteLine("Current log type: " + para.Category);
                }
                FirstOpen = false;
                //var Category = Console.ReadLine();
                Console.WriteLine("Please input location of the logs");
                var Location = Console.ReadLine();

                //for test
                //var Category = "msipc";
                //Console.ReadLine();

                var Handler = new CommonHandler();

                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

                if (Location.ToLower() == "c" || Location.ToLower() == "clear")
                {
                    Console.Clear();
                }
                else if (Location.ToLower() == "p" || Location.ToLower() == "para")
                {
                    para.Print();
                g
                else if (Location.ToLower() == "category")
                {
                    Console.WriteLine("Change category to");
                    string temp = Console.ReadLine();
                    if (SupportedCategory.Exists(x => x == temp))
                    {
                        para.Category = temp.ToUpper();
                    }
                    else
                    {
                        Console.WriteLine("Not supported category!");
                    }
                }
                else if (Location.ToLower() == "h" || Location.ToLower() == "help")
                {
                    Console.WriteLine("'c' or 'clear' to clean the window\n");
                    Console.WriteLine("'p' or 'para' to display the current parameters\n");
                    Console.WriteLine("'category' to change the analyser category\n");
                    Console.WriteLine("Proudly provided by chenych and yiminyuan");
                }
                else
                {
                    switch (para.Category.ToUpper())
                    {
                        case "MSIPC":
                            var Analyser = new MSIPC();
                            var Result = new MSIPC_Response();
                            if (Location.Length > 0)
                            {
                                Location = Handler.ParseLocation(Location);
                                Console.WriteLine(Location);
                                Result = Analyser.Analyse(Location);
                            }
                            else
                            {
                                Result.ErrMessage = "Not a valid Location";
                            }
                            Console.WriteLine(Result.ErrMessage);
                            break;
                        default:
                            Console.WriteLine("Invalid Input!");
                            break;
                    }
                }
            }
            

        }
            
        
    }
}
