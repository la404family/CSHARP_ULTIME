# Projet 005 : Gestion d'inventaire

Ce projet est une application console interactive développée en C#. Elle permet de gérer un inventaire d'articles (ajouter, afficher, rechercher par ID/nom, supprimer et calculer la valeur totale du stock) en exploitant les concepts de la **Programmation Orientée Objet (POO)**, des **classes (`Article`)**, des **constructeurs**, de la collection **`List<T>`** et des **exceptions métier personnalisées**.

---

## Architecture du Projet

Le projet respecte une architecture modulaire en couches isolées et réutilisables :

```text
005.Gestion/
│
├── 005.Gestion.csproj
├── Program.cs                      <-- Interface console & boucle principale
│
├── Models/
│   └── Article.cs                  <-- Modèle de données d'un article
│
├── Services/
│   └── InventoryEngine.cs          <-- Moteur métier & gestion du stock (List<Article>)
│
├── Exceptions/
│   ├── EmptyInventoryException.cs  <-- Exception si l'inventaire est vide
│   └── ArticleNotFoundException.cs <-- Exception si un article n'est pas trouvé
│
└── Utils/
    ├── ConsoleInput.cs             <-- Saisie et validations sécurisées
    ├── ConsoleSound.cs             <-- Retours audios UX (Windows)
    └── ConsoleTheme.cs             <-- Thème et encodage UTF-8
```

---

## Fonctionnalités

1. **Ajouter un article** : Saisie guidée du Nom, du Prix unitaire (€) et de la Quantité avec attribution automatique d'un ID unique séquentiel.
2. **Afficher l'inventaire** : Présentation sous forme de tableau formaté avec calcul automatique des sous-totaux et de la valeur globale du stock.
3. **Rechercher un article** :
   - Recherche exacte par ID unique.
   - Recherche partielle par Nom (mot-clé insensible à la casse via LINQ).
4. **Supprimer un article** : Suppression par ID avec confirmation et mise à jour dynamique du stock.
5. **Vider l'inventaire** : Réinitialisation complète des données.

---

## Concepts clés abordés

- **`class` et Constructeur** : Définition de l'objet `Article` avec clauses de garde dans le constructeur.
- **Propriétés calculées (`=>`)** : `ValeurTotale => Prix * Quantite`.
- **Collection `List<Article>`** : Stockage dynamique en mémoire et encapsulation via `IReadOnlyList<Article>`.
- **Recherches LINQ** : `.FirstOrDefault()`, `.Where()`, `.Sum()`.
- **Exceptions métier personnalisées** : `EmptyInventoryException` et `ArticleNotFoundException`.

---

## Instructions d'exécution

Pour compiler et lancer le projet :

```bash
cd 005.Gestion
dotnet run
```
