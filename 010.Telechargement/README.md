# Projet 010 : Téléchargements simultanés (Async)

## Objectif du Projet
Ce projet marque une étape importante dans votre apprentissage de C# : l'introduction à la **programmation asynchrone**. 
L'objectif est de concevoir un gestionnaire de téléchargement de fichiers réels en parallèle. Cela vous permettra de comprendre comment exécuter des opérations longues (comme des appels réseau ou des accès disque) sans bloquer le fil d'exécution principal de votre application.

## Concepts Clés Abordés
- **`async` et `await`** : Les mots-clés fondamentaux pour écrire du code asynchrone de manière lisible et séquentielle.
- **`Task` et `Task.WhenAll`** : La classe représentant une opération asynchrone, et la méthode permettant de coordonner l'attente de multiples tâches exécutées en parallèle.
- **`HttpClient` et `FileStream`** : Pour effectuer les requêtes HTTP réelles et écrire les données téléchargées directement sur le disque dur sans saturer la mémoire (RAM).
- **`CancellationToken`** : Le mécanisme standard en .NET pour propager et gérer des demandes d'annulation (ex: un utilisateur qui clique sur "Annuler le téléchargement").
- **`IDisposable` et le bloc `using`** : Pour garantir la libération correcte des ressources (comme les connexions réseau ou les flux de fichiers), même en cas d'erreur ou d'annulation.

## Fonctionnalités Attendues
1. **Téléchargements Réels** : Créer une méthode asynchrone qui télécharge un vrai fichier depuis internet via `HttpClient`. 
2. **Gestion des Fichiers Locaux** : Avant de démarrer, vérifier si le fichier existe déjà sur le disque et le supprimer le cas échéant (`File.Exists`, `File.Delete`).
3. **Exécution Concurrente** : Démarrer plusieurs téléchargements simultanément.
4. **Gestion de l'Annulation** : Intégrer un `CancellationTokenSource` pour permettre d'interrompre proprement tous les téléchargements en cours sur une action de l'utilisateur (ex: appui sur une touche).
5. **Nettoyage** : En cas d'annulation, attraper l'exception `OperationCanceledException` et supprimer les fichiers partiellement téléchargés.
6. **Libération des Ressources** : Utiliser correctement les instructions `using` pour `HttpClient`, `FileStream`, et le `CancellationTokenSource`.

## Architecture Suggérée
Afin de structurer proprement ce projet et de commencer à respecter le principe de responsabilité unique (SOLID), voici l'architecture recommandée pour vos fichiers :

```text
010.Telechargement/
│
├── Program.cs                  # Point d'entrée, interface console, et écoute de l'annulation (CancellationTokenSource)
│
├── Models/
│   └── FileDownload.cs         # Classe (ou record) représentant les infos d'un fichier (Nom, Url, Taille, Progression)
│
└── Services/
    └── DownloadService.cs      # Logique métier asynchrone (HttpClient, FileStream)
```

**Rôle de chaque composant :**
- **`Models/FileDownload.cs`** : Garde l'état d'un téléchargement, incluant l'URL source. Évite d'utiliser de simples strings ou int dans le service.
- **`Services/DownloadService.cs`** : Isole la complexité de l'asynchrone et du réseau. C'est ici que `HttpClient` et `FileStream` sont utilisés.
- **`Program.cs`** : Orchestre le tout. Il instancie le service, lance un `Task.WhenAll` sur plusieurs téléchargements, et gère l'interaction avec l'utilisateur (comme appuyer sur une touche pour déclencher le `CancellationToken`).

## Conseils du Formateur
* **Asynchrone ≠ Multi-threading pur** : Comprenez bien que l'utilisation de `async/await` sur des opérations d'I/O permet de libérer le thread appelant, évitant ainsi de monopoliser inutilement les ressources CPU de votre machine.
* **Propreté et robustesse** : Avec l'asynchronisme, la gestion des exceptions devient cruciale. Pensez à gérer l'exception `OperationCanceledException` qui est levée lorsqu'une tâche est annulée.
* Référez-vous à la documentation Microsoft sur [la programmation asynchrone avec async et await](https://learn.microsoft.com/fr-fr/dotnet/csharp/asynchronous-programming/).

Bon courage pour ce défi !
