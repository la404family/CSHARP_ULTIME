# Les Conventions et Bonnes Pratiques en C#

Quand tu écris du code C#, il ne suffit pas que ça "fonctionne". Un bon développeur écrit du code **lisible**, **maintenable** et **cohérent**. C'est exactement le rôle des **conventions** : un ensemble de règles que tous les développeurs C# suivent pour que le code soit compréhensible par n'importe qui.

> 💡 Pense aux conventions comme les règles de grammaire d'une langue : ton interlocuteur te comprendra peut-être sans elles, mais c'est beaucoup plus facile avec !

---

## 1. Les Conventions de Nommage

### 📝 Explication

Le **nommage**, c'est la façon dont tu donnes des noms à tes variables, méthodes, classes, etc. En C#, il existe des règles précises pour chaque type d'élément. Un mauvais nom rend le code incompréhensible ; un bon nom le rend auto-documenté.

**Les styles de casse utilisés en C# :**

| Style | Format | Exemple | Utilisé pour |
| :--- | :--- | :--- | :--- |
| **PascalCase** | Chaque mot commence par une majuscule | `CalculerPrix` | Classes, méthodes, propriétés, événements |
| **camelCase** | Comme PascalCase mais le 1er mot est en minuscule | `prixTotal` | Variables locales, paramètres de méthodes |
| **_camelCase** | camelCase précédé d'un underscore | `_compteur` | Champs privés d'une classe |
| **UPPER_CASE** | Tout en majuscules, mots séparés par `_` | `MAX_ESSAIS` | Constantes (parfois, selon les équipes) |
| **IPascalCase** | PascalCase précédé d'un `I` | `IDisposable` | Interfaces |

### 🔤 Syntaxe

```csharp
// PascalCase pour les classes
public class NomDeLaClasse { }

// PascalCase pour les méthodes
public void CalculerTotal() { }

// PascalCase pour les propriétés
public string NomComplet { get; set; }

// camelCase pour les variables locales
int prixUnitaire = 10;

// camelCase pour les paramètres
public void AfficherMessage(string messageUtilisateur) { }

// _camelCase pour les champs privés
private int _compteur;

// PascalCase avec préfixe I pour les interfaces
public interface ICalculable { }

// PascalCase pour les constantes (recommandé par Microsoft)
public const int NombreMaximumEssais = 3;
```

### 💡 Exemple Simple

```csharp
// ✅ BON — Les noms suivent les conventions C#
public class Joueur                    // PascalCase pour la classe
{
    private string _nom;               // _camelCase pour le champ privé
    private int _score;                // _camelCase pour le champ privé

    public string Nom { get; set; }    // PascalCase pour la propriété
    public int Score { get; set; }     // PascalCase pour la propriété

    public void AjouterPoints(int nombrePoints) // PascalCase pour la méthode, camelCase pour le paramètre
    {
        int nouveauScore = Score + nombrePoints; // camelCase pour la variable locale
        Score = nouveauScore;                    // On met à jour la propriété
    }
}
```

```csharp
// ❌ MAUVAIS — Les noms ne suivent pas les conventions
public class joueur                    // ❌ Devrait être PascalCase : Joueur
{
    private string Nom;                // ❌ Champ privé devrait être _nom
    public int score { get; set; }     // ❌ Propriété devrait être Score

    public void ajouter_points(int NombrePoints) // ❌ Méthode : AjouterPoints, paramètre : nombrePoints
    {
        int NouveauScore = score + NombrePoints;  // ❌ Variable locale : nouveauScore
        score = NouveauScore;
    }
}
```

### 🚀 Exemple Avancé

