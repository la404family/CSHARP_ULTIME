using _010.Telechargement.Models;
using _010.Telechargement.Services;

Console.WriteLine("=== Simulateur de Téléchargements Multiples ===");
Console.WriteLine("Appuyez sur 'C' pour annuler tous les téléchargements à tout moment.\n");

// 1. Initialisation des données avec de vraies URLs trouvées !
var filesToDownload = new List<FileDownload>
{
    new FileDownload 
    { 
        Name = "image_hd.jpg", 
        Url = "https://picsum.photos/4000/3000" // Génère une image aléatoire en 4K !
    },
    new FileDownload 
    { 
        Name = "frankenstein.txt", 
        Url = "https://www.gutenberg.org/cache/epub/84/pg84.txt" // Le livre entier de Frankenstein
    }
};

using var cts = new CancellationTokenSource();

_ = Task.Run(() =>
{
    if (Console.ReadKey(true).Key == ConsoleKey.C)
    {
        Console.WriteLine("\n[!] Annulation demandée par l'utilisateur...\n");
        cts.Cancel();
    }
});

using (var service = new DownloadService())
{
    var downloadTasks = new List<Task>();
    foreach (var file in filesToDownload)
    {
        downloadTasks.Add(service.DownloadFileAsync(file, cts.Token));
    }

    try
    {
        await Task.WhenAll(downloadTasks);
        Console.WriteLine("\nTous les téléchargements sont terminés !");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("\nLes téléchargements ont été arrêtés proprement.");
    }
}

Console.WriteLine("Vérifiez le dossier du projet, vous devriez pouvoir ouvrir la photo et lire le livre !");
Console.WriteLine("Fin du programme.");

Console.WriteLine("\nAppuyez sur Entrée pour quitter...");
Console.ReadLine();
