# Les fonctions relatives aux ints en csharp

Les fonctions relatives aux ints sont des fonctions qui permettent de manipuler des entiers. Elles sont très utiles pour effectuer des opérations mathématiques, des conversions, des comparaisons, etc.

## Exemples de fonctions relatives aux ints

### Abs : retourne la valeur absolue d'un entier

```csharp
int a = -5;
Console.WriteLine(Math.Abs(a)); // Affiche 5
```

### Max : retourne le maximum de deux entiers

```csharp
int a = 5;
int b = 10;
Console.WriteLine(Math.Max(a, b)); // Affiche 10
```

### Min : retourne le minimum de deux entiers

```csharp
int a = 5;
int b = 10;
Console.WriteLine(Math.Min(a, b)); // Affiche 5
```

### Pow : retourne la puissance d'un entier

```csharp
int a = 2;
int b = 3;
Console.WriteLine(Math.Pow(a, b)); // Affiche 8
```

### Sqrt : retourne la racine carrée d'un entier

```csharp
int a = 16;
Console.WriteLine(Math.Sqrt(a)); // Affiche 4
```

### Round : arrondit un entier

```csharp
double a = 5.5;
Console.WriteLine(Math.Round(a)); // Affiche 6
```

### ToString : convertit un entier en chaîne de caractères

```csharp
int a = 5;
Console.WriteLine(a.ToString()); // Affiche "5"
```

### Parse : convertit une chaîne de caractères en entier

```csharp
string str = "5";
int a = int.Parse(str);
Console.WriteLine(a); // Affiche 5
```

### TryParse : tente de convertir une chaîne de caractères en entier

```csharp
string str = "5";
int a;
if (int.TryParse(str, out a))
{
    Console.WriteLine(a); // Affiche 5
}
else
{
    Console.WriteLine("Conversion échouée");
}
```

### Compare : compare deux entiers

```csharp
int a = 5;
int b = 10;
if (Math.Compare(a, b) < 0)
{
    Console.WriteLine("a est inférieur à b");
}
else if (Math.Compare(a, b) > 0)
{
    Console.WriteLine("a est supérieur à b");
}
else
{
    Console.WriteLine("a est égal à b");
}
```

### Clamp : limite une valeur entre deux bornes

```csharp
int a = 5;
int min = 1;
int max = 10;
Console.WriteLine(Math.Clamp(a, min, max)); // Affiche 5
```

### Sign : retourne le signe d'un entier

```csharp
int a = -5;
Console.WriteLine(Math.Sign(a)); // Affiche -1
```

### IsEven : vérifie si un entier est pair

```csharp
int a = 4;
Console.WriteLine(a % 2 == 0 ? "Pair" : "Impair");
```

### IsOdd : vérifie si un entier est impair

```csharp
int a = 5;
Console.WriteLine(a % 2 != 0 ? "Impair" : "Pair");
```

### Factorial : calcule la factorielle d'un entier

```csharp
int Factorial(int n)
{
    if (n < 0) throw new ArgumentException("Le nombre doit être positif");
    if (n == 0) return 1;
    return n * Factorial(n - 1);
}
Console.WriteLine(Factorial(5)); // Affiche 120
```
