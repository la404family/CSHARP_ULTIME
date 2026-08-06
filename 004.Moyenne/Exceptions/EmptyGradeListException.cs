namespace Moyenne.Exceptions;

/// <summary>
/// Exception personnalisée de domaine levée lorsqu'une opération nécessite au moins une note,
/// mais que la liste de notes est actuellement vide.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Héritage ( : InvalidOperationException) : EmptyGradeListException dérive de la classe d'exception standard C#.
/// - Constructeurs & ': base(...)' : Transmet le message d'erreur au constructeur de la classe parente (InvalidOperationException).
/// </summary>
public class EmptyGradeListException : InvalidOperationException
{
    /// <summary>
    /// Constructeur par défaut : initialise l'exception avec un message prédéfini explicite.
    /// EXPLICATION de ': base(...)' : 
    /// Appelle le constructeur de InvalidOperationException(string message) pour fixer le message d'erreur de base.
    /// </summary>
    public EmptyGradeListException() 
        : base("Impossible d'effectuer cette opération : aucune note n'a été enregistrée.")
    {
    }

    /// <summary>
    /// Constructeur surcharge : permet de transmettre un message d'erreur personnalisé si nécessaire.
    /// </summary>
    /// <param name="message">Le message personnalisé décrivant la situation d'erreur.</param>
    public EmptyGradeListException(string message) 
        : base(message)
    {
    }
}

