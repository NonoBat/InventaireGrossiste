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

namespace InventaireGrossiste.EditCategories
{
    /// <summary>
    /// Logique d'interaction pour ModifManuCategories.xaml
    /// </summary>
    public partial class ModifManuCategories : Window
    {
        public Category CategorieModifiee { get; private set; }

        public ModifManuCategories(Category category)
        {
            InitializeComponent();
            CategorieModifiee = category;
            DataContext = CategorieModifiee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Valider les modifications et fermer la fenêtre de dialogue
            if (CategorieModifiee != null)
            {
                // Vous pouvez ajouter des validations ici si nécessaire
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Erreur : La catégorie modifiée est null.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Annuler les modifications et fermer la fenêtre de dialogue
            DialogResult = false;
            Close();
        }
    }
}
