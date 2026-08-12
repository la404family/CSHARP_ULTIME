using System;
using Simulateur.Exceptions;
using Simulateur.Models;
using Simulateur.Services;

namespace Simulateur;

/// <summary>
/// Classe principale du programme (Point d'entrée).
/// Gère l'interface utilisateur en console et la boucle d'interaction principale.
/// </summary>
class Program
{
    /// <summary>
    /// Méthode d'exécution principale de l'application.
    /// Configure l'environnement et orchestre les appels aux classes métier (Models/Services).
    /// </summary>
    /// <param name="args">Arguments de la ligne de commande (non utilisés ici).</param>
    static void Main(string[] args)
    {
        // Forcer l'encodage UTF-8 dans la console pour s'assurer que les caractères accentués s'affichent correctement.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Bienvenue dans le Simulateur de Banque 007 ===");
        
        // --- ÉTAPE 1 : Création du compte ---
        
        Console.Write("Veuillez entrer le nom du titulaire du compte : ");
        string titulaire = Console.ReadLine() ?? "Client";
        
        CompteBancaire compte;
        
        // Utilisation d'un bloc try/catch pour intercepter toute erreur dès l'instanciation du compte.
        try
        {
            compte = new CompteBancaire(titulaire);
            Console.WriteLine($"\nCompte créé avec succès pour {compte.Titulaire} !");
        }
        catch (Exception ex)
        {
            // En cas d'erreur bloquante (par exemple si on forçait un constructeur à refuser un nom vide),
            // on avertit l'utilisateur et on quitte l'application prématurément avec 'return'.
            Console.WriteLine($"Erreur fatale lors de la création du compte : {ex.Message}");
            return;
        }

        // Variable de contrôle pour la boucle du menu
        bool quitter = false;
        
        // --- ÉTAPE 2 : Boucle principale de l'application ---
        
        while (!quitter)
        {
            // Affichage du menu interactif
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Déposer de l'argent");
            Console.WriteLine("2. Retirer de l'argent");
            Console.WriteLine("3. Afficher le solde");
            Console.WriteLine("4. Quitter");
            Console.Write("Votre choix : ");
            
            // Lecture du choix utilisateur
            string choix = Console.ReadLine() ?? "";

            // Le grand bloc try/catch qui entoure toutes les opérations métier.
            // Il permet de capturer les exceptions personnalisées remontées par la classe CompteBancaire.
            try
            {
                switch (choix)
                {
                    case "1":
                        // Dépôt
                        Console.Write("Montant à déposer : ");
                        // TryParse tente de convertir le texte en nombre décimal. S'il réussit, il place la valeur dans montantDepot.
                        if (decimal.TryParse(Console.ReadLine(), out decimal montantDepot))
                        {
                            compte.Deposer(montantDepot); // Peut lever une MontantInvalideException
                            Console.WriteLine("Dépôt effectué avec succès !");
                        }
                        else
                        {
                            Console.WriteLine("Format de montant invalide. Veuillez entrer un nombre.");
                        }
                        break;
                        
                    case "2":
                        // Retrait
                        Console.Write("Montant à retirer : ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal montantRetrait))
                        {
                            compte.Retirer(montantRetrait); // Peut lever MontantInvalideException ou FondsInsuffisantsException
                            Console.WriteLine("Retrait effectué avec succès !");
                        }
                        else
                        {
                            Console.WriteLine("Format de montant invalide. Veuillez entrer un nombre.");
                        }
                        break;
                        
                    case "3":
                        // Consultation
                        // Le paramètre :C (Currency) formate automatiquement le nombre en monnaie locale (ex: 50,00 €)
                        Console.WriteLine($"Solde actuel : {compte.Solde:C}");
                        break;
                        
                    case "4":
                        // Quitter
                        quitter = true; // Met fin à la boucle while
                        Console.WriteLine("Merci d'avoir utilisé le Simulateur de Banque. Au revoir !");
                        break;
                        
                    default:
                        // Gestion d'une saisie hors menu (5, A, etc.)
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
            // --- ÉTAPE 3 : Gestion spécifique des Exceptions Métier ---
            catch (MontantInvalideException ex)
            {
                // Si l'utilisateur tente de retirer ou déposer -50€ par exemple.
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Erreur de saisie] {ex.Message}");
                Console.ResetColor();
            }
            catch (FondsInsuffisantsException ex)
            {
                // Si l'utilisateur tente de retirer plus que ce qu'il ne possède.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Fonds insuffisants] {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Un catch "fourre-tout" de sécurité au cas où une exception non prévue surviendrait 
                // (ex: OutOfMemoryException, problèmes inattendus).
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[Erreur inattendue] {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
