namespace Gestion.Exceptions;

/// <summary>
/// Exception personnalisée de domaine levée lorsqu'une opération nécessite au moins un article,
/// mais que l'inventaire est actuellement vide.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Héritage ( : InvalidOperationException) : EmptyInventoryException dérive de la classe d'exception standard C#.
///   Cela permet au bloc 'catch (InvalidOperationException)' de capturer aussi cette exception si nécessaire.
/// - Constructeurs &amp; ': base(...)' : Transmet le message d'erreur au constructeur de la classe parente.
/// </summary>
public class EmptyInventoryException : InvalidOperationException
{
    /// <summary>
    /// Constructeur par défaut : initialise l'exception avec un message prédéfini explicite.
    /// EXPLICATION de ': base(...)' : 
    /// Appelle le constructeur de InvalidOperationException(string message) pour fixer le message d'erreur de base.
    /// </summary>
    public EmptyInventoryException()
        : base("L'inventaire est actuellement vide. Aucune opération ne peut être effectuée.")
    {
    }

    /// <summary>
    /// Constructeur surchargé : permet de transmettre un message d'erreur personnalisé si nécessaire.
    /// </summary>
    /// <param name="message">Le message personnalisé décrivant la situation d'erreur.</param>
    public EmptyInventoryException(string message)
        : base(message)
    {
    }
}
