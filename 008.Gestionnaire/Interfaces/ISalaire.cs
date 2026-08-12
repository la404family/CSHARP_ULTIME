namespace Gestionnaire.Interfaces;

/// <summary>
/// Interface définissant le contrat (les règles) pour le calcul d'un salaire.
/// L'utilisation d'une interface (principe d'abstraction) permet de s'assurer que 
/// n'importe quelle classe qui décide de l'implémenter fournira obligatoirement 
/// sa propre version de la méthode CalculerSalaire().
/// </summary>
public interface ISalaire
{
    /// <summary>
    /// Calcule le salaire net d'une entité (un employé par exemple).
    /// </summary>
    /// <returns>Le montant du salaire sous forme de nombre décimal (decimal), très précis pour les devises.</returns>
    decimal CalculerSalaire();
}
