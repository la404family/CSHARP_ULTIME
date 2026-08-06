using Moyenne.Exceptions;
using Moyenne.Services;
using Moyenne.Utils;

// ========================================================================
// Projet 004 : Mini-calculatrice de notes (Version Modulaire, LINQ & Exceptions)
// ------------------------------------------------------------------------
// CONCEPTS EXPLICITÉS ET DÉMONTRÉS DANS CE PROJET :
// - POO & Architecture Modulaire (Services, Utils, Exceptions)
// - Collections dynamiques (List<T>) et interfaces en lecture seule (IReadOnlyList<T>)
// - LINQ (Language Integrated Query) pour les calculs (.Average(), .Max(), .Min())
// - Opérateurs Ternaires ( ? : ) et membres à expression fléchée (=>)
// - Transmission de valeurs de retour (return) et paramètres de sortie (out)
// - Gestion stricte des exceptions métiers (try / catch avec exceptions personnalisées)
// ========================================================================

// 0. INITIALISATION DU THÈME & DU MOTEUR
// Configure les couleurs de la console et l'encodage UTF-8 sous Windows
ConsoleTheme.ApplyTheme();

// Instanciation de l'objet GradeEngine qui va gérer l'état interne des notes
var engine = new GradeEngine();

// Variable d'état de contrôle de la boucle principale du menu
bool running = true;

// Boucle principale d'interaction utilisateur
while (running)
{
    ConsoleTheme.WriteInfo("========================================");
    ConsoleTheme.WriteInfo("   MINI-CALCULATRICE DE NOTES (C#)");
    ConsoleTheme.WriteInfo("========================================\n");

    // Propriété fléchée engine.Count (renvoie le nombre actuel de notes via get { return _grades.Count; })
    Console.WriteLine($"Nombre de notes enregistrées : {engine.Count}\n");

    Console.WriteLine("1. Ajouter une note (0 à 20)");
    Console.WriteLine("2. Afficher la liste des notes");
    Console.WriteLine("3. Calculer la moyenne, note Max et Min (LINQ)");
    Console.WriteLine("4. Vider la liste des notes");
    Console.WriteLine("5. Quitter\n");

    // Appel à la fonction utilitaire qui renvoie l'option choisie (return choice)
    int option = ConsoleInput.AskForMenuOption("Votre choix (1-5) : ", 1, 5);

    Console.WriteLine();

    // =========================================================================
    // BLOC TRY-CATCH : GESTION DES EXCEPTIONS ET SÉCURITÉ D'EXÉCUTION
    // =========================================================================
    // Le bloc 'try' englobe tout code susceptible de lever une exception.
    // Si une méthode dans le 'try' fait un 'throw', l'exécution normale s'arrête
    // et C# bascule immédiatement dans le premier bloc 'catch' correspondant.
    // =========================================================================
    try
    {
        switch (option)
        {
            case 1:
                // --- SAISIE D'UNE NOTE ---
                ConsoleTheme.WriteInfo("--- AJOUT D'UNE NOTE ---");
                
                // TryAskForGrade utilise le mot-clé 'out' pour fournir la valeur 'grade'.
                // La méthode RENVOIE 'true' (return true) si la saisie a réussi, ou 'false' (return false) si annulée.
                if (ConsoleInput.TryAskForGrade("Entrez une note (entre 0.0 et 20.0, ou 'Q' pour annuler) : ", out double grade))
                {
                    engine.AddGrade(grade);
                    
                    // Formatage numérique :F2 affiche le nombre avec exactement 2 décimales (ex: 14.50)
                    ConsoleTheme.WriteSuccess($"\n[OK] Note {grade:F2}/20 ajoutée avec succès !");
                }
                else
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Ajout de note annulé.");
                }
                break; // 'break' sort du switch pour passer à la fin de la boucle while

            case 2:
                // --- AFFICHAGE DE LA LISTE DE NOTES ---
                ConsoleTheme.WriteInfo("--- LISTE DES NOTES ---");
                
                // GetGrades() renvoie l'interface IReadOnlyList<double>.
                // Si la liste est vide, GetGrades() fait un 'throw new EmptyGradeListException()',
                // ce qui saute directement au bloc 'catch (EmptyGradeListException ex)'.
                var grades = engine.GetGrades(); 
                int index = 1;
                
                // Parcours de la collection sécurisée via 'foreach'
                foreach (double g in grades)
                {
                    // index++ : Post-incrémentation (affiche l'index courant puis ajoute 1)
                    Console.WriteLine($"  Note n°{index++} : {g:F2} / 20");
                }
                break;

            case 3:
                // --- CALCULS DE STATISTIQUES (LINQ) ---
                ConsoleTheme.WriteInfo("--- STATISTIQUES (LINQ) ---");
                
                // Chacune de ces 3 méthodes appelle 'return _grades.Average()', etc.
                // Elles lèvent une EmptyGradeListException si _grades est vide.
                double avg = engine.CalculateAverage();
                double max = engine.GetMaxGrade();
                double min = engine.GetMinGrade();

                ConsoleSound.PlayStats();
                ConsoleTheme.WriteSuccess($"[MOYENNE] Moyenne générale   : {avg:F2} / 20");
                Console.WriteLine($"[MAX]     Note la plus haute : {max:F2} / 20");
                Console.WriteLine($"[MIN]     Note la plus basse : {min:F2} / 20");
                break;

            case 4:
                // --- VIDER LA LISTE DES NOTES ---
                ConsoleTheme.WriteInfo("--- VIDER LA LISTE ---");
                engine.Clear(); // Lève EmptyGradeListException si la liste était déjà vide
                ConsoleTheme.WriteSuccess("[OK] Toutes les notes ont été supprimées avec succès.");
                break;

            case 5:
                // --- QUITTER L'APPLICATION ---
                // Modifier 'running' à false arrêtera le prochain tour de la boucle 'while (running)'
                running = false;
                ConsoleTheme.WriteInfo("Merci d'avoir utilisé la mini-calculatrice de notes. À bientôt !");
                break;
        }
    }
    // =========================================================================
    // CAPTURE DES EXCEPTIONS (DU PLUS SPÉCIFIQUE AU PLUS GÉNÉRIQUE)
    // =========================================================================
    catch (EmptyGradeListException ex)
    {
        // Capture ciblée de notre exception métier personnalisée
        ConsoleSound.PlayError();
        ConsoleTheme.WriteWarning($"[ATTENTION] {ex.Message}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        // Capture des erreurs de paramètres numériques invalides
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR] Paramètre invalide : {ex.Message}");
    }
    catch (Exception ex)
    {
        // Catch global "filet de sécurité" pour toute autre erreur imprévue
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR] Une erreur inattendue est survenue : {ex.Message}");
    }

    // Pause d'affichage entre chaque opération du menu si l'utilisateur n'a pas quitté
    if (running)
    {
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        // intercept: true masque la touche pressée à l'écran
        Console.ReadKey(intercept: true);
        ConsoleTheme.ApplyTheme();
    }
}

// Nettoyage final des couleurs et réinitialisation de la console avant de quitter
ConsoleTheme.Reset();

