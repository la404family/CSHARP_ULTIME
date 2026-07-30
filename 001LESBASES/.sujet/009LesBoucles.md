# Les boucles en C-Sharp

Les boucles sont des structures de contrôle qui permettent d'exécuter un bloc de code plusieurs fois, tant qu'une condition est vraie. Elles sont essentielles pour automatiser des tâches répétitives et parcourir des collections de données.

## Sommaire

1. [Boucle `for`](#boucle-for)
2. [Boucle `while`](#boucle-while)
3. [Boucle `do while`](#boucle-do-while)
4. [Boucle `foreach`](#boucle-foreach)

## Boucle `for`

La boucle `for` est utilisée lorsque vous connaissez à l'avance le nombre d'itérations à effectuer. Elle se compose de trois parties : l'initialisation, la condition et l'incrémentation.

    ```csharp
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(i); // Affiche les nombres de 0 à 4
    }
    ```

La boucle commence par initialiser la variable `i` à 0, puis elle vérifie si `i` est inférieur à 5. Si c'est le cas, elle exécute le bloc de code et incrémente `i` de 1.
La boucle continue jusqu'à ce que la condition ne soit plus vraie.

## Boucle `while`

La boucle `while` exécute un bloc de code tant qu'une condition est vraie. Elle est utile lorsque vous ne savez pas à l'avance combien d'itérations seront nécessaires.

    ```csharp
    int i = 0;
    while (i < 5)
    {
        Console.WriteLine(i); // Affiche les nombres de 0 à 4
        i++;
    }
    ```

La boucle commence par vérifier la condition. Si elle est vraie, elle exécute le bloc de code et incrémente `i` de 1. La boucle continue jusqu'à ce que la condition ne soit plus vraie.

## Boucle `do while`

La boucle `do while` est similaire à la boucle `while`, mais elle garantit que le bloc de code sera exécut
é au moins une fois, même si la condition est fausse dès le départ.

    ```csharp
    int i = 0;
    do
    {
        Console.WriteLine(i); // Affiche les nombres de 0 à 4
        i++;
    } while (i < 5);
    ```

La boucle commence par exécuter le bloc de code, puis elle vérifie la condition. Si la condition est vraie, elle continue à exécuter le bloc de code.
La boucle continue jusqu'à ce que la condition ne soit plus vraie.

## Boucle `foreach`

La boucle `foreach` est utilisée pour parcourir les éléments d'une collection, comme un tableau ou une liste. Elle simplifie le code en évitant d'utiliser un index.

    ```csharp
    int[] tableau = { 1, 2, 3, 4, 5 };
    foreach (int i in tableau)
    {
        Console.WriteLine(i); // Affiche les nombres de 1 à 5
    }
    ```

La boucle `foreach` parcourt chaque élément du tableau et l'affiche. Elle est particulièrement utile pour les collections, car elle évite les erreurs d'indexation.

La boucle `foreach` est plus lisible et moins sujette aux erreurs que les boucles `for` ou `while` lorsque vous travaillez avec des collections.
