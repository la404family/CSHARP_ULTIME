# Idées de Projets — Formation C#

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

---

## Phase 1 — Console : Bases du langage C#

> Objectif : maîtriser la syntaxe C# et la logique algorithmique avant toute interface ou réseau.
> Projets `002` à `013`

- `002` **Calculatrice :** Saisir deux nombres et un opérateur, afficher le résultat. (Concepts : types, `if/else`, `switch`)
- `003` **Table de multiplication :** Afficher la table d'un nombre saisi. (Concepts : boucles `for`, entrée console)
- `004` **Devine le nombre :** L'ordinateur choisit un nombre, l'utilisateur doit le trouver avec des indices. (Concepts : `Random`, `while`, comparaisons)
- `005` **Vérificateur de palindrome :** Détermine si un mot saisi est un palindrome. (Concepts : `string`, méthodes de chaînes, `Reverse`)
- `006` **Compteur de mots :** Lit une phrase et compte mots, voyelles et consonnes. (Concepts : `Split`, `foreach`, `char`)
- `007` **Mini-calculatrice de notes :** Saisie de plusieurs notes, calcul de la moyenne, du max et du min. (Concepts : `List<T>`, LINQ : `Average`, `Max`, `Min`)
- `008` **Gestion d'inventaire :** Menu console pour ajouter, afficher et supprimer des articles. (Concepts : `class`, constructeur, `List<T>`, boucle `while`)
- `009` **Journal de bord :** Ajoute chaque message saisi avec un horodatage dans un fichier texte. (Concepts : `DateTime`, `File.AppendAllText`, I/O)
- `010` **Convertisseur de fichier texte :** Lit un `.txt` et écrit son contenu transformé dans un autre fichier. (Concepts : `File.ReadAllText`, `File.WriteAllText`)
- `011` **Filtreur de données CSV :** Lit un CSV, filtre les lignes selon un critère, sauvegarde le résultat. (Concepts : LINQ `Where`, `string.Split`, écriture de fichier)
- `012` **Simulateur de Banque (Exceptions) :** Gérer des dépôts et retraits avec des blocs `try/catch` et la création d'exceptions personnalisées (`FondsInsuffisantsException`).
- `013` **Gestionnaire d'Employés (POO Avancée) :** Utilisation de l'héritage (classes de base vs dérivées) et des interfaces (`IEmploye`) pour calculer des salaires différents selon le type d'employé.

---

## Phase 2 — Bases de données et SQL (Théorie & Pratique)

> Objectif : apprendre à modéliser des données et maîtriser le langage SQL brut avant d'utiliser un ORM.
> Projets `014` à `018`

- `014` **Création de la base de données :** Modélisation et création des tables pour un système e-commerce (Clients, Produits, Commandes) via des scripts SQL (`CREATE TABLE`).
- `015` **Insertion de données (Mock) :** Scripts d'insertion massive de données factices pour tester les futures requêtes (`INSERT INTO`).
- `016` **Requêtes CRUD de base :** Exercices de sélection, mise à jour et suppression de données simples (`SELECT`, `UPDATE`, `DELETE`).
- `017` **Jointures et Aggrégations :** Requêtes impliquant plusieurs tables pour obtenir le total des commandes par client ou le CA généré (`INNER JOIN`, `LEFT JOIN`, `GROUP BY`, `SUM`).
- `018` **Procédures stockées :** Création d'une procédure stockée simple permettant de valider une commande et de diminuer le stock d'un produit.

---

## Phase 3 — Console + ASP.NET Core : Introduction au Web

> Objectif : créer et consommer de petites APIs REST depuis la console. Apprendre les deux côtés (serveur et client) simultanément.
> Projets `019` à `028`

