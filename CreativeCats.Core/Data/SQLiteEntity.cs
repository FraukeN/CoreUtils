using CreativeCats.Core.Abstractions;
using SQLite;

namespace CreativeCats.Core.Data
{
    public class SQLiteEntity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
