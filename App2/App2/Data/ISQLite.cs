using SQLite;

namespace App2.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}