- `019` **Première Minimal API :** Route GET renvoyant un message de bienvenue avec le prénom en paramètre. (Concepts : Minimal API, Routing, Query parameters)
- `020` **API Calculatrice :** Route recevant deux nombres et une opération, renvoyant le résultat en JSON. (Concepts : Route parameters, retour JSON)
- `021` **API Générateur de citations (CRUD mémoire) :** Créer, lire, mettre à jour et supprimer des citations dans une liste. (Concepts : `GET`/`POST`/`PUT`/`DELETE`, Controllers)
- `022` **Console Client — Citations :** Application console consommant l'API de citations `021`. (Concepts : `HttpClient`, `async/await`, désérialisation JSON)
- `023` **API Météo mockée :** Renvoie des données météo aléatoires pour une ville passée en paramètre. (Concepts : `record`, sérialisation JSON, `Random`)
- `024` **Console Client — Météo :** Consomme l'API `023` et affiche les informations de façon formatée. (Concepts : `JsonSerializer.Deserialize`, `Console.ForegroundColor`)
- `025` **API de Quiz :** Renvoie des questions à choix multiples tirées au hasard depuis une liste. (Concepts : Injection de dépendances, liste de données statiques)
- `026` **Console Client — Quiz interactif :** Appelle l'API `025`, pose les questions et calcule le score. (Concepts : boucle de jeu, `HttpClient` dans une boucle)
- `027` **API Todo simple :** CRUD pour des tâches stockées en mémoire, avec statut (fait / en cours). (Concepts : `[FromBody]`, codes de retour `201 Created`, `404 Not Found`)
- `028` **Console Client — Todo :** Gère les tâches via la console : ajouter, lister, marquer comme fait, supprimer. (Concepts : client HTTP complet, sérialisation des requêtes)

---

## Phase 4 — Console + ASP.NET Core : Niveau Avancé

> Objectif : ajouter la persistance en base de données, la validation, la sécurité et les tests.
> Projets `029` à `040`

- `029` **API avec SQLite :** Reprendre l'API Todo `027` et persister les données avec Entity Framework Core. (Concepts : EF Core, `DbContext`, Migrations)
- `030` **API Blog avec SQL Server :** Articles avec titre, contenu, date et auteur, stockés en base SQL Server. (Concepts : EF Core Code First, relations entre entités)
- `031` **API Catalogue de produits :** Produits avec stock et catégories, retour d'erreur si stock insuffisant. (Concepts : codes HTTP métier, `409 Conflict`, `404 Not Found`)
- `032` **API avec validation stricte :** Carnet de contacts avec vérification du format email et du téléphone. (Concepts : `Data Annotations`, `ModelState.IsValid`)
- `033` **API avec Authentification JWT :** Endpoint de login renvoyant un token JWT signé. (Concepts : `JwtBearer`, claims, `IConfiguration`)
- `034` **Console Client — Authentifié :** Se connecte à l'API `033`, récupère le token et appelle une route protégée. (Concepts : `Authorization: Bearer`, headers HTTP)
- `035` **API avec upload de fichiers :** Route pour uploader une image, la sauvegarder et renvoyer son URL. (Concepts : `IFormFile`, `multipart/form-data`)
- `036` **Console Client — Upload :** Envoie un fichier local vers l'API `035` et affiche l'URL reçue. (Concepts : `MultipartFormDataContent`, `StreamContent`)
- `037` **API avec documentation Swagger :** Ajouter Swagger/OpenAPI à une API existante avec descriptions. (Concepts : `Swashbuckle`, commentaires XML, `SwaggerUI`)
- `038` **Tests unitaires de l'API :** Écrire des tests pour valider la logique des services. (Concepts : `xUnit`, `Moq`, injection de dépendances en test)
- `039` **Middleware de Log Global :** Création d'un middleware personnalisé interrogeant le pipeline HTTP pour chronométrer et logger chaque requête entrante.
- `040` **Mini-chat en temps réel (SignalR) :** Mise en place d'un Hub SignalR pour diffuser des messages en direct à tous les clients connectés.

---

## Phase 5 — Angular : Frontend seul (sans backend)