```csharp
// Un exemple réaliste montrant toutes les conventions de nommage en action
public interface IVehicule             // Interface : préfixe I + PascalCase
{
    string Marque { get; }             // Propriété : PascalCase
    void Demarrer();                   // Méthode : PascalCase
}

public class Voiture : IVehicule       // Classe : PascalCase
{
    // Constante : PascalCase (recommandation Microsoft)
    public const int NombreRoues = 4;

    // Champs privés : _camelCase
    private readonly string _marque;
    private bool _estDemarree;

    // Propriété publique : PascalCase
    public string Marque => _marque;

    // Constructeur : le paramètre est en camelCase
    public Voiture(string marqueVehicule)
    {
        _marque = marqueVehicule;      // On assigne le paramètre au champ privé
        _estDemarree = false;          // La voiture est éteinte par défaut
    }

    // Méthode publique : PascalCase
    public void Demarrer()
    {
        // Variable locale : camelCase
        bool peutDemarrer = !_estDemarree;

        if (peutDemarrer)
        {
            _estDemarree = true;       // On met à jour l'état
            Console.WriteLine($"La {_marque} démarre !");
        }
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **Utiliser `snake_case`** comme en Python (`nombre_de_joueurs`). En C#, on utilise `camelCase` pour les variables locales : `nombreDeJoueurs`.
- ❌ **Oublier le préfixe `I`** pour les interfaces : `Calculable` au lieu de `ICalculable`.
- ❌ **Utiliser des abréviations obscures** : `clcPrx()` au lieu de `CalculerPrix()`. Sois explicite !
- ❌ **Nommer avec un seul caractère** : `int x = 5;` au lieu de `int compteur = 5;` (sauf dans les boucles `for` où `i`, `j`, `k` sont acceptés).
- ❌ **Mettre le type dans le nom** (notation hongroise) : `strNom`, `intAge`. Écris simplement `nom`, `age`.

### ✅ Bonnes Pratiques

- ✅ Choisis des **noms descriptifs** qui expliquent le rôle de l'élément : `CalculerTotalCommande()` plutôt que `Calc()`.
- ✅ Utilise des **noms en anglais** pour les projets professionnels (standard de l'industrie), mais en français pour l'apprentissage c'est très bien.
- ✅ Les **noms de booléens** devraient poser une question : `estConnecte`, `aDesEnfants`, `peutModifier`.
- ✅ Les **noms de méthodes** devraient être des verbes d'action : `Envoyer()`, `Calculer()`, `AfficherResultat()`.
- ✅ Les **noms de classes** devraient être des noms (substantifs) : `Voiture`, `Joueur`, `CommandeClient`.

---

## 2. Les Conventions de Formatage

### 📝 Explication

Le **formatage**, c'est la façon dont tu organises visuellement ton code : l'indentation, les espaces, les retours à la ligne, les accolades. Un code bien formaté est facile à lire et à comprendre d'un seul coup d'œil.

### 🔤 Syntaxe

```csharp
// Règle 1 : Accolades TOUJOURS sur leur propre ligne (style Allman)
public class MaClasse
{                                      // ← Accolade ouvrante seule sur sa ligne
    public void MaMethode()
    {                                  // ← Idem ici
        // Code...
    }                                  // ← Accolade fermante seule sur sa ligne
}

// Règle 2 : Indentation avec 4 espaces (ou 1 tabulation)
public void Exemple()
{
    if (true)
    {
        Console.WriteLine("Indenté de 4 espaces");
    }
}

// Règle 3 : Un espace autour des opérateurs
int resultat = 5 + 3;                 // ✅ Bien
int resultat2 = 5+3;                  // ❌ Mal — pas d'espace

// Règle 4 : Pas d'espace avant les parenthèses d'un appel de méthode
Console.WriteLine("Bonjour");         // ✅ Bien
Console.WriteLine ("Bonjour");        // ❌ Mal — espace en trop
```

### 💡 Exemple Simple

```csharp
// ✅ BON FORMATAGE — Clair et aéré
public class Calculatrice
{
    public int Additionner(int a, int b)
    {
        int resultat = a + b;
        return resultat;
    }

    public int Soustraire(int a, int b)
    {
        int resultat = a - b;
        return resultat;
    }
}
```

```csharp
// ❌ MAUVAIS FORMATAGE — Compact et illisible
public class Calculatrice{
    public int Additionner(int a,int b){
        int resultat=a+b;return resultat;}
    public int Soustraire(int a,int b){int resultat=a-b;return resultat;}}
```

### 🚀 Exemple Avancé

```csharp
// Un fichier bien formaté avec toutes les conventions respectées
using System;                          // Les using en haut du fichier
using System.Collections.Generic;      // Triés par ordre alphabétique

namespace MonApplication.Services       // Namespace en PascalCase avec points
{
    /// <summary>
    /// Service responsable de la gestion des utilisateurs.
    /// </summary>
    public class ServiceUtilisateur
    {
        // 1. D'abord les champs privés
        private readonly List<string> _utilisateurs;
        private int _compteur;

        // 2. Ensuite le constructeur
        public ServiceUtilisateur()
        {
            _utilisateurs = new List<string>();
            _compteur = 0;
        }

        // 3. Puis les propriétés publiques
        public int NombreUtilisateurs => _utilisateurs.Count;

