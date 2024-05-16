using System;
using MySqlConnector;

namespace E7_DatabasesandInteroperability
{
    internal class Program 
    {
        // Connection string
        static string connectionString = "server=localhost;user=root;password=your_password;port=3306";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create a new database user.");
                Console.WriteLine("2. Change the password of an existing database user.");
                Console.WriteLine("3. Grant permissions to a database user.");
                Console.WriteLine("4. Show an example of a transaction.");
                Console.WriteLine("5. Exit.");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        ChangeUserPassword();
                        break;
                    case 3:
                        GrantPermissions();
                        break;
                    case 4:
                        ShowTransactions();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Create User
        static void CreateUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"CREATE USER '{username}'@'%' IDENTIFIED BY '{password}'";
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("User created successfully.");
        }

        // Change User Password
        static void ChangeUserPassword()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"ALTER USER '{username}'@'%' IDENTIFIED BY '{newPassword}'";
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Password changed successfully.");
        }

        // Grant Permissions
        static void GrantPermissions()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter database name: ");
            string databaseName = Console.ReadLine();
            Console.Write("Enter permission type (e.g., SELECT, INSERT, UPDATE, DELETE): ");
            string permissionType = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"GRANT {permissionType} ON {databaseName}.* TO '{username}'@'%'";
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"Permission '{permissionType}' granted to user '{username}' for database '{databaseName}'.");
        }

        // Show Transactions
        static void ShowTransactions()
        {
            Console.WriteLine("A transaction is a sequence of SQL operations that are executed as a single unit of work.");
            Console.WriteLine("Transaction Control Language (TCL) statements are used to manage transactions.");
            Console.WriteLine("Examples of TCL statements:");
            Console.WriteLine("COMMIT: Saves changes made during the current transaction.");
            Console.WriteLine("ROLLBACK: Discards changes made during the current transaction.");

            Console.WriteLine("Now, let's demonstrate a transaction...");

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "INSERT INTO sample_table (column1) VALUES ('value1')";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO sample_table (column1) VALUES ('value2')";
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine("Transaction committed successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transaction rolled back due to an error: {ex.Message}");
                    }
                }
            }
        }
    }
}
