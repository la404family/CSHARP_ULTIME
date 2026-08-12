using System;

namespace Simulateur.Exceptions;

/// <summary>
/// Exception métier personnalisée, déclenchée lorsqu'un montant saisi 
/// par l'utilisateur est considéré comme invalide (par exemple : montant négatif ou nul).
/// Hérite de la classe de base <see cref="Exception"/>.
/// </summary>
public class MontantInvalideException : Exception
{
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="MontantInvalideException"/> 
    /// avec un message d'erreur par défaut.
    /// </summary>
    public MontantInvalideException() 
        : base("Le montant saisi est invalide. Il doit être strictement positif.") { }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="MontantInvalideException"/> 
    /// avec un message d'erreur spécifique fourni lors de la levée de l'exception.
    /// </summary>
    /// <param name="message">Le message expliquant la cause de l'exception.</param>
    public MontantInvalideException(string message) 
        : base(message) { }
}
