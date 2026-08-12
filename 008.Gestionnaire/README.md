# Projet 008 : Gestionnaire d'Employés (POO Avancée)

Ce projet est une application console en C# simulant un système de calcul des salaires. Son but n'est pas tant de faire un calcul complexe, mais de mettre en pratique l'architecture logicielle via les concepts avancés de la **Programmation Orientée Objet (POO)** et les **Principes SOLID**.

---

## Fonctionnalités

1. **Hiérarchie d'employés** : Création de différents types de contrats (Temps Plein, Indépendant/Contractuel, Stagiaire).
2. **Calcul de salaire polymorphique** : Le salaire de chaque employé est calculé selon une règle propre à son statut, bien qu'appelé via une même méthode.
3. **Génération de fiches de paie (immuables)** : Création d'objets en lecture seule représentant la paie finale.
4. **Gestion propre des ressources** : Simulation d'un processus lourd (comme l'écriture d'archives sur le disque) qui nécessite la libération explicite de la mémoire.

---

## Concepts clés abordés

- **Héritage** : Création d'une classe de base `Employe` et héritage via `:` pour partager les propriétés communes (Nom, Matricule).
- **Interfaces (`interface`)** : Définition de contrats comme `ICalculable` (pour calculer le salaire) permettant de découpler le code.
- **Polymorphisme** : Utilisation de `virtual` et `override` pour que la méthode `CalculerSalaire()` réagisse différemment selon le type réel de l'employé.
- **Principes SOLID** : S'assurer que le code est modulaire. Par exemple, séparer la logique d'un Employé (données) de la logique du Générateur de fiches de paie (Single Responsibility Principle).
- **Records (`record`)** : Structure de données très pratique apparue en C# 9 pour définir des objets immuables (dont la valeur ne peut plus changer après création), idéal pour une Fiche de Paie.
- **Gestion mémoire (`IDisposable` & `using`)** : Nettoyer proprement les ressources non gérées pour éviter les fuites de mémoire.

> 💡 **Note éducative** : L'ensemble du code source (Program, Interfaces, Models, Services) est **abondamment commenté** pour expliquer en détail chaque concept. Il est vivement recommandé d'ouvrir chaque fichier `.cs` et de lire les blocs de commentaires pour bien comprendre comment la magie du polymorphisme et des records s'opère !

---

## Architecture suggérée

```text
008.Gestionnaire/
│
├── 008.Gestionnaire.csproj
├── Program.cs                        <-- Point d'entrée (instanciation et tests de polymorphisme)
│
├── Interfaces/
│   └── ISalaire.cs                   <-- Définit la méthode CalculerSalaire()
│
├── Models/
│   ├── Employe.cs                    <-- Classe de base (abstraite de préférence)
│   ├── EmployeTempsPlein.cs          <-- Héritage, salaire fixe + primes
│   ├── Contractuel.cs                <-- Héritage, taux horaire * heures
│   └── FicheDePaie.cs                <-- `record` immuable stockant le résultat final
│
└── Services/
    └── ArchiveurPaie.cs              <-- Implémente `IDisposable`, écrit les fiches dans un fichier
```

---

## Instructions (Futures)

Pour compiler et lancer le projet (une fois initialisé avec `dotnet new console`) :

```bash
cd 008.Gestionnaire
dotnet run
```
