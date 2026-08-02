namespace Devine.Utils;

/// <summary>
/// Gestion de l'identité visuelle de la console.
/// Ce fichier reprend le même principe que dans le projet 002 (Calculatrice) :
/// on isole tout ce qui touche aux couleurs dans un utilitaire dédié,
/// pour que 'Program.cs' et 'GameEngine.cs' n'aient jamais à manipuler les couleurs eux-mêmes.
/// </summary>
public static class ConsoleTheme
{
    // Applique le thème principal (Cyan sur fond Noir) et efface l'écran par défaut.
    // Le paramètre optionnel 'clearConsole' permet de changer les couleurs sans perdre l'historique affiché.
    public static void ApplyTheme(bool clearConsole = true)
    {
        // 'ConsoleColor' est un Enum (énumération) qui liste toutes les couleurs possibles du terminal.
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;

        // 'Console.Clear()' est nécessaire pour que la couleur d'arrière-plan remplisse 
        // l'intégralité de la fenêtre, pas seulement l'arrière des lettres que l'on tape.
        if (clearConsole)
        {
            Console.Clear();
        }
    }

    /// <summary>
    /// Affiche un indice de jeu avec une couleur adaptée à la direction.
    /// </summary>
    public static void WriteHint(string message, bool isTooHigh)
    {
        // On change la couleur temporairement selon le type d'indice :
        // - Jaune pour "C'est plus !" (le joueur doit monter)
        // - Magenta pour "C'est moins !" (le joueur doit descendre)
        Console.ForegroundColor = isTooHigh ? ConsoleColor.Magenta : ConsoleColor.Yellow;
        Console.WriteLine(message);

        // On remet le thème sans effacer l'écran, pour conserver l'historique des essais.
        ApplyTheme(clearConsole: false);
    }

    /// <summary>
    /// Affiche le message de victoire dans une couleur éclatante.
    /// </summary>
    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        ApplyTheme(clearConsole: false);
    }

    /// <summary>
    /// Affiche un message d'erreur en rouge (saisie invalide, hors plage, etc.).
    /// Même principe que 'WriteError' dans le projet 002 (Calculatrice).
    /// </summary>
    public static void WriteError(string message)
    {
        // On passe temporairement en rouge vif pour attirer l'attention sur l'erreur.
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);

        // On restaure le thème principal sans effacer l'écran,
        // permettant à l'utilisateur de relire son erreur au-dessus.
        ApplyTheme(clearConsole: false);
    }

    /// <summary>
    /// Remet la console dans son état d'origine (généralement Noir/Blanc).
    /// Appelée à la toute fin du programme pour "nettoyer" le terminal de l'utilisateur.
    /// </summary>
    public static void Reset()
    {
        // Méthode native pour annuler toutes les couleurs personnalisées imposées précédemment.
        Console.ResetColor();
        Console.Clear();
    }
}
