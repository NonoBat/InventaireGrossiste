using InventaireGrossiste;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            try
            {
                // Vérifier et créer le répertoire si nécessaire
                string cheminRepertoire = Path.Combine(Directory.GetCurrentDirectory(), "ressources");
                if (!Directory.Exists(cheminRepertoire))
                {
                    Directory.CreateDirectory(cheminRepertoire);
                }

                // Générer les données
                var commandesParJour = _context.Commandes
                    .GroupBy(c => c.DateComm.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalCommandes = g.Count()
                    })
                    .OrderBy(g => g.Date)
                    .ToList();

                if (!commandesParJour.Any())
                {
                    throw new Exception("Aucune donnée disponible pour le graphique.");
                }

                StringBuilder dataBuilder = new StringBuilder();
                dataBuilder.AppendLine("[['Date', 'Nombre de commandes'],"); // Entêtes des colonnes

                // Ajout des données dynamiques
                var commandesParDate = _context.Commandes
                    .GroupBy(c => c.DateComm)
                    .Select(g => new { Date = g.Key, Total = g.Sum(c => c.Qte) })
                    .OrderBy(d => d.Date)
                    .ToList();

                foreach (var commande in commandesParDate)
                {
                    dataBuilder.AppendLine($"['{commande.Date:yyyy-MM-dd}', {commande.Total}],");
                }

                // Supprime la dernière virgule et ferme le tableau
                if (commandesParDate.Any())
                {
                    dataBuilder.Length -= 1; // Supprimer la dernière virgule
                }
                dataBuilder.AppendLine("]");

                string htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
    <script type='text/javascript'>
        window.onerror = function(message, source, lineno, colno, error) {{console.error('Erreur JavaScript : ' + message + ' à ' + source + ':' + lineno + ':' + colno);
        }};

        google.charts.load('current', {{packages:['corechart']}});
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {{
            var data = google.visualization.arrayToDataTable({dataBuilder});

            var options = {{
                title: 'Commandes par jour',
                curveType: 'function',
                legend: {{ position: 'bottom' }}
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

                string cheminFichier = System.IO.Path.Combine(cheminRepertoire, "chart.html");
                File.WriteAllText(cheminFichier, htmlContent);

                Console.WriteLine($"Fichier HTML généré à: {cheminFichier}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                throw;
            }
        }
    }
}
