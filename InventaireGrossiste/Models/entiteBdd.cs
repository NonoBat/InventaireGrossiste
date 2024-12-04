using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public required string Adresse { get; set; }
        public required string Siret { get; set; }
    }

    public class Product
    {
        [ForeignKey("categorie")]
        public int categorie { get; set; }
        public int Id { get; set; }
        public int Qte { get; set; }
        public decimal Prix { get; set; }
        public required string Nom { get; set; }
        public DateTime DatePerime { get; set; }
        public required string Emplacement { get; set; }
        public required Category Category { get; set; }
    }

    public class JoinProduct
    {
        public int categorie { get; set; }
        public int Id { get; set; }
        public int Qte { get; set; }
        public decimal Prix { get; set; }
        public required string Nom { get; set; }
        public DateTime DatePerime { get; set; }
        public required string Emplacement { get; set; }
        public required Category Category { get; set; }
    }

    public class Commande
    {
        [ForeignKey("Client")]
        public int id_client { get; set; }
        [ForeignKey("Product")]
        public int id_product { get; set; }
        public int Qte { get; set; }
        public DateTime DateComm { get; set; }
        public required string Status { get; set; }
        public required Client Client { get; set; }
        public required Product Product { get; set; }
    }

    public class JoinCommande
    {
        public int id_client { get; set; }
        public int id_product { get; set; }
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
