using System;
using Simulateur.Exceptions;
using Simulateur.Services;

namespace Simulateur.Models;

/// <summary>
/// Classe modèle métier représentant un compte bancaire.
/// Gère les règles d'intégrité du solde (pas de retraits excessifs, pas de dépôts négatifs).
/// </summary>
public class CompteBancaire
{
    /// <summary>
    /// Obtient le nom du titulaire du compte. Cette propriété est en lecture seule (définie à la création).
    /// </summary>
    public string Titulaire { get; }
    
    /// <summary>
    /// Obtient le solde actuel du compte. La modification (set) est privée pour empêcher
    /// toute altération du solde depuis l'extérieur sans passer par les méthodes Deposer ou Retirer.
    /// </summary>
    public decimal Solde { get; private set; }

    /// <summary>
    /// Constructeur principal du compte bancaire.
    /// </summary>
    /// <param name="titulaire">Le nom du client propriétaire du compte.</param>
    /// <param name="soldeInitial">Le montant de départ (0 par défaut).</param>
    /// <exception cref="MontantInvalideException">Levée si le solde initial fourni est négatif.</exception>
    public CompteBancaire(string titulaire, decimal soldeInitial = 0)
    {
        // Règle métier : un compte ne peut pas être créé avec un solde négatif.
        if (soldeInitial < 0)
        {
            throw new MontantInvalideException("Le solde initial ne peut pas être négatif.");
        }

        Titulaire = titulaire;
        Solde = soldeInitial;
        
        // On journalise la création réussie du compte pour l'historique
        JournalisationService.LogOperation($"Création du compte pour '{Titulaire}' avec un solde de {Solde:C}");
    }

    /// <summary>
    /// Ajoute des fonds au solde du compte.
    /// </summary>
    /// <param name="montant">Le montant à déposer. Doit être strictement supérieur à zéro.</param>
    /// <exception cref="MontantInvalideException">Levée si le montant est négatif ou nul.</exception>
    public void Deposer(decimal montant)
    {
        // Règle métier : interdiction de déposer 0 ou un montant négatif
        if (montant <= 0)
        {
            JournalisationService.LogOperation($"Tentative de dépôt invalide ({montant:C}) rejetée.");
            throw new MontantInvalideException("Le montant du dépôt doit être strictement positif.");
        }

        // Mise à jour du solde
        Solde += montant;
        
        // Trace de la réussite de l'opération
        JournalisationService.LogOperation($"Dépôt de {montant:C}. Nouveau solde : {Solde:C}.");
    }

    /// <summary>
    /// Retire des fonds du compte, en vérifiant la disponibilité du solde.
    /// </summary>
    /// <param name="montant">Le montant à retirer. Doit être strictement supérieur à zéro et inférieur ou égal au solde.</param>
    /// <exception cref="MontantInvalideException">Levée si le montant est négatif ou nul.</exception>
    /// <exception cref="FondsInsuffisantsException">Levée si le montant dépasse le solde disponible.</exception>
    public void Retirer(decimal montant)
    {
        // Règle métier 1 : interdiction de retirer 0 ou un montant négatif
        if (montant <= 0)
        {
            JournalisationService.LogOperation($"Tentative de retrait invalide ({montant:C}) rejetée.");
            throw new MontantInvalideException("Le montant du retrait doit être strictement positif.");
        }

        // Règle métier 2 : le retrait ne doit pas mettre le compte à découvert
        if (montant > Solde)
        {
            JournalisationService.LogOperation($"Tentative de retrait refusée ({montant:C} demandé, {Solde:C} disponible).");
            throw new FondsInsuffisantsException($"Fonds insuffisants. Solde actuel : {Solde:C}");
        }

        // Mise à jour du solde
        Solde -= montant;
        
        // Trace de la réussite de l'opération
        JournalisationService.LogOperation($"Retrait de {montant:C}. Nouveau solde : {Solde:C}.");
    }
}
