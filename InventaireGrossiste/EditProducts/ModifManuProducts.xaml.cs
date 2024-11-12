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
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditProducts
{
    /// <summary>
    /// Logique d'interaction pour ModifManuProducts.xaml
    /// </summary>
    public partial class ModifManuProducts : Window
    {
        public Product ProduitModifie { get; private set; }

        public ModifManuProducts(Product produit)
        {
            InitializeComponent();
            ProduitModifie = produit;
            DataContext = ProduitModifie;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Valider les modifications et fermer la fenêtre de dialogue
            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Annuler les modifications et fermer la fenêtre de dialogue
            DialogResult = false;
            Close();
        }
    }
}
