using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InventaireGrossiste;
using InventaireGrossiste.Models;

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
                        adresse TEXT, 
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

    public static bool AddUser(string email, string password)
    {
        using (var context = new ApplicationDbContext())
        {
            var user = new User { Email = email, Password = HashPassword(password) };
            context.Users.Add(user);
            return context.SaveChanges() > 0;
        }
    }

    public static bool ValidateUser(string email, string password)
    {
        using (var context = new ApplicationDbContext())
        {
            string hashedPassword = HashPassword(password);
            return context.Users.Any(u => u.Email == email && u.Password == hashedPassword);
        }
    }

    private static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}