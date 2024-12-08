using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InventaireGrossiste.EditClients;
using InventaireGrossiste.EditCommandes;
using InventaireGrossiste.Models;

namespace InventaireGrossiste
{
    public partial class Commandes : Page
    {
        private readonly ApplicationDbContext _context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Commandes(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            Logger.Info("Test de log NLog - initialisation de la classe Commandes.");
            LoadCommandes();
        }

        private void LoadCommandes()
        {
            List<JoinCommande> commandes = GetCommandesFromDatabase();
            CommandesListView.ItemsSource = commandes;
        }

        private List<JoinCommande> GetCommandesFromDatabase()
        {
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
            var clients = _context.Clients.ToList();
            var produits = _context.Products.ToList();

            var dialog = new AjoutManuCommandes(clients, produits);
            if (dialog.ShowDialog() == true)
            {
                var nouvelleCommande = dialog.NouvelleCommande;
                AjouterCommande(nouvelleCommande);
                LoadCommandes();
            }
        }

        private void AjouterCommande(Commande commande)
        {
            try
            {
                _context.Commandes.Add(commande);
                _context.SaveChanges();
                Logger.Info("Ajout | Utilisateur: {0} | Entité: Commande {1}-{2} | Commande ajoutée avec succès.",
                    "UtilisateurActuel", commande.id_client, commande.id_product);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Commande {1}-{2} | Erreur lors de l'ajout de la commande.",
                    "UtilisateurActuel", commande.id_client, commande.id_product);
            }
        }

        private void ModifierCommande_Click(object sender, RoutedEventArgs e)
        {
            if (CommandesListView.SelectedItem is JoinCommande selectedCommande)
            {
                var commande = _context.Commandes
                    .Include(c => c.Client)
                    .Include(c => c.Product)
                    .FirstOrDefault(c => c.id_client == selectedCommande.id_client && c.id_product == selectedCommande.id_product);

                if (commande != null)
                {
                    var dialog = new ModifManuCommandes(commande, _context);
                    if (dialog.ShowDialog() == true)
                    {
                        var commandeModifiee = dialog.CommandeModifiee;
                        ModifierCommande(commandeModifiee);
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
            try
            {
                var commandeExistante = _context.Commandes.Find(commande.id_client, commande.id_product);
                if (commandeExistante != null)
                {
                    commandeExistante.Qte = commande.Qte;
                    commandeExistante.DateComm = commande.DateComm;
                    commandeExistante.Status = commande.Status;
                    _context.SaveChanges();
                    Logger.Info("Modification | Utilisateur: {0} | Entité: Commande {1}-{2} | Commande modifiée avec succès.",
                        "UtilisateurActuel", commande.id_client, commande.id_product);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Commande {1}-{2} | Erreur lors de la modification de la commande.",
                    "UtilisateurActuel", commande.id_client, commande.id_product);
            }
        }

        private void SupprimerCommande_Click(object sender, RoutedEventArgs e)
        {
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

                var dialog = new EraseManuCommandes(commande, _context);
                if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                {
                    SupprimerCommande(selectedCommande);
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
            try
            {
                var commandeExistante = _context.Commandes.Find(joinCommande.id_client, joinCommande.id_product);
                if (commandeExistante != null)
                {
                    _context.Commandes.Remove(commandeExistante);
                    _context.SaveChanges();
                    Logger.Info("Suppression | Utilisateur: {0} | Entité: Commande {1}-{2} | Commande supprimée avec succès.",
                        "UtilisateurActuel", joinCommande.id_client, joinCommande.id_product);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Commande {1}-{2} | Erreur lors de la suppression de la commande.",
                    "UtilisateurActuel", joinCommande.id_client, joinCommande.id_product);
            }
        }
    }
}