> Objectif : apprendre les fondamentaux d'Angular avec des données locales, sans réseau.
> Projets `041` à `050`

- `041` **Hello Angular :** Formulaire modifiant un message de bienvenue en temps réel. (Concepts : interpolation `{{ }}`, `[(ngModel)]`)
- `042` **Compteur interactif :** Boutons pour incrémenter, décrémenter et réinitialiser un compteur. (Concepts : Event Binding `(click)`, Property Binding `[disabled]`)
- `043` **Affichage conditionnel :** Afficher ou masquer des blocs selon la valeur d'une variable. (Concepts : `*ngIf`, `*ngSwitch`)
- `044` **Liste de tâches locale :** Ajouter, cocher et supprimer des tâches. (Concepts : `*ngFor`, `[ngClass]`, gestion d'état local)
- `045` **Composant Carte de profil :** Composant `<app-profil>` recevant des données depuis son parent. (Concepts : `@Input`, création et déclaration de composants)
- `046` **Calculatrice d'IMC :** Formulaire poids/taille avec résultat affiché instantanément. (Concepts : Template-driven forms, two-way binding)
- `047` **Convertisseur de texte :** Transformer un texte avec un Pipe personnalisé. (Concepts : `Pipe`, `PipeTransform`)
- `048` **Formulaire de contact validé :** Champs obligatoires avec messages d'erreur visibles. (Concepts : Reactive Forms, `FormBuilder`, `Validators`)
- `049` **Carrousel d'images :** Composant affichant une image à la fois avec boutons précédent/suivant. (Concepts : `@Output`, `EventEmitter`, communication enfant → parent)
- `050` **Navigation multi-pages :** Accueil / Liste d'articles / Détail d'un article (données statiques). (Concepts : `RouterModule`, `routerLink`, paramètres de route `/:id`)

---

## Phase 6 — Angular + ASP.NET Core : Frontend connecté au Backend

> Objectif : connecter l'application Angular aux APIs créées lors des Phases 3 et 4.
> Projets `051` à `060`

- `051` **Affichage des citations :** Charger la liste depuis l'API `021`. (Concepts : `HttpClient`, `Observable`, `async pipe`)
- `052` **Ajout de citation :** Formulaire Angular envoyant un `POST` à l'API `021`. (Concepts : requête POST avec corps JSON, rafraîchissement de liste)
- `053` **Modification et suppression :** Boutons d'édition et de suppression en ligne pour chaque citation. (Concepts : `PUT`/`DELETE`, confirmation d'action)
- `054` **Recherche et filtrage :** Barre de recherche filtrant les citations côté client. (Concepts : `filter()`, réactivité via `Subject` RxJS)
- `055` **Page de connexion :** Formulaire envoyant les identifiants à l'API JWT `033` et stockant le token. (Concepts : `localStorage`, `HttpClient` POST)
- `056` **Garde de route :** Pages de gestion accessibles uniquement si l'utilisateur est connecté. (Concepts : `CanActivate`, `AuthGuard`, `Router.navigate`)
- `057` **Affichage du catalogue produits :** Charger et paginer le catalogue depuis l'API `031`. (Concepts : pagination, paramètres de requête)
- `058` **Panier d'achat :** Ajouter/retirer des produits via un `Service` partagé. (Concepts : Service Angular, Injection de dépendances, état global)
- `059` **Tableau de bord :** Page résumant des statistiques de l'API (citations, tâches, produits). (Concepts : `forkJoin` pour requêtes parallèles, composants fils)
- `060` **Thème Dark/Light global :** Basculer les couleurs via un service persisté dans `localStorage`. (Concepts : `@HostBinding`, service global, CSS variables)

---

## Phase 7 — WPF : Applications Bureau Windows (sans backend)

> Objectif : créer des interfaces graphiques riches avec C# et XAML, apprendre le Data Binding et le pattern MVVM.
> Projets `061` à `070`

