# 021 - LINQ (Language Integrated Query) et les expressions Lambda

Bienvenue dans l'univers de **LINQ** ! C'est ce qui fait que de nombreux développeurs tombent amoureux du langage C#. LINQ te permet de manipuler, filtrer, trier et transformer des données (comme des listes ou des tableaux) aussi facilement que si tu posais une question à une base de données, mais directement dans ton code, sans utiliser d'énormes boucles `for` ou `foreach`.

Pour que LINQ fonctionne, tu vas devoir utiliser ce qu'on appelle la **syntaxe Lambda** : la fameuse flèche `=>`.

_*(N'oublie pas d'ajouter `using System.Linq;` tout en haut de ton fichier C# pour pouvoir utiliser LINQ !)*_

---

## Les expressions Lambda (`x => ...`)

### 📝 Explication
Une **expression Lambda** est une façon d'écrire une mini-fonction anonyme sur une seule ligne. Le symbole `=>` se prononce "tel que" ou "qui devient". Elle définit ce que tu veux faire "pour chaque élément" de ta collection au moment où la ligne de code s'exécute.

_Note:_ La variable à gauche de la flèche (souvent nommée `x`, mais tu peux l'appeler `joueur`, `nombre`, etc.) représente un élément unique de la liste au moment où LINQ est en train de la lire.

---

## Filtrer avec `Where`

### 📝 Explication
La méthode `.Where()` sert à **filtrer** une collection. Elle regarde chaque élément et ne conserve que ceux qui répondent "Vrai" à la condition que tu lui imposes dans ta Lambda.

### 🔤 Syntaxe
```csharp
var resultats = liste.Where(element => conditionAsatisfaire);
```

### 💡 Exemple Simple
```csharp
// Une liste de nombres basique
List<int> nombres = new List<int> { 1, 2, 3, 4, 5, 6 };

// On demande à conserver uniquement les nombres qui sont pairs (modulo 2 = 0)
// "n" représente chaque nombre, un par un, quand LINQ fait sa vérification
var nombresPairs = nombres.Where(n => n % 2 == 0).ToList();

// Affichera : 2, 4, 6
foreach(var nb in nombresPairs)
{
    Console.WriteLine(nb);
}
```

### 🚀 Exemple Avancé
```csharp
// Une classe simulant un joueur
class Joueur
{
    public string Nom { get; set; }
    public int Score { get; set; }
}

List<Joueur> joueurs = new List<Joueur>
{
    new Joueur { Nom = "Alice", Score = 120 },
    new Joueur { Nom = "Bob", Score = 45 },
    new Joueur { Nom = "Charlie", Score = 200 }
};

// On veut récupérer tous les joueurs ayant un score supérieur à 100
// Ici, on a appelé la variable 'j' pour symboliser un Joueur.
var joueursGagnants = joueurs.Where(j => j.Score > 100).ToList();

// Affichera Alice et Charlie
foreach(var gagnant in joueursGagnants)
{
    Console.WriteLine($"{gagnant.Nom} a gagné avec {gagnant.Score} points !");
}
```

### ⚠️ Erreurs Courantes
- **Oublier le `.ToList()` ou `.ToArray()` :** LINQ est feignant (on parle d'*exécution différée*). Tant que tu ne lui dis pas clairement d'exporter sa recherche dans une liste physique avec `.ToList()`, il ne fait rien et garde juste la "requête" en mémoire. Cela peut causer des comportements inattendus si on modifie la liste de base juste après.

### ✅ Bonnes Pratiques
- Donne toujours un nom de variable Lambda clair. Utilise la première lettre du type (`j` pour `Joueur`, `n` pour `Nombre`) pour que ton code soit facilement lisible par un autre humain.

---

## Transformer avec `Select`

### 📝 Explication
Contrairement à `Where` qui filtre (garde ou supprime), **`Select`** sert à **transformer** ou à extraire une information très précise. Par exemple, à partir d'une liste de personnes complètes, tu ne veux extraire qu'une liste contenant uniquement leurs prénoms.

### 🔤 Syntaxe
```csharp
var extraits = liste.Select(element => proprieteARecuperer);
```

### 💡 Exemple Simple
```csharp
// Une liste de mots
List<string> mots = new List<string> { "Chat", "Hippopotame", "Rat" };

// On utilise 'm' pour chaque mot, et on demande de récupérer uniquement la longueur du mot
var longueurs = mots.Select(m => m.Length).ToList();

// Affichera : 4, 11, 3
foreach(var taille in longueurs)
{
    Console.WriteLine(taille);
}
```

### 🚀 Exemple Avancé
```csharp
// Reprenons notre liste de joueurs du dessus.
// Cette fois, on veut créer une liste de textes simples pour un affichage sur un écran de score statique
var annoncesScores = joueurs.Select(j => $"SCORE: {j.Nom.ToUpper()} = {j.Score} pts").ToList();

// Tu remarqueras qu'on peut transformer la donnée (majuscules, concaténation) directement!
foreach(var texte in annoncesScores)
{
    // Affiche par exemple "SCORE: ALICE = 120 pts"
    Console.WriteLine(texte);
}
```

### ⚠️ Erreurs Courantes
- **Confondre `Where` et `Select` :** On croise souvent des débutants utiliser `Select` en espérant filtrer des résultats. `Select` *modifie la forme*, `Where` *riduit la taille* de la liste.

### ✅ Bonnes Pratiques
- N'hésite pas à chaîner LINQ ! Tu peux faire filtre PUIS transformer : `liste.Where(x => ...).Select(x => ...)`. La puissance devient incroyable sur une seule ligne.

---

## Trier avec `OrderBy` et `OrderByDescending`

### 📝 Explication
Comme leurs noms l'indiquent en anglais, ces méthodes permettent de **trier** les éléments de ta collection d'après le critère de ton choix, par ordre alphabétique/numérique croissant (`OrderBy`) ou décroissant (`OrderByDescending`).

### 🔤 Syntaxe
```csharp
var triesCroissant = liste.OrderBy(element => proprietePourLeTri);
var triesDecroissant = liste.OrderByDescending(element => proprietePourLeTri);
```

### 💡 Exemple Simple
```csharp
List<int> desordre = new List<int> { 5, 1, 9, 3 };

// Tri croissant (plus petit au plus grand)
var croissant = desordre.OrderBy(n => n).ToList(); // { 1, 3, 5, 9 }

// Tri décroissant (plus grand au plus petit)
var decroissant = desordre.OrderByDescending(n => n).ToList(); // { 9, 5, 3, 1 }
```

### 🚀 Exemple Avancé
```csharp
// On veut classer nos joueurs du gagnant (plus de points) au perdant (moins de points)
// On va donc utiliser un ordonnancement décroissant, et ce qui nous interesse pour trier c'est le 'Score' !
var tableauAnnonceurs = joueurs.OrderByDescending(j => j.Score).ToList();

// Les joueurs seront maintenant affichés dans l'ordre : Charlie (200), puis Alice (120), puis Bob (45)
Console.WriteLine("Classement actuel :");
foreach (var j in tableauAnnonceurs)
{
    Console.WriteLine($"{j.Nom} - {j.Score} pts");
}
```

### ⚠️ Erreurs Courantes
- Penser que `list.OrderBy()` trie la liste originale. Faux, LINQ ne modifie jamais les données d'origine ! Il crée une **nouvelle** séquence ordonnée. Tu dois l'assigner à une nouvelle variable ou écraser l'ancienne variable avec le résultat suivi d'un `.ToList()`.

### ✅ Bonnes Pratiques
- Toujours vérifier que la propriété que vous utilisez pour trier n'est pas nulle pour l'un des objets, sinon provoquer une exception.

---

## Trouver le premier avec `FirstOrDefault`

### 📝 Explication
Tu recherches UNE cible spécifique (ex: le joueur qui a l'ID numéro 42). `.FirstOrDefault()` parcourt la liste et s'arrête net dès qu'il a trouvé le **premier élément** qui correspond à ton critère. S'il ne le trouve pas du tout, il ne fait pas planter le programme : il te renvoie sereinement la valeur par défaut du type (souvent `null` pour un objet, ou `0` pour un entier). 

### 🔤 Syntaxe
```csharp
var cible = liste.FirstOrDefault(element => condition);
```

### 💡 Exemple Simple
```csharp
List<string> prenoms = new List<string> { "Marc", "Luc", "Mathieu" };

// On cherche le tout premier prénom qui commence par la lettre 'M'
var chercheM = prenoms.FirstOrDefault(p => p.StartsWith("M")); 

// Il trouvera "Marc" (et s'arrêtera sans aller jusqu'à Mathieu)
Console.WriteLine($"Trouvé : {chercheM}"); 
```

### 🚀 Exemple Avancé
```csharp
// Un gestionnaire pour déconnecter un joueur precis d'un serveur multijoueur
string nomRecherche = "Bob";

// On cherche le joueur qui porte exactement ce nom
var joueurCible = joueurs.FirstOrDefault(j => j.Nom == nomRecherche);

// Très important : On vérifie si LINQ a bien trouvé quelque chose, ou s'il a renvoyé 'null' (Default)
if (joueurCible != null)
{
    Console.WriteLine($"Connexion coupée pour {joueurCible.Nom}. Son score était de {joueurCible.Score}.");
}
else
{
    Console.WriteLine("Ce joueur n'est pas sur le serveur.");
}
```

### ⚠️ Erreurs Courantes
- **Utiliser `.First()` au lieu de `.FirstOrDefault()` :** Tu liras sans doute souvent la méthode `.First()` en ligne sur les forums. Le piège de `.First()` est que s'il ne trouve AUCUN résultat, ton application plantera net avec une exception violente (`InvalidOperationException`). Utilise toujours `.FirstOrDefault()` par sécurité à moins que tu sois sûr à 200% mathématiquement que la cible existe obligatoire.

### ✅ Bonnes Pratiques
- Après un `.FirstOrDefault()`, tu dois donc **toujours** faire un `if (resultat != null)` avant de vouloir lire à l'intérieur. C'est la garantie d'un code totalement robuste.

---

## Vérifier avec `Any`

### 📝 Explication
As-tu besoin de savoir avec certitude qu'au moins UN élément répond à une condition mais sans avoir besoin de rapatrier cet élément lui-même ? Oublie les boucles complexes, `.Any()` lit la liste et te renvoie simplement `true` (Vrai) ou `false` (Faux).

### 🔤 Syntaxe
```csharp
bool existe = liste.Any(element => condition);
```

### 💡 Exemple Simple
```csharp
List<int> inventaireBouletsDeCanon = new List<int> { 0, 0, 0, 1 };

// Le joueur peut-il enflammer un canon ?
// Any regarde s'il y a AU MOINS UN élément supérieur à 0
bool peutTirer = inventaireBouletsDeCanon.Any(b => b > 0);

if(peutTirer)
{
    Console.WriteLine("Feu !"); // S'affichera, car il y a un '1' dans la liste
}
```

### 🚀 Exemple Avancé
```csharp
// Un système anti-triche pour bloquer l'accès à une partie classée
// Si au moins un joueur a un score triché (inhabituellement haut disons... supérieur à 9000 !)

bool tricheDetectee = joueurs.Any(j => j.Score > 9000);

// Au lieu de checker tous les joueurs manuellement avec for, LINQ fait tout pour nous :
if (tricheDetectee)
{
    Console.WriteLine("L'escouade contient un tricheur, lancement annulé !");
}
else
{
    Console.WriteLine("Escouade de confiance. Lancement de la partie.");
}
```

### ⚠️ Erreurs Courantes
- Essayer de récupérer the donnée avec `Any`. N'oublie pas : Any ne renvoie qu'une réponse philosophique OUI ou NON (`bool`). Aucun élément concret ne sortira du calcul.

### ✅ Bonnes Pratiques
- Préfère utiliser `.Any()` plutôt que de faire un `.Where(...).Count() > 0`. La méthode `Any` est ultra-performante car elle s'arrête et s'interrompt de chercher dès l'instant de la seconde milli-seconde où elle en trouve juste UN, alors que `Count` s'acharnera pour compter minutieusement toute la liste jusqu'au bout pour rien !
