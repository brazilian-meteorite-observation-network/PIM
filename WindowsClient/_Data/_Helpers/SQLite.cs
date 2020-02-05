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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Trajectories (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(255) NOT NULL, status BOOLEAN NOT NULL CHECK (status IN (0, 1)), last_visit DATETIME NOT NULL, STATION VARCHAR(255), DIRECTORY TEXT)";

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
                    cmd.CommandText = "SELECT * FROM Trajectories";

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
                    cmd.CommandText = $"SELECT * FROM Trajectories Where id={Id}";

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

        public static void Insert(Trajectory trajectory)
        {
            try
            {
                using (SQLiteCommand cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Trajectories (id, name, status, last_visit, station, directory) VALUES (NULL, @name, @status, @last_visit, @station, @directory)";

                    cmd.Parameters.AddWithValue("@name", trajectory.Name);
                    cmd.Parameters.AddWithValue("@status", trajectory.Status);
                    cmd.Parameters.AddWithValue("@last_visit", trajectory.Last_Visit);
                    cmd.Parameters.AddWithValue("@station", trajectory.Station);
                    cmd.Parameters.AddWithValue("@directory", trajectory.Directory);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(Trajectory trajectory)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBConnection()))
                {
                    if (trajectory.Id > 0)
                    {
                        cmd.CommandText = "UPDATE Trajectories SET name=@name, status=@status, last_visit=@last_visit, station=@station, directory=@directory WHERE id=@id";

                        cmd.Parameters.AddWithValue("@id", trajectory.Id);
                        cmd.Parameters.AddWithValue("@name", trajectory.Name);
                        cmd.Parameters.AddWithValue("@status", trajectory.Status);
                        cmd.Parameters.AddWithValue("@last_visit", trajectory.Last_Visit);
                        cmd.Parameters.AddWithValue("@station", trajectory.Station);
                        cmd.Parameters.AddWithValue("@directory", trajectory.Directory);

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
                    cmd.CommandText = "DELETE FROM Trajectories Where id=@id";
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
