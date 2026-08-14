namespace _010.Telechargement.Models;

/// <summary>
/// Représente les informations liées à un téléchargement.
/// L'utilisation de 'record' (apparu en C# 9) est idéale pour des objets de données (Data Transfer Objects) 
/// car il offre une sémantique d'égalité par valeur et une syntaxe concise.
/// </summary>
public record FileDownload
{
    // Le mot-clé 'required' (C# 11) force l'initialisation de cette propriété lors de la création de l'objet.
    // L'accesseur 'init' permet d'affecter une valeur uniquement lors de l'initialisation de l'objet, 
    // rendant la propriété immuable par la suite. C'est une excellente pratique pour garantir l'intégrité des données.
    public required string Name { get; init; }
    
    // De même, l'URL est obligatoire et ne doit pas changer une fois le téléchargement défini.
    public required string Url { get; init; }
    
    // 'long' est utilisé ici au lieu de 'int' car un fichier peut facilement dépasser 
    // la limite d'un 'int' (environ 2 Go). Le serveur ne donne pas toujours la taille totale à l'avance, 
    // on la mettra à jour au moment de la réponse HTTP.
    public long SizeInBytes { get; set; } 
    
    // Cette propriété sera mise à jour au fur et à mesure du téléchargement. 
    // Elle utilise un accesseur 'set' standard car sa valeur évolue dans le temps.
    public long DownloadedBytes { get; set; }
}
