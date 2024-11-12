using System;
using System.Collections.Generic;
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
using InventaireGrossiste.EditCategories;
using InventaireGrossiste.EditClients;
using InventaireGrossiste.Models;

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        private readonly ApplicationDbContext _context;

        public Categories()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Récupérer les catégories de la base de données
            List<Category> categories = GetCategoriesFromDatabase();

            CategoriesListView.ItemsSource = categories;
        }

        private List<Category> GetCategoriesFromDatabase()
        {
            // Récupérer les données de la base de données
            return _context.Categories.Select(c => new Category
            {
                Id = c.Id,
                Nom = c.Nom
            }).ToList();
        }

        private void AjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            // Afficher une fenêtre de dialogue pour saisir les informations de la catégorie
            var dialog = new AjoutManuCategories();
            if (dialog.ShowDialog() == true)
            {
                // Récupérer les informations de la catégorie depuis la fenêtre de dialogue
                var nouvelleCategory = dialog.NouvelleCategory;

                // Ajouter la catégorie à la base de données
                AjouterCategorie(nouvelleCategory);

                // Recharger la liste des catégories
                LoadCategories();
            }
        }

        private void AjouterCategorie(Category category)
        {
            // Ajouter la catégorie à la base de données
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        private void ModifierCategorie_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si une catégorie est sélectionnée
            if (CategoriesListView.SelectedItem is Category selectedCategory)
            {
                // Ouvrir la fenêtre de modification avec les informations de la catégorie sélectionnée
                var dialog = new ModifManuCategories(selectedCategory);
                if (dialog.ShowDialog() == true)
                {
                    // Récupérer les informations modifiées de la catégorie depuis la fenêtre de dialogue
                    var categorieModifiee = dialog.CategorieModifiee;

                    // Mettre à jour les informations de la catégorie dans la base de données
                    ModifierCategorie(categorieModifiee);

                    // Recharger la liste des catégories
                    LoadCategories();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une catégorie à modifier.");
            }
        }

        private void ModifierCategorie(Category category)
        {
            // Mettre à jour la catégorie dans la base de données
            var categorieExistante = _context.Categories.Find(category.Id);
            if (categorieExistante != null)
            {
                categorieExistante.Nom = category.Nom;
                _context.SaveChanges();
            }
        }

        private void SupprimerCategorie_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si une catégorie est sélectionnée
            if (CategoriesListView.SelectedItem is Category selectedCategory)
            {
                // Afficher une fenêtre de confirmation pour la suppression de la catégorie
                var dialog = new EraseManuCategories(selectedCategory);
                if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                {
                    // Supprimer la catégorie de la base de données
                    SupprimerCategorie(selectedCategory);

                    // Recharger la liste des catégories
                    LoadCategories();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une catégorie à supprimer.");
            }
        }

        private void SupprimerCategorie(Category category)
        {
            // Supprimer la catégorie de la base de données
            var categorieExistante = _context.Categories.Find(category.Id);
            if (categorieExistante != null)
            {
                _context.Categories.Remove(categorieExistante);
                _context.SaveChanges();
            }
        }
    }
}
