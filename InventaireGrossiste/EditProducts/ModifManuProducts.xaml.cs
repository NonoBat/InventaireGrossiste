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
using System.Windows.Shapes;
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditProducts
{
    /// <summary>
    /// Logique d'interaction pour ModifManuProducts.xaml
    /// </summary>
    public partial class ModifManuProducts : Window
    {
        private readonly ApplicationDbContext _context;
        public Product ProduitModifie { get; private set; }

        public ModifManuProducts(Product produit, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            ProduitModifie = produit;
            DataContext = ProduitModifie;
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Charger les catégories depuis la base de données
            var categories = _context.Categories.ToList();
            CategorieComboBox.ItemsSource = categories;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!AreFieldsValid())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant de sauvegarder les modifications.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Valider les modifications et fermer la fenêtre de dialogue
            ProduitModifie.DatePerime = DLCDatePicker.SelectedDate ?? ProduitModifie.DatePerime;
            DialogResult = true;
            Close();
        }

        private bool AreFieldsValid()
        {
            // Vérifiez ici que tous les champs nécessaires sont remplis
            if (string.IsNullOrWhiteSpace(ProduitModifie.Nom) || string.IsNullOrWhiteSpace(ProduitModifie.Emplacement) || ProduitModifie.Prix <= 0 || ProduitModifie.Qte < 0 || CategorieComboBox.SelectedItem == null)
            {
                return false;
            }

            // Ajoutez d'autres vérifications si nécessaire
            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Annuler les modifications et fermer la fenêtre de dialogue
            DialogResult = false;
            Close();
        }
    }
}
