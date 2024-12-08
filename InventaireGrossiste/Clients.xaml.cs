using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InventaireGrossiste.Models;
using Microsoft.EntityFrameworkCore;
using InventaireGrossiste.EditClients;

namespace InventaireGrossiste
{
    /// <summary>
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        private readonly ApplicationDbContext _context;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Clients()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            Logger.Info("Initialisation de la classe Clients.");
            LoadClients();
        }

        private void LoadClients()
        {
            // Récupérer les clients de la base de données
            List<Client> clients = GetClientsFromDatabase();
            ClientsListView.ItemsSource = clients;
        }

        private List<Client> GetClientsFromDatabase()
        {
            // Récupérer les données de la base de données
            return _context.Clients.Select(c => new Client
            {
                Id = c.Id,
                Nom = c.Nom,
                Adresse = c.Adresse,
                Siret = c.Siret
            }).ToList();
        }

        private void AjouterClient_Click(object sender, RoutedEventArgs e)
        {
            // Afficher une fenêtre de dialogue pour saisir les informations du client
            var dialog = new AjoutManuClients();
            if (dialog.ShowDialog() == true)
            {
                // Récupérer les informations du client depuis la fenêtre de dialogue
                var nouveauClient = dialog.NouveauClient;

                // Ajouter le client à la base de données
                AjouterClient(nouveauClient);

                // Recharger la liste des clients
                LoadClients();
            }
        }

        private void AjouterClient(Client client)
        {
            try
            {
                // Ajouter le client à la base de données
                _context.Clients.Add(client);
                _context.SaveChanges();
                Logger.Info("Ajout | Utilisateur: {0} | Entité: Client {1} | Client ajouté avec succès.",
                    "UtilisateurActuel", client.Id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Client {1} | Erreur lors de l'ajout du client.",
                    "UtilisateurActuel", client.Id);
            }
        }

        private void ModifierClient_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un client est sélectionné
            if (ClientsListView.SelectedItem is Client selectedClient)
            {
                // Ouvrir la fenêtre de modification avec les informations du client sélectionné
                var dialog = new ModifManuClients(selectedClient);
                if (dialog.ShowDialog() == true)
                {
                    // Récupérer les informations modifiées du client depuis la fenêtre de dialogue
                    var clientModifie = dialog.ClientModifie;

                    // Mettre à jour les informations du client dans la base de données
                    ModifierClient(clientModifie);

                    // Recharger la liste des clients
                    LoadClients();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.");
            }
        }

        private void ModifierClient(Client client)
        {
            try
            {
                // Mettre à jour le client dans la base de données
                var clientExistant = _context.Clients.Find(client.Id);
                if (clientExistant != null)
                {
                    clientExistant.Nom = client.Nom;
                    clientExistant.Adresse = client.Adresse;
                    clientExistant.Siret = client.Siret;
                    _context.SaveChanges();
                    Logger.Info("Modification | Utilisateur: {0} | Entité: Client {1} | Client modifié avec succès.",
                        "UtilisateurActuel", client.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Client {1} | Erreur lors de la modification du client.",
                    "UtilisateurActuel", client.Id);
            }
        }

        private void SupprimerClient_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un client est sélectionné
            if (ClientsListView.SelectedItem is Client selectedClient)
            {
                // Afficher une fenêtre de confirmation pour la suppression du client
                var dialog = new EraseManuClients(selectedClient);
                if (dialog.ShowDialog() == true && dialog.IsConfirmed)
                {
                    // Supprimer le client de la base de données
                    SupprimerClient(selectedClient);

                    // Recharger la liste des clients
                    LoadClients();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.");
            }
        }

        private void SupprimerClient(Client client)
        {
            try
            {
                // Supprimer le client de la base de données
                var clientExistant = _context.Clients.Find(client.Id);
                if (clientExistant != null)
                {
                    _context.Clients.Remove(clientExistant);
                    _context.SaveChanges();
                    Logger.Info("Suppression | Utilisateur: {0} | Entité: Client {1} | Client supprimé avec succès.",
                        "UtilisateurActuel", client.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erreur | Utilisateur: {0} | Entité: Client {1} | Erreur lors de la suppression du client.",
                    "UtilisateurActuel", client.Id);
            }
        }
    }
}
