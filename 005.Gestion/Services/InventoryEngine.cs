using Gestion.Exceptions;
using Gestion.Models;

namespace Gestion.Services;

/// <summary>
/// Moteur de gestion de l'inventaire.
/// Encapsule la collection dynamique `List&lt;Article&gt;` et gère l'attribution automatique des identifiants (IDs).
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - `List&lt;Article&gt;` : Collection générique d'objets personnalisés stockée en mémoire.
///   Contrairement à `List&lt;double&gt;` (projet 004), on stocke ici des instances d'une CLASSE.
/// - Encapsulation &amp; IReadOnlyList : Protection de la liste interne contre les modifications externes.
/// - LINQ (`.Sum()`, `.FirstOrDefault()`, `.Where()`, `.ToList()`) : Requêtes intégrées au langage
///   permettant de filtrer, rechercher et agréger directement sur la collection d'objets.
/// - Clauses de garde &amp; Exceptions personnalisées : Validation de l'état de l'inventaire avant chaque opération.
/// - Auto-incrémentation (`_nextId++`) : Génération séquentielle d'identifiants uniques sans base de données.
/// </summary>
public class InventoryEngine
{
    // =========================================================================
    // CHAMPS PRIVÉS (État interne encapsulé)
    // =========================================================================

    // Collection privée stockant les articles de l'inventaire.
    // 'readonly' empêche de réassigner _articles à une autre liste après l'initialisation.
    // Cela n'empêche PAS d'ajouter ou supprimer des éléments dans la liste existante.
    private readonly List<Article> _articles = new();

    // Compteur interne pour la génération automatique d'IDs uniques séquentiels.
    // Chaque appel à AddArticle() consomme et incrémente ce compteur via _nextId++.
    private int _nextId = 1;

    // =========================================================================
    // PROPRIÉTÉS PUBLIQUES (Expression-bodied properties avec '=>')
    // =========================================================================

    /// <summary>
    /// Nombre d'articles distincts enregistrés dans l'inventaire.
    /// EXPLICATION du '=>' (Expression-bodied property) :
    /// Équivalent à : public int Count { get { return _articles.Count; } }
    /// </summary>
    public int Count => _articles.Count;

    /// <summary>
    /// Indique si l'inventaire est actuellement vide.
    /// Renvoie true si Count vaut 0, sinon false.
    /// </summary>
    public bool IsEmpty => _articles.Count == 0;

    // =========================================================================
    // MÉTHODES PUBLIQUES (CRUD : Create, Read, Search, Delete)
    // =========================================================================

    /// <summary>
    /// Ajoute un nouvel article dans l'inventaire en générant automatiquement un ID unique.
    /// </summary>
    /// <param name="nom">Nom de l'article.</param>
    /// <param name="prix">Prix unitaire (en euros).</param>
    /// <param name="quantite">Quantité initiale en stock.</param>
    /// <returns>L'article nouvellement créé et ajouté.</returns>
    public Article AddArticle(string nom, decimal prix, int quantite)
    {
        // Instanciation de l'article avec l'ID séquentiel courant.
        // POST-INCRÉMENTATION (_nextId++) :
        // 1. Utilise la valeur ACTUELLE de _nextId comme ID de l'article.
        // 2. Puis incrémente _nextId de 1 pour le prochain article.
        // Exemple : si _nextId vaut 3, l'article reçoit l'ID 3 et _nextId passe à 4.
        var article = new Article(_nextId++, nom, prix, quantite);
        
        _articles.Add(article);

        // POURQUOI CE RETURN ?
        // Renvoie l'objet Article complet (avec son ID généré) à l'appelant (Program.cs),
        // permettant d'afficher immédiatement les informations de l'article créé.
        return article;
    }

    /// <summary>
    /// Renvoie la liste complète des articles sous forme de vue en lecture seule.
    /// </summary>
    /// <returns>Une collection `IReadOnlyList&lt;Article&gt;`.</returns>
    /// <exception cref="EmptyInventoryException">Levée si l'inventaire est vide.</exception>
    public IReadOnlyList<Article> GetArticles()
    {
        // 1. Clause de garde : vérifie que l'inventaire n'est pas vide avant d'exposer les données.
        EnsureNotEmpty("Aucun article à afficher : l'inventaire est vide.");
        
        // 2. POURQUOI .AsReadOnly() ET CE RETURN ?
        // .AsReadOnly() crée un wrapper IReadOnlyList<Article> autour de _articles.
        // Le 'return' transmet cette vue protégée à Program.cs, empêchant le code externe
        // d'ajouter ou supprimer des éléments directement (protection de l'encapsulation).
        return _articles.AsReadOnly();
    }

    /// <summary>
    /// Recherche un article spécifique par son identifiant unique.
    /// </summary>
    /// <param name="id">Identifiant de l'article recherché.</param>
    /// <returns>L'instance de l'article correspondant.</returns>
    /// <exception cref="ArticleNotFoundException">Levée si l'ID n'existe pas dans l'inventaire.</exception>
    public Article GetArticleById(int id)
    {
        EnsureNotEmpty();

        // =========================================================================
        // LINQ .FirstOrDefault() — RECHERCHE D'UN ÉLÉMENT UNIQUE
        // =========================================================================
        // .FirstOrDefault(prédicat) parcourt la liste et renvoie le PREMIER élément
        // pour lequel le prédicat (a => a.Id == id) est vrai.
        // Si AUCUN élément ne correspond, renvoie la valeur par défaut du type :
        // - Pour un type référence (class Article) : null
        // - Pour un type valeur (int, double) : 0
        // =========================================================================
        var article = _articles.FirstOrDefault(a => a.Id == id);
        
        // POURQUOI CE RETURN AVEC '??' ?
        // L'opérateur '??' (null-coalescing) vérifie si 'article' est null.
        // Si article N'EST PAS null : renvoie l'article trouvé.
        // Si article EST null : exécute le 'throw' qui lève l'exception.
        return article ?? throw new ArticleNotFoundException(id);
    }

