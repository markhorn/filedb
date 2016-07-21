using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace FileTableOperations
{
    public class FileTableOperation
    {
        const string connectionString = @"server=localhost\sql;database=filedb;Integrated Security=TRUE";
        public static System.Guid UploadFile(string name, byte[] data)
        {
            Guid returnGuid = new Guid();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 0;

                string sqlText = "INSERT INTO FileTable1 (name,file_stream) OUTPUT INSERTED.stream_id VALUES (@Name,@Data)";
                cmd.CommandText = sqlText;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Data", data);
                returnGuid = (System.Guid)cmd.ExecuteScalar();

                conn.Close();
            }
            return returnGuid;

        }

        public static byte[] RetrieveFile(System.Guid id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 0;

                string sqlText = "SELECT file_stream FROM FileTable1 WHERE stream_id = @stream_id";
                cmd.CommandText = sqlText;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@stream_id", id);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            return (Byte[])dt.Rows[0]["file_stream"];
        }

    }
}
