using System;
using System.IO;
using FiltreCSV.Services;
using FiltreCSV.Utils;

namespace FiltreCSV;

class Program
{
    static void Main(string[] args)
    {
        ConsoleTheme.ApplyTheme();
        ConsoleTheme.WriteInfo("=== Filtreur de données CSV ===");

        // Définir les chemins de fichiers (relatifs à l'exécution)
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        // Remonter vers la racine du projet car l'exécutable est dans bin/Debug/net8.0/
        var parentDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent;
        string projectDir = parentDir != null ? parentDir.FullName : baseDir;
        
        string inputPath = Path.Combine(projectDir, "Data", "input.csv");
        string outputPath = Path.Combine(projectDir, "Data", "output.csv");

        // Saisir le critère
        Console.WriteLine("\nVeuillez entrer un mot-clé pour filtrer le CSV (ex: 'Fruit' ou 'Legume') :");
        Console.Write("> ");
        string? searchTerm = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            ConsoleTheme.WriteWarning("Le terme de recherche ne peut pas être vide.");
            return;
        }

        var filterService = new CsvFilterService();

        try
        {
            ConsoleTheme.WriteInfo($"\nRecherche de '{searchTerm}' en cours...");
            var resultats = filterService.FilterCsv(inputPath, outputPath, searchTerm);
            
            ConsoleTheme.WriteSuccess($"Filtrage terminé avec succès ! ({resultats.Count - 1} résultats trouvés)");
            ConsoleTheme.WriteSuccess($"Les résultats ont été sauvegardés dans : {outputPath}");

            Console.WriteLine("\n=== Aperçu des résultats ===");
            foreach(var ligne in resultats)
            {
                Console.WriteLine(ligne.Replace(",", " | "));
            }
            Console.WriteLine("============================");
        }
        catch (FileNotFoundException ex)
        {
            ConsoleTheme.WriteError($"Erreur : {ex.Message}");
            // Message d'aide
            ConsoleTheme.WriteInfo("Veuillez vous assurer que le fichier input.csv existe dans le dossier Data.");
        }
        catch (Exception ex)
        {
            ConsoleTheme.WriteError($"Une erreur inattendue s'est produite : {ex.Message}");
        }

        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
        ConsoleTheme.Reset();
    }
}
