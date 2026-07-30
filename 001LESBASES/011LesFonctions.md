# Les fonctions en C-Sharp

## Sommaire

1. [Les fonctions](#les-fonctions)
2. [Les paramètres](#les-paramètres)
3. [Les valeurs de retour](#les-valeurs-de-retour)

<!-- 4. [Les fonctions anonymes](#les-fonctions-anonymes)
4. [Les fonctions lambda](#les-fonctions-lambda)
5. [Les fonctions récursives](#les-fonctions-récursives)
6. [Les fonctions d'ordre supérieur](#les-fonctions-dordre-supérieur)
7. [Les fonctions de rappel](#les-fonctions-de-rappel)
8. [Les fonctions d'extension](#les-fonctions-dextension)
9. [Les fonctions génériques](#les-fonctions-génériques)
10. [Les fonctions asynchrones](#les-fonctions-asynchrones) -->

### Les fonctions

Les fonctions sont des blocs de code qui effectuent une tâche spécifique. Elles peuvent prendre des paramètres en entrée et retourner une valeur en sortie. Les fonctions permettent de structurer le code, de le rendre plus lisible et de le réutiliser.
Les fonctions peuvent être définies à l'intérieur d'une classe ou d'une structure, et elles peuvent être appelées à partir d'autres parties du code.
Les fonctions peuvent également être définies à l'intérieur d'autres fonctions, ce qui permet de créer des fonctions imbriquées.
Les fonctions peuvent être définies avec ou sans paramètres, et elles peuvent retourner une valeur ou ne rien retourner du tout.
Les fonctions peuvent également être définies avec des paramètres par défaut, ce qui permet de les appeler sans spécifier tous les arguments.
Les fonctions peuvent également être définies avec des paramètres nommés, ce qui permet de les appeler en spécifiant uniquement les arguments souhaités.

exemple de fonction en C# :

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// exemple de fonction en C#
class Program
{
    static void Main(string[] args)
    {
        // Appel de la fonction sans paramètres
        AfficherMessage();

        // Appel de la fonction avec un paramètre
        AfficherMessage("Bonjour le monde !");

        // Appel de la fonction avec plusieurs paramètres
        int somme = Additionner(5, 10);
        Console.WriteLine("La somme est : " + somme);

        // Appel de la fonction avec des paramètres par défaut
        int produit = Multiplier(5);
        Console.WriteLine("Le produit est : " + produit);

        // Appel de la fonction avec des paramètres nommés
        int difference = Soustraire(b: 10, a: 5);
        Console.WriteLine("La différence est : " + difference);
    }

    // Fonction sans paramètres
    static void AfficherMessage()
    {
        Console.WriteLine("Bonjour !");
    }

    // Fonction avec un paramètre
    static void AfficherMessage(string message)
    {
        Console.WriteLine(message);
    }

    // Fonction avec plusieurs paramètres
    static int Additionner(int a, int b)
    {
        return a + b;
    }

    // Fonction avec des paramètres par défaut
    static int Multiplier(int a, int b = 2)
    {
        return a * b;
    }

    // Fonction avec des paramètres nommés
    static int Soustraire(int a, int b)
    {
        return a - b;
    }
}
```

### Les paramètres

Les paramètres sont des variables qui sont passées à une fonction lors de son appel. Ils permettent de transmettre des valeurs à la fonction pour qu'elle puisse les utiliser dans son traitement. Les paramètres peuvent être de différents types, y compris des types primitifs, des objets, des tableaux, etc.
Les paramètres peuvent être passés par valeur ou par référence. Lorsqu'un paramètre est passé par valeur, une copie de la valeur est transmise à la fonction. Lorsqu'un paramètre est passé par référence, la fonction peut modifier la valeur d'origine.
Les paramètres peuvent également être définis avec des valeurs par défaut, ce qui permet de les appeler sans spécifier tous les arguments. Les paramètres peuvent également être définis avec des paramètres nommés, ce qui permet de les appeler en spécifiant uniquement les arguments souhaités.

exemple de fonction avec des paramètres en C# :

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// exemple de fonction avec des paramètres en C#
class Program
{
    static void Main(string[] args)
    {
        // Appel de la fonction avec des paramètres
        int somme = Additionner(5, 10);
        Console.WriteLine("La somme est : " + somme);

        // Appel de la fonction avec des paramètres par défaut
        int produit = Multiplier(5);
        Console.WriteLine("Le produit est : " + produit);

        // Appel de la fonction avec des paramètres nommés
        int difference = Soustraire(b: 10, a: 5);
        Console.WriteLine("La différence est : " + difference);
    }

    // Fonction avec plusieurs paramètres
    static int Additionner(int a, int b)
    {
        return a + b;
    }

    // Fonction avec des paramètres par défaut
    static int Multiplier(int a, int b = 2)
    {
        return a * b;
    }

    // Fonction avec des paramètres nommés
    static int Soustraire(int a, int b)
    {
        return a - b;
    }
}
```

### Les valeurs de retour

Les valeurs de retour sont les valeurs qui sont renvoyées par une fonction après son exécution. Elles permettent de transmettre des résultats à l'appelant de la fonction. Les valeurs de retour peuvent être de différents types, y compris des types primitifs, des objets, des tableaux, etc.
Les valeurs de retour peuvent être définies à l'aide du mot-clé `return`, suivi de la valeur à renvoyer. Si une fonction ne renvoie pas de valeur, elle doit être définie avec le type `void`.
Les valeurs de retour peuvent également être utilisées pour signaler des erreurs ou des exceptions. Dans ce cas, la fonction peut renvoyer une valeur spéciale ou lever une exception.
Les valeurs de retour peuvent également être utilisées pour renvoyer plusieurs valeurs à l'appelant. Dans ce cas, la fonction peut renvoyer un objet contenant plusieurs valeurs ou utiliser des paramètres de sortie.

// exemple de fonction avec des valeurs de retour en C# :

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// exemple de fonction avec des valeurs de retour en C#
class Program
{
    static void Main(string[] args)
    {
        // Appel de la fonction avec des valeurs de retour
        int somme = Additionner(5, 10);
        Console.WriteLine("La somme est : " + somme);

        // Appel de la fonction avec des valeurs de retour et des paramètres de sortie
        int produit;
        Multiplier(5, out produit);
        Console.WriteLine("Le produit est : " + produit);

        // Appel de la fonction avec des valeurs de retour et une exception
        try
        {
            int division = Diviser(10, 0);
            Console.WriteLine("La division est : " + division);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }

    // Fonction avec plusieurs valeurs de retour
    static int Additionner(int a, int b)
    {
        return a + b;
    }

    // Fonction avec des valeurs de retour et des paramètres de sortie
    static void Multiplier(int a, out int b)
    {
        b = a * 2;
    }

    // Fonction avec des valeurs de retour et une exception
    static int Diviser(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Division par zéro.");
        return a / b;
    }
}
```
