using System;
using System.IO;
using FiltreCSV.Services;
using FiltreCSV.Utils;

namespace FiltreCSV;

/// <summary>
/// Classe principale du programme.
/// Contient le point d'entrée de l'application console.
/// </summary>
class Program
{
    /// <summary>
    /// Point d'entrée de l'application FiltreCSV.
    /// Gère les interactions avec l'utilisateur et l'orchestration du filtrage.
    /// </summary>
    /// <param name="args">Arguments passés en ligne de commande (non utilisés ici).</param>
    static void Main(string[] args)
    {
        // Applique le thème de couleurs personnalisé et force l'encodage UTF-8 pour un bon affichage des accents
        ConsoleTheme.ApplyTheme();
        ConsoleTheme.WriteInfo("=== Filtreur de données CSV ===");

        // --- ÉTAPE 1 : Configuration des chemins d'accès ---
        
        // Récupère le dossier où s'exécute actuellement l'application (ex: bin/Debug/net8.0/)
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        
        // L'exécutable étant souvent dans les sous-dossiers bin/Debug/...,
        // on remonte de 3 niveaux dans l'arborescence pour retrouver la racine du projet où se trouve le dossier "Data"
        var parentDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent;
        
        // Si parentDir est null, on reste sur baseDir par sécurité
        string projectDir = parentDir != null ? parentDir.FullName : baseDir;
        
        // Construction des chemins absolus vers les fichiers CSV d'entrée et de sortie
        string inputPath = Path.Combine(projectDir, "Data", "input.csv");
        string outputPath = Path.Combine(projectDir, "Data", "output.csv");

        // --- ÉTAPE 2 : Interaction utilisateur ---
        
        // Demande à l'utilisateur de saisir le critère (mot-clé) qui servira de filtre
        Console.WriteLine("\nVeuillez entrer un mot-clé pour filtrer le CSV (ex: 'Fruit' ou 'Legume') :");
        Console.Write("> ");
        string? searchTerm = Console.ReadLine();

        // Vérification de la saisie : si la chaîne est nulle, vide ou composée uniquement d'espaces, on arrête.
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            ConsoleTheme.WriteWarning("Le terme de recherche ne peut pas être vide.");
            return;
        }

        // --- ÉTAPE 3 : Traitement des données ---
        
        // Instanciation du service responsable du filtrage des données
        var filterService = new CsvFilterService();

        try
        {
            ConsoleTheme.WriteInfo($"\nRecherche de '{searchTerm}' en cours...");
            
            // Appel de la méthode de filtrage du service.
            // On récupère le résultat pour pouvoir l'afficher.
            var resultats = filterService.FilterCsv(inputPath, outputPath, searchTerm);
            
            // Affichage d'un message de réussite avec le nombre d'éléments trouvés (moins 1 pour exclure l'en-tête)
            ConsoleTheme.WriteSuccess($"Filtrage terminé avec succès ! ({resultats.Count - 1} résultats trouvés)");
            ConsoleTheme.WriteSuccess($"Les résultats ont été sauvegardés dans : {outputPath}");

            // --- ÉTAPE 4 : Affichage des résultats ---
            
            Console.WriteLine("\n=== Aperçu des résultats ===");
            
            // Boucle sur chaque ligne récupérée (en-tête inclus) pour l'afficher à l'utilisateur
            foreach(var ligne in resultats)
            {
                // Remplacement des virgules par des barres verticales pour une lecture plus agréable en console
                Console.WriteLine(ligne.Replace(",", " | "));
            }
            Console.WriteLine("============================");
        }
        catch (FileNotFoundException ex)
        {
            // Bloc catch spécifique si le fichier CSV d'entrée est introuvable
            ConsoleTheme.WriteError($"Erreur : {ex.Message}");
            ConsoleTheme.WriteInfo("Veuillez vous assurer que le fichier input.csv existe dans le dossier Data.");
        }
        catch (Exception ex)
        {
            // Bloc catch général pour intercepter et afficher toute autre erreur inattendue (accès refusé, fichier utilisé, etc.)
            ConsoleTheme.WriteError($"Une erreur inattendue s'est produite : {ex.Message}");
        }

        // --- ÉTAPE 5 : Fin du programme ---
        
        // Met le programme en pause jusqu'à ce que l'utilisateur appuie sur une touche
        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
        
        // Réinitialise les couleurs de la console à leurs valeurs par défaut pour ne pas affecter le terminal système
        ConsoleTheme.Reset();
    }
}
