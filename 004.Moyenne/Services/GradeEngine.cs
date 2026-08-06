using System.Linq;
using Moyenne.Exceptions;

namespace Moyenne.Services;

/// <summary>
/// Moteur de calcul et gestionnaire de notes pour la mini-calculatrice de notes.
/// Encapsule la collection dynamique List<double> et garantit la validité du domaine
/// en levant des exceptions explicites (Domain Exception Handling).
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - List<T> : Collection dynamique pour le stockage des notes en mémoire.
/// - LINQ (Language Integrated Query) : Méthodes d'extension (.Average(), .Max(), .Min()) pour réaliser des calculs statistiques simples.
/// - Syntaxe fléchée (=>) : Raccourci d'écriture pour les propriétés ou méthodes à expression unique.
/// - Opérateur Ternaire ( ? : ) : Syntaxe compacte conditionnelle "condition ? siVrai : siFaux".
/// - Rôle des 'return' : Transmettre une valeur de retour à l'appelant et mettre fin immédiatement à l'exécution de la méthode.
/// </summary>
public class GradeEngine
{
    // Collection privée contenant les notes. 
    // 'readonly' empêche de réassigner la variable _grades à une autre liste après sa création.
    private readonly List<double> _grades = new();

    /// <summary>
    /// Nombre de notes actuellement stockées dans la liste.
    /// EXPLICATION du '=>' (Expression-bodied property) :
    /// C'est un raccourci d'écriture équivalent à :
    /// public int Count { get { return _grades.Count; } }
    /// </summary>
    public int Count => _grades.Count;

    /// <summary>
    /// Indique si la liste est vide.
    /// Renvoie true si Count vaut 0, sinon false.
    /// </summary>
    public bool IsEmpty => _grades.Count == 0;

    /// <summary>
    /// Ajoute une note à la liste après validation de la plage [0.0, 20.0].
    /// </summary>
    /// <param name="grade">La note à ajouter (comprise entre 0.0 et 20.0).</param>
    /// <exception cref="ArgumentOutOfRangeException">Levée si la note est hors limites.</exception>
    public void AddGrade(double grade)
    {
        // Clause de garde (Guard Clause) : Vérification des préconditions avant d'exécuter la logique.
        if (grade < 0.0 || grade > 20.0)
        {
            // 'throw' interrompt immédiatement la méthode et propage l'erreur.
            // Aucun 'return' n'est nécessaire ici car 'throw' sort du bloc d'exécution.
            throw new ArgumentOutOfRangeException(nameof(grade), "La note doit être comprise entre 0.0 et 20.0.");
        }

        // Si la validation passe, on ajoute la note à la liste dynamique.
        _grades.Add(grade);
    }

    /// <summary>
    /// Renvoie une vue en lecture seule (IReadOnlyList) des notes actuelles.
    /// </summary>
    /// <returns>La liste sous forme d'interface en lecture seule.</returns>
    /// <exception cref="EmptyGradeListException">Levée si aucune note n'est disponible.</exception>
    public IReadOnlyList<double> GetGrades()
    {
        // 1. Vérification préalable : l'exception est levée si la liste est vide.
        EnsureNotEmpty("Aucune note à afficher : la liste est vide.");
        
        // 2. POURQUOI CE RETURN ?
        // .AsReadOnly() crée un wrapper en lecture seule autour de _grades.
        // Le 'return' transmet ce wrapper à l'appelant (Program.cs) tout en empêchant
        // le code externe de modifier la liste originale (ex: faire g.Add() d'en dehors).
        return _grades.AsReadOnly();
    }

    /// <summary>
    /// Calcule la moyenne générale via la méthode d'extension LINQ .Average().
    /// </summary>
    /// <returns>La moyenne sous forme de nombre décimal (double).</returns>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double CalculateAverage()
    {
        EnsureNotEmpty("Impossible de calculer la moyenne : aucune note n'a été enregistrée.");

        // POURQUOI CE RETURN ?
        // LINQ .Average() parcourt les éléments de _grades, en calcule la somme et la divise par le nombre d'éléments.
        // Le 'return' renvoie le résultat du calcul décimal directement au code qui a appelé CalculateAverage().
        return _grades.Average();
    }

    /// <summary>
    /// Recherche la note la plus haute (Max) via la méthode d'extension LINQ .Max().
    /// </summary>
    /// <returns>La note maximale (double).</returns>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double GetMaxGrade()
    {
        EnsureNotEmpty("Impossible de déterminer la note maximale : aucune note n'a été enregistrée.");

        // POURQUOI CE RETURN ?
        // .Max() analyse tous les éléments et renvoie le plus grand.
        // 'return' transmet cette valeur maximale au programme principal.
        return _grades.Max();
    }

    /// <summary>
    /// Recherche la note la plus basse (Min) via la méthode d'extension LINQ .Min().
    /// </summary>
    /// <returns>La note minimale (double).</returns>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double GetMinGrade()
    {
        EnsureNotEmpty("Impossible de déterminer la note minimale : aucune note n'a été enregistrée.");

        // POURQUOI CE RETURN ?
        // .Min() renvoie la plus petite valeur de la collection.
        return _grades.Min();
    }

    /// <summary>
    /// Réinitialise et supprime toutes les notes de la liste.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si la liste est déjà vide.</exception>
    public void Clear()
    {
        EnsureNotEmpty("La liste des notes est déjà vide.");

        // .Clear() est une méthode native de List<T> qui réinitialise la taille de la liste à 0.
        _grades.Clear();
    }

    /// <summary>
    /// Clause de garde privée (Guard Clause) pour vérifier que la collection n'est pas vide.
    /// </summary>
    /// <param name="customMessage">Message d'erreur personnalisé facultatif (nullable).</param>
    private void EnsureNotEmpty(string? customMessage = null)
    {
        if (IsEmpty)
        {
            // =========================================================================
            // DÉMONSTRATION DE L'OPÉRATEUR TERNAIRE ( ? : )
            // =========================================================================
            // Structure : condition ? expression_si_vrai : expression_si_faux
            //
            // Ici : 
            // - Condition : 'customMessage is not null' (vérifie si un message sur-mesure a été fourni).
            // - Si VRAI (?) : Instancie EmptyGradeListException avec le message personnalisé.
            // - Si FAUX (:) : Instancie EmptyGradeListException avec le message par défaut.
            //
            // ÉQUIVALENT EN IF / ELSE :
            // if (customMessage is not null)
            // {
            //     throw new EmptyGradeListException(customMessage);
            // }
            // else
            // {
            //     throw new EmptyGradeListException();
            // }
            // =========================================================================
            throw customMessage is not null 
                ? new EmptyGradeListException(customMessage) 
                : new EmptyGradeListException();
        }
    }
}

