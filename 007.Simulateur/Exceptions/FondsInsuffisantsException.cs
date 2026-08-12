using System;

namespace Simulateur.Exceptions;

/// <summary>
/// Exception métier personnalisée, déclenchée lorsqu'un client tente de retirer 
/// un montant qui excède le solde disponible sur son compte bancaire.
/// Hérite de la classe de base <see cref="Exception"/>.
/// </summary>
public class FondsInsuffisantsException : Exception
{
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FondsInsuffisantsException"/> 
    /// avec un message d'erreur par défaut.
    /// </summary>
    public FondsInsuffisantsException() 
        : base("Fonds insuffisants pour effectuer cette opération.") { }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FondsInsuffisantsException"/> 
    /// avec un message d'erreur spécifique décrivant la situation (ex: montant demandé et solde actuel).
    /// </summary>
    /// <param name="message">Le message expliquant la cause de l'exception.</param>
    public FondsInsuffisantsException(string message) 
        : base(message) { }
}
