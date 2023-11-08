using Microsoft.Data.Sqlite;

namespace Foraging_Kentucky.Data;

// This class follows the Single-Responsibility principle.
// It has one job: to clear the database of all records.
public static class ClearDb
{
    public static void ClearDatabase()
    {
        var folder = Environment.SpecialFolder.Desktop;
        var path = Environment.GetFolderPath(folder);
        string DbPath = Path.Join(path, "/db/forage-kentucky.db");

        string connectionString = $"Data Source={DbPath}";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand("DELETE FROM Items", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Items'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM Users", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Users'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM ItemUser", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'ItemUser'", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("DELETE FROM Recipes", connection))
            {
                command.ExecuteNonQuery();
            }
            using (SqliteCommand command = new SqliteCommand("UPDATE sqlite_sequence SET seq=0 WHERE name = 'Recipes'", connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}