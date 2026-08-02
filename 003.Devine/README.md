# Projet 003 : Devine le nombre

Ce projet est un mini-jeu interactif en console écrit en C#. L'ordinateur choisit un nombre aléatoire entre 1 et 100, et le joueur doit le deviner en recevant des indices colorés ("C'est plus !", "C'est moins !"). L'objectif principal de cette implémentation est d'approfondir l'**architecture modulaire** introduite dans le projet 002, en y ajoutant les **enums** et la **validation des entrées avec plage**.

## Architecture du Projet

Le code source est découpé en plusieurs fichiers et dossiers (espaces de noms) afin d'isoler chaque responsabilité. Cette structure est identique à celle du projet 002 (Calculatrice).

```text
003.Devine/
│
├── Program.cs
│
├── Services/
│   └── GameEngine.cs
│
└── Utils/
    ├── ConsoleInput.cs
    ├── ConsoleSound.cs
    └── ConsoleTheme.cs
```

---

## Détail des fichiers

### `Program.cs` (Point d'entrée)
C'est le chef d'orchestre de l'application (le *Main*).
Il ne contient **aucune logique de jeu complexe** ni de code lourd de validation.
Son rôle unique est de coordonner les services au sein d'une double boucle : la boucle principale (rejouer) et la boucle de devinette (un essai par itération). Il appelle les utilitaires pour récupérer les saisies, transmet ces saisies au moteur de jeu, puis réutilise les utilitaires pour formater et afficher le résultat.

### `Services/GameEngine.cs` (Logique Métier)
Ce composant est le "cerveau" pur du jeu.
- **Utilité :** Isoler la logique de jeu. Ce fichier ne contient pas une seule ligne faisant appel à la `Console`. Si demain l'interface devient un site Web, ce fichier restera exactement le même.
- **Particularités :**
  - Définit un **`enum GuessResult`** (`TooLow`, `TooHigh`, `Correct`) au lieu de chaînes de caractères. Les enums sont vérifiés à la compilation, éliminant le risque de fautes de frappe silencieuses.
  - Utilise une *switch expression* (syntaxe moderne de C# 8+) pour retourner le résultat de manière concise, identique au pattern utilisé dans `CalculatorEngine.cs` du projet 002.
  - Utilise `Random.Shared` (API moderne .NET 6+), une instance statique thread-safe plus optimisée que `new Random()`.

### `Utils/ConsoleInput.cs` (Gestion des Entrées Utilisateur)
Ce composant s'assure que le moteur de jeu reçoit toujours des données propres.
- **Utilité :** Filtrer et sécuriser toutes les frappes au clavier.
- **Particularités :**
  - Utilise le même pattern `while(true)` + `return` que dans le projet 002 : la boucle refuse de rendre la main tant que la saisie n'est pas valide.
  - Triple validation : non-vide, entier valide (`int.TryParse`), et dans la plage 1–100.
  - Protège le programme des plantages si le flux d'entrée est coupé (ex: `Ctrl+Z` / `EOF`) en quittant proprement via `Environment.Exit(0)`.

### `Utils/ConsoleTheme.cs` (Gestion Visuelle)
Un service dédié à l'esthétique du terminal.
- **Utilité :** Offrir une identité visuelle au programme (thème Cyan sur fond Noir) et afficher les messages avec des couleurs adaptées au contexte.
- **Particularités :** Propose des méthodes spécialisées (`WriteHint`, `WriteSuccess`, `WriteError`) qui changent temporairement la couleur puis restaurent le thème, exactement comme `WriteError` dans le projet 002. Permet au joueur de conserver l'historique de ses essais à l'écran.

### `Utils/ConsoleSound.cs` (Retour Auditif — UX)
Gère le retour sonore de l'application en exploitant `Console.Beep()`.
- **Utilité :** Confirmer les actions du joueur par l'ouïe, offrant une "User Experience" (UX) réactive et intuitive.
- **Particularités :** Joue différentes fréquences selon le contexte : un bip bref pour une saisie acceptée, un bip neutre pour les indices, un "buzzer" grave pour les erreurs, et un arpège montant (Do-Mi-Sol-Do) pour célébrer la victoire. Contient une vérification de l'OS (`OperatingSystem.IsWindows()`) pour la compatibilité multi-plateforme.

---

## Concepts clés abordés
- **`Random`** (`Random.Shared`) : Pour générer le nombre secret de manière thread-safe.
- **`enum`** : Pour représenter les états du jeu de manière type-safe, vérifiée à la compilation.
- **Boucles `while`** : Double boucle (rejouer + deviner) avec sentinelles booléennes.
- **Conditions (`switch` sur enum)** : Aiguillage sécurisé du joueur selon sa réponse.
- **Validation des entrées (`int.TryParse`)** : Programmation défensive pour éviter les plantages.
- **`switch expression` (C# 8+)** : Syntaxe moderne et concise dans `GameEngine`.

---

## Instructions d'exécution

Pour lancer le projet, ouvrez un terminal dans ce dossier `003.Devine` et exécutez simplement la commande suivante :
```bash
dotnet run
```
