namespace Gestionnaire.Models;

/// <summary>
/// Représente un employé en CDI ou CDD avec un salaire fixe.
/// Hérite de la classe abstraite Employe.
/// </summary>
public class EmployeTempsPlein : Employe
{
    /// <summary>
    /// Le salaire de base garanti chaque mois.
    /// </summary>
    public decimal SalaireMensuelBase { get; }
    
    /// <summary>
    /// Une prime éventuelle (bonus de performance, ancienneté, etc.).
    /// </summary>
    public decimal Prime { get; }

    /// <summary>
    /// Constructeur de l'employé à temps plein.
    /// Le mot-clé 'base(matricule, nom)' appelle directement le constructeur de la classe parente (Employe).
    /// </summary>
    /// <param name="matricule">Matricule unique de l'employé.</param>
    /// <param name="nom">Nom de l'employé.</param>
    /// <param name="salaireMensuelBase">Salaire fixe par mois.</param>
    /// <param name="prime">Prime optionnelle (vaut 0 par défaut).</param>
    public EmployeTempsPlein(string matricule, string nom, decimal salaireMensuelBase, decimal prime = 0) 
        : base(matricule, nom)
    {
        SalaireMensuelBase = salaireMensuelBase;
        Prime = prime;
    }

    /// <summary>
    /// Redéfinition (override) obligatoire de la méthode abstraite définie dans la classe parente.
    /// Ici, la règle de calcul est très simple : Salaire fixe + Primes éventuelles.
    /// </summary>
    /// <returns>Le montant net total.</returns>
    public override decimal CalculerSalaire()
    {
        return SalaireMensuelBase + Prime;
    }
}
