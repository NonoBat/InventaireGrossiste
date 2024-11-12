using System.Windows;
using InventaireGrossiste.Models;

namespace InventaireGrossiste.EditClients
{
    /// <summary>
    /// Logique d'interaction pour EraseManuClients.xaml
    /// </summary>
    public partial class EraseManuClients : Window
    {
        public bool IsConfirmed { get; private set; }
        private readonly Client ClientToDelete;

        public EraseManuClients(Client client)
        {
            InitializeComponent();
            ClientToDelete = client;
            DataContext = ClientToDelete;
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
