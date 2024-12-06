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

namespace InventaireGrossiste.EditCommandes
{
    /// <summary>
    /// Logique d'interaction pour EraseManuCommandes.xaml
    /// </summary>
    public partial class EraseManuCommandes : Window
    {
        public bool IsConfirmed { get; private set; }
        private readonly Commande CommandeToDelete;
        private readonly ApplicationDbContext _context;


        public EraseManuCommandes(Commande commande, ApplicationDbContext context)
        {
            InitializeComponent();
            CommandeToDelete = commande;
            _context = context;
            DataContext = CommandeToDelete;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le produit associé à la commande
            var product = _context.Products.Find(CommandeToDelete.id_product);

            if (product != null)
            {
                // Ajouter la quantité de la commande à la quantité du produit
                product.Qte += CommandeToDelete.Qte;

                // Enregistrer les modifications dans le contexte de la base de données
                _context.SaveChanges();
            }
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
