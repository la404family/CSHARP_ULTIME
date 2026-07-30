# Les Fonctions Génériques

## Les Fonctions Génériques

### 📝 Explication
Imagine que tu as inventé une boîte magique qui peut ranger des affaires. Ce serait dommage de devoir construire une boîte spécifique uniquement pour des pommes, une autre uniquement pour des livres, et une autre pour des jouets, alors que le mécanisme de rangement de la boîte est exactement le même !

En C#, c'est là qu'interviennent les **fonctions génériques**. Elles te permettent d'écrire une méthode **une seule fois**, mais qui sera capable de fonctionner avec **n'importe quel type de données** (des nombres `int`, du texte `string`, des booléens `bool`, ou même tes propres créations).

Pour indiquer à C# que ta fonction est "générique", on utilise des chevrons `< >` contenant une lettre. Très souvent, on utilise la lettre **`T`** (pour "Type"). C'est comme une "variable de type", un espace réservé, qui sera remplacé par le vrai type de données (int, string...) au moment où tu utiliseras la fonction.

### 🔤 Syntaxe
La syntaxe d'une méthode générique place les chevrons `<T>` juste après le nom de la méthode, avant les parenthèses des paramètres.

```csharp
// Le "T" indique que cette méthode fonctionne avec n'importe quel type
type_de_retour NomDeLaMéthode<T>(T parametre)
{
    // ... code ...
}

// On peut aussi utiliser "T" comme type de retour
T AutreMethode<T>(T parametre1, T parametre2)
{
    // ... code ...
}
```

### 💡 Exemple Simple
Créons une méthode toute simple qui affiche la valeur qu'on lui donne, ainsi que son type en mémoire.

```csharp
using System;

class Program
{
    // Déclaration de notre fonction générique "Affiche"
    // Elle accepte n'importe quel type "T"
    static void Affiche<T>(T valeur)
    {
        // On affiche la valeur et on utilise "typeof(T)" pour connaître son type
        Console.WriteLine($"Valeur : {valeur} | Type : {typeof(T)}");
    }

    static void Main()
    {
        // On appelle la fonction avec un nombre entier (int)
        Affiche<int>(5); 
        
        // C# est intelligent : tu n'es même pas obligé de préciser <int>, il le devine tout seul !
        Affiche(10); 

        // On appelle la même fonction avec du texte (string)
        Affiche("Bonjour !");

        // Et avec un booléen (bool)
        Affiche(true);
    }
}
```

### 🚀 Exemple Avancé
Un cas classique de la programmation est d'intervertir (échanger) le contenu de deux variables. Sans fonction générique, il te faudrait écrire une fonction pour échanger deux `int`, une autre pour deux `string`, etc. Avec les génériques, une seule fonction suffit pour tous les types du monde !

```csharp
using System;

class Program
{
    // Fonction qui échange les valeurs de la variable "a" et de la variable "b"
    // L'utilisation de "ref" (référence) permet de modifier directement les variables originales
    static void Echanger<T>(ref T a, ref T b)
    {
        // On sauvegarde la valeur de "a" dans une variable temporaire de type "T"
        T temporaire = a;
        
        // La variable "a" prend la valeur de "b"
        a = b;
        
        // La variable "b" prend l'ancienne valeur de "a" (sauvegardée dans "temporaire")
        b = temporaire;
    }

    static void Main()
    {
        // --- Utilisation avec des nombres entiers (int) ---
        int x = 5;
        int y = 10;
        
        Console.WriteLine($"Avant : x = {x}, y = {y}");
        // La fonction "Echanger" comprend qu'on lui donne des "int"
        Echanger(ref x, ref y);
        Console.WriteLine($"Après : x = {x}, y = {y}\n");

        // --- Utilisation avec du texte (string) ---
        string prenom1 = "Alice";
        string prenom2 = "Bob";
        
        Console.WriteLine($"Avant : prenom1 = {prenom1}, prenom2 = {prenom2}");
        // La MÊME fonction "Echanger" comprend ici qu'on lui donne des "string"
        Echanger(ref prenom1, ref prenom2);
        Console.WriteLine($"Après : prenom1 = {prenom1}, prenom2 = {prenom2}");
    }
}
```

### ⚠️ Erreurs Courantes
- ❌ **Croire que `T` sait tout faire par défaut.**
  - **Explication :** Si tu crées une fonction générique `T Additionner<T>(T a, T b)`, tu ne pourras **pas** simplement écrire `return a + b;`. Pourquoi ? Parce que C# ne sait pas à l'avance si `T` sera un nombre (qui peut s'additionner) ou un bouton cliquable (qui ne peut pas s'additionner). Par défaut, `T` est considéré comme "n'importe quoi", donc on ne peut faire que des opérations qui marchent sur "n'importe quoi" (comme l'afficher, l'échanger ou le stocker).
- ❌ **Forcer l'écriture du type inutilement lors de l'appel.**
  - **Explication :** Bien que tu puisses écrire `MaFonction<int>(5)`, le compilateur C# est très intelligent (on appelle cela l'inférence de type). Il voit que tu passes le chiffre `5`, il comprend immédiatement que `T` est un `int`. Écris simplement `MaFonction(5)`, c'est plus épuré !

### ✅ Bonnes Pratiques
- ✔️ **Utilise des noms parlants si tu as plusieurs types génériques.** Si tu as besoin de deux types "T" différents dans la même fonction, nomme-les de manière compréhensible. Par exemple, au lieu de les appeler `<T, U>`, utilise plutôt `<TKey, TValue>`. C'est une convention très utilisée en C#.
- ✔️ **Découvre les "Contraintes de type" (le mot-clé `where`).** Plus tard dans ton apprentissage, tu apprendras que tu peux restreindre ce fameux `T`. Par exemple, tu pourras dire : *"Cette fonction est générique, mais le `T` DOIT OBLIGATOIREMENT être un type comparable"*. Cela se fait avec les contraintes (ex: `where T : IComparable`), ce qui permet d'utiliser des génériques tout en sécurisant ton code !
