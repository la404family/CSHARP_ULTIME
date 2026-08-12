namespace Gestion.Exceptions;

/// <summary>
/// Exception personnalisée de domaine levée lorsqu'un article recherché par ID ou par nom
/// n'existe pas dans l'inventaire.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Héritage ( : KeyNotFoundException) : ArticleNotFoundException dérive de KeyNotFoundException
///   qui est l'exception standard C# pour les recherches infructueuses dans les collections.
/// - Surcharge de constructeurs : Deux constructeurs acceptant des types de paramètres différents
///   (int pour l'ID, string pour le mot-clé) permettent d'adapter le message d'erreur au contexte de recherche.
/// - Interpolation de chaîne ($"...{variable}...") : Construction dynamique du message d'erreur.
/// </summary>
public class ArticleNotFoundException : KeyNotFoundException
{
    /// <summary>
    /// Constructeur pour une recherche par identifiant (ID entier).
    /// EXPLICATION de ': base($"...")' :
    /// Appelle le constructeur de KeyNotFoundException(string message) avec un message
    /// contenant dynamiquement l'ID recherché via l'interpolation de chaîne.
    /// </summary>
    /// <param name="id">L'identifiant de l'article recherché qui n'a pas été trouvé.</param>
    public ArticleNotFoundException(int id)
        : base($"Aucun article n'a été trouvé avec l'identifiant #{id}.")
    {
    }

    /// <summary>
    /// Constructeur pour une recherche par mot-clé (texte).
    /// Utilisé lorsqu'aucun article ne correspond au filtre de recherche par nom.
    /// </summary>
    /// <param name="searchKeyword">Le mot-clé utilisé pour la recherche infructueuse.</param>
    public ArticleNotFoundException(string searchKeyword)
        : base($"Aucun article correspondant à '{searchKeyword}' n'a été trouvé dans l'inventaire.")
    {
    }
}
