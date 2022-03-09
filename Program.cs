using System;
using SmallTool_MSIPC;
using SmallTool_MSIPC.Models;

namespace SmallTool
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please input the log you want to analyse(MSIPC/MSIP)");
                //var Category = Console.ReadLine();
                Console.WriteLine("Please input location of the logs");
                var Location = Console.ReadLine();

                //for test
                var Category = "msipc";
                //var Location = @"C:\Users\chenych\AppData\Local\Microsoft\MSIPC";
                //var Location = @"C:\Users\chenych\Desktop\incubation ppt pics\MSIPC0831UserDecrypt";
                //Console.ReadLine();

                var Handler = new CommonHandler();
                
                switch (Category.ToUpper())
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
