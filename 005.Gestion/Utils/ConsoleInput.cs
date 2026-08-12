using System.Globalization;

namespace Gestion.Utils;

/// <summary>
/// Service utilitaire statique pour la saisie et la validation sécurisée
/// des données de l'inventaire et des choix de menu dans la console.
/// 
/// CONCEPTS CLÉS EXPLIQUÉS :
/// - Paramètre 'out' : Permet à une méthode de retourner plusieurs valeurs (ex: bool pour le succès + string/decimal/int pour le résultat).
/// - Mot-clé 'return' : Arrête l'exécution de la boucle infinie (while(true)) et renvoie le résultat à l'appelant.
/// - Pattern TryXxx : Convention C# où une méthode renvoie un bool (succès/échec) et fournit le résultat via 'out'.
/// - TryParse : Méthode sécurisée de conversion qui évite de faire crasher le programme si la saisie est invalide.
/// - InvariantCulture : Garantit la cohérence des nombres décimaux (gestion du point '.' vs virgule ',').
/// </summary>
public static class ConsoleInput
{
    /// <summary>
    /// Demande un choix de menu entier compris dans l'intervalle [minChoice, maxChoice].
    /// </summary>
    /// <param name="prompt">Le message d'invite affiché.</param>
    /// <param name="minChoice">L'option minimale acceptée (ex: 1).</param>
    /// <param name="maxChoice">L'option maximale acceptée (ex: 6).</param>
    /// <returns>L'entier représentant le choix valide de l'utilisateur.</returns>
    public static int AskForMenuOption(string prompt, int minChoice, int maxChoice)
    {
        // Boucle infinie : continue de demander tant que la saisie n'est pas valide.
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            // Vérification de flux fermé / EOF (ex: Ctrl+C)
            if (input is null) Environment.Exit(0);

            // int.TryParse tente de convertir l'entrée textuelle en nombre entier.
            // La condition && (ET logique) vérifie aussi si le choix est dans l'intervalle autorisé.
            if (int.TryParse(input.Trim(), out int choice) && choice >= minChoice && choice <= maxChoice)
            {
                ConsoleSound.PlaySuccess();

                // POURQUOI RETURN CHOICE ?
                // Sort immédiatement de la boucle 'while (true)' et renvoie l'entier validé à Program.cs
                // pour alimenter l'instruction 'switch (option)'.
                return choice;
            }

            ConsoleSound.PlayError();
            ConsoleTheme.WriteError($"Choix invalide. Veuillez entrer un nombre entre {minChoice} et {maxChoice}.");
        }
    }

    /// <summary>
    /// Demande la saisie d'un texte non vide (ex: nom d'un article).
    /// L'utilisateur peut saisir 'Q' pour annuler l'opération en cours.
    /// </summary>
    /// <param name="prompt">Le message d'invite affiché à la console.</param>
    /// <param name="result">
    /// PARAMÈTRE 'out' : Transmet le texte validé à la variable passée par l'appelant.
    /// Une variable 'out' DOIT obligatoirement être assignée avant de quitter la méthode via 'return'.
    /// </param>
    /// <returns>
    /// bool : 
    /// - 'return true' si un texte valide a été saisi et stocké dans 'result'.
    /// - 'return false' si l'utilisateur a saisi 'Q' pour annuler.
    /// </returns>
    public static bool TryAskForString(string prompt, out string result)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null) Environment.Exit(0);

            // Nettoie les espaces inutiles au début et à la fin de la chaîne
            string trimmed = input.Trim();

            // Vérification de la touche d'annulation 'Q' ou 'q'
            if (trimmed.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                // POURQUOI ASSIGNER result = string.Empty ?
                // En C#, tout paramètre 'out' doit être initialisé avant CHAQUE instruction 'return'.
                result = string.Empty;

                // POURQUOI RETURN FALSE ?
                // Indique à l'appelant (Program.cs) que l'opération a été annulée volontairement.
                return false;
            }

            if (!string.IsNullOrWhiteSpace(trimmed))
            {
                ConsoleSound.PlaySuccess();

                // Assignation de la valeur à la variable de sortie 'out'
                result = trimmed;

                // POURQUOI RETURN TRUE ?
                // Arrête immédiatement la boucle 'while (true)' et indique à Program.cs que la saisie a réussi.
                return true;
            }

            ConsoleSound.PlayError();
            ConsoleTheme.WriteError("Erreur : La saisie ne peut pas être vide.");
        }
    }

    /// <summary>
    /// Demande la saisie d'un nombre décimal positif (ex: prix unitaire d'un article).
    /// L'utilisateur peut saisir 'Q' pour annuler l'opération en cours.
    /// </summary>
    /// <param name="prompt">Le message d'invite affiché à la console.</param>
    /// <param name="result">
    /// PARAMÈTRE 'out' : Transmet la valeur décimale validée à la variable passée par l'appelant.
    /// </param>
    /// <param name="minValue">Valeur minimale acceptée (par défaut 0m, interdisant les valeurs négatives).</param>
    /// <returns>
    /// bool :
    /// - 'return true' si un montant valide a été saisi et stocké dans 'result'.
    /// - 'return false' si l'utilisateur a saisi 'Q' pour annuler.
    /// </returns>
    public static bool TryAskForDecimal(string prompt, out decimal result, decimal minValue = 0m)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null) Environment.Exit(0);

            string trimmed = input.Trim();

            if (trimmed.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                // Obligation d'assigner le paramètre 'out' avant 'return'
                result = 0m;
                return false;
            }

            // Remplacement de la virgule par un point pour harmoniser les nombres décimaux.
            // decimal.TryParse tente de convertir la chaîne en nombre décimal sans lever d'exception.
            // CultureInfo.InvariantCulture s'assure que le séparateur décimal attendu est le point (ex: 14.50).
            if (decimal.TryParse(trimmed.Replace(',', '.'), CultureInfo.InvariantCulture, out decimal val) && val >= minValue)
            {
                ConsoleSound.PlaySuccess();
                result = val;
                return true;
            }

            ConsoleSound.PlayError();
            ConsoleTheme.WriteError($"Erreur : Veuillez entrer un montant numérique valide (supérieur ou égal à {minValue:C2}).");
        }
    }

    /// <summary>
    /// Demande la saisie d'un nombre entier positif (ex: quantité en stock ou identifiant d'article).
    /// L'utilisateur peut saisir 'Q' pour annuler l'opération en cours.
    /// </summary>
    /// <param name="prompt">Le message d'invite affiché à la console.</param>
    /// <param name="result">
    /// PARAMÈTRE 'out' : Transmet l'entier validé à la variable passée par l'appelant.
    /// </param>
    /// <param name="minValue">Valeur minimale acceptée (par défaut 0, interdisant les valeurs négatives).</param>
    /// <returns>
    /// bool :
    /// - 'return true' si un entier valide a été saisi et stocké dans 'result'.
    /// - 'return false' si l'utilisateur a saisi 'Q' pour annuler.
    /// </returns>
    public static bool TryAskForInt(string prompt, out int result, int minValue = 0)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null) Environment.Exit(0);

            string trimmed = input.Trim();

            if (trimmed.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                result = 0;
                return false;
            }

            // int.TryParse tente de convertir la chaîne en entier sans lever d'exception.
            // La condition && vérifie aussi que la valeur est supérieure ou égale au minimum.
            if (int.TryParse(trimmed, out int val) && val >= minValue)
            {
                ConsoleSound.PlaySuccess();
                result = val;
                return true;
            }

            ConsoleSound.PlayError();
            ConsoleTheme.WriteError($"Erreur : Veuillez entrer un nombre entier valide (supérieur ou égal à {minValue}).");
        }
    }
}
