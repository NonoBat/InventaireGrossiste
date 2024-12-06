using System;
using System.Collections.Generic;
using System.Windows;
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditCommandes
{
    /// <summary>
    /// Logique d'interaction pour AjoutManuCommandes.xaml
    /// </summary>
    public partial class AjoutManuCommandes : Window
    {
        public Commande NouvelleCommande { get; set; }
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

        public AjoutManuCommandes(List<Client> clients, List<Product> products)
        {
            InitializeComponent();
            Clients = clients;
            Products = products;

            ClientComboBox.ItemsSource = Clients;
            ProductComboBox.ItemsSource = Products;
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le produit sélectionné
            var selectedProduct = (Product)ProductComboBox.SelectedItem;
            int commandeQte = int.Parse(qteTextBox.Text);

            // Vérifier si la quantité de la commande est supérieure à la quantité disponible
            if (commandeQte > selectedProduct.Qte)
            {
                int qteManquante = commandeQte - selectedProduct.Qte;
                MessageBox.Show($"Manquant ; il vous manque {qteManquante} {selectedProduct.Nom}", "Erreur de quantité", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Mettre à jour la quantité du produit
            selectedProduct.Qte -= commandeQte;


            // Créer une nouvelle commande avec les informations saisies
            NouvelleCommande = new Commande
            {
                id_client = (int)ClientComboBox.SelectedValue,
                id_product = (int)ProductComboBox.SelectedValue,
                Qte = int.Parse(qteTextBox.Text),
                DateComm = DateTime.Parse(DateCommTextBox.Text),
                Status = StatusTextBox.Text,
                Client = (Client)ClientComboBox.SelectedItem,
                Product = (Product)ProductComboBox.SelectedItem
            };

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }
    }
}
