# 001 — Les Bases : C# et SQL

> Socle théorique à maîtriser avant de commencer les projets pratiques (à partir du projet `002`).

---

## Partie 1 — C# : Le Langage

### 1. Environnement et premier programme
- Installation de Visual Studio / VS Code
- Qu'est-ce que C#, .NET et le CLR
- Structure d'un programme (`namespace`, `class`, `Main`)
- Compilation et exécution

### 2. Variables et types de données
- Déclaration et affectation
- Types valeur : `int`, `long`, `double`, `decimal`, `bool`, `char`
- Type référence : `string`
- Types date et heure : `DateTime`, `DateOnly`, `TimeSpan`
- Génération de nombres aléatoires (`Random`)
- Inférence de type (`var`)
- Constantes (`const`) et `readonly`
- Conversions et casting (`(int)`, `Convert.ToInt32`, `Parse`, `TryParse`)

### 3. Opérateurs
- Arithmétiques (`+`, `-`, `*`, `/`, `%`)
- D'affectation (`=`, `+=`, `-=`, `*=`, `/=`)
- D'incrémentation (`++`, `--`)
- De comparaison (`==`, `!=`, `<`, `>`, `<=`, `>=`)
- Logiques (`&&`, `||`, `!`)
- Priorité des opérateurs

