using System;
using System.IO;
using Gestionnaire.Models;

namespace Gestionnaire.Services;

/// <summary>
/// Service gérant l'écriture et l'archivage physique des fiches de paie dans un fichier texte.
/// Il implémente l'interface IDisposable (un concept avancé majeur en .NET).
/// IDisposable garantit que les "ressources non managées" (ici, un flux de fichier ouvert par le système d'exploitation)
/// seront refermées proprement, évitant ainsi que le fichier reste "bloqué" par l'application ou provoque une fuite de mémoire.
/// </summary>
public class ArchiveurPaie : IDisposable
{
    // Le flux (stream) qui maintient un accès en écriture ouvert vers le fichier.
    private readonly StreamWriter _writer;
    
    // Un drapeau de sécurité pour savoir si les ressources ont déjà été nettoyées,
    // afin d'éviter de les libérer deux fois.
    private bool _disposed = false;

    /// <summary>
    /// Ouvre le fichier et prépare l'écriture.
    /// </summary>
    /// <param name="cheminFichier">Le nom ou chemin du fichier d'archives (ex: "archives.txt").</param>
    public ArchiveurPaie(string cheminFichier)
    {
        // Le paramètre "append: true" indique qu'on ne veut pas écraser l'ancien fichier, 
        // mais qu'on veut ajouter les nouvelles données à la suite.
        _writer = new StreamWriter(cheminFichier, append: true);
        _writer.WriteLine($"--- Début de l'archivage : {DateTime.Now} ---");
    }

    /// <summary>
    /// Sauvegarde une fiche de paie individuelle dans le fichier.
    /// </summary>
    /// <param name="fiche">La fiche immuable à archiver.</param>
    public void Archiver(FicheDePaie fiche)
    {
        // Sécurité : on vérifie que le développeur n'essaie pas d'écrire après avoir fermé le flux
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(ArchiveurPaie), "L'archiveur a déjà été fermé.");
        }

        // Écrit le contenu du 'record' directement. Le type record transforme automatiquement 
        // ses propriétés en une chaîne de texte très lisible via ToString().
        _writer.WriteLine(fiche.ToString());
    }

    /// <summary>
    /// Méthode principale exigée par IDisposable.
    /// Elle est appelée implicitement lorsqu'un bloc 'using' se termine.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        // On signale au Garbage Collector (le ramasse-miettes) qu'il n'a pas besoin 
        // d'appeler le destructeur final, puisque nous avons déjà nettoyé la mémoire manuellement.
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// C'est ici que se trouve la véritable logique de nettoyage (le pattern classique IDisposable).
    /// </summary>
    /// <param name="disposing">True si on vient de Dispose(), False si on vient du finaliseur.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed) // Si ce n'est pas déjà nettoyé
        {
            if (disposing)
            {
                // Libération des ressources managées (les objets gérés par .NET comme StreamWriter).
                _writer.WriteLine($"--- Fin de l'archivage ---{Environment.NewLine}");
                _writer.Close(); // Ferme le fichier
                _writer.Dispose(); // Libère la mémoire allouée par le StreamWriter
            }

            // (C'est ici qu'on libérerait des pointeurs systèmes bruts si on en utilisait)
            
            _disposed = true; // On indique que le ménage est fait
        }
    }

    /// <summary>
    /// Finaliseur (Destructeur) de la classe. 
    /// C'est le dernier rempart de sécurité : si le développeur a oublié d'utiliser 'using' ou d'appeler Dispose(), 
    /// le système .NET l'appellera tout seul juste avant de détruire l'objet.
    /// </summary>
    ~ArchiveurPaie()
    {
        Dispose(false);
    }
}
