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

namespace InventaireGrossiste.EditClients
{
    /// <summary>
    /// Logique d'interaction pour ModifManuClients.xaml
    /// </summary>
    public partial class ModifManuClients : Window
    {
        public Client ClientModifie { get; private set; }

        public ModifManuClients(Client client)
        {
            InitializeComponent();
            ClientModifie = client;
            DataContext = ClientModifie;
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
