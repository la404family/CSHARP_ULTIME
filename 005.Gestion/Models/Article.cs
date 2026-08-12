namespace Gestion.Models;

/// <summary>
/// Représente un article stocké dans l'inventaire.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Classe (`class`) : Modèle de données encapsulant l'état (propriétés) et le comportement d'un article.
/// - Constructeur : Méthode spéciale initialisant les données d'une nouvelle instance avec des validations.
/// - Propriétés auto-implémentées (`get; set;`) : Contrôle d'accès aux données.
/// - Propriété calculée (`=>`) : Propriété en lecture seule calculant dynamiquement la valeur totale du stock pour cet article.
/// </summary>
public class Article
{
    /// <summary>
    /// Identifiant unique de l'article dans l'inventaire.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Nom ou désignation de l'article.
    /// </summary>
    public string Nom { get; set; }

    /// <summary>
    /// Prix unitaire de l'article (en euros).
    /// </summary>
    public decimal Prix { get; set; }

    /// <summary>
    /// Quantité disponible en stock.
    /// </summary>
    public int Quantite { get; set; }

    /// <summary>
    /// Valeur totale en stock pour cet article (Prix * Quantité).
    /// Propriété à expression fléchée (`=>`) calculée à la volée.
    /// </summary>
    public decimal ValeurTotale => Prix * Quantite;

    /// <summary>
    /// Constructeur de la classe Article.
    /// Initialise et valide les données de l'article lors de son instanciation.
    /// </summary>
    /// <param name="id">Identifiant unique (positif).</param>
    /// <param name="nom">Nom de l'article (non vide).</param>
    /// <param name="prix">Prix unitaire (positif ou nul).</param>
    /// <param name="quantite">Quantité en stock (positive ou nulle).</param>
    public Article(int id, string nom, decimal prix, int quantite)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "L'ID doit être un entier strict positif.");

        if (string.IsNullOrWhiteSpace(nom))
            throw new ArgumentException("Le nom de l'article ne peut pas être vide ou composé uniquement d'espaces.", nameof(nom));

        if (prix < 0m)
            throw new ArgumentOutOfRangeException(nameof(prix), "Le prix unitaire ne peut pas être négatif.");

        if (quantite < 0)
            throw new ArgumentOutOfRangeException(nameof(quantite), "La quantité en stock ne peut pas être négative.");

        Id = id;
        Nom = nom.Trim();
        Prix = prix;
        Quantite = quantite;
    }

    /// <summary>
    /// Renvoie une représentation textuelle formatée de l'article.
    /// </summary>
    public override string ToString()
    {
        return $"[ID #{Id:D3}] {Nom,-20} | Prix : {Prix,8:C2} | Qté : {Quantite,4} | Total : {ValeurTotale,10:C2}";
    }
}
