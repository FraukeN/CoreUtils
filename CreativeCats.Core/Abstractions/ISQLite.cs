using SQLite;

namespace CreativeCats.Core.Abstractions
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
