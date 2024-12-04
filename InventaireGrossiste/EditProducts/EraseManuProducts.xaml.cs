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
    /// Logique d'interaction pour EraseManuProducts.xaml
    /// </summary>
    public partial class EraseManuProducts : Window
    {
        public bool IsConfirmed { get; private set; }
        private readonly Product ProductToDelete;

        public EraseManuProducts(Product produit)
        {
            InitializeComponent();
            ProductToDelete = produit;
            DataContext = ProductToDelete;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirmer la suppression
            IsConfirmed = true;
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Annuler la suppression
            IsConfirmed = false;
            this.DialogResult = false;
            this.Close();
        }
    }
}
