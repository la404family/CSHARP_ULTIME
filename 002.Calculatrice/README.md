# Projet 002 : Calculatrice Modulaire

Ce projet est une calculatrice console robuste écrite en C#. L'objectif principal de cette implémentation est de démontrer l'importance de la **séparation des préoccupations (Separation of Concerns)**, même pour une application très simple. 

## Architecture du Projet

Le code source a été découpé en plusieurs fichiers et dossiers (espaces de noms) afin d'isoler chaque responsabilité. Cette approche professionnelle facilite la maintenance, l'ajout de fonctionnalités, et permettrait d'écrire des tests unitaires très facilement.

```text
002.Calculatrice/
│
├── Program.cs
│
├── Services/
│   └── CalculatorEngine.cs
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
Il ne contient **aucune logique mathématique complexe** ni de code lourd de validation.
Son rôle unique est de coordonner les services au sein d'une boucle principale infinie (`while (true)`). Il appelle les utilitaires pour récupérer les saisies, transmet ces saisies au moteur de calcul, puis réutilise les utilitaires pour formater et afficher le résultat, avant de demander à l'utilisateur s'il souhaite continuer ou quitter l'application.

### `Services/CalculatorEngine.cs` (Logique Métier)
Ce composant est le "cerveau" pur de l'application.
- **Utilité :** Isoler le calcul mathématique. Ce fichier ne contient pas une seule ligne faisant appel à la `Console`. Si demain l'interface devient un site Web, ce fichier restera exactement le même.
- **Particularités :** 
  - Utilise une *switch expression* (syntaxe moderne de C# 8+) pour retourner le résultat de manière concise. 
  - Protège l'application de la division par zéro en interceptant le dénominateur `0` et en renvoyant `double.NaN` (Not a Number).

### `Utils/ConsoleInput.cs` (Gestion des Entrées Utilisateur)
Ce composant s'assure que le moteur de calcul reçoit toujours des données propres.
- **Utilité :** Filtrer et sécuriser toutes les frappes au clavier.
- **Particularités :**
  - Enferme les demandes dans des boucles `while(true)` qui refusent de rendre la main tant que la saisie (nombre ou opérateur) n'est pas strictement valide.
  - Protège le programme des plantages silencieux si le flux d'entrée est coupé (ex: `Ctrl+Z` / `EOF`) en quittant proprement via `Environment.Exit(0)`.
  - Accepte indifféremment la virgule `,` ou le point `.` grâce à une manipulation de chaînes et à l'usage de `CultureInfo.InvariantCulture`.

### `Utils/ConsoleTheme.cs` (Gestion Visuelle)
Un service dédié à l'esthétique du terminal.
- **Utilité :** Offrir une identité visuelle au programme (Thème Jaune sur fond Noir) et attirer l'attention de l'utilisateur sur les erreurs.
- **Particularités :** La fonction `WriteError()` encapsule la bascule vers le rouge pour l'affichage de l'erreur, puis restaure instantanément le thème d'origine sans avoir besoin de nettoyer l'écran, ce qui permet à l'utilisateur de conserver l'historique de ses frappes au-dessus.

### `Utils/ConsoleSound.cs` (Retour Auditif - UX)
Gère le retour sonore de l'application en exploitant `Console.Beep()`.
- **Utilité :** Confirmer les actions de l'utilisateur par l'ouïe, offrant ainsi une "User Experience" (UX) atypique et réactive.
- **Particularités :** Joue différentes fréquences selon le contexte (un son aigu et très bref pour une entrée acceptée, un "buzzer" grave pour une erreur, et une courte mélodie d'arpège pour célébrer l'affichage du résultat). Contient une vérification de l'OS (`OperatingSystem.IsWindows()`) pour s'assurer que l'appel natif du processeur sonore réagisse bien comme attendu selon la plateforme.

---

## Instructions d'exécution

Pour lancer le projet, ouvrez un terminal dans ce dossier `002.Calculatrice` et exécutez simplement la commande suivante :
```bash
dotnet run
```
