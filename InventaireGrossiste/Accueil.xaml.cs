using System;
using System.Collections.Generic;
using System.IO;
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
using InventaireGrossiste.ressources;

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        ApplicationDbContext _context;

        public Accueil(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();

            // Générer le fichier HTML avec le graphique
            var generator = new GeneratorHTML(_context);
            generator.GenererFichierHTML();

            // Chemin du fichier HTML généré
            string cheminFichier = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "ressources", "chart.html");
            // Vérifier si le fichier existe avant de charger

            if (File.Exists(cheminFichier))
            {
                ChartWebView.Source = new Uri($"file:///{cheminFichier.Replace("\\", "/")}");
            }
            else
            {
                MessageBox.Show("Le fichier chart.html n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAccueil_Clicks(object sender, RoutedEventArgs e)
        {
            // Fermer toutes les pages et revenir à l'accueil
            MainFrame.Content = null;
        }

        private void BtnClients_Clicks(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Clients());
        }

        private void BtnCommandes_Clicks(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Commandes(_context));
        }
        private void BtnProducts_Clicks(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Produits(_context));
        }

        private void BtnCategorie_Clicks(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Categories());
        }
    }
}
