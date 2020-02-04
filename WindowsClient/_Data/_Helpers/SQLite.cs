using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace WindowsClient._Data._Helpers
{
    public static class SQLite
    {
        private static SQLiteConnection sqliteConnection;
        private static readonly string currentDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());

        private static SQLiteConnection DBConnection()
        {

            sqliteConnection = new SQLiteConnection($@"Data Source={currentDir}\db.sqlite; Version=3;");
            sqliteConnection.Open();

            return sqliteConnection;
        }

        public static void CreateSQLiteDB()
        {
            try
            {
                if (!File.Exists($@"{currentDir}\db.sqlite"))
                {
                    SQLiteConnection.CreateFile($@"{currentDir}\db.sqlite");
                }
            }
            catch
            {
                throw;
            }
        }

        public static void CreateSQLiteTable()
        {
            try
            {
                using (SQLiteCommand cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Objects (id INT PRIMARY KEY, variable VARCHAR(50), longitude FLOAT, latitude FLOAT, height FLOAT)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetObjects()
        {
            try
            {
                SQLiteDataAdapter da;
                DataTable dt = new DataTable();

                using (SQLiteCommand cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Objects";

                    da = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetObject(int Id)
        {
            try
            {
                SQLiteDataAdapter da;
                DataTable dt = new DataTable();

                using (SQLiteCommand cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Objects Where id={Id}";

                    da = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert(Object obj)
        {
            try
            {
                using (SQLiteCommand cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Objects (id, variable, longitude, latitude, height) values (@id, @variable, @longitude, @latitude, @height)";

                    cmd.Parameters.AddWithValue("@variable", obj.Variable);
                    cmd.Parameters.AddWithValue("@longitude", obj.Longitude);
                    cmd.Parameters.AddWithValue("@latitude", obj.Latitude);
                    cmd.Parameters.AddWithValue("@height", obj.Height);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(Object obj)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBConnection()))
                {
                    if (obj.Id > 0)
                    {
                        cmd.CommandText = "UPDATE Objects SET variable=@variable, longitude=@longitude, latitude=@latitude, height=@heght WHERE id=@id";

                        cmd.Parameters.AddWithValue("@id", obj.Id);
                        cmd.Parameters.AddWithValue("@variable", obj.Variable);
                        cmd.Parameters.AddWithValue("@longitude", obj.Longitude);
                        cmd.Parameters.AddWithValue("@latitude", obj.Latitude);
                        cmd.Parameters.AddWithValue("@height", obj.Height);

                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int Id)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBConnection()))
                {
                    cmd.CommandText = "DELETE FROM Objects Where id=@id";
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
