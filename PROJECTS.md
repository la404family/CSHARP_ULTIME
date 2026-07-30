# Projets — Formation C#

> `001` = Formation théorique au format papier (Bases de C# et SQL)
> Les projets pratiques sont numérotés à partir de `002`.
>
> **Progression des phases :**
> - Console →
> - SQL & Bases de données →
> - Console + ASP.NET →
> - Console + ASP.NET avancé →
> - Angular →
> - Angular + ASP.NET →
> - WPF →
> - WPF + ASP.NET →
> - MAUI →
> - MAUI + ASP.NET
>
> **Légende :**
> - 🔵 `ESSENTIEL` — Concept nouveau et fondamental, à faire obligatoirement.
> - 🟢 `BONUS` — Renforcement ou approfondissement, à piocher selon le rythme.
> - 🔴 `FIL ROUGE` — Projet long, repris et enrichi sur plusieurs semaines.
>
> **Philosophie :**
> Les Phases 1 à 4 forment le **tronc commun obligatoire** (C#, SQL, ASP.NET Core).
> À partir de la Phase 5, l'apprenant **choisit 1 ou 2 spécialisations** à approfondir
> (Web avec Angular, Desktop avec WPF, ou Mobile avec MAUI) plutôt que de tout suivre linéairement.

---

## Phase 1 — Console : Bases du langage C#

> Objectif : maîtriser la syntaxe C#, la logique algorithmique, la POO et le Clean Code avant toute interface ou réseau.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `002` | **Calculatrice** — Saisir deux nombres et un opérateur, afficher le résultat. | Types, `if/else`, `switch`, entrée console | 🔵 `ESSENTIEL` |
| `003` | **Devine le nombre** — L'ordinateur choisit un nombre, l'utilisateur doit le trouver avec des indices. | `Random`, boucles `while`, comparaisons | 🔵 `ESSENTIEL` |
| `004` | **Mini-calculatrice de notes** — Saisie de plusieurs notes, calcul de la moyenne, du max et du min. | `List<T>`, LINQ (`Average`, `Max`, `Min`), `foreach` | 🔵 `ESSENTIEL` |
| `005` | **Gestion d'inventaire** — Menu console pour ajouter, afficher et supprimer des articles. | `class`, constructeur, `List<T>`, boucle `while` | 🔵 `ESSENTIEL` |
| `006` | **Filtreur de données CSV** — Lit un CSV, filtre les lignes selon un critère, sauvegarde le résultat. | LINQ `Where`, `string.Split`, `File.ReadAllText`, `File.WriteAllText`, I/O fichiers | 🔵 `ESSENTIEL` |
| `007` | **Simulateur de Banque** — Gérer des dépôts et retraits avec gestion d'exceptions personnalisées. | `try/catch`, exceptions personnalisées, `DateTime`, `File.AppendAllText` | 🔵 `ESSENTIEL` |
| `008` | **Gestionnaire d'Employés (POO Avancée)** — Héritage, interfaces et principes SOLID pour calculer des salaires. | Héritage, `interface`, polymorphisme, SOLID, `IDisposable`, `record` | 🔵 `ESSENTIEL` |
| `009` | **Structures de données & Algorithmes** — Implémenter Stack, Queue, Dictionary, HashSet, et algorithmes de tri/recherche. | Structures de données, tri fusion, recherche dichotomique, `Stopwatch` | 🔵 `ESSENTIEL` |
| `010` | **Téléchargements simultanés (Async)** — Simuler des téléchargements de fichiers en parallèle. | `async/await`, `Task.WhenAll`, `CancellationToken`, `IDisposable`, `using` | 🔵 `ESSENTIEL` |
| `011` | 🔴 **Gestionnaire de tâches avancé (Fil rouge Console)** — Application console complète avec priorités, dépendances entre tâches, et persistance JSON. Reprise et enrichissement sur plusieurs sessions. | POO complète, LINQ avancé, sérialisation JSON, architecture en couches, refactoring | 🔴 `FIL ROUGE` |

---

## Phase 2 — Bases de données et SQL (Théorie & Pratique)

> Objectif : apprendre à modéliser des données et maîtriser le langage SQL brut avant d'utiliser un ORM.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `012` | **Création et peuplement de la base** — Modélisation d'un système e-commerce (Clients, Produits, Commandes) + insertion de données factices. | `CREATE TABLE`, clés primaires/étrangères, `INSERT INTO`, types SQL | 🔵 `ESSENTIEL` |
| `013` | **Requêtes CRUD et Jointures** — Sélection, mise à jour, suppression + requêtes multi-tables. | `SELECT`, `UPDATE`, `DELETE`, `INNER JOIN`, `LEFT JOIN`, `GROUP BY`, `SUM`, `COUNT` | 🔵 `ESSENTIEL` |
| `014` | **Procédures stockées et Transactions** — Procédure de validation de commande + transfert de fonds atomique. | `STORED PROCEDURE`, `BEGIN TRAN`, `COMMIT`, `ROLLBACK`, paramètres | 🔵 `ESSENTIEL` |
| `015` | **Vues, Index et Optimisation** — Création de vues SQL, compréhension des index, analyse de plans d'exécution. | `VIEW`, `INDEX`, plans d'exécution, statistiques | 🔵 `ESSENTIEL` |
| `016` | **Requêtes complexes** — CTE, Window Functions, requêtes récursives pour arborescence de catégories. | `WITH` (CTE), `ROW_NUMBER`, `RANK`, requêtes récursives | 🟢 `BONUS` |
| `017` | **Triggers et Audit** — Table d'audit traçant automatiquement chaque modification de données. | `TRIGGER`, `INSERTED`, `DELETED`, table d'audit | 🟢 `BONUS` |

---

## Phase 3 — Console + ASP.NET Core : Introduction au Web

> Objectif : créer et consommer de petites APIs REST depuis la console. Apprendre les deux côtés (serveur et client) simultanément.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `018` | **Première Minimal API** — Route GET renvoyant un message de bienvenue, route POST calculatrice renvoyant un résultat en JSON. | Minimal API, Routing, Query/Route parameters, retour JSON | 🔵 `ESSENTIEL` |
| `019` | **API Citations (CRUD mémoire)** — Créer, lire, mettre à jour et supprimer des citations en mémoire. | `GET`/`POST`/`PUT`/`DELETE`, Controllers, codes HTTP | 🔵 `ESSENTIEL` |
| `020` | **Console Client — Citations** — Application console consommant l'API `019`. | `HttpClient`, `async/await`, `JsonSerializer.Deserialize`, headers HTTP | 🔵 `ESSENTIEL` |
| `021` | **API Quiz + Console Client** — API renvoyant des questions aléatoires, client console interactif calculant le score. | Injection de dépendances, boucle de jeu, `HttpClient` dans une boucle | 🔵 `ESSENTIEL` |
| `022` | **API Todo + Console Client** — CRUD complet pour des tâches avec statut, et son client console associé. | `[FromBody]`, `201 Created`, `404 Not Found`, sérialisation des requêtes | 🔵 `ESSENTIEL` |

---

## Phase 4 — Console + ASP.NET Core : Niveau Avancé

> Objectif : ajouter la persistance en base de données, la validation, la sécurité, les tests et l'architecture. **C'est la phase la plus importante.**

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `023` | **API Todo avec persistance** — Reprendre l'API Todo `022` et persister les données avec EF Core + SQLite. | EF Core, `DbContext`, Migrations, Code First | 🔵 `ESSENTIEL` |
| `024` | **API Blog avec SQL Server** — Articles avec titre, contenu, date, auteur et catégories. Relations entre entités. | EF Core Code First, relations 1-N / N-N, SQL Server | 🔵 `ESSENTIEL` |
| `025` | **EF Core Avancé** — Optimisation des requêtes et gestion complexe de la base de données. | `Include`/`ThenInclude`, `AsNoTracking`, Lazy Loading, `IDbContextTransaction`, Optimistic Concurrency (`RowVersion`) | 🔵 `ESSENTIEL` |
| `026` | **Validation et Documentation** — Validation stricte des entrées + documentation Swagger/OpenAPI. | `Data Annotations`, `FluentValidation`, `Swashbuckle`, commentaires XML | 🔵 `ESSENTIEL` |
| `027` | **Authentification JWT complète** — Login, token signé, Refresh Token, rôles, hachage de mot de passe + client console authentifié. | `JwtBearer`, claims, BCrypt, `[Authorize(Roles="Admin")]`, `Authorization: Bearer` | 🔵 `ESSENTIEL` |
| `028` | **Sécurité et Middleware** — CORS, Rate Limiting, HTTPS, middleware de log chronométrant chaque requête. | CORS, Rate Limiting, middleware personnalisé, logging structuré (Serilog) | 🔵 `ESSENTIEL` |
| `029` | **API Production-Ready** — Pagination, filtrage, tri, mise en cache, gestion globale des exceptions. | `?page=1&pageSize=20`, `IMemoryCache`, Global Exception Handling, Validation Pipeline | 🔵 `ESSENTIEL` |
| `030` | **Tests unitaires et d'intégration** — Tester les services et les endpoints de l'API. | `xUnit`, `Moq`, `WebApplicationFactory`, tests d'intégration avec base en mémoire | 🔵 `ESSENTIEL` |
| `031` | **Upload de fichiers et SignalR** — Upload d'images + mini-chat en temps réel. | `IFormFile`, `multipart/form-data`, Hub SignalR, `MultipartFormDataContent` | 🔵 `ESSENTIEL` |
| `032` | **Clean Architecture et CQRS** — Refactorisation du Blog `024` en couches distinctes avec commandes et queries séparées. | Domain / Application / Infrastructure / Presentation, `MediatR`, CQRS | 🔵 `ESSENTIEL` |
| `033` | **Background Jobs** — Tâches planifiées exécutées en arrière-plan. | `IHostedService`, `BackgroundService` (nettoyage quotidien, envoi d'emails simulé) | 🟢 `BONUS` |
| `034` | 🔴 **E-commerce API complète (Fil rouge Backend)** — Refaire entièrement le Catalogue e-commerce avec toutes les bonnes pratiques accumulées : Clean Architecture, JWT, pagination, tests, concurrence, logging. | Synthèse de toute la Phase 4 : architecture, sécurité, performance, tests, API versioning | 🔴 `FIL ROUGE` |

---

> ### 🔀 Point de spécialisation
>
> À partir d'ici, vous maîtrisez le **tronc commun** (C#, SQL, ASP.NET Core).
> Choisissez **1 ou 2 spécialisations** à approfondir selon votre orientation professionnelle :
>
> | Orientation | Phases à suivre | Débouché |
> |-------------|----------------|----------|
> | **Développeur Web Full-Stack** | Phase 5 + 6 (Angular) | Applications web SPA |
> | **Développeur Desktop** | Phase 7 + 8 (WPF) | Applications métier Windows |
> | **Développeur Mobile** | Phase 9 + 10 (MAUI) | Applications cross-platform |
>
> *Vous pouvez aussi explorer les phases bonus pour élargir vos compétences.*

---

## Phase 5 — Angular : Frontend seul (sans backend)

> Objectif : apprendre les fondamentaux d'Angular avec des données locales, sans réseau.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `035` | **Hello Angular & Binding** — Formulaire modifiant un message en temps réel + compteur avec boutons. | Interpolation `{{ }}`, `[(ngModel)]`, Event Binding `(click)`, Property Binding | 🔵 `ESSENTIEL` |
| `036` | **Liste de tâches locale** — Ajouter, cocher et supprimer des tâches avec affichage conditionnel. | `*ngFor`, `*ngIf`, `[ngClass]`, gestion d'état local | 🔵 `ESSENTIEL` |
| `037` | **Composants et Communication** — Carte de profil (`@Input`) et carrousel d'images (`@Output`, `EventEmitter`). | Composants, `@Input`, `@Output`, `EventEmitter`, communication parent ↔ enfant | 🔵 `ESSENTIEL` |
| `038` | **Formulaires avancés** — Formulaire de contact validé + formulaire d'inscription multi-étapes avec validations asynchrones. | Reactive Forms, `FormBuilder`, `Validators`, `FormArray`, validations asynchrones | 🔵 `ESSENTIEL` |
| `039` | **Navigation et Pipes** — Application multi-pages + Pipe personnalisé de transformation de texte. | `RouterModule`, `routerLink`, `/:id`, `Pipe`, `PipeTransform`, `loadChildren` | 🔵 `ESSENTIEL` |
| `040` | **Performances Angular** — Optimisation du rendu et chargement virtuel de grandes listes. | `OnPush` Change Detection, `TrackBy`, Virtual Scrolling (`cdk-virtual-scroll`) | 🟢 `BONUS` |

---

## Phase 6 — Angular + ASP.NET Core : Frontend connecté au Backend

> Objectif : connecter l'application Angular aux APIs créées lors des Phases 3 et 4.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `041` | **CRUD Citations connecté** — Charger, ajouter, modifier et supprimer les citations depuis l'API `019`. | `HttpClient`, `Observable`, `async pipe`, requêtes POST/PUT/DELETE | 🔵 `ESSENTIEL` |
| `042` | **Recherche et filtrage réactif** — Barre de recherche filtrant les citations côté client en temps réel. | `filter()`, `Subject` RxJS, réactivité | 🔵 `ESSENTIEL` |
| `043` | **Authentification et Garde de route** — Page de connexion JWT + restriction d'accès aux pages protégées. | `localStorage`, `CanActivate`, `AuthGuard`, `Router.navigate` | 🔵 `ESSENTIEL` |
| `044` | **Interceptors HTTP** — Interception globale pour ajouter le token JWT et gérer les erreurs centralement. | `HttpInterceptor`, gestion centralisée des erreurs | 🔵 `ESSENTIEL` |
| `045` | **Catalogue et Panier d'achat** — Affichage paginé du catalogue + panier via un Service partagé. | Pagination, Service Angular, Injection de dépendances, état global | 🔵 `ESSENTIEL` |
| `046` | **Architecture Angular avancée** — Feature Modules, Core/Shared modules, State Management avec Signals + Services. | Feature Modules, `providedIn: 'root'`, architecture modulaire, Signals | 🟢 `BONUS` |
| `047` | **Tests de l'application Angular** — Tests unitaires et E2E côté client. | Jasmine/Karma (unitaires), Cypress ou Playwright (E2E) | 🟢 `BONUS` |
| `048` | 🔴 **E-commerce Angular (Fil rouge Web)** — Application e-commerce complète : catalogue, panier, commande, authentification, thème Dark/Light. Reprise et enrichissement sur plusieurs semaines. | Synthèse complète : architecture modulaire, RxJS, formulaires, auth, CSS variables, `@HostBinding` | 🔴 `FIL ROUGE` |

---

## Phase 7 — WPF : Applications Bureau Windows (sans backend)

> Objectif : créer des interfaces graphiques riches avec C# et XAML, apprendre le Data Binding et le pattern MVVM.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `049` | **Hello WPF & Calculatrice** — Interface de bienvenue + calculatrice visuelle avec boutons. | XAML basique, `TextBox`, `Grid`, `UniformGrid`, événements `Button` | 🔵 `ESSENTIEL` |
| `050` | **Contrôles interactifs** — Convertisseur de couleurs RGB (Sliders) + chronomètre dynamique. | `Slider`, Data Binding direct, `SolidColorBrush`, `DispatcherTimer` | 🔵 `ESSENTIEL` |
| `051` | **To-Do List et Bloc-notes** — Gestion de tâches + éditeur de texte avec sauvegarde/chargement de fichiers. | `ObservableCollection<T>`, `ListBox`, `SaveFileDialog`, `OpenFileDialog` | 🔵 `ESSENTIEL` |
| `052` | **Formulaire avec validation et Master-Detail** — Champs validés visuellement + carnet d'adresses sélection/détail. | `IDataErrorInfo`, Validation Rules, `DataContext`, `SelectedItem`, layout deux colonnes | 🔵 `ESSENTIEL` |
| `053` | **MVVM complet avec DI** — Reprendre la To-Do List avec un ViewModel propre et injection de dépendances. | Pattern MVVM, `RelayCommand`, `INotifyPropertyChanged`, `CommunityToolkit.Mvvm`, `IServiceCollection` | 🔵 `ESSENTIEL` |
| `054` | **Tests Unitaires MVVM** — Validation de la logique de présentation en testant directement le ViewModel. | `xUnit`, `Moq`, `WeakReferenceMessenger`, simulation de services | 🟢 `BONUS` |

---

## Phase 8 — WPF + ASP.NET Core : Desktop connecté au Backend

> Objectif : consommer les APIs REST depuis une application bureau WPF.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `055` | **CRUD Citations connecté (WPF)** — Charger, ajouter, modifier et supprimer les citations depuis l'API `019` dans un ViewModel. | `HttpClient` dans MVVM, `async` sur un `Command`, `StringContent`, `JsonSerializer` | 🔵 `ESSENTIEL` |
| `056` | **Authentification Desktop** — Fenêtre de connexion JWT + requêtes authentifiées avec token dans le header. | `PasswordBox`, `DefaultRequestHeaders.Authorization`, stockage du token en mémoire | 🔵 `ESSENTIEL` |
| `057` | **Catalogue avec recherche et DataGrid** — Affichage des produits avec tri, filtrage, pagination côté client et édition inline. | `CollectionView`, `Filter`, `DataGrid`, tri/filtrage, édition inline | 🔵 `ESSENTIEL` |
| `058` | **Dashboard et Upload** — Graphique à barres dessiné sur Canvas + upload d'images depuis le bureau. | `Canvas`, `Rectangle`, `OpenFileDialog`, `MultipartFormDataContent` | 🔵 `ESSENTIEL` |
| `059` | **Thème et Configuration** — Thème Dark/Light persisté + configuration multi-environnements. | `ResourceDictionary`, `DynamicResource`, `JsonSerializer` | 🟢 `BONUS` |
| `060` | **Impression et Rapports** — Génération de PDF ou impression via FlowDocument. | `FlowDocument`, `PrintDialog`, mise en page d'impression | 🟢 `BONUS` |
| `061` | 🔴 **Application de Gestion (Fil rouge Desktop)** — CRM ou Gestion de stock complète en WPF connectée à l'API : CRUD complet, auth, DataGrid avancé, graphiques, thème, impression. Reprise et enrichissement sur plusieurs semaines. | Synthèse complète : architecture MVVM, navigation `UserControl`, toutes les opérations API | 🔴 `FIL ROUGE` |

---

## Phase 9 — .NET MAUI : Applications Mobiles (sans backend)

> Objectif : porter les compétences C# sur mobile en apprenant le XAML multiplateforme et les fonctions natives.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `062` | **Hello MAUI & Tip Calculator** — Interface de bienvenue + calcul de pourboire avec Slider. | `ContentPage`, `StackLayout`, `Entry`, `Slider`, liaison de valeurs | 🔵 `ESSENTIEL` |
| `063` | **To-Do List Mobile** — Ajouter et supprimer des tâches avec geste de balayage. | `CollectionView`, `SwipeView`, `ObservableCollection`, `Picker` | 🔵 `ESSENTIEL` |
| `064` | **Utilitaires natifs** — Chronomètre sportif + prise de notes avec sauvegarde automatique. | `DispatcherTimer`, `Preferences` API, `Grid` proportionnel | 🔵 `ESSENTIEL` |
| `065` | **Capteurs et Médias** — Galerie d'images locale + lampe torche + boussole animée. | `MediaPicker`, MAUI Essentials (`Flashlight`, `Compass`), `RotateTo`, permissions | 🔵 `ESSENTIEL` |
| `066` | **Shell avancé et Navigation** — Navigation hiérarchique avec Flyout, Tabs et recherche globale. | `Shell`, `Flyout`, `TabBar`, navigation hiérarchique, `SearchHandler` | 🔵 `ESSENTIEL` |
| `067` | **Localisation et Permissions** — Application multilingue avec gestion dynamique des permissions. | Fichiers `.resx`, changement de culture, `Permissions.RequestAsync` | 🟢 `BONUS` |

---

## Phase 10 — .NET MAUI + ASP.NET Core : Mobile connecté au Backend

> Objectif : synchroniser l'application mobile avec le serveur, gérer les données en ligne et hors-ligne.

| # | Projet | Concepts clés | Badge |
|---|--------|---------------|-------|
| `068` | **CRUD Citations connecté (Mobile)** — Charger et ajouter des citations depuis l'API `019` avec indicateur de chargement. | `ActivityIndicator`, `HttpClient`, `async/await`, `Shell` navigation | 🔵 `ESSENTIEL` |
| `069` | **Authentification Mobile** — Formulaire de connexion JWT avec stockage sécurisé + requêtes authentifiées centralisées. | `SecureStorage`, `DelegatingHandler`, centralisation du token | 🔵 `ESSENTIEL` |
| `070` | **Catalogue et Upload** — Liste de produits avec recherche + prise de photo et envoi à l'API. | `CollectionView`, `SearchBar`, `MediaPicker`, `MultipartFormDataContent` | 🔵 `ESSENTIEL` |
| `071` | **Météo géolocalisée** — Récupérer les coordonnées GPS et appeler l'API météo. | MAUI Essentials `Geolocation`, appel HTTP avec paramètres | 🟢 `BONUS` |
| `072` | **Mode hors-ligne (EF Core)** — Stocker les données localement avec EF Core + SQLite et synchroniser à la reconnexion. | `Microsoft.EntityFrameworkCore.Sqlite`, `Connectivity`, offline-first, conflict resolution | 🔵 `ESSENTIEL` |
| `073` | 🔴 **Application Mobile complète (Fil rouge Mobile)** — Gestion de tâches ou e-commerce mobile avec tout le cycle : auth, offline, sync, profil utilisateur, notifications locales. Reprise et enrichissement sur plusieurs semaines. | Synthèse complète : MVVM MAUI, EF Core, `Shell`, mode hors-ligne, synchronisation delta | 🔴 `FIL ROUGE` |

---

> **Tronc commun (Phases 1–4) :** 33 projets — Le socle obligatoire.
> **Spécialisation (Phases 5–10) :** 39 projets à répartir selon votre orientation (≈20 par spécialisation choisie).
> **Fil rouge :** 5 projets longs simulant l'expérience réelle d'un développeur en entreprise.
