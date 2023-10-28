using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class SqlReaderHelperPassingFunctionAsParameterTests
    {

        [Test]
        public void PassingFunctionAsParameter()
        {
            int page = 0;
            int? pageSize = null;
            pageSize ??= 0;

            var response = this.Read<DeviceSummary>(
                "sp_get_connection_host",
                new()
                {
                    new("start_row_index", page * pageSize),
                    new("page_size",  pageSize )
                },
                r => new(
                    r.GetString("host"),
                    r.GetString("imei_no")
                )
            );

        }

        private async Task<List<T>> Read<T>(string storedProcedureName, List<SqlParameter> parameters, Func<SqlDataReader, T> creator)
        {
            using var connection = new SqlConnection("connectionString");
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            command.Parameters.AddRange(parameters.ToArray());

            using var reader = await command.ExecuteReaderAsync();
            var result = new List<T>();

            while (reader.Read())
                result.Add(creator(reader));

            return result;
        }
    }

    public static class SqlDataReaderExtensions
    {
        public static DateTime? GetDateTimeNullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetDateTime(columnName);
        public static string? GetStringNullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetString(columnName);
        public static bool? GetBooleanNullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetBoolean(columnName);
        public static byte? GetByteNullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetByte(columnName);
        public static int? GetInt32Nullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetInt32(columnName);
        public static long? GetInt64Nullable(this SqlDataReader reader, string columnName) => reader.IsDBNull(columnName) ? null : reader.GetInt64(columnName);
    }
    public record DeviceSummary(string Host, string Imei);
}
