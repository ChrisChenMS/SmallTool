using System;
using System.Data.SQLite;

namespace SmallTool
{
    class Test
    {
        private readonly string ProgramLocation = System.AppDomain.CurrentDomain.BaseDirectory;
        static void Main(string[] args)
        {
            var db = new SQLiteConnection("DataSource = database.db; Version = 3;");

            db.Open();

            string sql = "select value from test where name = 'lalala'";

            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["value"]);
            }
        }
    }
}