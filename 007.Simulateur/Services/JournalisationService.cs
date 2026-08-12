using System;
using System.IO;

namespace Simulateur.Services;

/// <summary>
/// Service utilitaire statique responsable de la journalisation (logging) des transactions.
/// Permet de garder une trace persistante de toutes les opérations effectuées sur le simulateur.
/// </summary>
public static class JournalisationService
{
    // Chemin vers le fichier de log. Il sera créé à la racine de l'exécutable s'il n'existe pas.
    private static readonly string LogFilePath = "transactions.log";

    /// <summary>
    /// Enregistre une opération dans le fichier de log texte de manière persistante,
    /// en y ajoutant automatiquement la date et l'heure exactes de l'opération.
    /// </summary>
    /// <param name="message">La description détaillée de l'opération ou de l'erreur à consigner.</param>
    public static void LogOperation(string message)
    {
        // Formatage de l'entrée de log : [AAAA-MM-JJ HH:mm:ss] Message
        // Environment.NewLine assure un retour à la ligne correct quel que soit le système d'exploitation.
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
        
        try
        {
            // File.AppendAllText ouvre le fichier, ajoute le texte à la fin, puis referme le fichier.
            // Si le fichier n'existe pas encore, il est automatiquement créé.
            File.AppendAllText(LogFilePath, logEntry);
        }
        catch (Exception ex)
        {
            // Bloc catch de secours : si l'écriture sur le disque échoue (ex: droits d'accès refusés, disque plein),
            // on évite de faire crasher toute l'application bancaire juste pour un problème de log.
            // On signale simplement le problème dans la console de l'administrateur système.
            Console.WriteLine($"[Erreur système critique] Impossible d'écrire dans le fichier de log : {ex.Message}");
        }
    }
}
