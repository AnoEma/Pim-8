using App2.Data;
using SQLite;
using System.IO;

namespace App2.Droid.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {
        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}