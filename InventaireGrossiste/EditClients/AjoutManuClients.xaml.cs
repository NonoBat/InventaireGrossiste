using System.Windows;
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditClients
{
    /// <summary>
    /// Logique d'interaction pour AjoutManuClients.xaml
    /// </summary>
    public partial class AjoutManuClients : Window
    {
        public Client NouveauClient { get; set; } 

        public AjoutManuClients()
        {
            InitializeComponent();
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AreFieldsValid())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant d'ajouter le client.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Créer un nouveau client avec les informations saisies
            NouveauClient = new Client
            {
                Nom = NomTextBox.Text,
                Adresse = AdresseTextBox.Text,
                Siret = SiretTextBox.Text
            };

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }

        private bool AreFieldsValid()
        {
            // Vérifiez ici que tous les champs nécessaires sont remplis
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(AdresseTextBox.Text) || string.IsNullOrWhiteSpace(SiretTextBox.Text))
            {
                return false;
            }

            // Ajoutez d'autres vérifications si nécessaire
            return true;
        }


    }
}
