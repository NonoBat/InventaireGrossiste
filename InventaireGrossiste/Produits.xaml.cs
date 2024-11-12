using System;
using System.Collections.Generic;
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

        public Produits()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadProduits();
        }

        private void LoadProduits()
        {
            // Récupérer les produits de la base de données
            List<Product> produits = GetProduitsFromDatabase();
            ProduitsListView.ItemsSource = produits;
        }

        private List<Product> GetProduitsFromDatabase()
        {
            // Récupérer les données de la base de données
            return _context.Products.ToList();
        }

        private void AjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            // Afficher une fenêtre de dialogue pour saisir les informations du produit
            var dialog = new AjoutManuProducts();
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
            // Ajouter le produit à la base de données
            _context.Products.Add(produit);
            _context.SaveChanges();
        }

        private void ModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un produit est sélectionné
            if (ProduitsListView.SelectedItem is Product selectedProduit)
            {
                // Ouvrir la fenêtre de modification avec les informations du produit sélectionné
                var dialog = new ModifManuProducts(selectedProduit);
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
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.");
            }
        }

        private void ModifierProduit(Product produit)
        {
            // Mettre à jour le produit dans la base de données
            var produitExistant = _context.Products.Find(produit.Id);
            if (produitExistant != null)
            {
                produitExistant.Nom = produit.Nom;
                produitExistant.Qte = produit.Qte;
                produitExistant.Prix = produit.Prix;
                produitExistant.DatePerime = produit.DatePerime;
                produitExistant.CategorieId = produit.CategorieId;
                produitExistant.Emplacement = produit.Emplacement;
                _context.SaveChanges();
            }
        }

        private void SupprimerProduit_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un produit est sélectionné
            if (ProduitsListView.SelectedItem is Product selectedProduit)
            {
                // Afficher une fenêtre de confirmation pour la suppression du produit
                var dialog = new EraseManuProducts(selectedProduit);
                if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                {
                    // Supprimer le produit de la base de données
                    SupprimerProduit(selectedProduit);

                    // Recharger la liste des produits
                    LoadProduits();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
            }
        }

        private void SupprimerProduit(Product produit)
        {
            // Supprimer le produit de la base de données
            var produitExistant = _context.Products.Find(produit.Id);
            if (produitExistant != null)
            {
                _context.Products.Remove(produitExistant);
                _context.SaveChanges();
            }
        }
    }
}
