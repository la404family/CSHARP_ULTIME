using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FiltreCSV.Services;

/// <summary>
/// Service responsable du traitement et du filtrage des données au format CSV.
/// Il encapsule la logique de lecture, de filtrage via LINQ et d'écriture des fichiers.
/// </summary>
public class CsvFilterService
{
    /// <summary>
    /// Lit un fichier CSV, filtre ses lignes (hors en-tête) en fonction d'un mot-clé,
    /// puis sauvegarde le résultat dans un nouveau fichier.
    /// </summary>
    /// <param name="inputFilePath">Chemin complet vers le fichier CSV source contenant les données à filtrer.</param>
    /// <param name="outputFilePath">Chemin complet vers le fichier CSV de destination pour les résultats.</param>
    /// <param name="searchTerm">Le mot-clé de recherche (la comparaison est insensible à la casse).</param>
    /// <returns>Une liste contenant l'en-tête suivi des lignes filtrées.</returns>
    /// <exception cref="FileNotFoundException">Levée si le fichier d'entrée n'existe pas.</exception>
    /// <exception cref="InvalidOperationException">Levée si le fichier d'entrée est vide.</exception>
    public List<string> FilterCsv(string inputFilePath, string outputFilePath, string searchTerm)
    {
        // Vérification de l'existence du fichier source avant de tenter toute lecture
        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException($"Le fichier d'entrée '{inputFilePath}' est introuvable.");
        }

        // Lecture de l'intégralité du fichier en mémoire.
        // Chaque ligne du fichier devient un élément du tableau de chaînes.
        string[] allLines = File.ReadAllLines(inputFilePath);

        // Vérifier que le fichier n'est pas complètement vide
        if (allLines.Length == 0)
        {
            throw new InvalidOperationException("Le fichier CSV est vide.");
        }

        // Extraction de la première ligne qui correspond généralement à l'en-tête des colonnes (Id, Nom, Categorie, etc.)
        string header = allLines[0];

        // Utilisation de LINQ pour filtrer les données :
        // 1. Skip(1) permet d'ignorer la première ligne (l'en-tête) pour ne pas la filtrer par erreur.
        // 2. Where() vérifie si la ligne contient le terme recherché.
        //    StringComparison.OrdinalIgnoreCase est utilisé pour ignorer la casse (majuscules/minuscules).
        // 3. ToList() exécute la requête et convertit le résultat en liste.
        var filteredLines = allLines.Skip(1)
            .Where(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Création d'une nouvelle liste de résultats en insérant d'abord l'en-tête sauvegardé précédemment
        var outputLines = new List<string> { header };
        
        // Ajout de toutes les lignes correspondantes trouvées par LINQ
        outputLines.AddRange(filteredLines);

        // Écriture du résultat final (en-tête + lignes correspondantes) dans le fichier de destination
        File.WriteAllLines(outputFilePath, outputLines);
        
        // On retourne également les lignes pour permettre un affichage éventuel dans la console
        return outputLines;
    }
}
