using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventaireGrossiste.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Adresse { get; set; }
        public required string Telephone { get; set; }
        public required string Email { get; set; }
        public required string Siret { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public int Qte { get; set; }
        public int Prix { get; set; }
        public required string Nom { get; set; }
        public DateTime DatePerime { get; set; }
        public int CategorieId { get; set; }
        public required string Emplacement { get; set; }
        public required Category Categorie { get; set; }
    }

    public class Commande
    {
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int Qte { get; set; }
        public DateTime DateComm { get; set; }
        public required string Status { get; set; }

        public required Client Client { get; set; }
        public required Product Product { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
    }

}
