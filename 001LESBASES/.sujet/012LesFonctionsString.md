# Les fonction relatives aux strings

Les fonctions relatives aux "string" en csharp sont des méthodes qui permettent de manipuler des chaînes de caractères. Elles sont très utiles pour effectuer des opérations telles que la recherche, la modification, la comparaison et la validation de chaînes.

## Fonctions de base

## `string.Length`

La propriété `Length` permet d'obtenir la longueur d'une chaîne de caractères. Elle renvoie le nombre de caractères dans la chaîne.

```csharp
string maChaine = "Bonjour";
int longueur = maChaine.Length; // longueur = 7
```

## `string.ToUpper()`

La méthode `ToUpper()` convertit tous les caractères d'une chaîne en majuscules.

```csharp
string maChaine = "Bonjour";
string majuscules = maChaine.ToUpper(); // majuscules = "BONJOUR"
```

## `string.ToLower()`

La méthode `ToLower()` convertit tous les caractères d'une chaîne en minuscules.

```csharp
string maChaine = "Bonjour";
string minuscules = maChaine.ToLower(); // minuscules = "bonjour"
```

## `string.Trim()`

La méthode `Trim()` supprime les espaces blancs au début et à la fin d'une chaîne.

```csharp
string maChaine = "   Bonjour   ";
string chaineTrimmee = maChaine.Trim(); // chaineTrimmee = "Bonjour"
```

## `string.Substring()`

La méthode `Substring(int startIndex, int length)` permet d'extraire une sous-chaîne à partir d'une position donnée et d'une longueur spécifiée.

```csharp
string maChaine = "Bonjour";
string sousChaine = maChaine.Substring(0, 3); // sousChaine = "Bon"
```

## `string.IndexOf()`

La méthode `IndexOf(string value)` recherche la première occurrence d'une sous-chaîne dans une chaîne et renvoie l'index de cette occurrence. Si la sous-chaîne n'est pas trouvée, elle renvoie -1.

```csharp
string maChaine = "Bonjour";
int index = maChaine.IndexOf("jour"); // index = 3
```

## `string.Contains()`

La méthode `Contains(string value)` vérifie si une chaîne contient une sous-chaîne spécifique. Elle renvoie `true` si la sous-chaîne est trouvée, sinon `false`.

```csharp
string maChaine = "Bonjour";
bool contient = maChaine.Contains("jour"); // contient = true
```

## `string.Replace()`

La méthode `Replace(string oldValue, string newValue)` remplace toutes les occurrences d'une sous-chaîne par une autre dans une chaîne.

```csharp
string maChaine = "Bonjour";
string nouvelleChaine = maChaine.Replace("jour", "soir"); // nouvelleChaine = "Bonsoir"
```

## `string.Split()`

La méthode `Split(char[] separator)` divise une chaîne en un tableau de sous-chaînes en utilisant un ou plusieurs caractères de séparation.

```csharp
string maChaine = "Bonjour, comment ça va ?";
string[] mots = maChaine.Split(new char[] { ' ', ',' }); // mots = ["Bonjour", "comment", "ça", "va", "?"]
```

## `string.Join()`

La méthode `Join(string separator, string[] values)` combine les éléments d'un tableau de chaînes en une seule chaîne, en utilisant un séparateur spécifié.

```csharp
string[] mots = { "Bonjour", "comment", "ça", "va" };
string phrase = string.Join(" ", mots); // phrase = "Bonjour comment ça va"
```

## `string.Equals()`

La méthode `Equals(string value)` compare deux chaînes et renvoie `true` si elles sont égales, sinon `false`. Elle est sensible à la casse par défaut.

```csharp



string maChaine1 = "Bonjour";
string maChaine2 = "bonjour";
bool sontEgales = maChaine1.Equals(maChaine2); // sontEgales = false

```

## `string.Compare()`

La méthode `Compare(string strA, string strB)` compare deux chaînes et renvoie un entier indiquant leur ordre lexicographique. Elle renvoie 0 si les chaînes sont égales, un nombre négatif si `strA` est inférieure à `strB`, et un nombre positif si `strA` est supérieure à `strB`.

```csharp
string maChaine1 = "Bonjour";
string maChaine2 = "bonjour";
int comparaison = string.Compare(maChaine1, maChaine2); // comparaison < 0 (sensible à la casse)
```

## `string.IsNullOrEmpty()`

La méthode `IsNullOrEmpty(string value)` vérifie si une chaîne est `null` ou vide. Elle renvoie `true` si la chaîne est `null` ou vide, sinon `false`.

```csharp
string maChaine = null;
bool estVide = string.IsNullOrEmpty(maChaine); // estVide = true
string maChaine2 = "";
bool estVide2 = string.IsNullOrEmpty(maChaine2); // estVide2 = true
```

## `string.IsNullOrWhiteSpace()`

La méthode `IsNullOrWhiteSpace(string value)` vérifie si une chaîne est `null`, vide ou ne contient que des espaces blancs. Elle renvoie `true` dans ces cas, sinon `false`.

