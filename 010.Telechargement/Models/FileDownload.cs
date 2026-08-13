namespace _010.Telechargement.Models;

public record FileDownload
{
    public required string Name { get; init; }
    public required string Url { get; init; }
    
    // Le serveur ne donne pas toujours la taille totale à l'avance, 
    // on la mettra à jour au moment de la réponse HTTP. On utilise 'long' pour les gros fichiers.
    public long SizeInBytes { get; set; } 
    public long DownloadedBytes { get; set; }
}
