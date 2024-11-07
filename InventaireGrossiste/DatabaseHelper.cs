using System.Data.SQLite;
using System.IO;

public static class DatabaseHelper
{
    private static string connectionString = @"Data Source=..\..\..\Files\librairie1.db; Version=3;";

    public static void InitializeDatabase()
    {
        if (!File.Exists(@"..\..\..\Files\librairie1.db"))
        {
            SQLiteConnection.CreateFile(@"..\..\..\Files\librairie1.db");

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createCategory =
                    @"CREATE TABLE IF NOT EXISTS Categories (
                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        nom TEXT
                        );";

                string createClient =
                    @"CREATE TABLE IF NOT EXISTS Clients (
                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        nom TEXT, 
                        prenom TEXT, 
                        adresse TEXT, 
                        telephone TEXT,
                        email TEXT,
                        siret TEXT
                        );";

                string createProduct =
                    @"CREATE TABLE IF NOT EXISTS Products (
                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        qte INTEGER, 
                        prix INTEGER, 
                        nom TEXT,
                        datePerime DATE,
                        categorie INTEGER,
                        emplacement TEXT,
                        FOREIGN KEY(categorie) REFERENCES Categories(id)
                        );";

                string createCommande =
                    @"CREATE TABLE IF NOT EXISTS Commandes (
                        id_client INTEGER,
                        id_product INTEGER, 
                        qte INTEGER,
                        dateComm DATE,
                        status TEXT,
                        FOREIGN KEY(id_client) REFERENCES Clients(id)
                        FOREIGN KEY(id_product) REFERENCES Products(id)
                        );";

                string createUsers =
                    @"CREATE TABLE IF NOT EXISTS Users (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        email TEXT, 
                        password TEXT
                        );";



                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createCategory;
                    command.ExecuteNonQuery();

                    command.CommandText = createClient;
                    command.ExecuteNonQuery();

                    command.CommandText = createProduct;
                    command.ExecuteNonQuery();

                    command.CommandText = createCommande;
                    command.ExecuteNonQuery();

                    command.CommandText = createUsers;
                    command.ExecuteNonQuery();
                };
            }
        }


    }

    public static bool ValidateUser(string email, string password)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE email = @Email AND password = @Password";
            using (var command = new SQLiteCommand(query, connection))
            {
                // Ajouter les paramètres pour éviter les injections SQL
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                // Exécuter la commande et obtenir le résultat
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Retourne true si l'utilisateur existe
            }
        }
    }

    public static bool AddUser(string email, string password)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Users (email, password) VALUES (@Email, @Password)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                // Exécuter la commande et vérifier si une ligne a été ajoutée
                return command.ExecuteNonQuery() > 0;
            }
        }

    }
}