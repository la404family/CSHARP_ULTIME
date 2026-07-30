# Les variables en C-Sharp

Les variables sont des éléments fondamentaux en programmation. Elles permettent de stocker des données en mémoire pour les manipuler dans un programme. En C#, les variables doivent être déclarées avant d'être utilisées. Voici comment déclarer et utiliser des variables en C#.

## Déclaration des variables en C-Sharp

En C#, les variables doivent être déclarées avant d'être utilisées. La déclaration d'une variable se fait en spécifiant son type et son nom. Voici un exemple de déclaration de variables en C# :

```csharp
int age;
string nom;
double prix;
```

Dans cet exemple, nous avons déclaré trois variables : `age` de type `int`, `nom` de type `string` et `prix` de type `double`.

## Initialisation des variables en C-Sharp

Après avoir déclaré une variable, vous pouvez lui attribuer une valeur en utilisant l'opérateur d'assignation `=`. Voici un exemple d'initialisation de variables en C# :

```csharp
int age = 30;
string nom = "Jean";
double prix = 19.99;
```

Dans cet exemple, nous avons initialisé les variables `age`, `nom` et `prix` avec les valeurs `30`, `"Jean"` et `19.99` respectivement.

## Les types de variables en C-Sharp

En C#, il existe plusieurs types de variables, chacun ayant des caractéristiques spécifiques. Voici les principaux types de variables classés par fréquence d'utilisation :

### Types indispensables (à connaître absolument)

| Type     | Description           | Exemple             |
| -------- | --------------------- | ------------------- |
| `int`    | Nombres entiers       | `42`, `-5`, `100`   |
| `string` | Chaînes de caractères | `"Bonjour"`, `"C#"` |
| `bool`   | Valeurs booléennes    | `true`, `false`     |
| `double` | Nombres décimaux      | `3.14`, `-0.5`      |
| `var`    | Inférence de type (mot-clé)| `var x = 10;`       |

```csharp
int age = 25;                    // Nombre entier simple
string nom = "Marie";            // Texte
bool estActif = true;            // Condition
double moyenne = 15.75;          // Calcul décimal
var compteur = 0;                // Le compilateur déduit : int
```

> [!NOTE]
> **Important** : `var` n'est pas un type en soi, c'est une instruction au compilateur pour qu'il devine le type. Une fois compilé, `var x = 10` est strictement identique à `int x = 10`. C'est du "typage statique implicite".

### Types pour des besoins spécifiques

| Type      | Description              | Exemple        |
| --------- | ------------------------ | -------------- |
| `decimal` | Haute précision décimale | `19.99m`       |
| `long`    | Grands entiers           | `10000000000L` |
| `float`   | Décimal simple précision | `3.14f`        |

```csharp
decimal prix = 19.99m;           // Prix exact, pas d'erreur d'arrondi
long idUtilisateur = 9876543210; // ID de base de données
float positionX = 1.5f;          // Coordonnée dans un jeu
```

**note** : Le suffixe `m` pour `decimal`, `L` pour `long` et `f` pour `float` est obligatoire lors de l'initialisation.

la différence principale entre `float`, `double` et `decimal` réside dans la précision et l'utilisation prévue :

- `float` : simple précision, utilisé pour les graphiques et les jeux.
- `double` : double précision, utilisé pour la plupart des calculs scientifiques.
- `decimal` : très haute précision, utilisé pour les calculs financiers où les erreurs d'arrondi sont inacceptables.

### Types pour des cas très particuliers

| Type                               | Description               |
| ---------------------------------- | ------------------------- |
| `char`                             | Caractère unique (`'A'`)  |
| `short`, `byte`                    | Petits entiers            |
| `sbyte`, `ushort`, `uint`, `ulong` | Entiers signés/non signés |

```csharp
char lettre = 'A';               // Un seul caractère
byte octet = 255;                // Valeur 0-255 (données binaires)
```

**Note** : Plus de détails dans une prochaine section sur les types de données.

## Utilisation des variables en C-Sharp

