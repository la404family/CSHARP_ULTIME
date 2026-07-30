# Les comparateurs en C-Sharp

Les comparateurs sont des symboles qui permettent de comparer des valeurs. Ils sont souvent utilisés dans les structures de contrôle pour prendre des décisions en fonction des résultats de ces comparaisons.

## Les opérateurs de comparaison

Avant de voir les structures de contrôle, voici les opérateurs de comparaison disponibles en C# :

| Opérateur | Signification       | Exemple  | Résultat |
| --------- | ------------------- | -------- | -------- |
| `==`      | Égal à              | `5 == 5` | `true`   |
| `!=`      | Différent de        | `5 != 3` | `true`   |
| `>`       | Supérieur à         | `5 > 3`  | `true`   |
| `<`       | Inférieur à         | `5 < 3`  | `false`  |
| `>=`      | Supérieur ou égal à | `5 >= 5` | `true`   |
| `<=`      | Inférieur ou égal à | `5 <= 3` | `false`  |

```csharp
int age = 18;
bool estMajeur = age >= 18;  // true
bool estMineur = age < 18;   // false
bool exactement18 = age == 18; // true
```

## Les opérateurs logiques

Pour combiner plusieurs conditions :

| Opérateur | Signification | Exemple           | Résultat |
| --------- | ------------- | ----------------- | -------- |
| `&&`      | ET logique    | `true && false`   | `false`  |
| `\|\|`    | OU logique    | `true \|\| false` | `true`   |
| `!`       | NON logique   | `!true`           | `false`  |

```csharp
int age = 20;
bool permis = true;

// ET logique : les deux conditions doivent être vraies
bool peutConduire = age >= 18 && permis; // true

// OU logique : au moins une condition doit être vraie
bool reduction = age < 12 || age > 65; // false

// NON logique : inverse la valeur
bool neAPasPermis = !permis; // false
```

## Le if / else

Le `if / else` est une structure de contrôle qui permet d'exécuter un bloc de code si une condition est vraie, et un autre bloc de code si la condition est fausse.

### Syntaxe de base

```csharp
int a = 5, b = 3;
if (a > b)
{
    Console.WriteLine("a est supérieur à b");
}
else
{
    Console.WriteLine("a n'est pas supérieur à b");
}
```

### if / else if / else

Pour tester plusieurs conditions :

```csharp
int note = 15;

if (note >= 16)
{
    Console.WriteLine("Très bien");
}
else if (note >= 14)
{
    Console.WriteLine("Bien");
}
else if (note >= 12)
{
    Console.WriteLine("Assez bien");
}
else if (note >= 10)
{
    Console.WriteLine("Passable");
}
else
{
    Console.WriteLine("Insuffisant");
}
```

### Conditions imbriquées

```csharp
int age = 20;
bool permis = true;

if (age >= 18)
{
    if (permis)
    {
        Console.WriteLine("Vous pouvez conduire");
    }
    else
    {
        Console.WriteLine("Vous devez passer le permis");
    }
}
else
{
    Console.WriteLine("Vous êtes trop jeune");
}
```

### Exemple pratique : Calculatrice simple

```csharp
int a = 10, b = 5;
string operation = "+";

if (operation == "+")
{
    Console.WriteLine($"Résultat : {a + b}");
}
else if (operation == "-")
{
    Console.WriteLine($"Résultat : {a - b}");
}
else if (operation == "*")
{
    Console.WriteLine($"Résultat : {a * b}");
}
else if (operation == "/")
{
    if (b != 0)
    {
        Console.WriteLine($"Résultat : {a / b}");
    }
    else
    {
        Console.WriteLine("Erreur : Division par zéro");
    }
}
else
{
    Console.WriteLine("Opération inconnue");
}
```

## Le switch

Le `switch` est une structure de contrôle qui permet de choisir entre plusieurs blocs de code en fonction de la valeur d'une expression. C'est une alternative plus lisible au `if / else if / else` quand on compare une même variable à plusieurs valeurs.

### Syntaxe classique

