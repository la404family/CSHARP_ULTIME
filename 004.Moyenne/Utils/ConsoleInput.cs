namespace Moyenne.Utils;

/// <summary>
/// Service utilitaire pour la saisie et validation des notes et choix dans le menu console.
/// </summary>
public static class ConsoleInput
{
    /// <summary>
    /// Demande à l'utilisateur de saisir une note comprise entre 0.0 et 20.0,
    /// ou de saisir 'Q' pour annuler l'opération.
    /// </summary>
    /// <param name="message">Le message d'invite affiché à l'écran.</param>
    /// <param name="grade">La note obtenue en cas de succès.</param>
    /// <returns>True si une note valide a été saisie, False si l'utilisateur a annulé ('Q').</returns>
    public static bool TryAskForGrade(string message, out double grade)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            string trimmedInput = input.Trim();

            if (trimmedInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                grade = 0.0;
                return false;
            }

            // Remplace la virgule par un point ou gère le format décimal selon le système local
            if (double.TryParse(trimmedInput.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double parsedValue))
            {
                if (parsedValue >= 0.0 && parsedValue <= 20.0)
                {
                    ConsoleSound.PlaySuccess();
                    grade = parsedValue;
                    return true;
                }

                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : La note doit être comprise entre 0.0 et 20.0.");
            }
            else
            {
                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : Format numérique invalide. Exemple attendu : 14.5 ou 15");
            }
        }
    }

    /// <summary>
    /// Demande une option de menu parmi un intervalle d'entiers.
    /// </summary>
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

            if (int.TryParse(input, out int choice) && choice >= minChoice && choice <= maxChoice)
            {
                ConsoleSound.PlaySuccess();
                return choice;
            }

            ConsoleSound.PlayError();
            ConsoleTheme.WriteError($"Erreur : Veuillez choisir une option entre {minChoice} et {maxChoice}.");
        }
    }
}