        // 4. Enfin les méthodes publiques
        public void AjouterUtilisateur(string nom)
        {
            // Validation en premier
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentException("Le nom ne peut pas être vide.");
            }

            // Logique métier ensuite
            _utilisateurs.Add(nom);
            _compteur++;

            // Affichage à la fin
            Console.WriteLine($"Utilisateur '{nom}' ajouté avec succès.");
        }

        // 5. Les méthodes privées en dernier
        private bool UtilisateurExiste(string nom)
        {
            return _utilisateurs.Contains(nom);
        }
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **Accolades à la K&R** (style Java/JavaScript) : `public void Methode() {`. En C#, l'accolade va **toujours** sur une nouvelle ligne.
- ❌ **Mélanger tabulations et espaces** pour l'indentation. Choisis l'un ou l'autre et sois constant.
- ❌ **Lignes trop longues** (plus de 120 caractères). Découpe-les pour améliorer la lisibilité.
- ❌ **Aucune ligne vide** entre les méthodes. Ajoute une ligne vide pour "aérer" le code.
- ❌ **Trop de lignes vides** (3, 4 vides d'affilée). Une seule ligne vide suffit pour séparer les blocs.

### ✅ Bonnes Pratiques

- ✅ Configure ton éditeur avec un fichier **`.editorconfig`** pour que le formatage soit automatique et uniforme dans tout le projet.
- ✅ Utilise **`Ctrl + K, Ctrl + D`** dans Visual Studio pour reformater automatiquement ton fichier.
- ✅ Un seul `using` par ligne, triés **alphabétiquement**, les `System` en premier.
- ✅ Une seule instruction par ligne : ne mets jamais deux instructions sur la même ligne.

---

## 3. Les Conventions de Commentaires

### 📝 Explication

Les **commentaires** servent à expliquer le **pourquoi** de ton code, pas le **quoi**. Un bon commentaire explique une décision ou un contexte ; un mauvais commentaire répète ce que le code dit déjà.

### 🔤 Syntaxe

```csharp
// Commentaire sur une seule ligne

/* Commentaire
   sur plusieurs
   lignes */

/// <summary>
/// Commentaire de documentation XML (pour les méthodes et classes publiques).
/// Ce type de commentaire génère automatiquement de la documentation.
/// </summary>
```

### 💡 Exemple Simple

```csharp
// ✅ BON COMMENTAIRE — Explique le "pourquoi"
// On arrondit à 2 décimales car les prix sont en euros
double prixFinal = Math.Round(prixBrut * 1.20, 2);

// ❌ MAUVAIS COMMENTAIRE — Répète ce que le code dit déjà
// On multiplie prixBrut par 1.20 et on arrondit à 2
double prixFinal = Math.Round(prixBrut * 1.20, 2);
```

```csharp
// ✅ BON — Le commentaire de documentation aide les autres développeurs
/// <summary>
/// Calcule le prix TTC à partir du prix HT.
/// </summary>
/// <param name="prixHorsTaxe">Le prix hors taxe en euros.</param>
/// <returns>Le prix TTC arrondi à 2 décimales.</returns>
public double CalculerPrixTTC(double prixHorsTaxe)
{
    return Math.Round(prixHorsTaxe * 1.20, 2);
}
```

### 🚀 Exemple Avancé

```csharp
/// <summary>
/// Vérifie si un utilisateur a le droit de se connecter.
/// </summary>
/// <param name="identifiant">L'identifiant unique de l'utilisateur.</param>
/// <param name="motDePasse">Le mot de passe en clair (sera haché pour la comparaison).</param>
/// <returns>
/// <c>true</c> si les identifiants sont valides et le compte n'est pas verrouillé ;
/// <c>false</c> sinon.
/// </returns>
/// <exception cref="ArgumentNullException">
/// Si <paramref name="identifiant"/> ou <paramref name="motDePasse"/> est null.
/// </exception>
public bool VerifierConnexion(string identifiant, string motDePasse)
{
    // Vérification des paramètres obligatoires
    if (identifiant == null)
    {
        throw new ArgumentNullException(nameof(identifiant));
    }

    if (motDePasse == null)
    {
        throw new ArgumentNullException(nameof(motDePasse));
    }

    // On vérifie d'abord si le compte est verrouillé
    // avant de tester le mot de passe (pour éviter des appels inutiles à la BDD)
    if (EstCompteVerrouille(identifiant))
    {
        return false;
    }

    // Comparaison sécurisée du mot de passe haché
    string motDePasseHache = Hacher(motDePasse);
    return motDePasseHache == ObtenirMotDePasseStocke(identifiant);
}
```

### ⚠️ Erreurs Courantes

- ❌ **Commenter chaque ligne** : noie l'information utile dans le bruit.
- ❌ **Commentaires obsolètes** : un commentaire qui ne correspond plus au code est **pire** que pas de commentaire du tout.
- ❌ **Commenter du code** au lieu de le supprimer : utilise Git pour retrouver l'ancien code, ne le laisse pas en commentaire.
- ❌ **Oublier les commentaires XML** sur les méthodes publiques : ils sont essentiels pour générer la documentation et aider IntelliSense.

### ✅ Bonnes Pratiques

- ✅ Commente le **pourquoi**, pas le **quoi**. Si tu dois expliquer le "quoi", c'est que ton code n'est pas assez clair — renomme tes variables.
- ✅ Utilise les **commentaires XML** (`///`) pour toutes les classes et méthodes **publiques**.
- ✅ Place un commentaire **TODO** pour marquer le travail restant : `// TODO: Ajouter la validation de l'email`.
- ✅ Mets à jour les commentaires **en même temps** que le code qu'ils décrivent.

---

## 4. L'Organisation d'un Fichier C#

### 📝 Explication

Un fichier C# bien organisé suit un **ordre logique** que tous les développeurs connaissent. Cela permet de retrouver rapidement ce qu'on cherche dans une classe.

### 🔤 Syntaxe — L'ordre recommandé

```csharp
// 1. Directives using (en haut du fichier)
using System;
using System.Collections.Generic;

// 2. Déclaration du namespace
namespace MonApplication.Models
{
    // 3. Déclaration de la classe
    public class Exemple
    {
        // 4. Constantes et champs statiques
        public const int Capacite = 100;
        private static int _instanceCount;

        // 5. Champs privés
        private readonly string _nom;
        private int _valeur;

        // 6. Constructeur(s)
        public Exemple(string nom)
        {
            _nom = nom;
        }

        // 7. Propriétés publiques
        public string Nom => _nom;
        public int Valeur { get; set; }

        // 8. Méthodes publiques
        public void Afficher()
        {
            Console.WriteLine(_nom);
        }

        // 9. Méthodes privées
        private void MethodeInterne()
        {
            // Logique interne...
        }
    }
}
```

### 💡 Exemple Simple

```csharp
using System;                          // 1. Using en haut

namespace MonJeu                       // 2. Namespace
{
    public class Personnage            // 3. Classe
    {
        // 4. Champs privés
        private string _nom;
        private int _pointsDeVie;

        // 5. Constructeur
        public Personnage(string nom)
        {
            _nom = nom;
            _pointsDeVie = 100;        // Un nouveau personnage a 100 PV
        }

        // 6. Propriétés
        public string Nom => _nom;
        public int PointsDeVie => _pointsDeVie;
        public bool EstVivant => _pointsDeVie > 0;

        // 7. Méthodes publiques
        public void SubirDegats(int degats)
        {
            _pointsDeVie = Math.Max(0, _pointsDeVie - degats);
        }
    }
}
```

### 🚀 Exemple Avancé

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonApplication.Services
{
    /// <summary>
    /// Service de gestion de l'inventaire d'un magasin.
    /// Gère l'ajout, la suppression et la recherche de produits.
    /// </summary>
    public class ServiceInventaire : IServiceInventaire
    {
        // ── Constantes ──────────────────────────────────────
        private const int StockMinimumAlerte = 5;

        // ── Champs privés ───────────────────────────────────
        private readonly List<Produit> _produits;
        private readonly ILogger _logger;

        // ── Constructeur ────────────────────────────────────
        public ServiceInventaire(ILogger logger)
        {
            _produits = new List<Produit>();
            _logger = logger;
        }

        // ── Propriétés publiques ────────────────────────────
        public int NombreProduits => _produits.Count;

        public bool ADesAlertesStock =>
            _produits.Any(p => p.Quantite < StockMinimumAlerte);

        // ── Méthodes publiques ──────────────────────────────
        public void AjouterProduit(Produit produit)
        {
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit));
            }

            _produits.Add(produit);
            _logger.Log($"Produit '{produit.Nom}' ajouté à l'inventaire.");
        }

