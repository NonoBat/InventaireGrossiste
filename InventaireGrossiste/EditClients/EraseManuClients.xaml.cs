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
        public Client ClientToDelete { get; }

        public EraseManuClients(Client client)
        {
            InitializeComponent();
            ClientToDelete = client;
            DataContext = client;
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