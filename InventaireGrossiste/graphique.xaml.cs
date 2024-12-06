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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;
using InventaireGrossiste.ressources;

namespace InventaireGrossiste
{
    public partial class Graphique : Page
    {
        ApplicationDbContext _context;

        public Graphique(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();

            CheckProductQuantities();

            // Générer le fichier HTML avec le graphique
            try
            {
                var generator = new GeneratorHTML(_context);
                generator.GenererFichierHTML();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération du fichier HTML : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
        private void CheckProductQuantities()
        {
            var lowStockProducts = _context.Products.Where(p => p.Qte < 5).ToList();
            if (lowStockProducts.Any())
            {
                var warningMessage = "ATTENTION /!\\ Quantité faible en stock : ";
                foreach (var product in lowStockProducts)
                {
                    warningMessage += $"| {product.Qte} {product.Nom} ";
                }
                WarningTextBlock.Text = warningMessage;
                WarningTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}

