using Moyenne.Exceptions;
using Moyenne.Services;
using Moyenne.Utils;

// ========================================================================
// Projet 004 : Mini-calculatrice de notes (Version Modulaire, LINQ & Exceptions)
// ------------------------------------------------------------------------
// Ce projet s'appuie sur la POO, List<T>, LINQ (Average, Min, Max), foreach
// et la gestion des exceptions métiers (try/catch + exceptions personnalisées).
// ========================================================================

// 0. INITIALISATION DU THÈME & DU MOTEUR
ConsoleTheme.ApplyTheme();

var engine = new GradeEngine();
bool running = true;

while (running)
{
    ConsoleTheme.WriteInfo("========================================");
    ConsoleTheme.WriteInfo("   MINI-CALCULATRICE DE NOTES (C#)");
    ConsoleTheme.WriteInfo("========================================\n");

    Console.WriteLine($"Nombre de notes enregistrées : {engine.Count}\n");

    Console.WriteLine("1. Ajouter une note (0 à 20)");
    Console.WriteLine("2. Afficher la liste des notes");
    Console.WriteLine("3. Calculer la moyenne, note Max et Min (LINQ)");
    Console.WriteLine("4. Vider la liste des notes");
    Console.WriteLine("5. Quitter\n");

    int option = ConsoleInput.AskForMenuOption("Votre choix (1-5) : ", 1, 5);

    Console.WriteLine();

    // Bloc try-catch englobant le traitement de l'option choisie
    try
    {
        switch (option)
        {
            case 1:
                // Saisie d'une note
                ConsoleTheme.WriteInfo("--- AJOUT D'UNE NOTE ---");
                if (ConsoleInput.TryAskForGrade("Entrez une note (entre 0.0 et 20.0, ou 'Q' pour annuler) : ", out double grade))
                {
                    engine.AddGrade(grade);
                    ConsoleTheme.WriteSuccess($"\n[OK] Note {grade:F2}/20 ajoutée avec succès !");
                }
                else
                {
                    ConsoleTheme.WriteWarning("\n[ANNULÉ] Ajout de note annulé.");
                }
                break;

            case 2:
                // Affichage de la liste via foreach
                ConsoleTheme.WriteInfo("--- LISTE DES NOTES ---");
                var grades = engine.GetGrades(); // Lève EmptyGradeListException si la liste est vide
                int index = 1;
                
                // Parcours de la collection List<T> via foreach
                foreach (double g in grades)
                {
                    Console.WriteLine($"  Note n°{index++} : {g:F2} / 20");
                }
                break;

            case 3:
                // Calculs de statistiques LINQ
                ConsoleTheme.WriteInfo("--- STATISTIQUES (LINQ) ---");
                
                // Les méthodes du moteur lèvent des exceptions si la liste est vide
                double avg = engine.CalculateAverage();
                double max = engine.GetMaxGrade();
                double min = engine.GetMinGrade();

                ConsoleSound.PlayStats();
                ConsoleTheme.WriteSuccess($"[MOYENNE] Moyenne générale   : {avg:F2} / 20");
                Console.WriteLine($"[MAX]     Note la plus haute : {max:F2} / 20");
                Console.WriteLine($"[MIN]     Note la plus basse : {min:F2} / 20");
                break;

            case 4:
                // Vider la liste
                ConsoleTheme.WriteInfo("--- VIDER LA LISTE ---");
                engine.Clear(); // Lève EmptyGradeListException si la liste est déjà vide
                ConsoleTheme.WriteSuccess("[OK] Toutes les notes ont été supprimées avec succès.");
                break;

            case 5:
                // Quitter
                running = false;
                ConsoleTheme.WriteInfo("Merci d'avoir utilisé la mini-calculatrice de notes. À bientôt !");
                break;
        }
    }
    catch (EmptyGradeListException ex)
    {
        // Capture des exceptions de domaine liées à une liste vide
        ConsoleSound.PlayError();
        ConsoleTheme.WriteWarning($"[ATTENTION] {ex.Message}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        // Capture des erreurs de paramètres invalides
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR] Paramètre invalide : {ex.Message}");
    }
    catch (Exception ex)
    {
        // Capture globale des exceptions inattendues
        ConsoleSound.PlayError();
        ConsoleTheme.WriteError($"[ERREUR] Une erreur inattendue est survenue : {ex.Message}");
    }

    if (running)
    {
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey(intercept: true);
        ConsoleTheme.ApplyTheme();
    }
}

// Nettoyage final du thème de la console
ConsoleTheme.Reset();
