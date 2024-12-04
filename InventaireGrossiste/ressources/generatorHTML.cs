using InventaireGrossiste;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventaireGrossiste.ressources
{
    public class GeneratorHTML
    {
        private readonly ApplicationDbContext _context;

        public GeneratorHTML(ApplicationDbContext context)
        {
            _context = context;
        }

        public void GenererFichierHTML()
        {
            // Obtenir les données cumulées des quantités commandées par produit et par jour
            var commandesParProduitEtJour = _context.Commandes
                .GroupBy(c => new { c.Product.Nom, c.DateComm.Date })  // Grouper par produit et date
                .Select(g => new
                {
                    Produit = g.Key.Nom,
                    Date = g.Key.Date,
                    TotalQuantite = g.Sum(c => c.Qte)  // Somme des quantités par produit et par jour
                })
                .OrderBy(g => g.Date)  // Trier par date
                .ToList();

            // Vérifiez les données générées
            Console.WriteLine("Données des commandes par produit et par jour:");
            foreach (var item in commandesParProduitEtJour)
            {
                Console.WriteLine($"Produit: {item.Produit}, Date: {item.Date}, Quantité: {item.TotalQuantite}");
            }

            // Obtenir la liste des produits distincts
            var produits = commandesParProduitEtJour.Select(c => c.Produit).Distinct().ToList();

            // Créer les données pour le graphique (format attendu par Google Charts)
            StringBuilder dataBuilder = new StringBuilder();
            dataBuilder.AppendLine("[['Date', " + string.Join(", ", produits.Select(p => $"'{p}'")) + "]]");

            // Obtenir la liste des dates distinctes
            var dates = commandesParProduitEtJour.Select(c => c.Date).Distinct().OrderBy(d => d).ToList();

            foreach (var date in dates)
            {
                var quantitesParProduit = produits.Select(p => commandesParProduitEtJour
                    .Where(c => c.Produit == p && c.Date == date)
                    .Select(c => c.TotalQuantite)
                    .FirstOrDefault()).ToList();

                string dateStr = date.ToString("yyyy-MM-dd"); // Format de date (année-mois-jour)
                dataBuilder.AppendLine($"['{dateStr}', {string.Join(", ", quantitesParProduit)}]");
            }

            // HTML du graphique
            string htmlContent = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
                <script type='text/javascript'>
                    google.charts.load('current', {{packages:['corechart']}});
                    google.charts.setOnLoadCallback(drawChart);

                    function drawChart() {{
                        var data = google.visualization.arrayToDataTable([
                            {dataBuilder.ToString()}
                        ]);

                        console.log(data); // Log pour vérifier les données

                        var options = {{
                            title: 'Quantités commandées par produit et par jour',
                            curveType: 'function',
                            legend: {{ position: 'bottom' }},
                            hAxis: {{ title: 'Date' }},
                            vAxis: {{ title: 'Quantité totale' }}
                        }};

                        var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));
                        chart.draw(data, options);
                    }}
                </script>
            </head>
            <body>
                <div id='curve_chart' style='width: 100%; height: 500px;'></div>
            </body>
            </html>";

            // Sauvegarder le fichier HTML généré
            string cheminFichier = Path.Combine(Directory.GetCurrentDirectory(), "ressources", "chart.html");
            File.WriteAllText(cheminFichier, htmlContent);

            // Vérifiez que le fichier HTML est bien généré
            Console.WriteLine($"Fichier HTML généré à: {cheminFichier}");
        }
    }
}
