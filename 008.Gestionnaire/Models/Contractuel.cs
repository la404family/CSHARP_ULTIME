namespace Gestionnaire.Models;

/// <summary>
/// Représente un travailleur freelance, prestataire ou contractuel payé selon un tarif horaire.
/// Hérite de la classe abstraite Employe.
/// </summary>
public class Contractuel : Employe
{
    /// <summary>
    /// Le tarif facturé pour une heure de travail.
    /// </summary>
    public decimal TauxHoraire { get; }
    
    /// <summary>
    /// Le volume d'heures effectuées dans le mois (ou la période de facturation).
    /// </summary>
    public int HeuresTravaillees { get; }

    /// <summary>
    /// Constructeur du contractuel.
    /// Transmet 'matricule' et 'nom' à la classe de base, et gère ses propres données financières.
    /// </summary>
    /// <param name="matricule">Matricule unique (ex: numéro SIRET/Freelance).</param>
    /// <param name="nom">Nom du prestataire.</param>
    /// <param name="tauxHoraire">Prix d'une heure de travail.</param>
    /// <param name="heuresTravaillees">Nombre d'heures réalisées.</param>
    public Contractuel(string matricule, string nom, decimal tauxHoraire, int heuresTravaillees) 
        : base(matricule, nom)
    {
        TauxHoraire = tauxHoraire;
        HeuresTravaillees = heuresTravaillees;
    }

    /// <summary>
    /// Redéfinition (override) obligatoire de la méthode abstraite.
    /// Pour le contractuel, la règle de calcul diffère du temps plein : TauxHoraire x HeuresTravaillees.
    /// </summary>
    /// <returns>Le montant net total.</returns>
    public override decimal CalculerSalaire()
    {
        return TauxHoraire * HeuresTravaillees;
    }
}