    /// <summary>
    /// Recherche les articles dont le nom contient le mot-clé spécifié (insensible à la casse).
    /// </summary>
    /// <param name="keyword">Mot-clé ou partie du nom de l'article.</param>
    /// <returns>La liste des articles correspondants.</returns>
    /// <exception cref="EmptyInventoryException">Levée si l'inventaire est vide.</exception>
    /// <exception cref="ArticleNotFoundException">Levée si aucun article ne correspond à la recherche.</exception>
    public IReadOnlyList<Article> SearchArticlesByName(string keyword)
    {
        EnsureNotEmpty();

        // Clause de garde : le mot-clé de recherche ne peut pas être vide
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("Le mot-clé de recherche ne peut pas être vide.", nameof(keyword));

        // =========================================================================
        // LINQ .Where() — FILTRAGE D'UNE COLLECTION
        // =========================================================================
        // .Where(prédicat) parcourt TOUS les éléments de _articles et ne conserve
        // que ceux pour lesquels le prédicat est vrai (retourne true).
        //
        // Ici le prédicat vérifie si le Nom de l'article contient le mot-clé,
        // en ignorant la casse (StringComparison.OrdinalIgnoreCase).
        //
        // .ToList() matérialise le résultat filtré dans une nouvelle List<Article>.
        // Sans .ToList(), le résultat serait un IEnumerable<Article> à évaluation paresseuse (lazy).
        // =========================================================================
        var results = _articles
            .Where(a => a.Nom.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
            throw new ArticleNotFoundException(keyword);

        // POURQUOI CE RETURN ?
        // Renvoie la sous-liste filtrée sous forme IReadOnlyList pour protéger les données.
        return results.AsReadOnly();
    }

    /// <summary>
    /// Supprime un article de l'inventaire à partir de son identifiant.
    /// Réutilise GetArticleById() pour la recherche (principe DRY : Don't Repeat Yourself).
    /// </summary>
    /// <param name="id">Identifiant de l'article à supprimer.</param>
    /// <returns>L'article qui a été supprimé (pour permettre l'affichage de confirmation).</returns>
    /// <exception cref="ArticleNotFoundException">Levée si l'article n'existe pas.</exception>
    public Article RemoveArticleById(int id)
    {
        // Réutilisation de GetArticleById() : si l'article n'existe pas,
        // l'exception ArticleNotFoundException sera levée automatiquement.
        var article = GetArticleById(id);
        _articles.Remove(article);

        // POURQUOI CE RETURN ?
        // Renvoie l'article supprimé à Program.cs pour afficher un message de confirmation
        // contenant le nom et l'ID de l'article retiré.
        return article;
    }

    // =========================================================================
    // MÉTHODES D'AGRÉGATION LINQ (.Sum())
    // =========================================================================

    /// <summary>
    /// Calcule la valeur financière totale de l'ensemble du stock.
    /// </summary>
    /// <returns>La valeur totale en euros (decimal).</returns>
    public decimal CalculateTotalInventoryValue()
    {
        // LINQ .Sum(sélecteur) parcourt chaque article et additionne la valeur
        // renvoyée par le sélecteur (ici la propriété calculée ValeurTotale = Prix * Quantite).
        // Si la liste est vide, .Sum() renvoie 0 (pas d'exception).
        return _articles.Sum(a => a.ValeurTotale);
    }

    /// <summary>
    /// Calcule le nombre total d'unités physiques en stock (toutes références confondues).
    /// </summary>
    /// <returns>La somme des quantités de tous les articles.</returns>
    public int CalculateTotalQuantity()
    {
        // .Sum() sur les entiers renvoie 0 si la liste est vide.
        return _articles.Sum(a => a.Quantite);
    }

    /// <summary>
    /// Supprime l'intégralité des articles de l'inventaire.
    /// </summary>
    /// <exception cref="EmptyInventoryException">Levée si l'inventaire est déjà vide.</exception>
    public void Clear()
    {
        EnsureNotEmpty("L'inventaire est déjà vide.");

        // .Clear() est une méthode native de List<T> qui retire tous les éléments
        // et remet le Count interne de la liste à 0.
        _articles.Clear();
    }

    // =========================================================================
    // MÉTHODE PRIVÉE (Clause de garde interne)
    // =========================================================================

    /// <summary>
    /// Clause de garde privée vérifiant la présence d'au moins un article dans l'inventaire.
    /// </summary>
    /// <param name="customMessage">Message d'erreur personnalisé facultatif (nullable).</param>
    private void EnsureNotEmpty(string? customMessage = null)
    {
        if (IsEmpty)
        {
            // OPÉRATEUR TERNAIRE ( ? : ) :
            // Si customMessage n'est pas null → instancie l'exception avec le message personnalisé.
            // Sinon → instancie l'exception avec son message par défaut.
            throw customMessage is not null
                ? new EmptyInventoryException(customMessage)
                : new EmptyInventoryException();
        }
    }
}
