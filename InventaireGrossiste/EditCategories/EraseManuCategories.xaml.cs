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
    /// Logique d'interaction pour EraseManuCategories.xaml
    /// </summary>
    public partial class EraseManuCategories : Window
    {
        public bool IsConfirmed { get; private set; }
        public Category CategoryToDelete { get; }

        public EraseManuCategories(Category category)
        {
            InitializeComponent();
            CategoryToDelete = category;
            DataContext = category;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            Close();
        }
    }
}