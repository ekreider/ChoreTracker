using Microsoft.Data.Sqlite;
using Dapper;

namespace ChoreTracker.Models
{
    public static class DataAccess
    {
        public static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data/ChoreTracker.db");

        public static void InitDB()
        {
            using (var connection = new SqliteConnection($"Data Source={FilePath}"))
            {
                connection.Open();

                SqliteCommand cmd = new SqliteCommand(@"CREATE TABLE ""FREQUENCY_TYPE"" (
	                ""ID""	INTEGER,
	                ""NAME""	TEXT NOT NULL UNIQUE,
	                ""DESCRIPTION""	TEXT,
	                PRIMARY KEY(""ID"" AUTOINCREMENT)
                )", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"CREATE TABLE ""FREQUENCY"" (
	                ""ID""	INTEGER,
	                ""NAME""	TEXT NOT NULL UNIQUE,
	                ""DESCRIPTION""	TEXT,
	                ""FREQUENCY_TYPE_ID""	INTEGER NOT NULL,
	                ""FREQUENCY_VALUE""	INTEGER,
	                PRIMARY KEY(""ID"" AUTOINCREMENT),
	                CONSTRAINT ""FREQUENCY_FREQUENCY_TYPE"" FOREIGN KEY(""FREQUENCY_TYPE_ID"") REFERENCES ""FREQUENCY_TYPE""(""ID"")
                )", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"CREATE TABLE ""CATEGORY"" (
	                ""ID""	INTEGER,
	                ""NAME""	TEXT NOT NULL UNIQUE,
	                ""DESCRIPTION""	TEXT,
	                PRIMARY KEY(""ID"" AUTOINCREMENT)
                )", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"CREATE TABLE ""CHORE"" (
					""ID""	INTEGER,
					""NAME""	TEXT NOT NULL UNIQUE,
					""DESCRIPTION""	TEXT,
					""FREQUENCY_ID""	INTEGER NOT NULL,
					""CATEGORY_ID""	INTEGER DEFAULT 1,
					""LAST_DONE""	DATETIME,
					PRIMARY KEY(""ID"" AUTOINCREMENT),
					CONSTRAINT ""CHORE_CATEGORY_ID"" FOREIGN KEY(""CATEGORY_ID"") REFERENCES ""CATEGORY""(""ID""),
					CONSTRAINT ""CHORE_FREQUENCY"" FOREIGN KEY(""FREQUENCY_ID"") REFERENCES ""FREQUENCY""(""ID"")
				)", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"CREATE TABLE ""CHORE_HISTORY"" (
					""ID""	INTEGER,
					""CHORE_ID""	INTEGER NOT NULL,
					""DATETIMESTAMP""	DATETIME NOT NULL,
					PRIMARY KEY(""ID"" AUTOINCREMENT),
					CONSTRAINT ""CHORE_HISTORY_CHORE"" FOREIGN KEY(""CHORE_ID"") REFERENCES ""CHORE""(""ID"")
				)", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"INSERT INTO CATEGORY (NAME, DESCRIPTION)
					VALUES ('UNCATEGORIZED','Chores that have not been assigned any category.')", connection);

                cmd.ExecuteNonQuery();

                cmd = new SqliteCommand(@"INSERT INTO ""FREQUENCY_TYPE"" (NAME, DESCRIPTION)
					VALUES ('MONTHLY','Occurs on a specific day of the month.'),
					('DAILY','Occurs after a specific number of days.'),
					('COUNTER','Used for tracking how often something is done with no scheduled frequency.')", connection);

                cmd.ExecuteNonQuery();

                connection.Close();
            }

			
        }

		#region icon
		public static List<Icon> GetIcons()
		{
			try
			{
                using (var connection = new SqliteConnection($"Data Source={FilePath}"))
                {
                    connection.Open();
                    return connection.Query<Icon>("SELECT * FROM ICON").ToList();
                }
            }
			catch (Exception ex)
			{
				
				Console.WriteLine(ex.Message.ToString());
				return null;
			}
        }

        public static Icon GetIcon(int _ID)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={FilePath}"))
                {
                    connection.Open();
                    var i = connection.Query<Icon>("SELECT * FROM ICON WHERE ID = @ID", new { ID = _ID }).FirstOrDefault();
                    return i;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        #endregion

        #region category



        #endregion
    }
}
