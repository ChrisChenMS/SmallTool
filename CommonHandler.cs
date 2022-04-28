using System.IO;
using System.Text.RegularExpressions;

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

        public bool isLocation(string input)
        {
            bool isLocation = false;

            Regex FolderRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection FolderMatches = FolderRegex.Matches(input);

            if (FolderMatches.Count > 0)
            {
                isLocation = true;
            }

            return isLocation;
        }

    }
}
