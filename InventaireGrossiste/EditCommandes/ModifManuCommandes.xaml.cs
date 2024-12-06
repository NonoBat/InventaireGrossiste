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
using SQLitePCL;

namespace InventaireGrossiste.EditCommandes
{
    /// <summary>
    /// Logique d'interaction pour ModifManuCommandes.xaml
    /// </summary>
    public partial class ModifManuCommandes : Window
    {
        private readonly ApplicationDbContext _context;
        private readonly int _ancienneQuantite;
        public Commande CommandeModifiee { get; private set; }

        public ModifManuCommandes(Commande commande, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            CommandeModifiee = commande;
            _ancienneQuantite = commande.Qte;
            DataContext = CommandeModifiee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var produit = _context.Products.Find(CommandeModifiee.id_product);
            if (produit != null)
            {
                int difference = CommandeModifiee.Qte - _ancienneQuantite;

                if (difference > 0)
                {
                    // Si la nouvelle quantité est supérieure à l'ancienne, soustraire la différence du stock
                    if (produit.Qte >= difference)
                    {
                        produit.Qte -= difference;
                    }
                    else
                    {
                        MessageBox.Show("Stock insuffisant pour cette modification.");
                        return;
                    }
                }
                else if (difference < 0)
                {
                    // Si la nouvelle quantité est inférieure à l'ancienne, ajouter la différence au stock
                    produit.Qte += Math.Abs(difference);
                }

                // Enregistrer les modifications dans le contexte de la base de données
                _context.SaveChanges();
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Produit introuvable.");
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
