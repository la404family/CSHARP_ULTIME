# Projet 004 : Mini-calculatrice de notes

Ce projet est une application console interactive développée en C#. Elle permet de saisir plusieurs notes scolaires (de 0 à 20), d'afficher la liste des notes saisies et de calculer automatiquement la moyenne générale, la note maximale et la note minimale en exploitant la puissance de **LINQ**, des collections génériques **`List<T>`** et de la **gestion d'exceptions personnalisées (`try/catch`)**.

---

## Architecture du Projet

Le projet adopte la même architecture modulaire propre et séparée par responsabilités que les projets précédents, en y ajoutant le package d'exceptions du domaine :

```text
004.Moyenne/
│
├── 004.Moyenne.csproj
├── Program.cs
│
├── Exceptions/
│   └── EmptyGradeListException.cs
│
├── Services/
│   └── GradeEngine.cs
│
└── Utils/
    ├── ConsoleInput.cs
    ├── ConsoleSound.cs
    └── ConsoleTheme.cs
```

---

## Détail des composants

### `Exceptions/EmptyGradeListException.cs`
- Class d'exception personnalisée héritant de `InvalidOperationException`.
- Levée lorsqu'une opération nécessitant au moins une note (calcul de moyenne, recherche de min/max, affichage, vidage) est exécutée alors que la liste est vide.

### `Services/GradeEngine.cs` (Logique Métier)
- Encapsule une liste dynamique `List<double>` privée.
- Utilise des **clauses de garde (Guard Clauses)** pour vérifier que la liste n'est pas vide avant tout calcul.
- Propose les calculs LINQ :
  - **`CalculateAverage()`** -> `.Average()` (lève `EmptyGradeListException` si vide).
  - **`GetMaxGrade()`** -> `.Max()` (lève `EmptyGradeListException` si vide).
  - **`GetMinGrade()`** -> `.Min()` (lève `EmptyGradeListException` si vide).

### `Program.cs` (Point d'entrée & UI)
- Entoure l'exécution des choix de menu par un bloc **`try-catch`**.
- Intercepte les exceptions métier (`EmptyGradeListException`, `ArgumentOutOfRangeException`) et affiche des messages d'erreur élégants et bienveillants à l'utilisateur sans faire planter le programme.

---

## Concepts clés abordés
- **`List<T>`** : Utilisation d'un tableau dynamique générique.
- **LINQ** (`System.Linq`) : Utilisation des méthodes d'agrégation d'extensions (`Average`, `Max`, `Min`).
- **Gestion des Exceptions** : `try / catch`, création d'une exception personnalisée (`EmptyGradeListException`), et levée explicite (`throw`).
- **Clauses de garde (Guard Clauses)** : Validation du domaine au niveau du moteur avant les calculs.

---

## Instructions d'exécution

Pour lancer le projet, ouvrez un terminal dans ce dossier `004.Moyenne` et exécutez :
```bash
dotnet run
```