### 4. Structures conditionnelles
- `if`, `else if`, `else`
- Opérateur ternaire (`? :`)
- `switch` / `case` classique
- `switch` expressions (C# moderne)

### 5. Boucles
- `for`
- `foreach`
- `while`
- `do...while`
- `break` et `continue`

### 6. Tableaux et collections de base
- Tableaux (`int[]`, `string[]`)
- `List<T>` : ajout, suppression, accès, parcours
- `Dictionary<TKey, TValue>` : clé/valeur, ajout, recherche
- `enum` : définition et utilisation
- Fonctions de manipulation des structures de données

### 7. Fonctions et méthodes
- Déclaration, paramètres et valeur de retour
- Méthodes `void` vs méthodes avec retour
- Paramètres optionnels et valeurs par défaut
- Passage par valeur vs par référence (`ref`, `out`)
- Surcharge de fonction / méthodes
- Méthodes statiques vs d'instance
- `params` (nombre variable d'arguments)

### 8. Manipulation des types de base (Chaînes et Nombres)
- Manipulation de chaînes : `Length`, `ToUpper`, `Substring`, `Split`, `Join`, Interpolation
- Manipulation de Int et Mathématiques : `Math.Abs`, `Math.Round`, `Min`, `Max`, `Parse`

### 9. Gestion des erreurs
- `try` / `catch` / `finally`
- Types d'exceptions courants (`FormatException`, `NullReferenceException`, `IndexOutOfRangeException`)
- `throw` et propagation
- Création d'exceptions personnalisées

### 10. Programmation Orientée Objet — Bases
- Classes et objets
- `struct` vs `class` (types valeur vs types référence)
- Constructeurs
- Propriétés (`get`, `set`, `init`)
- Encapsulation et modificateurs d'accès (`public`, `private`, `protected`, `internal`)
- Le mot-clé `this`
- Méthodes d'instance

### 11. POO — Héritage et polymorphisme
- Héritage (`: BaseClass`)
- `virtual`, `override`, `base`
- Classes `abstract` et méthodes abstraites
- `sealed` (empêcher l'héritage)
- Polymorphisme et transtypage (`is`, `as`)

### 12. POO — Interfaces
- Déclaration et implémentation d'interfaces
- Implémentation multiple
- `IComparable`, `IEquatable` (exemples concrets)
- Quand utiliser une interface vs une classe abstraite

### 13. Génériques
- Méthodes génériques (`<T>`)
- Classes génériques
- Contraintes (`where T : class`, `where T : new()`, `where T : IComparable`)

### 14. Collections avancées
- `Stack<T>` (pile)
- `Queue<T>` (file)
- `HashSet<T>` (ensemble sans doublons)
- `SortedList<TKey, TValue>` (rappel sur `IComparer<T>`)
- Choisir la bonne collection selon le besoin

### 15. Delegates, lambdas, événements et méthodes d'extension
- `delegate` : déclaration et invocation
- `Action` et `Func` (delegates prédéfinis)
- Expressions lambda (`=>`)
- Événements (`event`, `EventHandler`)
- Méthodes d'extension (`static` + `this` en premier paramètre)

### 16. LINQ
- `IEnumerable<T>` et exécution différée (Deferred Execution)
- Syntaxe méthode (`Where`, `Select`, `OrderBy`, `GroupBy`)
- Syntaxe requête (`from ... where ... select`)
- Agrégations (`Sum`, `Average`, `Count`, `Min`, `Max`)
- `First`, `FirstOrDefault`, `Any`, `All`
- Chaînage de requêtes

### 17. Programmation asynchrone
- Pourquoi l'asynchronisme (ne pas bloquer le thread principal)
- `async` et `await`
- `Task` et `Task<T>`
- `Task.WhenAll` (parallélisme)

### 18. Types modernes et Pattern Matching
- `record` (types immuables)
- `init` et expression `with`
- `Nullable reference types` (`string?`)
- Pattern matching avancé (property / tuple patterns)
- `using` declaration (`using var ...;` sans accolades)

### 19. Entrées/Sorties, Fichiers et Sérialisation
- Manipulation de fichiers (`System.IO`, `File.ReadAllText`, `StreamReader` / `StreamWriter`)
- Sérialisation JSON (`System.Text.Json`)
- `Stopwatch` (mesure de performance)

---

## Partie 2 — SQL : Les Bases de Données

### 20. Introduction aux bases de données relationnelles
- Qu'est-ce qu'une base de données relationnelle
- Tables, lignes, colonnes
- Clés primaires et clés étrangères
- Relations : 1-1, 1-N, N-N (tables de liaison)
- Installation et utilisation de SQL Server / SSMS

### 21. Création de tables et types de données
- `CREATE TABLE`
- Types de données SQL (`INT`, `VARCHAR`, `NVARCHAR`, `DATETIME`, `DECIMAL`, `BIT`)
- Contraintes : `PRIMARY KEY`, `FOREIGN KEY`, `NOT NULL`, `UNIQUE`, `CHECK`, `DEFAULT`
- `IDENTITY` (auto-incrémentation)
- `ALTER TABLE` (modifier une table existante)
- `DROP TABLE`

### 22. Insertion de données
- `INSERT INTO ... VALUES`
- Insertion de plusieurs lignes
- Insertion depuis une autre table (`INSERT INTO ... SELECT`)
- Valeurs par défaut et colonnes nullable

### 23. Requêtes de lecture
- `SELECT` : colonnes, alias (`AS`), `DISTINCT`
- `WHERE` : filtres simples et combinés
- `ORDER BY` : tri ascendant / descendant
- `LIKE` : recherche avec motifs (`%`, `_`)
- `IN`, `BETWEEN`, `IS NULL`
- `TOP` / `OFFSET ... FETCH`

### 24. Mise à jour et suppression
- `UPDATE ... SET ... WHERE`
- `DELETE FROM ... WHERE`
- `TRUNCATE TABLE`
- Importance du `WHERE` (éviter les suppressions massives)

### 25. Jointures
- `INNER JOIN` (intersection)
- `LEFT JOIN` (tout à gauche + correspondances)
- `RIGHT JOIN`
- `CROSS JOIN` (produit cartésien)
- Jointures sur plusieurs tables
- Auto-jointure (table jointe à elle-même)

### 26. Agrégations et groupements
- Fonctions d'agrégation : `COUNT`, `SUM`, `AVG`, `MIN`, `MAX`
- `GROUP BY`
- `HAVING` (filtre après agrégation)
- Sous-requêtes (dans `WHERE`, dans `FROM`)

### 27. Procédures stockées
- `CREATE PROCEDURE`
- Paramètres d'entrée et de sortie
- `EXEC` / `EXECUTE`
- Cas d'usage (validation de commande, calculs métier)

### 28. Transactions
- `BEGIN TRANSACTION`
- `COMMIT` et `ROLLBACK`
- Atomicité : tout réussit ou rien ne s'applique
- `TRY...CATCH` en SQL
- Niveaux d'isolation (introduction)

### 29. Vues et index
- `CREATE VIEW` : requêtes pré-enregistrées
- Cas d'usage des vues (simplifier les requêtes complexes)
- `CREATE INDEX` : accélérer les recherches
- Index clustered vs non-clustered

---
