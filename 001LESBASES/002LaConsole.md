# 🖥️ La Console en C#

La classe `Console` de l'espace de noms `System` est ta boîte à outils pour interagir avec le terminal. Elle te permet d'afficher du texte, de lire les entrées de l'utilisateur, de personnaliser les couleurs, de manipuler le curseur et bien plus encore.

> 💡 **Toutes les méthodes et propriétés présentées ici font partie de la classe statique `System.Console`.** Tu n'as donc pas besoin de créer d'objet : tu appelles directement `Console.NomDeLaMéthode()`.

---

## 📑 Table des matières

1. [Entrée et Sortie (Le standard)](#1--entrée-et-sortie-le-standard)
2. [Personnalisation de l'Apparence](#2--personnalisation-de-lapparence)
3. [Gestion du Curseur et de la Fenêtre](#3--gestion-du-curseur-et-de-la-fenêtre)
4. [Signaux Sonores et Buffer](#4--signaux-sonores-et-buffer)
5. [Récapitulatif Général](#5--récapitulatif-général)

---

## 1. 📝 Entrée et Sortie (Le standard)

### 📝 Explication

C'est la base absolue de toute application console : **afficher du texte à l'écran** et **récupérer ce que l'utilisateur tape au clavier**. Sans ces outils, ton programme serait muet et sourd !

En C#, la classe `Console` fournit 5 méthodes fondamentales pour gérer les entrées/sorties :

| Méthode | Rôle | Retourne |
| :--- | :--- | :--- |
| `WriteLine()` | Affiche du texte **suivi d'un retour à la ligne** | `void` |
| `Write()` | Affiche du texte **sans retour à la ligne** | `void` |
| `ReadLine()` | Lit **une ligne entière** (jusqu'à Entrée) | `string` |
| `Read()` | Lit **un seul caractère** (valeur entière) | `int` |
| `ReadKey()` | Attend qu'**une touche** soit pressée | `ConsoleKeyInfo` |

---

### 🔤 Syntaxe

```csharp
// --- SORTIE ---
Console.WriteLine("Texte avec retour à la ligne");
Console.Write("Texte sans retour à la ligne");

// --- ENTRÉE ---
string ligne = Console.ReadLine();        // Lit une ligne entière
int codeCaractere = Console.Read();       // Lit un caractère (code ASCII/Unicode)
ConsoleKeyInfo touche = Console.ReadKey(); // Attend une touche
```

---

### 💡 Exemple Simple — Dire bonjour à l'utilisateur

```csharp
using System; // On importe l'espace de noms System qui contient la classe Console

class Program
{
    static void Main()
    {
        // WriteLine() affiche le texte puis passe à la ligne suivante
        Console.WriteLine("=== Bienvenue dans le programme ! ===");

        // Write() affiche le texte SANS passer à la ligne
        // Le curseur reste juste après les deux-points
        Console.Write("Comment t'appelles-tu ? ");

        // ReadLine() attend que l'utilisateur tape du texte et appuie sur Entrée
        // Le texte saisi est stocké dans la variable "nom"
        string nom = Console.ReadLine();

        // On utilise l'interpolation de chaîne ($"...") pour insérer la variable
        Console.WriteLine($"Enchanté, {nom} ! 🎉");

        // ReadKey() met le programme en pause jusqu'à ce qu'une touche soit pressée
        Console.WriteLine("Appuie sur une touche pour quitter...");
        Console.ReadKey();
    }
}
```

**Résultat dans la console :**
```
=== Bienvenue dans le programme ! ===
Comment t'appelles-tu ? Kevin
Enchanté, Kevin ! 🎉
Appuie sur une touche pour quitter...
```

---

### 🚀 Exemple Avancé — Menu d'un jeu avec toutes les méthodes d'entrée

```csharp
using System;

class Program
{
    static void Main()
    {
        // --- Affichage du menu avec WriteLine() ---
        Console.WriteLine("╔═══════════════════════════════╗");
        Console.WriteLine("║    ⚔️  DONJON DES OMBRES  ⚔️ ║");
        Console.WriteLine("╠═══════════════════════════════╣");
        Console.WriteLine("║  1. Nouvelle partie           ║");
        Console.WriteLine("║  2. Charger une sauvegarde    ║");
        Console.WriteLine("║  3. Options                   ║");
        Console.WriteLine("║  4. Quitter                   ║");
        Console.WriteLine("╚═══════════════════════════════╝");
        Console.WriteLine(); // Ligne vide pour aérer l'affichage

        // --- Utilisation de Write() pour garder le curseur sur la même ligne ---
        Console.Write("Entre le nom de ton héros : ");

        // --- ReadLine() pour récupérer le nom complet ---
        string nomHeros = Console.ReadLine();
        Console.WriteLine($"Bienvenue, {nomHeros} le brave !");
        Console.WriteLine();

        // --- ReadKey() pour capturer un choix par une seule touche ---
        Console.WriteLine("Choisis une option du menu (1-4) :");
        ConsoleKeyInfo choix = Console.ReadKey(true);
        // Le paramètre 'true' (intercept) empêche la touche de s'afficher à l'écran

        // La propriété KeyChar contient le caractère de la touche pressée
        Console.WriteLine($"Tu as choisi l'option : {choix.KeyChar}");

        // On peut aussi vérifier quelle touche exacte a été pressée
        if (choix.Key == ConsoleKey.D1) // D1 = touche "1"
        {
            Console.WriteLine("🗡️ Une nouvelle aventure commence !");
        }
        else if (choix.Key == ConsoleKey.D4)
        {
            Console.WriteLine("👋 À bientôt, aventurier !");
        }

        Console.WriteLine();

        // --- Read() pour lire un seul caractère (moins courant) ---
        Console.Write("Tape la première lettre de ta classe (G/M/A) : ");
        int codeLettre = Console.Read(); // Retourne le code ASCII/Unicode
        char lettre = (char)codeLettre;  // On convertit l'entier en caractère
        Console.WriteLine($"Tu as tapé : '{lettre}' (code Unicode : {codeLettre})");

        // Attention : Read() laisse le '\n' (retour chariot) dans le buffer
        // Il faut le "vider" avec un ReadLine() supplémentaire
        Console.ReadLine(); // Vide le buffer du retour à la ligne résiduel

        Console.WriteLine("\nAppuie sur Échap pour quitter...");

        // Boucle qui attend spécifiquement la touche Échap
        while (Console.ReadKey(true).Key != ConsoleKey.Escape)
        {
            Console.WriteLine("Ce n'est pas Échap ! Réessaie...");
        }

        Console.WriteLine("Programme terminé. 👋");
    }
}
```

---

### ⚠️ Erreurs Courantes

1. **Oublier que `ReadLine()` retourne toujours une `string`**
   ```csharp
   // ❌ ERREUR : on ne peut pas stocker une string dans un int
   int age = Console.ReadLine();

   // ✅ CORRECT : il faut convertir la string en int
   int age = int.Parse(Console.ReadLine());

   // ✅ ENCORE MIEUX : utiliser TryParse pour gérer les erreurs de saisie
   if (int.TryParse(Console.ReadLine(), out int age))
   {
       Console.WriteLine($"Tu as {age} ans.");
   }
   else
   {
       Console.WriteLine("Ce n'est pas un nombre valide !");
   }
   ```

2. **Confondre `Read()` et `ReadLine()`**
   ```csharp
   // ⚠️ Read() retourne un INT (le code Unicode), pas une string !
   int resultat = Console.Read(); // Si l'utilisateur tape 'A' → resultat = 65
   ```

3. **Oublier que `Read()` laisse des caractères dans le buffer**
   ```csharp
   // Après un Read(), le '\r\n' (retour à la ligne) reste dans le buffer
   Console.Read();
   Console.ReadLine(); // ← Ce ReadLine() va consommer le '\n' résiduel et retourner ""
   ```

4. **Ne pas utiliser `intercept: true` avec `ReadKey()`**
   ```csharp
   // Sans le paramètre true, la touche s'affiche dans la console
   Console.ReadKey();       // La touche pressée apparaît à l'écran
   Console.ReadKey(true);   // La touche pressée N'apparaît PAS à l'écran (mode silencieux)
   ```

---

### ✅ Bonnes Pratiques

- **Préfère `ReadLine()` à `Read()`** : `ReadLine()` est plus prévisible et plus simple à utiliser. `Read()` est rarement nécessaire.
- **Valide toujours les entrées utilisateur** : Ne fais jamais confiance à ce que l'utilisateur tape. Utilise `TryParse()` plutôt que `Parse()`.
- **Utilise `ReadKey(true)`** pour les menus interactifs : le paramètre `true` (intercept) empêche la touche de s'afficher, rendant l'interface plus propre.
- **Utilise l'interpolation de chaînes** (`$"Bonjour {nom}"`) plutôt que la concaténation (`"Bonjour " + nom`).
- **Aère tes affichages** avec `Console.WriteLine()` sans paramètre pour insérer des lignes vides.

---

## 2. 🎨 Personnalisation de l'Apparence

### 📝 Explication

La console n'est pas condamnée à rester un écran noir avec du texte blanc ! C# te permet de **personnaliser les couleurs du texte et du fond**, de **changer le titre de la fenêtre**, et même d'**effacer complètement l'écran**. C'est très utile pour rendre tes programmes plus lisibles et plus professionnels.

| Propriété / Méthode | Rôle |
| :--- | :--- |
| `ForegroundColor` | Change la **couleur du texte** |
| `BackgroundColor` | Change la **couleur de l'arrière-plan** du texte |
| `ResetColor()` | Réinitialise les couleurs **aux valeurs par défaut** |
| `Clear()` | **Efface tout** le contenu de la console |
| `Title` | Définit le **titre** de la fenêtre de la console |

Les couleurs disponibles sont définies dans l'énumération `ConsoleColor` :

| Couleur | Nom ConsoleColor |
| :--- | :--- |
| ⬛ Noir | `ConsoleColor.Black` |
| 🔵 Bleu foncé | `ConsoleColor.DarkBlue` |
| 🟢 Vert foncé | `ConsoleColor.DarkGreen` |
| 🔵 Cyan foncé | `ConsoleColor.DarkCyan` |
| 🔴 Rouge foncé | `ConsoleColor.DarkRed` |
| 🟣 Magenta foncé | `ConsoleColor.DarkMagenta` |
| 🟡 Jaune foncé | `ConsoleColor.DarkYellow` |
| ⬜ Gris | `ConsoleColor.Gray` |
| ⬛ Gris foncé | `ConsoleColor.DarkGray` |
| 🔵 Bleu | `ConsoleColor.Blue` |
| 🟢 Vert | `ConsoleColor.Green` |
| 🔵 Cyan | `ConsoleColor.Cyan` |
| 🔴 Rouge | `ConsoleColor.Red` |
| 🟣 Magenta | `ConsoleColor.Magenta` |
| 🟡 Jaune | `ConsoleColor.Yellow` |
| ⬜ Blanc | `ConsoleColor.White` |

---

### 🔤 Syntaxe

```csharp
// Changer la couleur du texte
Console.ForegroundColor = ConsoleColor.NomDeLaCouleur;

// Changer la couleur de l'arrière-plan du texte
Console.BackgroundColor = ConsoleColor.NomDeLaCouleur;

// Réinitialiser toutes les couleurs aux valeurs par défaut
Console.ResetColor();

// Effacer tout le contenu de la console
Console.Clear();

// Changer le titre de la fenêtre
Console.Title = "Mon Titre Personnalisé";
```

---

### 💡 Exemple Simple — Texte en couleur

```csharp
using System;

class Program
{
    static void Main()
    {
        // On change le titre de la fenêtre du terminal
        Console.Title = "🎨 Démo des couleurs";

        // On change la couleur du texte en vert
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ce texte est vert !");

        // On change la couleur du texte en rouge
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ce texte est rouge !");

        // On change la couleur du texte en jaune avec fond bleu
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Texte jaune sur fond bleu !");

        // IMPORTANT : on réinitialise les couleurs pour ne pas affecter le reste
        Console.ResetColor();
        Console.WriteLine("Retour aux couleurs normales.");

        Console.ReadKey();
    }
}
```

**Résultat dans la console :**
```
Ce texte est vert !          ← (en vert)
Ce texte est rouge !         ← (en rouge)
Texte jaune sur fond bleu !  ← (jaune sur fond bleu)
Retour aux couleurs normales.
```

---

### 🚀 Exemple Avancé — Système de logs colorés pour un jeu

```csharp
using System;

class Program
{
    // Méthode utilitaire pour afficher un message avec un niveau de log coloré
    static void AfficherLog(string niveau, string message, ConsoleColor couleur)
    {
        // On sauvegarde la couleur actuelle pour pouvoir la restaurer
        ConsoleColor couleurOriginale = Console.ForegroundColor;

        // On affiche le tag [NIVEAU] en couleur
        Console.ForegroundColor = couleur;
        Console.Write($"[{niveau}] ");

        // On remet la couleur d'origine pour le message
        Console.ForegroundColor = couleurOriginale;
        Console.WriteLine(message);
    }

    static void Main()
    {
        Console.Title = "⚔️ Donjon des Ombres — Journal de bord";

        // On crée un fond sombre pour l'ambiance
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear(); // Clear APRÈS avoir changé le BackgroundColor
        // Cela applique la couleur de fond à TOUT l'écran

        Console.WriteLine("========================================");
        Console.WriteLine("   📜 Journal de bord de l'aventurier   ");
        Console.WriteLine("========================================");
        Console.WriteLine();

        // Différents niveaux de log avec des couleurs distinctes
        AfficherLog("INFO",    "Tu entres dans la forêt sombre...", ConsoleColor.Cyan);
        AfficherLog("SUCCÈS",  "Tu as trouvé une épée légendaire ! 🗡️", ConsoleColor.Green);
        AfficherLog("AVERTIR", "Un bruit étrange se fait entendre...", ConsoleColor.Yellow);
        AfficherLog("DANGER",  "Un dragon apparaît devant toi ! 🐉", ConsoleColor.Red);
        AfficherLog("CRITIQUE","Tu n'as plus que 1 PV !", ConsoleColor.DarkRed);

        Console.WriteLine();

        // Affichage d'une barre de vie colorée
        Console.Write("PV : ");
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("  ██  ");  // Barre de vie faible
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" / ");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("  ██████████████████████  ");  // Barre de vie totale
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Appuie sur une touche pour continuer...");
        Console.ReadKey(true);
    }
}
```

---

### ⚠️ Erreurs Courantes

1. **Oublier `ResetColor()` après avoir changé les couleurs**
   ```csharp
   // ❌ PROBLÈME : tout le texte suivant sera rouge !
   Console.ForegroundColor = ConsoleColor.Red;
   Console.WriteLine("Erreur !");
   Console.WriteLine("Ce texte est aussi rouge, sans le vouloir...");

   // ✅ CORRECT : on remet les couleurs par défaut
   Console.ForegroundColor = ConsoleColor.Red;
   Console.WriteLine("Erreur !");
   Console.ResetColor(); // ← On réinitialise !
   Console.WriteLine("Ce texte est normal.");
   ```

2. **Appeler `Clear()` AVANT de changer `BackgroundColor`**
   ```csharp
   // ❌ Le fond ne change que pour les nouvelles lignes écrites
   Console.Clear();
   Console.BackgroundColor = ConsoleColor.DarkBlue;

   // ✅ Changer le BackgroundColor AVANT Clear() pour que tout l'écran change
   Console.BackgroundColor = ConsoleColor.DarkBlue;
   Console.Clear(); // Maintenant tout l'écran est bleu foncé
   ```

3. **Confondre `ForegroundColor` et `BackgroundColor`**
   ```csharp
   // ⚠️ ForegroundColor = couleur du TEXTE
   // ⚠️ BackgroundColor = couleur DERRIÈRE le texte
   Console.ForegroundColor = ConsoleColor.DarkBlue;  // Le texte sera bleu foncé
   Console.BackgroundColor = ConsoleColor.White;      // Le fond sera blanc
   ```

---

### ✅ Bonnes Pratiques

- **Toujours appeler `ResetColor()`** après avoir utilisé des couleurs personnalisées, pour ne pas polluer le reste de l'affichage.
- **Crée des méthodes utilitaires** (comme `AfficherLog`) pour encapsuler la logique de coloration. Cela rend ton code plus propre et réutilisable.
- **Utilise les couleurs avec parcimonie** : trop de couleurs rendent la console illisible. Réserve-les pour les informations importantes (erreurs, succès, alertes).
- **Pense aux terminaux qui ne supportent pas toutes les couleurs** : certains terminaux anciens ou certaines configurations peuvent ne pas afficher les 16 couleurs correctement.
- **Utilise `Console.Title`** pour donner un nom descriptif à la fenêtre — c'est un petit détail qui rend l'application plus professionnelle.

---

## 3. 🎯 Gestion du Curseur et de la Fenêtre

### 📝 Explication

La console n'est pas juste un flux de texte de haut en bas ! Tu peux **déplacer le curseur n'importe où** sur l'écran, comme un pinceau sur une toile. C'est ce qui permet de créer des **menus interactifs**, des **barres de progression**, voire des **petits jeux** dans la console.

Le système de coordonnées de la console fonctionne ainsi :
- **`left` (colonne)** : position horizontale, commence à `0` (tout à gauche).
- **`top` (ligne)** : position verticale, commence à `0` (tout en haut).

```
     Colonne (left) →
     0   1   2   3   4   5   ...
  0 [ ] [ ] [ ] [ ] [ ] [ ]
  1 [ ] [ ] [ ] [ ] [ ] [ ]
  2 [ ] [ ] [X] [ ] [ ] [ ]  ← Le curseur est en (2, 2)
  3 [ ] [ ] [ ] [ ] [ ] [ ]
  ↓
  Ligne (top)
```

| Propriété / Méthode | Rôle |
| :--- | :--- |
| `SetCursorPosition(left, top)` | **Déplace** le curseur aux coordonnées données |
| `CursorLeft` | Récupère ou définit la **colonne** actuelle du curseur |
| `CursorTop` | Récupère ou définit la **ligne** actuelle du curseur |
| `CursorVisible` | Masque (`false`) ou affiche (`true`) le **curseur clignotant** |
| `WindowWidth` | Récupère ou définit la **largeur** de la fenêtre (en colonnes) |
| `WindowHeight` | Récupère ou définit la **hauteur** de la fenêtre (en lignes) |

---

### 🔤 Syntaxe

```csharp
// Déplacer le curseur à la colonne 10, ligne 5
Console.SetCursorPosition(10, 5);

// Récupérer la position actuelle du curseur
int colonne = Console.CursorLeft;
int ligne = Console.CursorTop;

// Masquer le curseur clignotant
Console.CursorVisible = false;

// Obtenir la taille de la fenêtre
int largeur = Console.WindowWidth;
int hauteur = Console.WindowHeight;
```

---

### 💡 Exemple Simple — Écrire à des positions précises

```csharp
using System;

class Program
{
    static void Main()
    {
        // On masque le curseur pour un affichage plus propre
        Console.CursorVisible = false;

        // On efface l'écran
        Console.Clear();

        // On écrit "Bonjour" à la position (0, 0) — coin supérieur gauche (par défaut)
        Console.WriteLine("Coin supérieur gauche");

        // On déplace le curseur au milieu de l'écran
        // WindowWidth / 2 = milieu horizontal, WindowHeight / 2 = milieu vertical
        int centreX = Console.WindowWidth / 2 - 5; // -5 pour centrer le texte "Au milieu!"
        int centreY = Console.WindowHeight / 2;
        Console.SetCursorPosition(centreX, centreY);
        Console.Write("Au milieu !");

        // On déplace le curseur en bas à droite
        Console.SetCursorPosition(Console.WindowWidth - 20, Console.WindowHeight - 1);
        Console.Write("En bas à droite");

        // On affiche la taille de la fenêtre en haut à droite
        string taille = $"Fenêtre : {Console.WindowWidth}x{Console.WindowHeight}";
        Console.SetCursorPosition(Console.WindowWidth - taille.Length, 0);
        Console.Write(taille);

        // On remet le curseur visible et on attend
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.CursorVisible = true;
        Console.ReadKey();
    }
}
```

---

### 🚀 Exemple Avancé — Barre de progression animée

```csharp
using System;
using System.Threading; // Nécessaire pour Thread.Sleep()

class Program
{
    static void DessinerBarreProgression(int pourcentage, int posY)
    {
        // Largeur de la barre en caractères (50 caractères = 100%)
        int largeurBarre = 50;

        // Nombre de blocs remplis proportionnel au pourcentage
        int blocsRemplis = (int)(largeurBarre * (pourcentage / 100.0));

        // On se positionne au début de la barre
        Console.SetCursorPosition(0, posY);

        // Affichage du libellé
        Console.Write("Progression : [");

        // Partie remplie en vert
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(new string('█', blocsRemplis));

        // Partie vide en gris foncé
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(new string('░', largeurBarre - blocsRemplis));

        // Fermeture et pourcentage
        Console.ResetColor();
        Console.Write($"] {pourcentage,3}%"); // {pourcentage,3} = aligné à droite sur 3 caractères
    }

    static void Main()
    {
        Console.Title = "📊 Barre de Progression";
        Console.CursorVisible = false; // On masque le curseur pour un affichage propre
        Console.Clear();

        Console.WriteLine("=== Téléchargement en cours ===");
        Console.WriteLine();

        // Animation de la barre de 0% à 100%
        for (int i = 0; i <= 100; i++)
        {
            DessinerBarreProgression(i, 2); // Dessine la barre à la ligne 2
            Thread.Sleep(50); // Pause de 50ms pour l'animation
        }

        Console.SetCursorPosition(0, 4);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✅ Téléchargement terminé !");
        Console.ResetColor();

        Console.CursorVisible = true;
        Console.ReadKey();
    }
}
```

**Résultat dans la console (à 60%) :**
```
=== Téléchargement en cours ===

Progression : [██████████████████████████████░░░░░░░░░░░░░░░░░░░░]  60%
```

---

### 🚀 Exemple Avancé 2 — Menu interactif navigable au clavier

```csharp
using System;

class Program
{
    static void Main()
    {
        // Liste des options du menu
        string[] options = { "🎮 Nouvelle Partie", "📂 Charger", "⚙️ Options", "🚪 Quitter" };

        int selection = 0; // Index de l'option actuellement sélectionnée
        bool continuer = true;

        Console.CursorVisible = false;
        Console.Title = "Menu Interactif";

        while (continuer)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║     MENU PRINCIPAL     ║");
            Console.WriteLine("╠════════════════════════╣");

            // On dessine chaque option du menu
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selection) // Si c'est l'option sélectionnée
                {
                    // On la met en surbrillance (fond blanc, texte noir)
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"║ ► {options[i],-19}║");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"║   {options[i],-19}║");
                }
            }

            Console.WriteLine("╚════════════════════════╝");
            Console.WriteLine("\n  ↑↓ pour naviguer, Entrée pour valider");

            // On capture la touche pressée (sans l'afficher)
            ConsoleKeyInfo touche = Console.ReadKey(true);

            switch (touche.Key)
            {
                case ConsoleKey.UpArrow: // Flèche du haut
                    selection = (selection == 0) ? options.Length - 1 : selection - 1;
                    // Si on est tout en haut, on boucle vers le bas
                    break;

                case ConsoleKey.DownArrow: // Flèche du bas
                    selection = (selection == options.Length - 1) ? 0 : selection + 1;
                    // Si on est tout en bas, on boucle vers le haut
                    break;

                case ConsoleKey.Enter: // Touche Entrée
                    Console.Clear();
                    Console.WriteLine($"Tu as sélectionné : {options[selection]}");

                    if (selection == options.Length - 1) // "Quitter"
                    {
                        continuer = false;
                    }
                    else
                    {
                        Console.WriteLine("Appuie sur une touche pour revenir au menu...");
                        Console.ReadKey(true);
                    }
                    break;
            }
        }

        Console.CursorVisible = true;
    }
}
```

---

### ⚠️ Erreurs Courantes

1. **Dépasser les limites de la fenêtre**
   ```csharp
   // ❌ ERREUR : si la fenêtre fait 80 colonnes, la position 100 provoque une exception
   Console.SetCursorPosition(100, 5); // ArgumentOutOfRangeException !

   // ✅ CORRECT : toujours vérifier les limites
   int colonne = Math.Min(100, Console.WindowWidth - 1);
   Console.SetCursorPosition(colonne, 5);
   ```

2. **Modifier `CursorVisible` dans un environnement redirigé**
   ```csharp
   // ⚠️ Si la sortie console est redirigée (ex : dans un pipeline),
   // CursorVisible peut lever une exception sur certains systèmes.
   // Entoure-le d'un try/catch si ton programme peut être utilisé dans un pipeline.
   try
   {
       Console.CursorVisible = false;
   }
   catch (System.IO.IOException)
   {
       // La console n'est pas disponible (sortie redirigée)
   }
   ```

3. **Oublier de revenir à la bonne position après un dessin**
   ```csharp
   // ⚠️ Après avoir dessiné avec SetCursorPosition, le curseur reste à la dernière position
   // Pense à le replacer là où tu veux écrire ensuite
   Console.SetCursorPosition(0, Console.WindowHeight - 1);
   ```

---

### ✅ Bonnes Pratiques

- **Masque le curseur** (`CursorVisible = false`) quand tu dessines des interfaces animées — cela évite le clignotement parasite.
- **Sauvegarde et restaure la position du curseur** si tu as besoin de revenir écrire au même endroit :
   ```csharp
   int ancienLeft = Console.CursorLeft;
   int ancienTop = Console.CursorTop;
   // ... dessin ailleurs ...
   Console.SetCursorPosition(ancienLeft, ancienTop);
   ```
- **Vérifie `WindowWidth` et `WindowHeight`** avant de positionner le curseur pour éviter les exceptions.
- **Préfère `SetCursorPosition()`** à la modification séparée de `CursorLeft` et `CursorTop` — c'est plus lisible et atomique.
- **Remets toujours `CursorVisible = true`** à la fin du programme pour ne pas laisser le terminal dans un état bizarre.

---

## 4. 🔊 Signaux Sonores et Buffer

### 📝 Explication

La console peut aussi **émettre des sons** ! La méthode `Console.Beep()` te permet de jouer des signaux sonores, allant du simple bip d'alerte à de véritables petites **mélodies 8-bit**. 🎵

En parallèle, le **buffer** de la console est la zone mémoire où tout le texte affiché est stocké. C'est ce qui te permet de **scroller** vers le haut pour revoir du texte précédent.

| Propriété / Méthode | Rôle |
| :--- | :--- |
| `Beep()` | Émet un **bip sonore standard** |
| `Beep(fréquence, durée)` | Émet un son à une **fréquence donnée** (Hz) pendant une **durée donnée** (ms) |
| `BufferWidth` | Largeur du **buffer** (zone de stockage) en colonnes |
| `BufferHeight` | Hauteur du **buffer** en lignes (nombre de lignes conservées pour le scroll) |

> ⚠️ **Note importante** : `Console.Beep(frequency, duration)` ne fonctionne que sur **Windows**. Sur macOS et Linux, seule la version sans paramètres `Console.Beep()` fonctionne (elle émet le son du terminal).

---

### 🔤 Syntaxe

```csharp
// Bip simple (son par défaut du système)
Console.Beep();

// Bip personnalisé : fréquence en Hertz (37-32767), durée en millisecondes
Console.Beep(440, 500); // Note "La" (440 Hz) pendant 500 ms

// Taille du buffer
int largeurBuffer = Console.BufferWidth;
int hauteurBuffer = Console.BufferHeight;

// Modifier la taille du buffer (Windows uniquement)
Console.BufferHeight = 300; // Le buffer peut conserver 300 lignes de texte
```

---

### 💡 Exemple Simple — Signaux sonores d'alerte

```csharp
using System;
using System.Threading; // Pour Thread.Sleep()

class Program
{
    static void Main()
    {
        Console.Title = "🔊 Démo Sonore";

        // --- Bip simple ---
        Console.WriteLine("🔔 Bip standard du système :");
        Console.Beep(); // Émet le son par défaut
        Thread.Sleep(500);

        // --- Sons personnalisés ---
        Console.WriteLine("🎵 Note basse (200 Hz, 300 ms) :");
        Console.Beep(200, 300);

        Console.WriteLine("🎵 Note moyenne (600 Hz, 300 ms) :");
        Console.Beep(600, 300);

        Console.WriteLine("🎵 Note haute (1200 Hz, 300 ms) :");
        Console.Beep(1200, 300);

        // --- Son d'erreur (3 bips rapides aigus) ---
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ ERREUR ! Bips d'alerte :");
        Console.ResetColor();

        for (int i = 0; i < 3; i++)
        {
            Console.Beep(800, 150); // Bip court et aigu
            Thread.Sleep(100);       // Petite pause entre les bips
        }

        // --- Affichage des infos du buffer ---
        Console.WriteLine();
        Console.WriteLine($"📐 Taille du buffer : {Console.BufferWidth} x {Console.BufferHeight}");
        Console.WriteLine($"📐 Taille de la fenêtre : {Console.WindowWidth} x {Console.WindowHeight}");

        Console.ReadKey();
    }
}
```

---

### 🚀 Exemple Avancé — Mélodie 8-bit et gestion du buffer

```csharp
using System;
using System.Threading;

class Program
{
    // Notes de musique en Hertz (octave 4)
    // Tu peux t'en servir comme référence pour créer des mélodies !
    const int Do  = 262;  // C4
    const int Re  = 294;  // D4
    const int Mi  = 330;  // E4
    const int Fa  = 349;  // F4
    const int Sol = 392;  // G4
    const int La  = 440;  // A4
    const int Si  = 494;  // B4
    const int Do5 = 523;  // C5

    // Durées en millisecondes
    const int Noire   = 400;  // Note standard
    const int Croche  = 200;  // Note rapide
    const int Blanche = 800;  // Note longue
    const int Pause   = 100;  // Silence entre les notes

    static void JouerNote(int frequence, int duree, string nomNote)
    {
        // Affichage visuel de la note jouée
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"  ♪ {nomNote,-4}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($" ({frequence} Hz, {duree} ms) ");

        // Barre visuelle proportionnelle à la durée
        Console.ForegroundColor = ConsoleColor.Yellow;
        int longueurBarre = duree / 50;
        Console.WriteLine(new string('█', longueurBarre));
        Console.ResetColor();

        // On joue la note
        Console.Beep(frequence, duree);
        Thread.Sleep(Pause); // Petite pause entre les notes
    }

    static void Main()
    {
        Console.Title = "🎵 Lecteur Musical 8-bit";
        Console.CursorVisible = false;
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║    🎵 Mélodie : Gamme de Do 🎵    ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.ResetColor();

        Console.WriteLine();

        // Jouer la gamme de Do majeur
        JouerNote(Do,  Noire,   "Do ");
        JouerNote(Re,  Noire,   "Ré ");
        JouerNote(Mi,  Noire,   "Mi ");
        JouerNote(Fa,  Noire,   "Fa ");
        JouerNote(Sol, Noire,   "Sol");
        JouerNote(La,  Noire,   "La ");
        JouerNote(Si,  Noire,   "Si ");
        JouerNote(Do5, Blanche, "Do!");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ✅ Mélodie terminée !");
        Console.ResetColor();

        // --- Démonstration du Buffer ---
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║   📐 Informations sur le Buffer   ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.ResetColor();

        Console.WriteLine($"  Buffer  : {Console.BufferWidth} colonnes × {Console.BufferHeight} lignes");
        Console.WriteLine($"  Fenêtre : {Console.WindowWidth} colonnes × {Console.WindowHeight} lignes");
        Console.WriteLine();

        // Le buffer est plus grand que la fenêtre = on peut scroller
        if (Console.BufferHeight > Console.WindowHeight)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  💡 Le buffer est plus grand que la fenêtre :");
            Console.WriteLine("     Tu peux scroller vers le haut pour revoir le texte précédent !");
            Console.ResetColor();
        }

        Console.WriteLine();
        Console.WriteLine("  Appuie sur une touche pour quitter...");
        Console.CursorVisible = true;
        Console.ReadKey(true);
    }
}
```

---

### ⚠️ Erreurs Courantes

1. **Fréquence hors limites**
   ```csharp
   // ❌ ERREUR : la fréquence doit être entre 37 et 32767 Hz
   Console.Beep(10, 500);    // ArgumentOutOfRangeException !
   Console.Beep(50000, 500); // ArgumentOutOfRangeException !

   // ✅ CORRECT : rester dans l'intervalle [37, 32767]
   Console.Beep(440, 500);   // OK : 440 Hz est dans l'intervalle
   ```

2. **Utiliser `Beep(freq, dur)` sur Linux/macOS**
   ```csharp
   // ⚠️ La surcharge Beep(frequency, duration) est spécifique à Windows !
   // Sur Linux/macOS, elle lève une PlatformNotSupportedException
   // Utilise un try/catch si ton programme doit être multiplateforme
   try
   {
       Console.Beep(440, 500);
   }
   catch (PlatformNotSupportedException)
   {
       Console.Beep(); // Version simple qui fonctionne partout
   }
   ```

3. **Modifier `BufferWidth` à une valeur inférieure à `WindowWidth`**
   ```csharp
   // ❌ Le buffer ne peut pas être plus petit que la fenêtre !
   Console.BufferWidth = 10; // ArgumentOutOfRangeException si WindowWidth > 10

   // ✅ Le buffer doit être >= à la taille de la fenêtre
   Console.BufferWidth = Math.Max(Console.WindowWidth, 120);
   ```

---

### ✅ Bonnes Pratiques

- **Utilise `Beep()` avec modération** : les sons répétitifs peuvent vite devenir agaçants pour l'utilisateur.
- **Prévois une option "mode silencieux"** dans tes programmes qui utilisent des sons.
- **Gère la compatibilité multiplateforme** : entoure `Beep(freq, dur)` d'un `try/catch` si ton programme peut tourner sur Linux/macOS.
- **Ne modifie pas `BufferWidth`** sauf si tu as une raison précise : la valeur par défaut du système convient dans 99% des cas.
- **Utilise le buffer à ton avantage** : un `BufferHeight` élevé permet à l'utilisateur de remonter dans l'historique de la console.

---

## 5. 📋 Récapitulatif Général

### Tableau de synthèse de la classe `Console`

| Catégorie | Membre | Type | Description |
| :--- | :--- | :--- | :--- |
| **Sortie** | `WriteLine()` | Méthode | Affiche du texte + retour à la ligne |
| **Sortie** | `Write()` | Méthode | Affiche du texte sans retour à la ligne |
| **Entrée** | `ReadLine()` | Méthode | Lit une ligne complète → `string` |
| **Entrée** | `Read()` | Méthode | Lit un caractère → `int` |
| **Entrée** | `ReadKey()` | Méthode | Attend une touche → `ConsoleKeyInfo` |
| **Couleurs** | `ForegroundColor` | Propriété | Couleur du texte |
| **Couleurs** | `BackgroundColor` | Propriété | Couleur de l'arrière-plan |
| **Couleurs** | `ResetColor()` | Méthode | Réinitialise les couleurs |
| **Fenêtre** | `Clear()` | Méthode | Efface la console |
| **Fenêtre** | `Title` | Propriété | Titre de la fenêtre |
| **Curseur** | `SetCursorPosition()` | Méthode | Déplace le curseur |
| **Curseur** | `CursorLeft` / `CursorTop` | Propriétés | Position du curseur |
| **Curseur** | `CursorVisible` | Propriété | Visibilité du curseur |
| **Fenêtre** | `WindowWidth` / `WindowHeight` | Propriétés | Taille de la fenêtre |
| **Son** | `Beep()` | Méthode | Émet un bip sonore |
| **Son** | `Beep(freq, dur)` | Méthode | Son personnalisé (Windows) |
| **Buffer** | `BufferWidth` / `BufferHeight` | Propriétés | Taille du buffer de texte |

- Note :  Le buffer est la zone de texte qui est affichée dans la console. La fenêtre est la zone de texte qui est visible par l'utilisateur. Le buffer est plus grand que la fenêtre, ce qui permet à l'utilisateur de remonter dans l'historique de la console.

### 🧠 Ce qu'il faut retenir

1. **`WriteLine` / `Write`** sont tes outils de base pour afficher du texte.
2. **`ReadLine`** est la méthode standard pour lire une saisie utilisateur — pense toujours à **valider** ce que l'utilisateur entre.
3. **`ReadKey`** est parfait pour les **menus interactifs** et les jeux (surtout avec `true` pour masquer la touche).
4. **`ForegroundColor` / `BackgroundColor`** permettent de rendre ta console **visuelle** — n'oublie pas `ResetColor()` !
5. **`SetCursorPosition`** transforme ta console en **canevas** — tu peux dessiner n'importe où.
6. **`Beep`** ajoute du **feedback sonore** — utile pour les alertes et les jeux.

