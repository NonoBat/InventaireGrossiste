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
    }
}
