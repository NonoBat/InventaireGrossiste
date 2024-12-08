using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InventaireGrossiste.EditProducts;
using InventaireGrossiste.Models;

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour Produits.xaml
    /// </summary>
    public partial class Produits : Page
    {
        private readonly ApplicationDbContext _context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Produits(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            Logger.Info("Initialisation de la classe Produits.");
            LoadProduits();
        }

        private void LoadProduits()
        {
            // Récupérer les produits de la base de données
            List<JoinProduct> produits = GetProduitsFromDatabase();
            ProduitsListView.ItemsSource = produits;
        }

        private List<JoinProduct> GetProduitsFromDatabase()
        {
            // récupérer les données de la base de données
            return _context.Products
                .Include(p => p.Category)
                .Select(p => new JoinProduct
                {
                    Id = p.Id,
                    Qte = p.Qte,
                    Prix = p.Prix,
                    Nom = p.Nom,
                    DatePerime = p.DatePerime,
                    categorie = p.categorie,
                    Emplacement = p.Emplacement,
                    Category = new Category
                    {
                        Id = p.Category.Id,
                        Nom = p.Category.Nom
                    }
                })
                .ToList();
        }

        private void AjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            // Afficher une fenêtre de dialogue pour saisir les informations du produit
            var dialog = new AjoutManuProducts(_context);
            if (dialog.ShowDialog() == true)
            {
                // Récupérer les informations du produit depuis la fenêtre de dialogue
                var nouveauProduit = dialog.NouveauProduit;

                // Ajouter le produit à la base de données
                AjouterProduit(nouveauProduit);

                // Recharger la liste des produits
                LoadProduits();
            }
        }

        private void AjouterProduit(Product produit)
        {
            try
            {
                // Ajouter le produit à la base de données
                _context.Products.Add(produit);
                _context.SaveChanges();
                Logger.Info("Ajout | Utilisateur: {0} | Entité: Produit {1} | Produit ajouté avec succès.",
                    "UtilisateurActuel", produit.Id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Produit {1} | Erreur lors de l'ajout du produit.",
                    "UtilisateurActuel", produit.Id);
            }
        }

        private void ModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un produit est sélectionné
            if (ProduitsListView.SelectedItem is JoinProduct selectedProduit)
            {
                // Récupérer le produit complet depuis la base de données
                var produit = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == selectedProduit.Id);

                if (produit != null)
                {
                    // Ouvrir la fenêtre de modification avec les informations du produit sélectionné
                    var dialog = new ModifManuProducts(produit, _context);
                    if (dialog.ShowDialog() == true)
                    {
                        // Récupérer les informations modifiées du produit depuis la fenêtre de dialogue
                        var produitModifie = dialog.ProduitModifie;

                        // Mettre à jour les informations du produit dans la base de données
                        ModifierProduit(produitModifie);

                        // Recharger la liste des produits
                        LoadProduits();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.");
            }
        }

        private void ModifierProduit(Product produit)
        {
            try
            {
                // Mettre à jour le produit dans la base de données
                var produitExistant = _context.Products.Find(produit.Id);
                if (produitExistant != null)
                {
                    produitExistant.Nom = produit.Nom;
                    produitExistant.Qte = produit.Qte;
                    produitExistant.Prix = produit.Prix;
                    produitExistant.DatePerime = produit.DatePerime;
                    produitExistant.categorie = produit.categorie;
                    produitExistant.Emplacement = produit.Emplacement;
                    _context.SaveChanges();
                    Logger.Info("Modification | Utilisateur: {0} | Entité: Produit {1} | Produit modifié avec succès.",
                        "UtilisateurActuel", produit.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Produit {1} | Erreur lors de la modification du produit.",
                    "UtilisateurActuel", produit.Id);
            }
        }

        private void SupprimerProduit_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un produit est sélectionné
            if (ProduitsListView.SelectedItem is JoinProduct selectedProduit)
            {
                // Récupérer le produit complet depuis la base de données
                var produit = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == selectedProduit.Id);

                if (produit != null)
                {
                    // Afficher une fenêtre de confirmation pour la suppression du produit
                    var dialog = new EraseManuProducts(produit);
                    if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                    {
                        // Supprimer le produit de la base de données
                        SupprimerProduit(produit);

                        // Recharger la liste des produits
                        LoadProduits();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
            }
        }

        private void SupprimerProduit(Product produit)
        {
            try
            {
                // Supprimer le produit de la base de données
                var produitExistant = _context.Products.Find(produit.Id);
                if (produitExistant != null)
                {
                    _context.Products.Remove(produitExistant);
                    _context.SaveChanges();
                    Logger.Info("Suppression | Utilisateur: {0} | Entité: Produit {1} | Produit supprimé avec succès.",
                        "UtilisateurActuel", produit.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Produit {1} | Erreur lors de la suppression du produit.",
                    "UtilisateurActuel", produit.Id);
            }
        }
    }
}