```csharp
int jour = 2;
switch (jour)
{
    case 1:
        Console.WriteLine("Lundi");
        break;
    case 2:
        Console.WriteLine("Mardi");
        break;
    case 3:
        Console.WriteLine("Mercredi");
        break;
    case 4:
        Console.WriteLine("Jeudi");
        break;
    case 5:
        Console.WriteLine("Vendredi");
        break;
    case 6:
        Console.WriteLine("Samedi");
        break;
    case 7:
        Console.WriteLine("Dimanche");
        break;
    default:
        Console.WriteLine("Jour invalide");
        break;
}
```

### Plusieurs cas pour une même action

```csharp
int mois = 2;
switch (mois)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("Hiver");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Printemps");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("Été");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("Automne");
        break;
    default:
        Console.WriteLine("Mois invalide");
        break;
}
```

### Switch avec des chaînes de caractères

```csharp
string grade = "B";
switch (grade)
{
    case "A":
        Console.WriteLine("Excellent !");
        break;
    case "B":
        Console.WriteLine("Très bien");
        break;
    case "C":
        Console.WriteLine("Bien");
        break;
    case "D":
        Console.WriteLine("Passable");
        break;
    case "E":
        Console.WriteLine("Insuffisant");
        break;
    default:
        Console.WriteLine("Grade inconnu");
        break;
}
```

### Switch expressions (C# 8.0+)

Syntaxe moderne et plus concise :

```csharp
string jour = "Lundi";
string typeJour = jour switch
{
    "Lundi" or "Mardi" or "Mercredi" or "Jeudi" or "Vendredi" => "Jour de semaine",
    "Samedi" or "Dimanche" => "Week-end",
    _ => "Jour inconnu"
};
Console.WriteLine(typeJour); // Jour de semaine
```

### Exemple pratique : Menu de restaurant

```csharp
Console.WriteLine("=== Menu du restaurant ===");
Console.WriteLine("1. Pizza - 12€");
Console.WriteLine("2. Burger - 10€");
Console.WriteLine("3. Salade - 8€");
Console.WriteLine("4. Pâtes - 9€");
Console.Write("Votre choix : ");

int choix = int.Parse(Console.ReadLine());

switch (choix)
{
    case 1:
        Console.WriteLine("Vous avez choisi : Pizza - 12€");
        break;
    case 2:
        Console.WriteLine("Vous avez choisi : Burger - 10€");
        break;
    case 3:
        Console.WriteLine("Vous avez choisi : Salade - 8€");
        break;
    case 4:
        Console.WriteLine("Vous avez choisi : Pâtes - 9€");
        break;
    default:
        Console.WriteLine("Choix invalide !");
        break;
}
```

## L'opérateur ternaire

L'opérateur ternaire est une forme abrégée de l'instruction `if / else`. Il permet d'écrire une condition et deux expressions en une seule ligne.

**Syntaxe :** `condition ? valeurSiVrai : valeurSiFaux`

Si la condition est vraie, `valeurSiVrai` est retournée, sinon `valeurSiFaux` est retournée.

### Exemple simple

```csharp
int a = 5, b = 3;
int max = (a > b) ? a : b;
Console.WriteLine("Le maximum est : " + max); // 5
```

### Comparaison avec if / else

```csharp
// Avec if / else (4 lignes)
int age = 20;
string statut;
if (age >= 18)
{
    statut = "Majeur";
}
else
{
    statut = "Mineur";
}

// Avec opérateur ternaire (1 ligne)
string statut = (age >= 18) ? "Majeur" : "Mineur";
```

### Exemples pratiques

#### Déterminer si un nombre est pair ou impair

```csharp
int nombre = 7;
string resultat = (nombre % 2 == 0) ? "pair" : "impair";
Console.WriteLine($"{nombre} est {resultat}"); // 7 est impair
```

#### Appliquer une réduction

```csharp
double prix = 100;
bool clientVIP = true;
double prixFinal = clientVIP ? prix * 0.8 : prix; // 20% de réduction si VIP
Console.WriteLine($"Prix à payer : {prixFinal}€"); // 80€
```

