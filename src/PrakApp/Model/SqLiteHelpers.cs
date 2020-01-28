using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace PrakApp.Model
{
    internal static class SqLiteHelpers
    {
        internal static string GetString (this SQLiteDataReader reader, string Column)
        {
            return reader[Column].ToString();
        }

        // Tries to get a long value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static long GetLong(this SQLiteDataReader reader, string Column, long? Default = null)
        {
            if (reader[Column] is null) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetInt64(reader.GetOrdinal(Column));
            return result;
        }

        // Tries to get a int value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static int GetInt(this SQLiteDataReader reader, string Column, int? Default = null)
        {
            if (reader[Column] is null) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetInt32(reader.GetOrdinal(Column));
            return result;
        }

    }
}
