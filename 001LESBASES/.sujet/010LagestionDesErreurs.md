# La gestion des erreurs en C-Sharp

La gestion des erreurs est un aspect essentiel de la programmation, car elle permet de traiter les situations imprévues qui peuvent survenir lors de l'exécution d'un programme. En C-Sharp, la gestion des erreurs est principalement effectuée à l'aide des exceptions.
Les exceptions sont des événements qui se produisent pendant l'exécution d'un programme et qui perturbent le flux normal de l'exécution. Elles peuvent être causées par des erreurs de syntaxe, des erreurs de logique, des erreurs d'entrée/sortie, des erreurs de réseau, etc.
La gestion des exceptions permet de capturer ces erreurs et de les traiter de manière appropriée, plutôt que de laisser le programme se terminer brutalement.

## Sommaire

1. [Gestion des exceptions](#gestion-des-exceptions) (Try catch finally throw)
2. [Le bloc using](#le-bloc-using)

## Gestion des exceptions

La gestion des exceptions est le processus de capture et de traitement des exceptions qui se produisent pendant l'exécution d'un programme. En C-Sharp, la gestion des exceptions est principalement effectuée à l'aide des blocs `try`, `catch`, `finally` et `throw`.
Les blocs `try` et `catch` sont utilisés pour capturer les exceptions, tandis que le bloc `finally` est utilisé pour exécuter du code qui doit être exécuté, qu'une exception se produise ou non.
Le bloc `throw` est utilisé pour lever une exception.

exemple de gestion des exceptions en C# :

```csharp
try
{
    // Code qui peut lever une exception
    int resultat = 10 / 0; // Division par zéro
}
catch (DivideByZeroException ex)
{
    // Code qui s'exécute si une exception de type DivideByZeroException est levée
    Console.WriteLine("Erreur : " + ex.Message);
}
catch (Exception ex)
{
    // Code qui s'exécute si une exception de type Exception est levée
    Console.WriteLine("Erreur : " + ex.Message);
}
finally
{
    // Code qui s'exécute toujours, qu'une exception soit levée ou non
    Console.WriteLine("Fin du traitement.");
}
```

exemple de gestion des exceptions avec le bloc `throw` en C# :

```csharp
try
{
    // Code qui peut lever une exception
    int resultat = 10 / 0; // Division par zéro
}
catch (DivideByZeroException ex)
{
    // Lever une nouvelle exception avec un message personnalisé
    throw new Exception("Une erreur s'est produite lors de la division : " + ex.Message);
}
catch (Exception ex)
{
    // Lever une nouvelle exception avec un message personnalisé
    throw new Exception("Une erreur s'est produite : " + ex.Message);
}
finally
{
    // Code qui s'exécute toujours, qu'une exception soit levée ou non
    Console.WriteLine("Fin du traitement.");
}
```

Le throw est utilisé pour lever une exception, ce qui permet de signaler une erreur à un niveau supérieur dans la pile d'appels. Cela peut être utile lorsque vous souhaitez propager une exception à un appelant ou à un gestionnaire d'exceptions supérieur.

## Le bloc using

Le bloc `using` est utilisé pour gérer les ressources non managées, telles que les fichiers, les connexions réseau, etc. Il garantit que les ressources sont correctement libérées après utilisation, même en cas d'exception.
Le bloc `using` est particulièrement utile pour éviter les fuites de mémoire et garantir que les ressources sont correctement nettoyées.

exemple d'utilisation du bloc `using` en C# :

```csharp
using (StreamReader reader = new StreamReader("fichier.txt"))
{
    // Code qui lit le fichier
    string contenu = reader.ReadToEnd();
    Console.WriteLine(contenu);
} // Le fichier est automatiquement fermé ici, même en cas d'exception
```