```csharp
string maChaine = "   ";
bool estBlanc = string.IsNullOrWhiteSpace(maChaine); // estBlanc = true
string maChaine2 = "Bonjour";
bool estBlanc2 = string.IsNullOrWhiteSpace(maChaine2); // estBlanc2 = false
```

## `string.Format()`

La méthode `Format(string format, object arg0)` permet de formater une chaîne en insérant des valeurs dans des emplacements spécifiés par des accolades `{}`.

```csharp
string nom = "Alice";
int age = 30;
string message = string.Format("Bonjour {0}, vous avez {1} ans.", nom, age); // message = "Bonjour Alice, vous avez 30 ans."
```

## `string.PadLeft()`

La méthode `PadLeft(int totalWidth, char paddingChar)` ajoute des caractères de remplissage à gauche d'une chaîne jusqu'à ce qu'elle atteigne une largeur totale spécifiée.

```csharp
string maChaine = "123";
string chainePadded = maChaine.PadLeft(5, '0'); // chainePadded = "00123"
```

## `string.PadRight()`

La méthode `PadRight(int totalWidth, char paddingChar)` ajoute des caractères de remplissage à droite d'une chaîne jusqu'à ce qu'elle atteigne une largeur totale spécifiée.

```csharp
string maChaine = "123";
string chainePadded = maChaine.PadRight(5, '0'); // chainePadded = "12300"
```

## `string.StartsWith()`

La méthode `StartsWith(string value)` vérifie si une chaîne commence par une sous-chaîne spécifique. Elle renvoie `true` si c'est le cas, sinon `false`.

```csharp
string maChaine = "Bonjour";
bool commencePar = maChaine.StartsWith("Bon"); // commencePar = true
```

## `string.EndsWith()`

La méthode `EndsWith(string value)` vérifie si une chaîne se termine par une sous-chaîne spécifique. Elle renvoie `true` si c'est le cas, sinon `false`.

```csharp
string maChaine = "Bonjour";
bool seTerminePar = maChaine.EndsWith("jour"); // seTerminePar = true
```

## `string.ToCharArray()`

La méthode `ToCharArray()` convertit une chaîne en un tableau de caractères.

```csharp
string maChaine = "Bonjour";
char[] tableauDeCaracteres = maChaine.ToCharArray(); // tableauDeCaracteres = ['B', 'o', 'n', 'j', 'o', 'u', 'r']
```

## `string.Insert()`

La méthode `Insert(int startIndex, string value)` insère une sous-chaîne à une position spécifiée dans une chaîne.

```csharp
string maChaine = "Bonjour";
string chaineModifiee = maChaine.Insert(5, " le monde"); // chaineModifiee = "Bonjour le monde"
```

## `string.Remove()`

La méthode `Remove(int startIndex, int count)` supprime une sous-chaîne à partir d'une position spécifiée et d'une longueur donnée.

```csharp
string maChaine = "Bonjour le monde";
string chaineModifiee = maChaine.Remove(5, 3); // chaineModifiee = "Bonjour monde"
```

## `string.ToString()`

La méthode `ToString()` convertit un objet en une chaîne de caractères. Pour les chaînes, elle renvoie la chaîne elle-même.

```csharp
string maChaine = "Bonjour";
string chaine = maChaine.ToString(); // chaine = "Bonjour"
```

## `string.GetHashCode()`

La méthode `GetHashCode()` renvoie un code de hachage pour la chaîne. Ce code est utilisé pour identifier la chaîne dans des structures de données comme les tables de hachage.

```csharp
string maChaine = "Bonjour";
int hashCode = maChaine.GetHashCode(); // hashCode = un entier représentant le hachage de la chaîne
```

## `string.CompareOrdinal()`

La méthode `CompareOrdinal(string strA, string strB)` compare deux chaînes en utilisant la comparaison ordinale, qui est sensible à la casse et à la culture. Elle renvoie un entier indiquant leur ordre lexicographique.

```csharp
string maChaine1 = "Bonjour";
string maChaine2 = "bonjour";
int comparaisonOrdinale = string.CompareOrdinal(maChaine1, maChaine2); // comparaisonOrdinale < 0 (sensible à la casse)
```

## `string.ToString(IFormatProvider)`

La méthode `ToString(IFormatProvider provider)` convertit un objet en une chaîne de caractères en utilisant un fournisseur de formatage spécifique. Pour les chaînes, elle renvoie la chaîne elle-même.

```csharp
string maChaine = "Bonjour";
IFormatProvider formatProvider = System.Globalization.CultureInfo.InvariantCulture;
string chaineFormattee = maChaine.ToString(formatProvider); // chaineFormattee = "Bonjour"
```

## `string.GetType()`

La méthode `GetType()` renvoie le type de l'objet actuel. Pour les chaînes, elle renvoie `System.String`.

```csharp
string maChaine = "Bonjour";
Type typeDeChaine = maChaine.GetType(); // typeDeChaine = System.String
```
