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
            if (!AreFieldsValid())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant d'ajouter le produit. (Attention pour le prix. Il faut une , et non un . )", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Créer un nouveau produit avec les informations saisies
            NouveauProduit = new Product
            {
                Nom = NomTextBox.Text,
                Prix = decimal.Parse(prixTextBox.Text),
                Qte = int.Parse(QteTextBox.Text),
                DatePerime = DLCDatePicker.SelectedDate ?? DateTime.Now,
                Emplacement = EmpTextBox.Text,
                Category = (Category)CategorieComboBox.SelectedItem
            };

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }

        private bool AreFieldsValid()
        {
            // Vérifiez ici que tous les champs nécessaires sont remplis
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(prixTextBox.Text) || string.IsNullOrWhiteSpace(QteTextBox.Text) || string.IsNullOrWhiteSpace(EmpTextBox.Text) || CategorieComboBox.SelectedItem == null)
            {
                return false;
            }

            // Vérifiez que le prix est un nombre valide et supérieur à zéro
            if (!decimal.TryParse(prixTextBox.Text, out decimal prix) || prix <= 0)
            {
                return false;
            }

            // Vérifiez que la quantité est un nombre valide et supérieur ou égal à zéro
            if (!int.TryParse(QteTextBox.Text, out int qte) || qte < 0)
            {
                return false;
            }

            // Ajoutez d'autres vérifications si nécessaire
            return true;
        }



    }
}
