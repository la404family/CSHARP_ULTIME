using System;
using System.Collections.Generic;
using Gestionnaire.Models;
using Gestionnaire.Services;

namespace Gestionnaire;

/// <summary>
/// Point d'entrée principal de l'application.
/// Il illustre concrètement la notion de Polymorphisme et la gestion sécurisée 
/// des ressources matérielles via le mot-clé 'using'.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // On s'assure que le terminal supporte l'affichage de caractères monétaires (comme l'euro €).
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Gestionnaire d'Employés (POO & SOLID) ===\n");

        // --- ÉTAPE 1 : Démonstration du Polymorphisme ---
        
        // Bien que la liste soit typée "Employe" (la classe mère abstraite), 
        // on y insère des objets différents (des EmployeTempsPlein et des Contractuel).
        // C'est possible car ces deux classes dérivent de Employe.
        List<Employe> employes = new List<Employe>
        {
            new EmployeTempsPlein("EMP001", "Alice Dupont", salaireMensuelBase: 3200m, prime: 300m), // Total espéré: 3500
            new Contractuel("EMP002", "Bob Martin", tauxHoraire: 45m, heuresTravaillees: 140),         // Total espéré: 6300
            new EmployeTempsPlein("EMP003", "Charlie Dubois", salaireMensuelBase: 2800m)               // Total espéré: 2800
        };

        // --- ÉTAPE 2 : Traitement et Archivage avec IDisposable ---
        
        string fichierArchives = "archives_paie.txt";
        
        // Le mot-clé 'using' est fondamental ici.
        // L'objet 'ArchiveurPaie' maintient un fichier ouvert sur le disque dur.
        // Grâce au 'using', dès que l'accolade fermante sera atteinte, la méthode archiveur.Dispose()
        // sera automatiquement appelée par le système pour fermer le fichier en toute sécurité.
        // Cela fonctionne même si le programme plante (exception) à l'intérieur du bloc !
        using (var archiveur = new ArchiveurPaie(fichierArchives))
        {
            foreach (var employe in employes)
            {
                // Ici, c'est la magie du polymorphisme !
                // Lorsque la méthode appelle 'employe.GenererFicheDePaie()', elle-même appelle 'CalculerSalaire()'.
                // Le programme .NET "devine" tout seul la vraie nature de l'objet :
                // - Si c'est Alice (Temps Plein), il additionne base + prime.
                // - Si c'est Bob (Contractuel), il multiplie taux horaire * heures.
                // Il n'y a besoin d'aucun 'if' ou 'switch' pour distinguer le type d'employé.
                FicheDePaie fiche = employe.GenererFicheDePaie();
                
                // Affichage en temps réel dans la console
                Console.WriteLine($"Génération de la paie pour {employe.Nom} (Matricule: {employe.Matricule})");
                Console.WriteLine($" -> Salaire Net Calculé : {fiche.MontantNet:C}\n");
                
                // On délègue l'enregistrement disque au service d'archivage (Single Responsibility Principle)
                archiveur.Archiver(fiche);
            }
        } 
        // <- À cet endroit précis, le fichier texte est fermé automatiquement par Dispose().

        Console.WriteLine($"Toutes les fiches de paie ont été générées et archivées dans le fichier '{fichierArchives}'.");
        Console.WriteLine("Appuyez sur une touche pour quitter l'application.");
        Console.ReadKey();
    }
}
