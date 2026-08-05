namespace Moyenne.Exceptions;

/// <summary>
/// Exception personnalisée levée lorsqu'une opération nécessite au moins une note,
/// mais que la liste de notes est vide.
/// </summary>
public class EmptyGradeListException : InvalidOperationException
{
    public EmptyGradeListException() 
        : base("Impossible d'effectuer cette opération : aucune note n'a été enregistrée.")
    {
    }

    public EmptyGradeListException(string message) 
        : base(message)
    {
    }
}
