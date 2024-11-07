using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventaireGrossiste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les valeurs des champs Email et Mot de Passe
            string email = mailBox.Text;
            string password = passwordBox.Password;

            // Vérifier si l'email et le mot de passe sont valides
            if (DatabaseHelper.ValidateUser(email, password))
            {
                MessageBox.Show("Connexion réussie !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                // Redirigez ou effectuez d'autres actions après la connexion réussie
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Inscrire_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Ouvrir la fenêtre d'inscription
            InscriptionWindow inscriptionWindow = new InscriptionWindow();
            inscriptionWindow.Show();
        }
    }
}