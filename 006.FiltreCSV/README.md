# Projet 006 : Filtreur de données CSV

Ce projet est une application console développée en C#. Elle permet de lire un fichier CSV, de filtrer ses lignes en fonction d'un critère donné (par exemple, un mot clé), d'afficher un aperçu des résultats dans la console, puis de sauvegarder le résultat dans un nouveau fichier. Ce projet met en pratique la manipulation de fichiers (I/O) et l'utilisation de LINQ.

---

## Architecture du Projet

Le projet respecte une architecture simple axée sur le traitement de données :

```text
006.FiltreCSV/
│
├── 006.FiltreCSV.csproj
├── Program.cs                      <-- Interface console & boucle principale
│
├── Data/
│   ├── input.csv                   <-- Fichier de données d'entrée 
│   └── output.csv                  <-- Fichier généré avec les résultats
│
├── Services/
│   └── CsvFilterService.cs         <-- Logique de lecture, filtrage et écriture (File.ReadAllLines, string.Split)
│
└── Utils/
    └── ConsoleTheme.cs             <-- Thème et encodage UTF-8
```

---

## Fonctionnalités

1. **Chargement du CSV** : Lecture du fichier source via les classes d'entrées/sorties (ex: `File.ReadAllLines` ou `File.ReadAllText`).
2. **Filtrage des données** : Application de conditions de filtrage à l'aide de méthodes LINQ (`Where`) et des méthodes de manipulation de chaîne (`string.Split`).
3. **Affichage des résultats** : Aperçu direct des lignes filtrées dans la console pour une meilleure expérience utilisateur.
4. **Sauvegarde des résultats** : Écriture des données filtrées dans un nouveau fichier CSV cible (ex: `File.WriteAllLines` ou `File.WriteAllText`).

---

## Concepts clés abordés

- **I/O Fichiers** : `System.IO.File`, `ReadAllText`, `ReadAllLines`, `WriteAllText`.
- **Manipulation de chaînes** : Découpage d'une ligne CSV avec `string.Split`.
- **LINQ** : Filtrage de collections avec `.Where()`.
- **Gestion des Exceptions** : Traitement des erreurs potentielles lors de la lecture/écriture sur le disque (ex: fichier introuvable, droits d'accès).

---

## Instructions d'exécution

Pour compiler et lancer le projet :

```bash
cd 006.FiltreCSV
dotnet run
```
