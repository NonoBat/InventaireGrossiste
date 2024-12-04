using System;
using System.Windows;
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditProducts
{
    /// <summary>
    /// Logique d'interaction pour AjoutManuProducts.xaml
    /// </summary>
    public partial class AjoutManuProducts : Window
    {
        private readonly ApplicationDbContext _context;
        public Product NouveauProduit { get; private set; }

        public AjoutManuProducts(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadCategories();
        }
        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();
            CategorieComboBox.ItemsSource = categories;
            CategorieComboBox.DisplayMemberPath = "Nom";
            CategorieComboBox.SelectedValuePath = "Id";
        }
        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            // Créer un nouveau produit avec les informations saisies
            NouveauProduit = new Product
            {
                Nom = NomTextBox.Text,
                Prix = decimal.Parse(prixTextBox.Text),
                Qte = int.Parse(QteTextBox.Text),
                DatePerime = DateTime.Parse(DLCTextBox.Text),
                Emplacement = EmpTextBox.Text,
                Category = (Category)CategorieComboBox.SelectedItem
                //Category = new Category { Nom = CategorieComboBox.Text }
            };

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }
    }
}