        public List<Produit> ObtenirProduitsEnAlerte()
        {
            return _produits
                .Where(p => p.Quantite < StockMinimumAlerte)
                .OrderBy(p => p.Quantite)
                .ToList();
        }

        // ── Méthodes privées ────────────────────────────────
        private bool ProduitExiste(string nomProduit)
        {
            return _produits.Any(p => p.Nom == nomProduit);
        }
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **Mettre plusieurs classes dans un seul fichier**. Règle d'or : **une classe = un fichier**, et le fichier porte le même nom que la classe (`Joueur.cs` pour la classe `Joueur`).
- ❌ **Mélanger l'ordre des membres** : les champs privés au milieu, les constructeurs à la fin... Suis toujours le même ordre.
- ❌ **Mettre des `using` inutilisés** : ça encombre le haut du fichier. Visual Studio peut les nettoyer automatiquement.
- ❌ **Imbriquer trop de niveaux** (if dans if dans if...). Si tu dépasses 3 niveaux d'indentation, refactorise ton code.

### ✅ Bonnes Pratiques

- ✅ **Un fichier = une classe**. Nomme le fichier comme la classe.
- ✅ Utilise des **commentaires de section** (`// ── Section ──`) pour séparer visuellement les blocs dans les classes longues.
- ✅ Trie les membres par **niveau d'accès** : `public` avant `private`.
- ✅ Garde tes fichiers **courts** : si un fichier dépasse 200-300 lignes, c'est un signe qu'il faut découper la classe.

---

## 5. Les Conventions sur les Types et Variables

### 📝 Explication

En C#, tu peux déclarer les types de deux façons : en **écrivant le type explicitement** ou en utilisant le mot-clé **`var`** qui laisse le compilateur deviner le type. Il y a des règles pour savoir quand utiliser l'un ou l'autre.

### 🔤 Syntaxe

```csharp
// Type explicite — Tu écris le type toi-même
string nom = "Alice";
int age = 25;
List<string> prenoms = new List<string>();

// Mot-clé var — Le compilateur déduit le type automatiquement
var nom = "Alice";                     // Le compilateur sait que c'est un string
var age = 25;                          // int
var prenoms = new List<string>();      // List<string>
```

### 💡 Exemple Simple

```csharp
// ✅ Utilise var quand le type est ÉVIDENT à droite du signe =
var message = "Bonjour";               // On voit que c'est un string
var compteur = 0;                      // On voit que c'est un int
var joueurs = new List<Joueur>();       // On voit que c'est une List<Joueur>
var dictionnaire = new Dictionary<string, int>(); // Évite la répétition

// ✅ Utilise le type explicite quand le type n'est PAS évident
int resultat = CalculerScore();        // Sans le type, on ne saurait pas ce que retourne la méthode
FileStream fichier = ObtenirFichier(); // Le type explicite clarifie l'intention
```

### 🚀 Exemple Avancé

```csharp
public class Panier
{
    private readonly List<Article> _articles = new List<Article>();

    public void AjouterArticle(Article article)
    {
        // ✅ var : le type est évident (c'est une List<Article>)
        var articlesExistants = _articles.Where(a => a.Nom == article.Nom).ToList();

        // ✅ Type explicite : le type retourné n'est pas évident
        decimal prixTotal = CalculerPrixAvecReduction(article);

        // ✅ var : le type est visible dans le new
        var nouvelArticle = new Article
        {
            Nom = article.Nom,
            Prix = prixTotal,
            Quantite = 1
        };

        _articles.Add(nouvelArticle);
    }

    // ✅ Utilise des noms de variables qui se comprennent seuls
    public string ObtenirResume()
    {
        var nombreArticles = _articles.Count;             // int — évident
        decimal montantTotal = _articles.Sum(a => a.Prix); // decimal — précisé

        return $"{nombreArticles} articles pour {montantTotal:C}";
    }

    private decimal CalculerPrixAvecReduction(Article article)
    {
        const decimal tauxReduction = 0.10m;  // 10% de réduction
        return article.Prix * (1 - tauxReduction);
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **Utiliser `var` partout** sans réfléchir : `var x = GetData();` — impossible de savoir ce que retourne `GetData()`.
- ❌ **Ne jamais utiliser `var`** : écrire `Dictionary<string, List<int>> dico = new Dictionary<string, List<int>>();` est inutilement verbeux.
- ❌ **Déclarer les variables loin** de leur utilisation. Déclare une variable **au plus près** de l'endroit où tu l'utilises.
- ❌ **Réutiliser une variable** pour un autre usage : `total = total + 1; total = "fini";` — c'est interdit en C# (typage fort) et c'est une très mauvaise pratique.

### ✅ Bonnes Pratiques

- ✅ Utilise **`var`** quand le type est **évident** en lisant la ligne.
- ✅ Utilise le **type explicite** quand ça **clarifie** le code.
- ✅ Déclare les variables **au plus proche** de leur première utilisation.
- ✅ Une variable a **un seul rôle**. Ne recycle pas une variable pour un usage différent.
- ✅ Préfère **`const`** ou **`readonly`** quand une valeur ne change jamais.

---

## 6. Les Conventions sur les Accolades et le Flux de Contrôle

### 📝 Explication

En C#, les **accolades `{ }`** délimitent les blocs de code. Même quand le compilateur les rend optionnelles (pour un `if` d'une seule ligne par exemple), les conventions Microsoft recommandent de **toujours les mettre** pour éviter les bugs.

### 🔤 Syntaxe

```csharp
// ✅ RECOMMANDÉ — Toujours mettre les accolades
if (condition)
{
    FaireQuelqueChose();
}

// ❌ DÉCONSEILLÉ — Accolades manquantes (risque de bug)
if (condition)
    FaireQuelqueChose();
```

### 💡 Exemple Simple

```csharp
// ✅ BON — Les accolades protègent contre les erreurs
if (age >= 18)
{
    Console.WriteLine("Tu es majeur.");
}
else
{
    Console.WriteLine("Tu es mineur.");
}

// ✅ BON — Même pour une seule ligne dans le for
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

```csharp
// ❌ DANGEREUX — Le bug classique sans accolades
if (estConnecte)
    Console.WriteLine("Bienvenue !");
    ChargerProfil();   // ⚠️ PIÈGE ! Cette ligne s'exécute TOUJOURS,
                       // même si estConnecte est false.
                       // L'indentation est trompeuse !

// ✅ CORRECT — Avec les accolades, pas d'ambiguïté
if (estConnecte)
{
    Console.WriteLine("Bienvenue !");
    ChargerProfil();   // S'exécute uniquement si estConnecte est true
}
```

### 🚀 Exemple Avancé

```csharp
// ✅ BON — Utilisation des retours anticipés (early return)
// pour éviter l'imbrication excessive
public string ObtenirStatutCommande(Commande commande)
{
    // Validation en premier avec des retours anticipés
    if (commande == null)
    {
        return "Commande introuvable";
    }

    if (!commande.EstPayee)
    {
        return "En attente de paiement";
    }

    if (!commande.EstExpediee)
    {
        return "En cours de préparation";
    }

    if (!commande.EstLivree)
    {
        return "En cours de livraison";
    }

    return "Livrée";
}

// ❌ MAUVAIS — Trop d'imbrication (arrow anti-pattern)
public string ObtenirStatutCommandeMauvais(Commande commande)
{
    if (commande != null)
    {
        if (commande.EstPayee)
        {
            if (commande.EstExpediee)
            {
                if (commande.EstLivree)
                {
                    return "Livrée";       // 5 niveaux d'indentation !
                }
                else
                {
                    return "En cours de livraison";
                }
            }
            else
            {
                return "En cours de préparation";
            }
        }
        else
        {
            return "En attente de paiement";
        }
    }
    else
    {
        return "Commande introuvable";
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **Omettre les accolades** sur les blocs d'une seule ligne : c'est la porte ouverte aux bugs silencieux.
- ❌ **Imbriquer trop de niveaux** : si tu as plus de 3 niveaux de `if`, utilise des retours anticipés (early return).
- ❌ **Placer l'accolade ouvrante sur la même ligne** que la condition : `if (x) {`. En C#, elle va sur **la ligne suivante**.

### ✅ Bonnes Pratiques

- ✅ **Toujours mettre les accolades**, même pour une seule ligne.
- ✅ Utilise les **retours anticipés** (`return` en début de méthode) pour réduire l'imbrication.
- ✅ Le style **Allman** (accolade sur sa propre ligne) est le standard en C#.
- ✅ Chaque bloc `if`, `else`, `for`, `while`, `foreach` doit avoir ses accolades.

---

## 7. Les Conventions de Gestion des Exceptions

### 📝 Explication

Les **exceptions** sont des erreurs qui surviennent pendant l'exécution de ton programme (un fichier introuvable, une division par zéro, etc.). Les conventions te disent **quand** les attraper, **comment** les gérer et **ce qu'il ne faut surtout pas faire**.

### 🔤 Syntaxe

```csharp
try
{
    // Code qui pourrait échouer
}
catch (TypeExceptionSpecifique ex)     // Attrape un type précis
{
    // Traitement de l'erreur
}
catch (Exception ex)                   // Attrape toutes les autres erreurs
{
    // Traitement générique
}
finally
{
    // Code qui s'exécute TOUJOURS (avec ou sans erreur)
}
```

### 💡 Exemple Simple

```csharp
// ✅ BON — Attraper une exception spécifique
try
{
    int resultat = 10 / 0;             // Ceci va provoquer une erreur
}
catch (DivideByZeroException ex)       // On cible l'erreur exacte
{
    Console.WriteLine("Erreur : division par zéro impossible !");
    Console.WriteLine($"Détail : {ex.Message}");
}
```

```csharp
// ❌ MAUVAIS — Attraper toutes les exceptions et les ignorer
try
{
    int resultat = 10 / 0;
}
catch (Exception)                      // ❌ Trop large
{
    // ❌ VIDE ! L'erreur est avalée en silence
}
```

### 🚀 Exemple Avancé

```csharp
/// <summary>
/// Lit le contenu d'un fichier texte de manière sécurisée.
/// </summary>
/// <param name="cheminFichier">Le chemin vers le fichier à lire.</param>
/// <returns>Le contenu du fichier, ou null si la lecture échoue.</returns>
public string LireFichier(string cheminFichier)
{
    // Validation AVANT le try (pas besoin d'exception pour ça)
    if (string.IsNullOrWhiteSpace(cheminFichier))
    {
        throw new ArgumentException(
            "Le chemin du fichier ne peut pas être vide.",
            nameof(cheminFichier));
    }

    try
    {
        // La lecture pourrait échouer (fichier verrouillé, droits insuffisants...)
        string contenu = File.ReadAllText(cheminFichier);
        return contenu;
    }
    catch (FileNotFoundException ex)
    {
        // Exception spécifique : le fichier n'existe pas
        Console.WriteLine($"Le fichier '{cheminFichier}' est introuvable.");
        Console.WriteLine($"Détail : {ex.Message}");
        return null;
    }
    catch (UnauthorizedAccessException ex)
    {
        // Exception spécifique : pas les droits
        Console.WriteLine($"Accès refusé au fichier '{cheminFichier}'.");
        Console.WriteLine($"Détail : {ex.Message}");
        return null;
    }
    catch (IOException ex)
    {
        // Exception plus large pour les autres erreurs d'entrée/sortie
        Console.WriteLine($"Erreur lors de la lecture : {ex.Message}");
        return null;
    }
}
```

### ⚠️ Erreurs Courantes

- ❌ **`catch (Exception)` vide** : avaler les erreurs en silence rend le débogage impossible.
- ❌ **Utiliser les exceptions pour le flux normal** : `try/catch` n'est **pas** un remplacement de `if/else`. Teste avec `File.Exists()` avant de lire un fichier.
- ❌ **`throw ex;`** au lieu de **`throw;`** : `throw ex;` détruit la pile d'appels originale, ce qui complique le débogage.
- ❌ **Attraper `Exception`** trop tôt : cible d'abord les exceptions spécifiques.

### ✅ Bonnes Pratiques

- ✅ Attrape les **exceptions spécifiques** en premier (`FileNotFoundException` avant `IOException` avant `Exception`).
- ✅ Utilise **`throw;`** (sans paramètre) pour relancer une exception tout en gardant la trace complète.
- ✅ Utilise le bloc **`finally`** pour libérer les ressources (ou mieux, utilise **`using`**).
- ✅ **Valide les paramètres** en amont (avec `if`) plutôt que d'attraper des exceptions.
- ✅ **Journalise** (log) les erreurs pour pouvoir les diagnostiquer plus tard.

---

## 8. Tableau Récapitulatif des Conventions

| Catégorie | Convention | Exemple ✅ | Exemple ❌ |
| :--- | :--- | :--- | :--- |
| **Classe** | PascalCase | `class MonJoueur` | `class monJoueur` |
| **Méthode** | PascalCase | `void CalculerScore()` | `void calculer_score()` |
| **Propriété** | PascalCase | `public int Score { get; set; }` | `public int score { get; set; }` |
| **Variable locale** | camelCase | `int monScore = 0;` | `int MonScore = 0;` |
| **Paramètre** | camelCase | `void Dire(string message)` | `void Dire(string Message)` |
| **Champ privé** | _camelCase | `private int _compteur;` | `private int compteur;` |
| **Constante** | PascalCase | `const int MaxJoueurs = 4;` | `const int MAX_JOUEURS = 4;` |
| **Interface** | I + PascalCase | `interface IJouable` | `interface Jouable` |
| **Namespace** | PascalCase avec points | `MonApp.Services` | `monApp.services` |
| **Enum** | PascalCase (singulier) | `enum Couleur { Rouge }` | `enum Couleurs { rouge }` |
| **Accolades** | Style Allman (nouvelle ligne) | voir section 2 | `if (x) {` |
| **Indentation** | 4 espaces | voir section 2 | 2 espaces / tabs mélangés |

---

## 9. Les Outils pour Appliquer les Conventions

### 📝 Explication

Tu n'as pas besoin de tout retenir par cœur ! Il existe des **outils** qui vérifient et appliquent automatiquement les conventions pour toi.

| Outil | Rôle | Intégration |
| :--- | :--- | :--- |
| **EditorConfig** | Définit les règles de formatage dans un fichier `.editorconfig` à la racine du projet | Visual Studio, VSCode, Rider |
| **StyleCop Analyzers** | Vérifie les conventions de style **pendant la compilation** (affiche des warnings) | Package NuGet |
| **Roslyn Analyzers** | Analyse le code en profondeur et suggère des améliorations | Intégré dans Visual Studio |
| **dotnet format** | Reformate automatiquement tout le code d'un projet | Outil en ligne de commande |

### 💡 Exemple Simple — Fichier `.editorconfig`

```ini
# Fichier .editorconfig à placer à la racine de ton projet
# Il configure automatiquement l'éditeur pour respecter les conventions

# Paramètres par défaut pour tous les fichiers
root = true

[*]
indent_style = space
indent_size = 4
end_of_line = crlf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true

# Paramètres spécifiques aux fichiers C#
[*.cs]
# Nommage : les champs privés commencent par _
dotnet_naming_rule.private_fields_must_begin_with_underscore.severity = warning
dotnet_naming_rule.private_fields_must_begin_with_underscore.symbols = private_fields
dotnet_naming_rule.private_fields_must_begin_with_underscore.style = underscore_prefix

dotnet_naming_symbols.private_fields.applicable_kinds = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private

dotnet_naming_style.underscore_prefix.required_prefix = _
dotnet_naming_style.underscore_prefix.capitalization = camel_case

# Préférer var quand le type est évident
csharp_style_var_for_built_in_types = true:suggestion
csharp_style_var_when_type_is_apparent = true:suggestion
csharp_style_var_elsewhere = false:suggestion

# Toujours utiliser les accolades
csharp_prefer_braces = true:warning
```

### 🚀 Exemple Avancé — Commande dotnet format

```bash
# Reformater automatiquement tout le projet selon le .editorconfig
dotnet format ./MonProjet.sln

# Vérifier le formatage sans modifier les fichiers (utile en CI/CD)
dotnet format ./MonProjet.sln --verify-no-changes

# Reformater uniquement un fichier spécifique
dotnet format ./MonProjet.sln --include MonFichier.cs
```

### ✅ Bonnes Pratiques

- ✅ **Ajoute un `.editorconfig`** à chaque projet dès le début.
- ✅ **Installe StyleCop Analyzers** via NuGet pour avoir des retours automatiques sur les conventions.
- ✅ **Utilise `dotnet format`** dans ta pipeline CI/CD pour garantir que tout le code respecte les mêmes règles.
- ✅ Configure ton IDE pour **reformater automatiquement** à chaque sauvegarde.

---

## 🧠 Ce qu'il faut retenir

> Les conventions ne sont pas des obstacles à ta créativité — elles sont le **langage commun** qui permet à tous les développeurs C# de lire et comprendre le code des autres.

| Principe | Résumé |
| :--- | :--- |
| 📛 **Nommage** | PascalCase pour le public, camelCase pour le local, _camelCase pour le privé |
| 📐 **Formatage** | Style Allman, 4 espaces, code aéré |
| 💬 **Commentaires** | Explique le pourquoi, pas le quoi. Utilise XML (`///`) pour le public |
| 📁 **Organisation** | Un fichier = une classe. Ordre : champs → constructeur → propriétés → méthodes |
| 🔤 **var vs type** | `var` quand c'est évident, type explicite quand ça clarifie |
| 🔒 **Accolades** | Toujours les mettre, même pour une seule ligne |
| 🛡️ **Exceptions** | Spécifiques d'abord, jamais vides, `throw;` plutôt que `throw ex;` |
| 🔧 **Outils** | EditorConfig + StyleCop + dotnet format = conventions automatiques |