- `061` **Hello WPF :** Saisir un prénom et afficher un message de bienvenue. (Concepts : XAML basique, `TextBox`, `Label`, Code-behind)
- `062` **Calculatrice visuelle :** Interface de calculatrice avec boutons numériques et opérateurs. (Concepts : `Grid` Layout, `UniformGrid`, événements `Button`)
- `063` **Convertisseur de couleurs RGB :** Trois sliders modifiant la couleur d'un rectangle en temps réel. (Concepts : `Slider`, Data Binding direct, `SolidColorBrush`)
- `064` **Chronomètre :** Boutons Démarrer / Arrêter / Réinitialiser avec affichage dynamique. (Concepts : `DispatcherTimer`, UI Thread, formatage du temps)
- `065` **To-Do List locale :** Ajout et suppression de tâches dans une liste. (Concepts : `ObservableCollection<T>`, `ListBox`, `ItemsSource`)
- `066` **Visionneuse d'images :** Sélectionner une image sur le disque et l'afficher. (Concepts : `OpenFileDialog`, contrôle `Image`, `BitmapImage`)
- `067` **Bloc-notes :** Zone de texte avec sauvegarde et chargement de fichiers. (Concepts : `SaveFileDialog`, `TextBox` multi-lignes)
- `068` **Formulaire avec validation :** Champs qui deviennent rouges si le format est invalide. (Concepts : Styles conditionnels, `IDataErrorInfo`, Validation Rules)
- `069` **Carnet d'adresses (Master-Detail) :** Liste de contacts à gauche, détail à droite à la sélection. (Concepts : `DataContext`, `SelectedItem`, layout `Grid` deux colonnes)
- `070` **Interface MVVM complète :** Reprendre la To-Do List `065` avec un `ViewModel` propre. (Concepts : Pattern MVVM, `RelayCommand`, `INotifyPropertyChanged`, `Binding`)

---

## Phase 8 — WPF + ASP.NET Core : Desktop connecté au Backend

> Objectif : consommer les APIs REST depuis une application bureau WPF.
> Projets `071` à `080`

- `071` **Affichage des citations :** Charger la liste depuis l'API `021` dans un ViewModel WPF. (Concepts : `HttpClient` dans MVVM, `async` sur un `Command`)
- `072` **Ajout d'une citation :** Formulaire WPF envoyant un `POST` et rafraîchissant la liste. (Concepts : `StringContent`, `JsonSerializer`)
- `073` **Modification et suppression :** Boutons d'action sur chaque citation dans la `ListView`. (Concepts : `PUT`/`DELETE` depuis WPF, `SelectedItem`)
- `074` **Fenêtre de connexion :** Formulaire de login récupérant un token JWT depuis l'API `033`. (Concepts : `PasswordBox`, stockage du token en mémoire)
- `075` **Requêtes authentifiées :** Toutes les requêtes d'écriture incluent le token dans le header. (Concepts : `DefaultRequestHeaders.Authorization`)
- `076` **Affichage du catalogue produits :** `ListView` avec les produits de l'API `031` et barre de recherche locale. (Concepts : `CollectionView`, `Filter` sur `ObservableCollection`)
- `077` **Upload d'image depuis le bureau :** Sélectionner une image et l'envoyer à l'API `035`. (Concepts : `OpenFileDialog`, `MultipartFormDataContent`)
- `078` **Dashboard avec graphique :** Graphique à barres dessiné sur un `Canvas` à partir des données de l'API. (Concepts : `Canvas`, `Rectangle`, dimensions proportionnelles)
- `079` **Thème Dark/Light persisté :** Basculer le thème et le sauvegarder dans un fichier de configuration. (Concepts : `ResourceDictionary`, `DynamicResource`, `JsonSerializer`)
- `080` **Application CRUD complète :** Blog ou catalogue avec toutes les opérations connectées à l'API. (Concepts : architecture MVVM complète, navigation entre `UserControl`)

---

## Phase 9 — .NET MAUI : Applications Mobiles (sans backend)

