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

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour InscriptionsWindows.xaml
    /// </summary>
    public partial class InscriptionsWindows : Window
    {
        public InscriptionsWindow()
        {
            InitializeComponent();
        }

        private void Inscrire_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les valeurs des champs Email et Mot de Passe
            string email = InscmailBox.Text;
            string password = InscpasswordBox.Password;

            // Vérification simple pour s'assurer que les champs ne sont pas vides
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // Ajouter l'utilisateur à la base de données
                if (DatabaseHelper.AddUser(email, password))
                {
                    MessageBox.Show("Inscription réussie !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Fermer la fenêtre d'inscription
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'inscription. Veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

