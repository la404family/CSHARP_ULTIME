# Les structures de données en C-Sharp

Les structures de données sont des moyens d'organiser et de stocker des données dans un programme. Elles permettent de gérer efficacement les données et d'effectuer des opérations sur celles-ci.
Les structures de données sont essentielles pour le développement de logiciels, car elles influencent la performance et la complexité des algorithmes utilisés.

## Sommaire

1. [Tableaux](#tableaux)
2. [Listes](#listes)
3. [Dictionnaires](#dictionnaires)
4. [Ensembles](#ensembles)
5. [Piles](#piles)
6. [Files](#files)
7. [Structures](#structures)
8. [Classes](#classes)

## Tableaux

Les tableaux sont des collections d'éléments de même type, organisés de manière contiguë en mémoire. Ils permettent de stocker plusieurs valeurs sous un même nom, accessibles par un index.

exemple de déclaration et d'initialisation d'un tableau en C# :

```csharp
int[] tableau = new int[5]; // Déclaration d'un tableau de 5 entiers
tableau[0] = 1; // Affectation de la valeur 1 à l'index 0
tableau[1] = 2; // Affectation de la valeur 2 à l'index 1
tableau[2] = 3; // Affectation de la valeur 3 à l'index 2
tableau[3] = 4; // Affectation de la valeur 4 à l'index 3
tableau[4] = 5; // Affectation de la valeur 5 à l'index 4
// Affichage de la valeur à l'index 2
Console.WriteLine(tableau[2]); // Affiche 3
```

Les tableaux sont de taille fixe, ce qui signifie que vous devez connaître la taille du tableau au moment de sa déclaration. Si vous avez besoin d'une collection de taille variable, vous pouvez utiliser des listes ou d'autres structures de données.

Comment redimensionner un tableau ?

```csharp
int[] tableau = new int[5]; // Déclaration d'un tableau de 5 entiers
tableau[0] = 1; // Affectation de la valeur 1 à l'index 0
tableau[1] = 2; // Affectation de la valeur 2 à l'index 1
tableau[2] = 3; // Affectation de la valeur 3 à l'index 2
tableau[3] = 4; // Affectation de la valeur 4 à l'index 3
tableau[4] = 5; // Affectation de la valeur 5 à l'index 4

// Redimensionnement du tableau
Array.Resize(ref tableau, 10); // Redimensionne le tableau à 10 éléments
tableau[5] = 6; // Affectation de la valeur 6 à l'index 5
tableau[6] = 7; // Affectation de la valeur 7 à l'index 6
tableau[7] = 8; // Affectation de la valeur 8 à l'index 7
tableau[8] = 9; // Affectation de la valeur 9 à l'index 8
tableau[9] = 10; // Affectation de la valeur 10 à l'index 9
// Affichage de la valeur à l'index 5
Console.WriteLine(tableau[5]); // Affiche 6
```

## Listes

Les listes sont des collections d'éléments qui peuvent être de types différents. Elles permettent d'ajouter, de supprimer et de modifier des éléments dynamiquement. Les listes sont plus flexibles que les tableaux, car elles peuvent changer de taille à tout moment.

exemple :

```csharp
using System.Collections.Generic; // Nécessaire pour utiliser les listes
List<int> liste = new List<int>(); // Déclaration d'une liste d'entiers
liste.Add(1); // Ajout de la valeur 1 à la liste
liste.Add(2); // Ajout de la valeur 2 à la liste
liste.Add(3); // Ajout de la valeur 3 à la liste
liste.Remove(2); // Suppression de la valeur 2 de la liste

// Affichage de la valeur à l'index 1
Console.WriteLine(liste[1]); // Affiche 3
```

## Dictionnaires

Les dictionnaires sont des collections d'éléments qui associent une clé à une valeur. Ils permettent de stocker des paires clé-valeur, ce qui facilite la recherche et l'accès aux données.

Les dictionnaires sont particulièrement utiles lorsque vous devez stocker des données qui doivent être rapidement accessibles par une clé unique.
exemple :

```csharp
using System.Collections.Generic; // Nécessaire pour utiliser les dictionnaires
Dictionary<string, int> dictionnaire = new Dictionary<string, int>(); // Déclaration d'un dictionnaire avec des clés de type string et des valeurs de type int
dictionnaire.Add("un", 1); // Ajout de la paire clé-valeur "un" : 1
dictionnaire.Add("deux", 2); // Ajout de la paire clé-valeur "deux" : 2
dictionnaire.Add("trois", 3); // Ajout de la paire clé-valeur "trois" : 3
dictionnaire.Remove("deux"); // Suppression de la paire clé-valeur "deux" : 2

// Affichage de la valeur associée à la clé "trois"
Console.WriteLine(dictionnaire["trois"]); // Affiche 3
```

## Ensembles

Les ensembles sont des collections d'éléments uniques, c'est-à-dire qu'ils ne contiennent pas de doublons. Ils permettent de stocker des valeurs sans ordre particulier et sont utiles pour effectuer des opérations d'ensemble telles que l'union, l'intersection et la différence.

exemple :

```csharp
using System.Collections.Generic; // Nécessaire pour utiliser les ensembles
HashSet<int> ensemble = new HashSet<int>(); // Déclaration d'un ensemble d'entiers
ensemble.Add(1); // Ajout de la valeur 1 à l'ensemble
ensemble.Add(2); // Ajout de la valeur 2 à l'ensemble
ensemble.Add(3); // Ajout de la valeur 3 à l'ensemble
ensemble.Add(2); // Tentative d'ajout de la valeur 2 à l'ensemble (ignorer car doublon)
ensemble.Remove(2); // Suppression de la valeur 2 de l'ensemble
// Affichage de la valeur 3
Console.WriteLine(ensemble.Contains(3)); // Affiche True (3 est présent dans l'ensemble)
Console.WriteLine(ensemble.Contains(2)); // Affiche False (2 n'est pas présent dans l'ensemble)
```

## Piles

Les piles sont des collections d'éléments qui suivent le principe LIFO (Last In, First Out), c'est-à-dire que le dernier élément ajouté est le premier à être retiré. Elles sont souvent utilisées pour gérer des opérations de retour en arrière ou de navigation dans les applications.
exemple :

```csharp
using System.Collections.Generic; // Nécessaire pour utiliser les piles
Stack<int> pile = new Stack<int>(); // Déclaration d'une pile d'entiers
pile.Push(1); // Ajout de la valeur 1 à la pile
pile.Push(2); // Ajout de la valeur 2 à la pile
pile.Push(3); // Ajout de la valeur 3 à la pile
pile.Pop(); // Retrait de la valeur 3 de la pile (dernier élément ajouté)
pile.Pop(); // Retrait de la valeur 2 de la pile (avant-dernier élément ajouté)
// Affichage de la valeur 1
Console.WriteLine(pile.Peek()); // Affiche 1 (valeur au sommet de la pile sans la retirer)
```

## Files

Les files sont des collections d'éléments qui suivent le principe FIFO (First In, First Out), c'est-à-dire que le premier élément ajouté est le premier à être retiré. Elles sont souvent utilisées pour gérer des tâches en attente ou des opérations de traitement en série.
exemple :

```csharp
using System.Collections.Generic; // Nécessaire pour utiliser les files
Queue<int> file = new Queue<int>(); // Déclaration d'une file d'entiers
file.Enqueue(1); // Ajout de la valeur 1 à la file
file.Enqueue(2); // Ajout de la valeur 2 à la file
file.Enqueue(3); // Ajout de la valeur 3 à la file
file.Dequeue(); // Retrait de la valeur 1 de la file (premier élément ajouté)
file.Dequeue(); // Retrait de la valeur 2 de la file (deuxième élément ajouté)
// Affichage de la valeur 3
Console.WriteLine(file.Peek()); // Affiche 3 (valeur au début de la file sans la retirer)
```

## Structures

Les structures sont des types de données définis par l'utilisateur qui peuvent contenir plusieurs champs de données. Elles sont similaires aux classes, mais elles sont généralement utilisées pour des types de données plus simples et sont passées par valeur plutôt que par référence.

exemple :

```csharp
using System; // Nécessaire pour utiliser les structures

struct Point // Déclaration d'une structure Point
{
    public int X; // Champ de données X
    public int Y; // Champ de données Y

    public Point(int x, int y) // Constructeur de la structure
    {
        X = x; // Initialisation du champ X
        Y = y; // Initialisation du champ Y
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point point = new Point(10, 20); // Création d'une instance de la structure Point
        Console.WriteLine($"Point: ({point.X}, {point.Y})"); // Affichage des coordonnées du point
    }
}
```

## Classes

Les classes sont des types de données définis par l'utilisateur qui peuvent contenir des champs, des propriétés et des méthodes. Elles permettent de créer des objets qui encapsulent des données et des comportements. Les classes sont généralement utilisées pour modéliser des entités plus complexes que les structures.

exemple :

```csharp
using System; // Nécessaire pour utiliser les classes

class Personne // Déclaration d'une classe Personne
{
    public string Nom { get; set; } // Propriété Nom
    public int Age { get; set; } // Propriété Age

    public Personne(string nom, int age) // Constructeur de la classe
    {
        Nom = nom; // Initialisation de la propriété Nom
        Age = age; // Initialisation de la propriété Age
    }

    public void Afficher() // Méthode pour afficher les informations de la personne
    {
        Console.WriteLine($"Nom: {Nom}, Age: {Age}"); // Affichage des informations de la personne
    }
}
```

```csharp
class Program
{
    static void Main(string[] args)
    {
        Personne personne = new Personne("Alice", 30); // Création d'une instance de la classe Personne
        personne.Afficher(); // Appel de la méthode pour afficher les informations de la personne
    }
}
```
