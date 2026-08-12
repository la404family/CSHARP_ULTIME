using System;
using System.IO;
using System.Linq;

namespace FiltreCSV.Services;

public class CsvFilterService
{
    public System.Collections.Generic.List<string> FilterCsv(string inputFilePath, string outputFilePath, string searchTerm)
    {
        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException($"Le fichier d'entrée '{inputFilePath}' est introuvable.");
        }

        // Lire toutes les lignes du fichier
        string[] allLines = File.ReadAllLines(inputFilePath);

        if (allLines.Length == 0)
        {
            throw new InvalidOperationException("Le fichier CSV est vide.");
        }

        // Extraire l'en-tête (la première ligne)
        string header = allLines[0];

        // Filtrer les lignes (à l'exclusion de l'en-tête)
        // StringComparison.OrdinalIgnoreCase pour une recherche insensible à la casse
        var filteredLines = allLines.Skip(1)
            .Where(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Préparer le contenu de sortie avec l'en-tête
        var outputLines = new System.Collections.Generic.List<string> { header };
        outputLines.AddRange(filteredLines);

        // Sauvegarder dans le fichier de sortie
        File.WriteAllLines(outputFilePath, outputLines);
        
        return outputLines;
    }
}
