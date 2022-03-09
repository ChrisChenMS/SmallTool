using System.IO;

namespace SmallTool
{
    class CommonHandler
    {
        public string ParseLocation(string Location)
        {
            Location = Location.Trim();
            if (Location[^1] != '\\')
            {
                Location = $"{Location}\\";
            }

            if (Location.Length >= 2 && Location[1] == ':')
            {
                
            }
            else
            {
                Location = System.AppDomain.CurrentDomain.BaseDirectory + Location;
            }

            if (!Directory.Exists(Location))
            {
                Location = "";
            }
            

            return Location;
        }

        public void Logger()
        { 
            
        }

    }
}
