using _010.Telechargement.Models;

namespace _010.Telechargement.Services;

/// <summary>
/// Service responsable du téléchargement de fichiers de manière asynchrone.
/// L'implémentation de l'interface IDisposable est cruciale ici car notre service 
/// gère une ressource non managée (le HttpClient) qui doit être libérée proprement à la fin.
/// </summary>
public class DownloadService : IDisposable
{
    // Il est fortement recommandé par Microsoft d'utiliser une seule instance de HttpClient 
    // par application (ou par service) pour éviter l'épuisement des sockets réseau (Socket Exhaustion).
    private readonly HttpClient _httpClient;

    public DownloadService()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Télécharge un fichier depuis son URL et l'enregistre sur le disque local.
    /// L'utilisation de 'async Task' au lieu de 'void' est indispensable pour pouvoir 
    /// 'await' cette méthode de manière asynchrone sans bloquer le thread appelant.
    /// </summary>
    /// <param name="file">Les informations du fichier à télécharger.</param>
    /// <param name="cancellationToken">Le jeton d'annulation pour permettre d'interrompre l'opération proprement.</param>
    public async Task DownloadFileAsync(FileDownload file, CancellationToken cancellationToken)
    {
        var startTime = DateTime.Now;
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"[Début] {startTime:HH:mm:ss.ff} - Connexion au serveur pour {file.Name}...");

        try
        {
            // 1. Préparation de l'environnement local
            // On s'assure qu'il n'y a pas de conflit avec un téléchargement précédent.
            // L'accès au système de fichiers classique est synchrone ici, mais comme c'est très rapide, ce n'est pas bloquant en pratique.
            if (File.Exists(file.Name))
            {
                File.Delete(file.Name);
                Console.WriteLine($"[Info] L'ancien fichier {file.Name} a été effacé et va être retéléchargé.");
            }

            // 2. Initialisation de la requête HTTP asynchrone
            // HttpCompletionOption.ResponseHeadersRead est VITAL pour les gros fichiers.
            // Cela indique au HttpClient de ne pas charger tout le corps de la réponse en mémoire (RAM).
            // Il nous rend la main dès que les en-têtes HTTP (headers) sont reçus.
            using var response = await _httpClient.GetAsync(file.Url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            
            // Cette méthode lève une exception si le code HTTP n'est pas un succès (ex: 404 Not Found, 500 Internal Error).
            // C'est une bonne pratique de toujours valider la réponse avant de continuer le traitement.
            response.EnsureSuccessStatusCode();

            // 3. Récupération des métadonnées (Taille du fichier)
            // L'opérateur de coalescence nulle '??' permet d'affecter 0 si le ContentLength est null (non fourni par le serveur).
            file.SizeInBytes = response.Content.Headers.ContentLength ?? 0L;

            // 4. Ouverture des flux de données (Streams)
            // 'using var' (apparu en C# 8) garantit que les flux réseau et fichier seront correctement fermés et libérés
            // à la fin de la portée de la méthode, même si une exception se produit, évitant ainsi les fuites de mémoire.
            using var networkStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var fileStream = new FileStream(file.Name, FileMode.Create, FileAccess.Write, FileShare.None);

            // Création d'un tampon (buffer) mémoire. 8 Ko (8192 octets) est une taille standard et efficace pour les opérations d'I/O.
            byte[] buffer = new byte[8192];
            int bytesRead;

            Console.WriteLine($"[En cours] Téléchargement de {file.Name}...");

            // 5. Boucle de lecture et écriture asynchrone
            // On lit depuis le réseau (ReadAsync) et on écrit sur le disque (WriteAsync) par petits morceaux de 8 Ko.
            // Cette approche en streaming permet de télécharger des fichiers de plusieurs Giga-octets avec une empreinte mémoire quasi-nulle !
            while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
            {
                // Les méthodes asynchrones d'I/O acceptent le cancellationToken.
                // Si l'annulation est demandée (via cts.Cancel()), une OperationCanceledException sera levée ici.
                await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                file.DownloadedBytes += bytesRead;
                
                // Petit délai optionnel pour simuler une connexion plus lente, afin de voir les messages (purement pédagogique).
                await Task.Delay(10, cancellationToken);
            }

            stopwatch.Stop();
            var endTime = DateTime.Now;
            Console.WriteLine($"[Fin] {endTime:HH:mm:ss.ff} - Le téléchargement de {file.Name} est terminé ({file.DownloadedBytes} octets).");
            Console.WriteLine($"[Durée] Temps de téléchargement pour {file.Name} : {stopwatch.Elapsed.TotalSeconds:F2} secondes.");
        }
        catch (OperationCanceledException)
        {
            // La gestion de l'annulation est une brique fondamentale de l'asynchronisme en C#.
            // Il faut l'attraper spécifiquement pour la distinguer d'une véritable erreur système inattendue.
            stopwatch.Stop();
            var endTime = DateTime.Now;
            Console.WriteLine($"[Annulé] {endTime:HH:mm:ss.ff} - Le téléchargement de {file.Name} a été interrompu par l'utilisateur après {stopwatch.Elapsed.TotalSeconds:F2} secondes !");
            
            // Nettoyage des fichiers corrompus : puisqu'on a annulé en cours de route, le fichier sur le disque est incomplet.
            if (File.Exists(file.Name))
                File.Delete(file.Name);
        }
        catch (Exception ex)
        {
            // Catch général de sécurité pour les autres erreurs réseau (ex: perte de connexion wifi, URL invalide).
            stopwatch.Stop();
            var endTime = DateTime.Now;
            Console.WriteLine($"[Erreur] {endTime:HH:mm:ss.ff} - Problème avec {file.Name} après {stopwatch.Elapsed.TotalSeconds:F2} secondes : {ex.Message}");
        }
    }

    /// <summary>
    /// Implémentation du pattern Dispose pour libérer le HttpClient.
    /// Sera appelé automatiquement à la fin du bloc 'using (var service = new DownloadService())' dans le Program.cs.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
