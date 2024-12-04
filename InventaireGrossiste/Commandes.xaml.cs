using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventaireGrossiste.EditClients;
using InventaireGrossiste.EditCommandes;
using InventaireGrossiste.Models;

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour Commandes.xaml
    /// </summary>
    public partial class Commandes : Page
    {
        private readonly ApplicationDbContext _context;

        public Commandes(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadCommandes();
        }

        private void LoadCommandes()
        {
            // Récupérer les commandes de la base de données
            List<JoinCommande> commandes = GetCommandesFromDatabase();

            CommandesListView.ItemsSource = commandes;
        }

        private List<JoinCommande> GetCommandesFromDatabase()
        {
            // Récupérer les données de la base de données
            return _context.Commandes
                .Include(c => c.Client)
                .Include(c => c.Product)
                .Select(c => new JoinCommande
            {
                id_client = c.id_client,
                id_product = c.id_product,
                Qte = c.Qte,
                DateComm = c.DateComm,
                Status = c.Status,
                    Client = new Client
                    {
                        Id = c.Client.Id,
                        Nom = c.Client.Nom,
                        Adresse = c.Client.Adresse,
                        Siret = c.Client.Siret
                    },
                
                    Product = new Product
                    {
                        Id = c.Product.Id,
                        Nom = c.Product.Nom,
                        Qte = c.Product.Qte,
                        Prix = c.Product.Prix,
                        DatePerime = c.Product.DatePerime,
                        Emplacement = c.Product.Emplacement,
                        Category = c.Product.Category
                    }
                }).ToList();

        }

            private void AjouterCommande_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les clients et les produits de la base de données
            var clients = _context.Clients.ToList();
            var produits = _context.Products.ToList();

            // Afficher une fenêtre de dialogue pour saisir les informations de la commande
            var dialog = new AjoutManuCommandes(clients, produits);
            if (dialog.ShowDialog() == true)
            {
                // Récupérer les informations de la commande depuis la fenêtre de dialogue
                var nouvelleCommande = dialog.NouvelleCommande;

                // Ajouter la commande à la base de données
                AjouterCommande(nouvelleCommande);

                // Recharger la liste des commandes
                LoadCommandes();
            }
        }

        private void AjouterCommande(Commande commande)
        {
            // Ajouter la commande à la base de données
            _context.Commandes.Add(commande);
            _context.SaveChanges();
        }

        private void ModifierCommande_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si une commande est sélectionnée
            if (CommandesListView.SelectedItem is JoinCommande selectedCommande)
            {
                // Récupérer la commande complète depuis la base de données
                var commande = _context.Commandes
                    .Include(c => c.Client)
                    .Include(c => c.Product)
                    .FirstOrDefault(c => c.id_client == selectedCommande.id_client && c.id_product == selectedCommande.id_product);

                if (commande != null)
                {
                    // Ouvrir la fenêtre de modification avec les informations de la commande sélectionnée
                    var dialog = new ModifManuCommandes(commande, _context);
                    if (dialog.ShowDialog() == true)
                    {
                        // Récupérer les informations modifiées de la commande depuis la fenêtre de dialogue
                        var commandeModifiee = dialog.CommandeModifiee;

                        // Mettre à jour les informations de la commande dans la base de données
                        ModifierCommande(commandeModifiee);

                        // Recharger la liste des commandes
                        LoadCommandes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.");
            }
        }


        private void ModifierCommande(Commande commande)
        {
            // Mettre à jour la commande dans la base de données
            var commandeExistante = _context.Commandes.Find(commande.id_client, commande.id_product);
            if (commandeExistante != null)
            {
                commandeExistante.Qte = commande.Qte;
                commandeExistante.DateComm = commande.DateComm;
                commandeExistante.Status = commande.Status;
                _context.SaveChanges();
            }
        }

        private void SupprimerCommande_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si une commande est sélectionnée
            if (CommandesListView.SelectedItem is JoinCommande selectedCommande)
            {
                var commande = new Commande
                {
                    id_client = selectedCommande.id_client,
                    id_product = selectedCommande.id_product,
                    Qte = selectedCommande.Qte,
                    DateComm = selectedCommande.DateComm,
                    Status = selectedCommande.Status,
                    Client = selectedCommande.Client,
                    Product = selectedCommande.Product
                };

                // Afficher une fenêtre de confirmation pour la suppression de la commande
                var dialog = new EraseManuCommandes(commande);
                if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                {
                    // Supprimer la commande de la base de données
                    SupprimerCommande(selectedCommande);

                    // Recharger la liste des commandes
                    LoadCommandes();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.");
            }
        }

        private void SupprimerCommande(JoinCommande joinCommande)
        {
            // Supprimer la commande de la base de données
            var commandeExistante = _context.Commandes.Find(joinCommande.id_client, joinCommande.id_product);
            if (commandeExistante != null)
            {
                _context.Commandes.Remove(commandeExistante);
                _context.SaveChanges();
            }
        }

    }
}
