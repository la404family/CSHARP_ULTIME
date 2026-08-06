namespace Moyenne.Utils;

/// <summary>
/// Service utilitaire statique pour la saisie et la validation sécurisée des notes et des choix de menu dans la console.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Paramètre 'out' : Permet à une méthode de retourner plusieurs valeurs (ex: bool pour le succès + double pour le résultat).
/// - Mot-clé 'return' : Arrête l'exécution de la boucle infinie (while(true)) et renvoie le résultat à l'appelant.
/// - TryParse : Méthode sécurisée de conversion qui évite de faire crasher le programme si la saisie est invalide.
/// - InvariantCulture : Garantit la cohérence des nombres décimaux (ex: gestion du point '.' vs virgule ',').
/// </summary>
public static class ConsoleInput
{
    /// <summary>
    /// Demande à l'utilisateur de saisir une note comprise entre 0.0 et 20.0,
    /// ou de saisir 'Q' pour annuler l'opération.
    /// </summary>
    /// <param name="message">Le message d'invite affiché à la console.</param>
    /// <param name="grade">
    /// PARAMÈTRE 'out' : Transmet la note analysée à la variable passée par l'appelant.
    /// Une variable 'out' DOIT obligatoirement être assignée avant de quitter la méthode via 'return'.
    /// </param>
    /// <returns>
    /// bool : 
    /// - 'return true' si une note valide a été saisie et stockée dans 'grade'.
    /// - 'return false' si l'utilisateur a saisi 'Q' pour annuler.
    /// </returns>
    public static bool TryAskForGrade(string message, out double grade)
    {
        // Boucle infinie : continue de demander tant que la saisie n'est pas valide ou annulée.
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            // Vérification de flux fermé / EOF (ex: Ctrl+C)
            if (input is null)
            {
                Environment.Exit(0); // Quitte prématurément l'application si l'entrée système est fermée
            }

            // Nettoie les espaces inutiles au début et à la fin de la chaîne
            string trimmedInput = input.Trim();

            // Vérification de la touche d'annulation 'Q' ou 'q'
            if (trimmedInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                // POURQUOI ASSIGNER grade = 0.0 ?
                // En C#, tout paramètre 'out' doit être initialisé avant CHAQUE instruction 'return'.
                grade = 0.0;
                
                // POURQUOI RETURN FALSE ?
                // Indique à l'appelant (Program.cs) que l'opération a été annulée volontairement.
                return false; 
            }

            // Remplacement de la virgule par un point pour harmoniser les nombres décimaux
            // double.TryParse tente de convertir la chaîne en nombre décimal sans lever d'exception.
            // CultureInfo.InvariantCulture s'assure que le séparateur décimal attendu est le point (ex: 14.5).
            if (double.TryParse(trimmedInput.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double parsedValue))
            {
                // Validation métier : la note doit être entre 0.0 et 20.0 inclusivement
                if (parsedValue >= 0.0 && parsedValue <= 20.0)
                {
                    ConsoleSound.PlaySuccess();
                    
                    // Assignation de la valeur à la variable de sortie 'out'
                    grade = parsedValue;
                    
                    // POURQUOI RETURN TRUE ?
                    // Arrête immédiatement la boucle 'while (true)' et indique à Program.cs que l'ajout a réussi.
                    return true;
                }

                // Si hors intervalle [0, 20]
                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : La note doit être comprise entre 0.0 et 20.0.");
            }
            else
            {
                // Si la saisie n'est pas du tout un nombre (ex: "abc")
                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : Format numérique invalide. Exemple attendu : 14.5 ou 15");
            }
        }
    }

    /// <summary>
    /// Demande une option de menu valide parmi un intervalle d'entiers [minChoice, maxChoice].
    /// </summary>
    /// <param name="prompt">Le message d'invite.</param>
    /// <param name="minChoice">L'option minimale acceptée (ex: 1).</param>
    /// <param name="maxChoice">L'option maximale acceptée (ex: 5).</param>
    /// <returns>L'entier représentant le choix valide de l'utilisateur.</returns>
    public static int AskForMenuOption(string prompt, int minChoice, int maxChoice)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            // int.TryParse tente de convertir l'entrée textuelle en nombre entier.
            // La condition && (ET logique) vérifie aussi si le choix est dans l'intervalle autorisé.
            if (int.TryParse(input, out int choice) && choice >= minChoice && choice <= maxChoice)
            {
                ConsoleSound.PlaySuccess();

                // POURQUOI RETURN CHOICE ?
                // Sort immédiatement de la boucle 'while (true)' et renvoie l'entier validé à Program.cs
                // pour alimenter l'instruction 'switch (option)'.
                return choice;
            }

            // Si le choix n'est pas un nombre ou est hors limites
            ConsoleSound.PlayError();
            ConsoleTheme.WriteError($"Erreur : Veuillez choisir une option entre {minChoice} et {maxChoice}.");
        }
    }
}

