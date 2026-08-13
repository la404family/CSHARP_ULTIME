# Projet 009 - Structures de données & Algorithmes

**Description :** Implémenter depuis zéro des structures de données fondamentales (Stack, Queue, Dictionary, HashSet) et des algorithmes classiques (tri fusion, recherche dichotomique) en C#.

**Concepts abordés :** 
- Structures de données (Piles, Files, Dictionnaires, Ensembles)
- Algorithmes de tri (`Merge Sort`)
- Algorithmes de recherche (`Binary Search`)
- Mesure de performances et profilage avec `System.Diagnostics.Stopwatch`
- Généricité (utilisation de `<T>`)

## 🏗️ Architecture du Projet

Le projet suit une organisation claire pour séparer les structures de données, les algorithmes et les tests de performance.

```text
009.Structures/
│
├── Program.cs                  # Point d'entrée principal pour tester et lancer les mesures
├── 009.Structures.csproj       # Fichier de projet C#
│
├── DataStructures/             # Implémentations "faites maison"
│   ├── CustomStack.cs          # Implémentation d'une pile (LIFO - Last In, First Out)
│   ├── CustomQueue.cs          # Implémentation d'une file (FIFO - First In, First Out)
│   ├── CustomDictionary.cs     # Implémentation d'un dictionnaire basé sur table de hachage
│   └── CustomHashSet.cs        # Implémentation d'un ensemble (valeurs uniques via hachage)
│
├── Algorithms/                 # Algorithmes de base
│   ├── Sorting/
│   │   └── MergeSort.cs        # Implémentation du tri fusion (O(n log n))
│   └── Searching/
│       └── BinarySearch.cs     # Implémentation de la recherche dichotomique (O(log n))
│
└── Utils/                      # Utilitaires divers
    └── PerformanceTester.cs    # Utilise Stopwatch pour comparer avec les collections natives
```

## 🚀 Objectifs

1. **Comprendre les rouages** : Savoir comment fonctionnent les collections natives sous le capot.
2. **Algorithmique** : Coder le tri fusion et la recherche binaire par soi-même.
3. **Benchmarking** : Mesurer le temps d'exécution (avec `Stopwatch`) des implémentations personnalisées par rapport aux collections C# natives sur de grands volumes de données.
