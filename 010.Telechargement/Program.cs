using _010.Telechargement.Models;
using _010.Telechargement.Services;

Console.WriteLine("=== Simulateur de Téléchargements Multiples ===");
Console.WriteLine("Appuyez sur 'C' pour annuler tous les téléchargements à tout moment.\n");

// 1. Initialisation des données
// L'utilisation de List<T> couplée à l'initialisation d'objets (Object Initializer) 
// permet un code propre et concis pour définir notre ensemble de données.
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

// 2. Préparation du jeton d'annulation (CancellationToken)
// CancellationTokenSource est la classe qui permet de créer un jeton (Token)
// et de déclencher manuellement l'annulation via sa méthode Cancel().
// Le mot-clé 'using' (version simplifiée depuis C# 8) garantit la libération du token en fin de portée.
using var cts = new CancellationTokenSource();

// 3. Déclencheur d'annulation en tâche de fond (Fire and Forget)
// L'opérateur _ (discard) indique au compilateur que nous n'avons pas besoin de stocker ou d'attendre (await) cette tâche.
// Task.Run lance l'écoute clavier sur un thread séparé du ThreadPool pour ne pas bloquer le démarrage des téléchargements.
_ = Task.Run(() =>
{
    // Console.ReadKey(true) bloque le thread secondaire en attendant une touche.
    // L'argument 'true' empêche la touche d'être affichée dans la console (intercept).
    if (Console.ReadKey(true).Key == ConsoleKey.C)
    {
        Console.WriteLine("\n[!] Annulation demandée par l'utilisateur...\n");
        // Cette ligne diffuse un signal d'annulation à toutes les méthodes asynchrones 
        // qui surveillent le jeton 'cts.Token'.
        cts.Cancel();
    }
});

// 4. Utilisation du service (IDisposable)
// Le bloc 'using' appelle automatiquement service.Dispose() à la fin, fermant ainsi proprement le HttpClient.
using (var service = new DownloadService())
{
    // On prépare une liste pour stocker les promesses (Tasks) de téléchargement
    var downloadTasks = new List<Task>();
    foreach (var file in filesToDownload)
    {
        // Attention : on n'utilise PAS le mot-clé 'await' ici ! 
        // Si on l'utilisait, les téléchargements se feraient l'un après l'autre (de manière séquentielle).
        // En ajoutant simplement la Task retournée à la liste, on les démarre quasi-simultanément en parallèle.
        downloadTasks.Add(service.DownloadFileAsync(file, cts.Token));
    }

    try
    {
        // 5. Attente de toutes les tâches
        // Task.WhenAll est l'outil indispensable pour l'asynchronisme concurrentiel.
        // Il crée une nouvelle Task qui se termine uniquement lorsque toutes les tâches de la liste sont achevées (ou annulées/en erreur).
        await Task.WhenAll(downloadTasks);
        Console.WriteLine("\nTous les téléchargements sont terminés !");
    }
    catch (OperationCanceledException)
    {
        // Ce bloc intercepte l'annulation si le cts.Cancel() a été appelé.
        // C'est le flux d'exécution normal et attendu en cas d'annulation, ce n'est pas une véritable erreur.
        Console.WriteLine("\nLes téléchargements ont été arrêtés proprement.");
    }
}

Console.WriteLine("Vérifiez le dossier du projet, vous devriez pouvoir ouvrir la photo et lire le livre !");
Console.WriteLine("Fin du programme.");

Console.WriteLine("\nAppuyez sur Entrée pour quitter...");
Console.ReadLine();
