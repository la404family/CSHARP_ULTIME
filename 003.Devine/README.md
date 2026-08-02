# Projet 003 : Devine le nombre

## Objectif du projet
Créer un mini-jeu interactif en console où l'ordinateur choisit un nombre aléatoire entre 1 et 100, et l'utilisateur doit le deviner en recevant des indices ("c'est plus", "c'est moins").

## Concepts clés abordés
- **`Random`** : Pour générer le nombre secret.
- **Boucles `while` ou `do...while`** : Pour répéter la demande de saisie tant que le joueur ne trouve pas.
- **Conditions (`if`, `else if`, `else`)** : Pour aiguiller le joueur selon sa réponse.
- **Validation des entrées (`int.TryParse`)** : Pour s'assurer que le joueur tape bien un nombre et éviter que le programme plante s'il tape des lettres.

## Architecture Modulaire
Le code a été séparé en 3 responsabilités :
1. **`Program.cs`** : L'interface utilisateur, s'occupe de faire la boucle et l'affichage.
2. **`Services/GameEngine.cs`** : La logique métier (stocke le nombre, compte les essais, vérifie si c'est gagné).
3. **`Utils/ConsoleInput.cs`** : Boîte à outils technique pour gérer les saisies sécurisées de l'utilisateur.

## Instructions d'exécution

Pour lancer le projet, ouvrez un terminal dans ce dossier `003.Devine` et exécutez simplement la commande suivante :
```bash
dotnet run
```
