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
        public Product NouveauProduit { get; private set; }

        public AjoutManuProducts()
        {
            InitializeComponent();
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            // Créer un nouveau produit avec les informations saisies
            NouveauProduit = new Product
            {
                Nom = NomTextBox.Text,
                Prix = int.Parse(prixTextBox.Text),
                Qte = int.Parse(QteTextBox.Text),
                DatePerime = DateTime.Parse(DLCTextBox.Text),
                Emplacement = EmpTextBox.Text,
                Categorie = new Category { Nom = CategorieTextBox.Text }
            };

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }
    }
}