Une fois que vous avez déclaré et initialisé des variables, vous pouvez les utiliser dans votre programme. Voici un exemple d'utilisation de variables en C# :

```csharp
Console.WriteLine("Nom : " + nom);
Console.WriteLine("Age : " + age);
Console.WriteLine("Prix : " + prix);
```

Il n'est pas nécessaire de spécifier le type de la variable lors de son utilisation. Vous pouvez simplement utiliser son nom pour accéder à sa valeur. Mais il est important de noter que les variables doivent être déclarées avant d'être utilisées.

Spécifier le type de la variable lors de sa déclaration permet de définir la taille de l'espace mémoire alloué pour stocker la valeur de la variable. Cela permet également au compilateur de vérifier que les opérations effectuées sur la variable sont valides.

Exemple de programme utilisant des variables en C# :

```csharp
// Déclaration des espaces de noms utilisés
using System;
// Déclaration de l'espace de nom du projet
namespace LesVariables
{
    // Déclaration de la classe du projet
    class Program
    {
        static void Main(string[] args)
        {
            int age = 30;
            string nom = "Jean";
            double prix = 19.99;
            var estActif = true; // Le type de la variable est déduit automatiquement

            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Age : " + age);
            Console.WriteLine("Prix : " + prix);
            Console.WriteLine("Est actif : " + estActif);
        }
    }
}
```

## Les constantes en C-Sharp

En plus des variables, vous pouvez également déclarer des constantes en C#. Les constantes sont des valeurs immuables qui ne peuvent pas être modifiées une fois qu'elles ont été définies. Voici un exemple de déclaration de constante en C# :

```csharp
const double PI = 3.14159;
const string MESSAGE = "Bonjour, monde !";
```

Dans cet exemple, nous avons déclaré deux constantes : `PI` de type `double` et `MESSAGE` de type `string`. Les constantes doivent être initialisées lors de leur déclaration et ne peuvent pas être modifiées par la suite.

Exemple de programme utilisant des constantes en C# :

```csharp
// Déclaration des espaces de noms utilisés
using System;
// Déclaration de l'espace de nom du projet
namespace LesVariables
{
    // Déclaration de la classe du projet
    class Program
    {
        static void Main()
        {
            // Déclaration d'une variable de type entier
            int entier = 10;
            Console.WriteLine("entier = " + entier);

            // Déclaration d'une variable nombre à virgule
            float reel = 3.14f;
            Console.WriteLine("nombre à virgule = " + reel);

            // Déclaration d'une variable de type caractère
            char caractere = 'A';
            Console.WriteLine("caractere = " + caractere);

            // Déclaration d'une variable de type chaîne de caractères
            string chaine = "Hello World!";
            Console.WriteLine("chaine = " + chaine);

            // Déclaration d'une variable de type booléen (true ou false)
            bool booleen = true;
            Console.WriteLine("booleen = " + booleen);

            // Déclaration d'une constante
            const double PI = 3.14159;
            Console.WriteLine("PI = " + PI);
        }
    }
}
```

## La concaténation de chaînes en C-Sharp

En C#, vous pouvez concaténer des chaînes en utilisant l'opérateur `+`. Voici un exemple de concaténation de chaînes en C# :

```csharp
string prenom = "Jean";
string nom = "Dupont";
string nomComplet = prenom + " " + nom;
Console.WriteLine("Nom complet : " + nomComplet);
```

Stocker une valeur donnée par l'utilisateur dans une variable :

```csharp
Console.WriteLine("Entrez votre nom : ");
// string? indique que la valeur peut être nulle (depuis .NET 6)
string? nom = Console.ReadLine();
Console.WriteLine("Bonjour, " + nom + " !");
```

> [!WARNING]
> Depuis les versions récentes de .NET, `Console.ReadLine()` peut renvoyer `null`. Pour être rigoureux, on utilise souvent `string?` (nullable) ou on gère le cas null : `string nom = Console.ReadLine() ?? "";`.



## Portée des variables en C-Sharp

La portée d'une variable détermine où elle peut être utilisée dans le code. En C#, il existe plusieurs types de portée :