#### Afficher un message personnalisé

```csharp
int score = 85;
string message = (score >= 50) ? "Réussi !" : "Échoué...";
Console.WriteLine(message); // Réussi !
```

### Opérateurs ternaires imbriqués

```csharp
int note = 15;
string mention = (note >= 16) ? "Très bien" :
                 (note >= 14) ? "Bien" :
                 (note >= 12) ? "Assez bien" :
                 (note >= 10) ? "Passable" : "Insuffisant";
Console.WriteLine(mention); // Bien
```

**⚠️ Attention :** Les opérateurs ternaires imbriqués peuvent rendre le code difficile à lire. Privilégiez `if / else if / else` pour plus de clarté.

## Comparaison des structures

| Structure      | Utilisation recommandée                        | Avantage                          |
| -------------- | ---------------------------------------------- | --------------------------------- |
| `if / else`    | Conditions complexes, multiples conditions     | Très flexible                     |
| `switch`       | Comparaison d'une variable à plusieurs valeurs | Plus lisible pour beaucoup de cas |
| Opérateur `?:` | Assignation simple basée sur une condition     | Concis, une seule ligne           |

## Exemples complets

### Exemple 1 : Système de notes

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Entrez votre note (0-20) : ");
        int note = int.Parse(Console.ReadLine());

        // Validation
        if (note < 0 || note > 20)
        {
            Console.WriteLine("Note invalide !");
            return;
        }

        // Détermination de la mention avec if / else if
        string mention;
        if (note >= 16)
            mention = "Très bien";
        else if (note >= 14)
            mention = "Bien";
        else if (note >= 12)
            mention = "Assez bien";
        else if (note >= 10)
            mention = "Passable";
        else
            mention = "Insuffisant";

        // Détermination du résultat avec opérateur ternaire
        string resultat = (note >= 10) ? "Admis" : "Recalé";

        Console.WriteLine($"\nNote : {note}/20");
        Console.WriteLine($"Mention : {mention}");
        Console.WriteLine($"Résultat : {resultat}");
    }
}
```

### Exemple 2 : Calculatrice avec switch

```csharp
using System;

class Calculatrice
{
    static void Main()
    {
        Console.Write("Entrez le premier nombre : ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Entrez l'opération (+, -, *, /) : ");
        string operation = Console.ReadLine();

        Console.Write("Entrez le deuxième nombre : ");
        double b = double.Parse(Console.ReadLine());

        double resultat = 0;
        bool operationValide = true;

        switch (operation)
        {
            case "+":
                resultat = a + b;
                break;
            case "-":
                resultat = a - b;
                break;
            case "*":
                resultat = a * b;
                break;
            case "/":
                if (b != 0)
                    resultat = a / b;
                else
                {
                    Console.WriteLine("Erreur : Division par zéro !");
                    operationValide = false;
                }
                break;
            default:
                Console.WriteLine("Opération inconnue !");
                operationValide = false;
                break;
        }

        if (operationValide)
        {
            Console.WriteLine($"\nRésultat : {a} {operation} {b} = {resultat}");
        }
    }
}
```

## Bonnes pratiques

1. **Utilisez des accolades même pour une seule ligne** (pour éviter les erreurs)

```csharp
// Mauvais
if (condition)
    Console.WriteLine("OK");

// Bon
if (condition)
{
    Console.WriteLine("OK");
}
```

2. **Privilégiez la clarté à la concision**

```csharp
// Moins lisible
string msg = age >= 18 && permis ? "OK" : age >= 18 ? "Pas de permis" : "Trop jeune";

// Plus lisible
string msg;
if (age >= 18 && permis)
    msg = "OK";
else if (age >= 18)
    msg = "Pas de permis";
else
    msg = "Trop jeune";
```

3. **Utilisez `switch` quand vous comparez la même variable à plusieurs valeurs**
4. **N'oubliez pas le `break` dans les `switch`** (sinon le code "tombe" dans le cas suivant)
5. **Utilisez le `default` dans les `switch`** pour gérer les cas non prévus
