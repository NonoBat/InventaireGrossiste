﻿using System;
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
    /// Logique d'interaction pour AjoutManuCategories.xaml
    /// </summary>
    public partial class AjoutManuCategories : Window
    {
        public Category NouvelleCategory { get; set; }

        public AjoutManuCategories()
        {
            InitializeComponent();
            NouvelleCategory = new Category
            {
                Nom = NomTextBox.Text
            };
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AreFieldsValid())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant d'ajouter la catégorie.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Créer une nouvelle catégorie avec les informations saisies
            NouvelleCategory.Nom = NomTextBox.Text;

            // Fermer la fenêtre de dialogue et retourner le résultat
            DialogResult = true;
            Close();
        }

        private bool AreFieldsValid()
        {
            // Vérifiez ici que tous les champs nécessaires sont remplis
            if (string.IsNullOrWhiteSpace(NomTextBox.Text))
            {
                return false;
            }

            // Ajoutez d'autres vérifications si nécessaire
            return true;
        }

    }
}