- **Variable locale** : déclarée à l'intérieur d'une méthode, accessible uniquement dans cette méthode.
- **Champ de classe** : déclarée dans une classe mais en dehors des méthodes, accessible dans toute la classe.
- **Variable statique** : partagée par toutes les instances de la classe.

### Exemple 1 : Variables locales vs champs de classe

```csharp
using System;

class Compteur
{
    // Champ de classe (accessible dans toute la classe)
    private int total = 0;

    public void Incrementer()
    {
        // Variable locale (accessible uniquement dans cette méthode)
        int increment = 1;
        total = total + increment;
        Console.WriteLine($"Total après incrément : {total}");
        // increment disparaît à la fin de la méthode
    }

    public void AfficherTotal()
    {
        Console.WriteLine($"Total actuel : {total}");
        // Console.WriteLine(increment); // ERREUR : increment n'existe pas ici
    }
}

// Utilisation
class Program
{
    static void Main()
    {
        Compteur c = new Compteur();
        c.Incrementer(); // Affiche : Total après incrément : 1
        c.Incrementer(); // Affiche : Total après incrément : 2
        c.AfficherTotal(); // Affiche : Total actuel : 2
    }
}
```

**résumé** : Les variables locales sont temporaires et limitées à la méthode, tandis que les champs de classe persistent tant que l'objet existe.

### Exemple 2 : Variables statiques partagées

```csharp
using System;

class Joueur
{
    // Champ de classe (propre à chaque instance)
    private string nom;
    private int score;

    // Champ statique (partagé par TOUS les joueurs)
    private static int nombreJoueurs = 0;

    public Joueur(string nom)
    {
        this.nom = nom;
        this.score = 0;
        nombreJoueurs++; // Incrémente pour tous les joueurs
    }

    public void AjouterPoints(int points)
    {
        score += points;
        Console.WriteLine($"{nom} a maintenant {score} points");
    }

    public static void AfficherNombreJoueurs()
    {
        Console.WriteLine($"Nombre total de joueurs : {nombreJoueurs}");
        // Console.WriteLine(nom); // ERREUR : une méthode statique ne peut pas accéder aux champs d'instance
    }
}

// Utilisation
class Program
{
    static void Main()
    {
        Joueur j1 = new Joueur("Alice");
        Joueur j2 = new Joueur("Bob");
        Joueur j3 = new Joueur("Charlie");

        j1.AjouterPoints(10); // Alice a maintenant 10 points
        j2.AjouterPoints(5);  // Bob a maintenant 5 points

        Joueur.AfficherNombreJoueurs(); // Nombre total de joueurs : 3
    }
}
```

### Exemple 3 : Portée des variables dans les blocs

```csharp
using System;

class ExempleBlocs
{
    public void DemonstrationPortee()
    {
        int x = 10; // Variable de la méthode

        if (x > 5)
        {
            int y = 20; // Variable du bloc if
            Console.WriteLine($"x = {x}, y = {y}"); // OK
        }

        // Console.WriteLine(y); // ERREUR : y n'existe plus ici

        for (int i = 0; i < 3; i++)
        {
            int z = i * 2; // Variable du bloc for
            Console.WriteLine($"i = {i}, z = {z}");
        }

        // Console.WriteLine(i); // ERREUR : i n'existe plus ici
        // Console.WriteLine(z); // ERREUR : z n'existe plus ici

        Console.WriteLine($"x = {x}"); // OK : x existe toujours
    }
}
```

### Exemple 4 : Masquage de variables (shadowing)

```csharp
using System;

class ExempleMasquage
{
    private int valeur = 100; // Champ de classe

    public void Methode1()
    {
        Console.WriteLine($"Valeur de classe : {valeur}"); // 100
    }

    public void Methode2()
    {
        int valeur = 50; // Variable locale qui "masque" le champ
        Console.WriteLine($"Valeur locale : {valeur}"); // 50
        Console.WriteLine($"Valeur de classe : {this.valeur}"); // 100 (accès avec 'this')
    }

    public void Methode3(int valeur) // Paramètre qui masque le champ
    {
        Console.WriteLine($"Paramètre : {valeur}"); // Valeur passée en paramètre
        Console.WriteLine($"Champ de classe : {this.valeur}"); // 100
    }
}

// Utilisation
class Program
{
    static void Main()
    {
        ExempleMasquage ex = new ExempleMasquage();
        ex.Methode1(); // Valeur de classe : 100
        ex.Methode2(); // Valeur locale : 50, Valeur de classe : 100
        ex.Methode3(75); // Paramètre : 75, Champ de classe : 100
    }
}
```

