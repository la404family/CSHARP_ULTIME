# Les fonctions relatives aux collections

Les fonctions relatives aux collections sont des fonctions qui permettent de manipuler des collections de données, telles que les listes, les ensembles et les dictionnaires. Elles sont très utiles pour effectuer des opérations sur ces collections, comme le tri, la recherche, la transformation, etc.

## Exemples pour les tableaux et les listes

### Contains : vérifie si un tableau contient une valeur spécifique

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Console.WriteLine(Array.Exists(array, element => element == 3)); // Affiche True
```

### ToArray : convertit une collection en tableau

```csharp
List<int> list = new List<int> { 1, 2, 3, 4, 5 };
int[] array = list.ToArray();
Console.WriteLine(string.Join(", ", array)); // Affiche 1, 2, 3, 4, 5
```

### Length : retourne la taille du tableau

exemple :

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Console.WriteLine(array.Length); // Affiche 5
```

### IndexOf : retourne l'index de la première occurrence d'une valeur dans le tableau

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Console.WriteLine(Array.IndexOf(array, 3)); // Affiche 2
```

### Sort : trie les éléments du tableau

```csharp
int[] array = { 5, 3, 1, 4, 2 };
Array.Sort(array);
Console.WriteLine(string.Join(", ", array)); // Affiche 1, 2, 3, 4, 5
```

### Reverse : inverse les éléments du tableau

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Array.Reverse(array);
Console.WriteLine(string.Join(", ", array)); // Affiche 5, 4, 3, 2, 1
```

### ForEach : pour parcourir les éléments du tableau

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Array.ForEach(array, item => Console.WriteLine(item)); // Affiche 1, 2, 3, 4, 5
```

### Copy : copie un tableau dans un autre

```csharp
int[] src = { 1, 2, 3, 4, 5 };
int[] dest = new int[5];

Array.Copy(src, dest, src.Length);
Console.WriteLine(string.Join(", ", dest)); // Affiche 1, 2, 3, 4, 5
```

### Clear : efface les éléments d'un tableau

```csharp
int[] array = { 1, 2, 3, 4, 5 };
Array.Clear(array, 0, array.Length);
Console.WriteLine(string.Join(", ", array)); // Affiche 0, 0, 0, 0, 0
```

### Find : trouve le premier élément qui satisfait une condition

```csharp
int[] array = { 1, 2, 3, 4, 5 };
int found = Array.Find(array, item => item > 3);
Console.WriteLine(found); // Affiche 4
```

### FindAll : trouve tous les éléments qui satisfont une condition

```csharp
int[] array = { 1, 2, 3, 4, 5 };
int[] found = Array.FindAll(array, item => item > 3);
Console.WriteLine(string.Join(", ", found)); // Affiche 4, 5
```

### FindIndex : trouve l'index du premier élément qui satisfait une condition

```csharp
int[] array = { 1, 2, 3, 4, 5 };
int index = Array.FindIndex(array, item => item > 3);
Console.WriteLine(index); // Affiche 3
```

### FindLast : trouve le dernier élément qui satisfait une condition

```csharp
int[] array = { 1, 2, 3, 4, 5 };
int found = Array.FindLast(array, item => item < 4);
Console.WriteLine(found); // Affiche 3
```

## Exemplers pour les dictionnaires

### ContainsKey : vérifie si un dictionnaire contient une clé spécifique

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};
Console.WriteLine(dict.ContainsKey("banana")); // Affiche True
```

### ContainsValue : vérifie si un dictionnaire contient une valeur spécifique

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};
Console.WriteLine(dict.ContainsValue(2)); // Affiche True
```

## Add : ajoute une paire clé-valeur aux dictionnaires

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>();
dict.Add("apple", 1);
dict.Add("banana", 2);
dict.Add("cherry", 3);
Console.WriteLine(string.Join(", ", dict.Select(kv => $"{kv.Key}: {kv.Value}"))); // Affiche apple: 1, banana: 2, cherry: 3
```

### Remove : supprime une paire clé-valeur du dictionnaire

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};
dict.Remove("banana");
Console.WriteLine(string.Join(", ", dict.Select(kv => $"{kv.Key}: {kv.Value}"))); // Affiche apple: 1, cherry: 3
```

### TryGetValue : essaie de récupérer la valeur associée à une clé

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};
if (dict.TryGetValue("banana", out int value))
{
    Console.WriteLine(value); // Affiche 2
}
else
{
    Console.WriteLine("Clé non trouvée");
}
```

### Count : retourne le nombre de paires clé-valeur dans le dictionnaire

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};
Console.WriteLine(dict.Count); // Affiche 3
```