> Objectif : porter les compétences C# sur mobile en apprenant le XAML multiplateforme et les fonctions natives.
> Projets `081` à `090`

- `081` **Hello MAUI :** Interface de bienvenue avec saisie de prénom et bouton d'action. (Concepts : `ContentPage`, `StackLayout`, `Entry`, `Button`, `Label`)
- `082` **Tip Calculator :** Saisir un montant et choisir le pourcentage de pourboire avec un Slider. (Concepts : `Slider`, `Entry`, liaison de valeurs)
- `083` **Convertisseur de distances :** Saisir un nombre et choisir l'unité source/cible. (Concepts : `Picker`, `ObservableCollection`)
- `084` **To-Do List Mobile :** Ajouter et supprimer des tâches avec un geste de balayage. (Concepts : `CollectionView`, `SwipeView`, `ObservableCollection`)
- `085` **Générateur de mots de passe :** Switches pour les options, bouton de génération. (Concepts : `Switch`, `HorizontalStackLayout`)
- `086` **Chronomètre sportif :** Affichage plein écran avec boutons Démarrer / Arrêter / Tour. (Concepts : `Grid` proportionnel, `DispatcherTimer` MAUI)
- `087` **Prise de notes rapide :** Zone de texte sauvegardée automatiquement entre les sessions. (Concepts : `Preferences` API)
- `088` **Galerie d'images locale :** Sélectionner une photo depuis la galerie du téléphone et l'afficher. (Concepts : `MediaPicker`, permissions, contrôle `Image`)
- `089` **Lampe torche :** Bouton pour activer/désactiver le flash de l'appareil. (Concepts : MAUI Essentials `Flashlight`)
- `090` **Boussole animée :** Afficher l'orientation de l'appareil avec une flèche qui tourne. (Concepts : MAUI Essentials `Compass`, animation `RotateTo`)

---

## Phase 10 — .NET MAUI + ASP.NET Core : Mobile connecté au Backend

> Objectif : synchroniser l'application mobile avec le serveur, gérer les données en ligne et hors-ligne.
> Projets `091` à `100`

- `091` **Affichage des citations :** Charger la liste depuis l'API `021` avec un indicateur de chargement. (Concepts : `ActivityIndicator`, `HttpClient`, `async/await`)
- `092` **Ajout d'une citation :** Formulaire mobile envoyant un `POST` à l'API `021`. (Concepts : `Shell` navigation, requête POST, retour à la liste)
- `093` **Page de connexion :** Formulaire de login récupérant un token JWT et le stockant de façon sécurisée. (Concepts : `SecureStorage`)
- `094` **Requêtes authentifiées :** Toutes les opérations d'écriture incluent le token dans le header. (Concepts : `DelegatingHandler`, centralisation du token)
- `095` **Affichage du catalogue produits :** Liste de produits depuis l'API `031` avec barre de recherche. (Concepts : `CollectionView` + filtre, `SearchBar`)
- `096` **Upload de photo vers l'API :** Prendre une photo avec la caméra et l'envoyer à l'API `035`. (Concepts : `MediaPicker`, `MultipartFormDataContent`)
- `097` **Météo géolocalisée :** Récupérer les coordonnées GPS et appeler l'API météo `023`. (Concepts : MAUI Essentials `Geolocation`, appel HTTP avec paramètres)
- `098` **Mode hors-ligne :** Stocker les citations en local (SQLite) et synchroniser à la reconnexion. (Concepts : `sqlite-net-pcl`, `Connectivity` MAUI Essentials, offline-first)
- `099` **Profil utilisateur :** Afficher et modifier les informations du compte depuis l'API. (Concepts : `GET`/`PUT`, image ronde avec `Clip`, `EllipseGeometry`)
- `100` **Application CRUD mobile complète :** Gestion de tâches synchronisée avec l'API, avec mode hors-ligne. (Concepts : architecture MVVM MAUI complète, SQLite + API, `Shell` navigation)