### Résumé des portées

| Type de variable | Déclarée dans       | Accessible dans                              | Durée de vie                 |
| ---------------- | ------------------- | -------------------------------------------- | ---------------------------- |
| Locale           | Méthode/Bloc        | Méthode/Bloc uniquement                      | Jusqu'à la fin du bloc       |
| Champ d'instance | Classe (hors méth.) | Toute la classe                              | Tant que l'objet existe      |
| Champ statique   | Classe (static)     | Toute la classe + partout via `Classe.Champ` | Toute la durée du programme  |
| Paramètre        | Signature méthode   | Corps de la méthode                          | Jusqu'à la fin de la méthode |

## Variables implicites : `var` et `dynamic`

- **`var`** : le type est déterminé à la compilation, il ne peut pas changer par la suite.
- **`dynamic`** : le type est déterminé à l'exécution, il peut changer par la suite.

```csharp
var nombre = 42; // Le compilateur comprend que c'est un int
var texte = "Bonjour"; // string
// nombre = "texte"; // Erreur de compilation

dynamic valeur = 10;
valeur = "Maintenant une chaîne"; // Pas d'erreur à la compilation
Console.WriteLine(valeur);
```

Voici ce que ça implique :

- Le type réel de la variable dynamic est résolu au moment de l’exécution, pas à la compilation.

-Tu peux lui assigner une valeur de n’importe quel type, puis lui réassigner une autre valeur d’un type complètement différent.

- Cela permet une grande flexibilité, mais au détriment de la sécurité de type à la compilation.

## Variables non initialisées et valeurs par défaut

En C#, les variables locales doivent être initialisées avant d'être utilisées. Les champs de classe reçoivent une valeur par défaut.

```csharp
class ExempleDefaut
{
    int champClasse; // Par défaut : 0
    bool estActif;   // Par défaut : false

    void Afficher()
    {
        int local;
        // Console.WriteLine(local); // Erreur : la variable locale n'est pas initialisée
        Console.WriteLine(champClasse); // Affiche 0
        Console.WriteLine(estActif);    // Affiche False
    }
}
```

## Conversion de types (casting)

Il est parfois nécessaire de convertir une variable d'un type à un autre.

```csharp
int entier = 10;
double reel = entier; // Conversion implicite (int vers double)

// Conversion explicite (cast)
double d = 9.7;
int i = (int)d; // i vaut 9, la partie décimale est perdue

// Conversion de string vers int
string texte = "123";
int nombre = int.Parse(texte); // nombre vaut 123
// int nombre2 = int.Parse("abc"); // Provoque une exception
```

## Bonnes pratiques et erreurs courantes

- Toujours initialiser les variables locales avant utilisation.
- Utiliser des noms de variables explicites et significatifs.
- Privilégier `var` pour les types évidents, mais éviter pour les types ambigus.
- Attention à la casse : `maVariable` et `mavariable` sont différents.

```csharp
// Mauvaise pratique :
int a = 1, b = 2, c = 3; // Peu lisible

// Bonne pratique :
int nombreApples = 1;
int nombreOranges = 2;
int nombreBananes = 3;
```

// Erreur courante : utiliser une variable non initialisée

```csharp
int x;
// Console.WriteLine(x); // Erreur de compilation
```

// Erreur courante : confusion entre affectation (=) et comparaison (==)

```csharp
int y = 5;
if (y == 5) // Comparaison correcte
{
    Console.WriteLine("y vaut 5");
}
// if (y = 5) // Erreur : affectation au lieu de comparaison
```
