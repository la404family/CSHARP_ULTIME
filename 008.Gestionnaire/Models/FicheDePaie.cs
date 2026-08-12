using System;

namespace Gestionnaire.Models;

/// <summary>
/// Structure de données spéciale (record) représentant une fiche de paie finale.
/// Introduit en C# 9, le 'record' est idéal pour la POO moderne car il permet de définir 
/// en une seule ligne un objet **immuable** (qui ne peut pas être modifié une fois créé).
/// Cela garantit que la fiche de paie ne sera pas altérée accidentellement par une autre partie du programme.
/// Il génère automatiquement un constructeur, des propriétés en lecture seule et une méthode ToString() pratique.
/// </summary>
/// <param name="Matricule">Le matricule unique de l'employé.</param>
/// <param name="Nom">Le nom complet de l'employé.</param>
/// <param name="MontantNet">Le montant final du salaire, calculé par la méthode spécifique de l'employé.</param>
/// <param name="DateCreation">La date et l'heure exactes de la génération de cette fiche.</param>
public record FicheDePaie(string Matricule, string Nom, decimal MontantNet, DateTime DateCreation);
