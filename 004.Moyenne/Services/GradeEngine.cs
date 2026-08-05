using System.Linq;
using Moyenne.Exceptions;

namespace Moyenne.Services;

/// <summary>
/// Moteur de calcul et gestionnaire de notes pour la mini-calculatrice de notes.
/// Encapsule la collection dynamique List<double> et garantit la validité du domaine
/// en levant des exceptions explicites (Domain Exception Handling).
/// 
/// CONCEPTS CLÉS :
/// - List<T> : Collection dynamique pour le stockage des notes.
/// - LINQ (Language Integrated Query) : Méthodes d'extension (.Average(), .Max(), .Min()).
/// - Validation & Exceptions : Levée d'exceptions explicites (EmptyGradeListException, ArgumentOutOfRangeException)
///   pour éviter les valeurs factices (ex: retourner 0.0 quand la liste est vide).
/// </summary>
public class GradeEngine
{
    private readonly List<double> _grades = new();

    /// <summary>
    /// Nombre de notes actuellement stockées dans la liste.
    /// </summary>
    public int Count => _grades.Count;

    /// <summary>
    /// Indique si la liste est vide.
    /// </summary>
    public bool IsEmpty => _grades.Count == 0;

    /// <summary>
    /// Ajoute une note à la liste.
    /// </summary>
    /// <param name="grade">La note à ajouter (comprise entre 0.0 et 20.0).</param>
    /// <exception cref="ArgumentOutOfRangeException">Levée si la note est en dehors de l'intervalle [0.0, 20.0].</exception>
    public void AddGrade(double grade)
    {
        if (grade < 0.0 || grade > 20.0)
        {
            throw new ArgumentOutOfRangeException(nameof(grade), "La note doit être comprise entre 0.0 et 20.0.");
        }

        _grades.Add(grade);
    }

    /// <summary>
    /// Renvoie une vue en lecture seule des notes actuelles.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si aucune note n'est disponible.</exception>
    public IReadOnlyList<double> GetGrades()
    {
        EnsureNotEmpty("Aucune note à afficher : la liste est vide.");
        return _grades.AsReadOnly();
    }

    /// <summary>
    /// Calcule la moyenne générale via LINQ.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double CalculateAverage()
    {
        EnsureNotEmpty("Impossible de calculer la moyenne : aucune note n'a été enregistrée.");
        return _grades.Average();
    }

    /// <summary>
    /// Recherche la note la plus haute (Max) via LINQ.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double GetMaxGrade()
    {
        EnsureNotEmpty("Impossible de déterminer la note maximale : aucune note n'a été enregistrée.");
        return _grades.Max();
    }

    /// <summary>
    /// Recherche la note la plus basse (Min) via LINQ.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si la liste est vide.</exception>
    public double GetMinGrade()
    {
        EnsureNotEmpty("Impossible de déterminer la note minimale : aucune note n'a été enregistrée.");
        return _grades.Min();
    }

    /// <summary>
    /// Réinitialise et supprime toutes les notes.
    /// </summary>
    /// <exception cref="EmptyGradeListException">Levée si la liste est déjà vide.</exception>
    public void Clear()
    {
        EnsureNotEmpty("La liste des notes est déjà vide.");
        _grades.Clear();
    }

    /// <summary>
    /// Clause de garde (Guard Clause) pour vérifier l'état non vide de la collection.
    /// </summary>
    private void EnsureNotEmpty(string? customMessage = null)
    {
        if (IsEmpty)
        {
            throw customMessage is not null 
                ? new EmptyGradeListException(customMessage) 
                : new EmptyGradeListException();
        }
    }
}
