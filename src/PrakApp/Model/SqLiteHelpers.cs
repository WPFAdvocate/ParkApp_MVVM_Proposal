using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace PrakApp.Model
{
    internal static class SqLiteHelpers
    {
        internal static string GetString (this SqlDataReader reader, string Column)
        {
            return reader[Column].ToString();
        }

        // Tries to get a long value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static long GetLong(this SqlDataReader reader, string Column, long? Default = null)
        {
            if (reader[Column] is DBNull) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetInt32(reader.GetOrdinal(Column));
            return result;
        }

        // Tries to get a int value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static int GetInt(this SqlDataReader reader, string Column, int? Default = null)
        {
            if (reader[Column] is DBNull) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetInt32(reader.GetOrdinal(Column));
            return result;
        }

        // Tries to get a int value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static bool GetBool(this SqlDataReader reader, string Column, bool? Default = null)
        {
            if (reader[Column] is DBNull) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetBoolean(reader.GetOrdinal(Column));
            return result;
        }

        // Tries to get a int value from an SqlLite Table. Throws an error if Default is null and the Column is null
        internal static DateTime GetDateTime(this SqlDataReader reader, string Column, DateTime? Default = null)
        {
            if (reader[Column] is DBNull) return Default ?? throw new ArgumentNullException(Column);
            var result = reader.GetDateTime(reader.GetOrdinal(Column));
            return result;
        }

        internal static DateTime? GetNullableDateTime(this SqlDataReader reader, string Column)
        {
            if (reader[Column] is DBNull) return null;
            var result = reader.GetDateTime(reader.GetOrdinal(Column));
            return result;
        }

    }
}
