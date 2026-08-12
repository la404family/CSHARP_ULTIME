using System;
using Gestionnaire.Interfaces;

namespace Gestionnaire.Models;

/// <summary>
/// Classe de base représentant un employé générique.
/// Elle est marquée 'abstract' : on ne peut pas créer (instancier) un "Employé" directement. 
/// Il faut créer un "Employé à temps plein" ou un "Contractuel" (classes enfants).
/// Elle implémente ISalaire, donc elle s'engage à ce que tous ses enfants aient un salaire calculable.
/// </summary>
public abstract class Employe : ISalaire
{
    /// <summary>
    /// L'identifiant unique de l'employé. Propriété en lecture seule définie à l'instanciation.
    /// </summary>
    public string Matricule { get; }
    
    /// <summary>
    /// Le nom complet de l'employé. Propriété en lecture seule.
    /// </summary>
    public string Nom { get; }

    /// <summary>
    /// Constructeur "protected" car il ne peut être appelé que par les classes dérivées (enfants).
    /// Permet de centraliser l'affectation du matricule et du nom pour éviter de répéter ce code.
    /// </summary>
    /// <param name="matricule">Le matricule unique fourni par l'enfant.</param>
    /// <param name="nom">Le nom fourni par l'enfant.</param>
    protected Employe(string matricule, string nom)
    {
        Matricule = matricule;
        Nom = nom;
    }

    /// <summary>
    /// Méthode imposée par l'interface ISalaire.
    /// Marquer cette méthode 'abstract' force chaque classe dérivée (enfant) 
    /// à fournir sa propre implémentation mathématique (c'est le cœur du polymorphisme).
    /// </summary>
    /// <returns>Le salaire calculé par l'enfant.</returns>
    public abstract decimal CalculerSalaire();

    /// <summary>
    /// Méthode utilitaire disponible pour tous les types d'employés.
    /// Elle assemble les données de base (Nom, Matricule) avec le résultat de CalculerSalaire()
    /// pour générer l'objet final immuable FicheDePaie.
    /// </summary>
    /// <returns>Une FicheDePaie complète et immuable.</returns>
    public FicheDePaie GenererFicheDePaie()
    {
        // Appel polymorphique : le programme exécutera la méthode CalculerSalaire() 
        // spécifique au type réel de l'employé au moment de l'exécution (Temps Plein vs Contractuel).
        decimal salaire = CalculerSalaire();
        return new FicheDePaie(Matricule, Nom, salaire, DateTime.Now);
    }
}
