using _010.Telechargement.Models;

namespace _010.Telechargement.Services;

public class DownloadService : IDisposable
{
    // C'est une bonne pratique de réutiliser la même instance de HttpClient
    private readonly HttpClient _httpClient;

    public DownloadService()
    {
        _httpClient = new HttpClient();
    }

    public async Task DownloadFileAsync(FileDownload file, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Début] Connexion au serveur pour {file.Name}...");

        try
        {
            // 1. On supprime le fichier s'il est déjà présent sur le disque dur
            if (File.Exists(file.Name))
            {
                File.Delete(file.Name);
                Console.WriteLine($"[Info] L'ancien fichier {file.Name} a été effacé et va être retéléchargé.");
            }

            // 2. On lance la requête (HttpCompletionOption.ResponseHeadersRead permet de ne pas charger tout le fichier en mémoire vive d'un coup)
            using var response = await _httpClient.GetAsync(file.Url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            // 3. Récupération de la taille (si le serveur la renvoie dans l'en-tête Content-Length)
            file.SizeInBytes = response.Content.Headers.ContentLength ?? 0L;

            // 4. On ouvre les deux flux (le flux réseau entrant, et le flux fichier sortant)
            using var networkStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var fileStream = new FileStream(file.Name, FileMode.Create, FileAccess.Write, FileShare.None);

            // Buffer (tampon) de 8 Ko
            byte[] buffer = new byte[8192];
            int bytesRead;

            Console.WriteLine($"[En cours] Téléchargement de {file.Name}...");

            // 5. La boucle de lecture : tant qu'il y a des données sur le réseau, on lit, puis on écrit sur le disque
            while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
            {
                // Ici aussi on peut vérifier si on annule manuellement, mais ReadAsync/WriteAsync écoutent déjà le CancellationToken !
                await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                file.DownloadedBytes += bytesRead;
                
                // Petit délai 100% optionnel pour qu'on ait le temps de voir les affichages si votre fibre optique est trop rapide !
                await Task.Delay(10, cancellationToken);
            }

            Console.WriteLine($"[Fin] Le téléchargement de {file.Name} est terminé ({file.DownloadedBytes} octets).");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"[Annulé] Le téléchargement de {file.Name} a été interrompu par l'utilisateur !");
            
            // Si c'est annulé, le fichier sur le disque est corrompu/incomplet, on pourrait le supprimer ici.
            if (File.Exists(file.Name))
                File.Delete(file.Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Erreur] Problème avec {file.Name} : {ex.Message}");
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
