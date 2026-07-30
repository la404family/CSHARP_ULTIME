# La Surcharge de Fonction

## La Surcharge de Fonction

### 📝 Explication
Imagine que tu doives écrire un message. Si tu l'envoies par SMS ou par email, tu utilises le mot "Envoyer", même si l'action derrière n'est pas tout à fait la même (le format et les informations nécessaires changent). 

En C#, c'est pareil avec ce qu'on appelle la **surcharge de fonction** (ou "surcharge de méthode"). Cela te permet de créer **plusieurs fonctions portant le même nom**, à condition qu'elles ne prennent pas les mêmes paramètres (les informations que tu leur donnes entre parenthèses).

*   **Une fonction (ou méthode)** : C'est un bloc de code qui porte un nom et qui effectue une action précise.
*   **Les paramètres** : Ce sont les variables que l'on fournit à la fonction pour qu'elle puisse travailler avec (entre les parenthèses).
*   **La signature** : C'est la combinaison du nom de la fonction et de la liste de ses paramètres. Pour que la surcharge fonctionne, la signature doit être unique.

L'avantage principal ? Ton code devient beaucoup plus naturel à lire et à écrire. Au lieu d'avoir `AdditionnerDeuxNombres`, `AdditionnerTroisNombres`, tu as de la chance : tu as juste une seule action logique à retenir : `Additionner`.

### 🔤 Syntaxe
Pour surcharger une fonction, il te suffit de déclarer plusieurs fois la fonction avec le **même nom**, mais en changeant soit le **nombre**, soit le **type** des paramètres.

```csharp
// Fonction avec deux paramètres du même type
type_de_retour NomDeLaFonction(type param1, type param2)
{
    // ... code ...
}

// Même nom, mais avec TROIS paramètres !
type_de_retour NomDeLaFonction(type param1, type param2, type param3)
{
    // ... code ...
}

// Même nom, mais avec des types DIFFÉRENTS !
type_de_retour NomDeLaFonction(autre_type param1, autre_type param2)
{
    // ... code ...
}
```

### 💡 Exemple Simple
Dans cet exemple minimal, nous allons créer une fonction `CalculerSomme` qui sait à la fois additionner deux nombres entiers, mais aussi trois.

```csharp
using System;

class Program
{
    // Première version : Additionne deux nombres entiers (int)
    static int CalculerSomme(int nombre1, int nombre2)
    {
        // On retourne la somme des deux nombres fournis
        return nombre1 + nombre2;
    }

    // Deuxième version : Surcharge pour additionner trois nombres entiers (int)
    // Même nom "CalculerSomme", mais 3 paramètres au lieu de 2
    static int CalculerSomme(int nombre1, int nombre2, int nombre3)
    {
        // On retourne la somme des trois nombres
        return nombre1 + nombre2 + nombre3;
    }

    static void Main()
    {
        // On appelle la fonction avec deux paramètres
        // C# appelle automatiquement la première version
        int resultatDeux = CalculerSomme(5, 10);
        
        // On affiche le résultat (Affiche : 15)
        Console.WriteLine(resultatDeux); 

        // On appelle la même fonction, mais avec trois paramètres
        // C# comprend qu'il doit utiliser la deuxième version !
        int resultatTrois = CalculerSomme(5, 10, 20);
        
        // On affiche le résultat (Affiche : 35)
        Console.WriteLine(resultatTrois); 
    }
}
```

### 🚀 Exemple Avancé
Prenons un cas plus réaliste. Imaginons un système d'affichage de profil. Tu peux afficher les détails de l'utilisateur soit avec juste son pseudo, soit avec son pseudo et son âge.

```csharp
using System;

class Program
{
    // Version 1 : L'utilisateur donne uniquement son pseudo
    static void AfficherProfil(string pseudo)
    {
        // On utilise l'interpolation de chaîne (le symbole $) pour insérer le pseudo dans le texte
        Console.WriteLine($"Création du profil basique. Bienvenue, {pseudo} !");
    }

    // Version 2 : L'utilisateur donne son pseudo ET son âge
    // C'est une surcharge car le nombre de paramètres est différent (string puis int)
    static void AfficherProfil(string pseudo, int age)
    {
        // On personnalise le message avec l'âge de l'utilisateur
        Console.WriteLine($"Création du profil complet. Bienvenue {pseudo}, tu as {age} ans !");
    }

    // Version 3 : L'utilisateur donne son âge en premier, puis son pseudo
    // C'est aussi autorisé car l'ordre des types change (int puis string)
    static void AfficherProfil(int age, string pseudo)
    {
        // Cette version est là pour montrer que l'ordre des paramètres modifie la signature
        Console.WriteLine($"[Mode inversé] Utilisateur: {pseudo}, Âge: {age}");
    }

    static void Main()
    {
        // Appel de la version à 1 paramètre de type "string"
        AfficherProfil("Alex_Le_Gamer"); 

        // Appel de la version à 2 paramètres "string" puis "int"
        AfficherProfil("Sarah_Dev", 25); 

        // Appel de la version à 2 paramètres inversés "int" puis "string"
        AfficherProfil(32, "Marc");
    }
}
```

### ⚠️ Erreurs Courantes
- ❌ **Surcharger uniquement sur le type de retour.**
  - **Explication :** Tu ne peux pas avoir deux fonctions avec exactement les mêmes paramètres, mais qui renvoient des choses différentes (par exemple, une qui renvoie un `int` et l'autre un `string`). C# ne saurait pas laquelle choisir lors de l'appel ! La signature d'une méthode (son identité) ne prend en compte que son nom et les types de ses paramètres, pas ce qu'elle renvoie.
- ❌ **Créer de l'ambiguïté.**
  - **Explication :** Parfois, si deux surcharges sont trop similaires au niveau des types (par exemple une fonction qui prend un nombre à virgule `double` et une autre très similaire), C# peut s'emmêler les pinceaux et renvoyer une erreur car il hésite entre les deux.

### ✅ Bonnes Pratiques
- ✔️ **Garde une intention unique et similaire.** Toutes les surcharges d'une fonction doivent accomplir fondamentalement la même action (ici, `CalculerSomme` ou `AfficherProfil`). Ne te sers pas de la surcharge pour faire des actions complètement différentes sous le même nom, cela va embrouiller les autres développeurs qui liront ton code !
- ✔️ **Évite d'avoir une quantité déraisonnable de surcharges.** Si tu vois que tu commences à avoir 8 ou 10 versions de ta méthode, c'est sûrement qu'il existe un moyen plus propre (comme l'utilisation de paramètres optionnels dont nous parlerons plus tard !).
