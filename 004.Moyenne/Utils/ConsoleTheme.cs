using System.Text;

namespace Moyenne.Utils;

/// <summary>
/// Service utilitaire pour la gestion des couleurs et de l'encodage graphique dans la console.
/// Configure l'encodage UTF-8 pour éviter les caractères corrompus (??) sous Windows.
/// </summary>
public static class ConsoleTheme
{
    // Thème de couleur pour la Mini-calculatrice de notes : Fond Noir, Texte Jaune.
    private const ConsoleColor DefaultBackground = ConsoleColor.Black;
    private const ConsoleColor DefaultForeground = ConsoleColor.Yellow;

    /// <summary>
    /// Applique le thème de couleur par défaut, règle l'encodage UTF-8 et efface le terminal.
    /// </summary>
    public static void ApplyTheme()
    {
        try
        {
            // Configure la console Windows en UTF-8 pour supporter les caractères spéciaux et symboles
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        catch
        {
            // Ignoré si le terminal restreint la modification de codepage
        }

        Console.BackgroundColor = DefaultBackground;
        Console.ForegroundColor = DefaultForeground;
        Console.Clear();
    }

    /// <summary>
    /// Restaure les couleurs d'origine de la console.
    /// </summary>
    public static void Reset()
    {
        Console.ResetColor();
        Console.Clear();
    }

    /// <summary>
    /// Affiche un message d'erreur en rouge.
    /// </summary>
    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }

    /// <summary>
    /// Affiche un message de succès en vert.
    /// </summary>
    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }

    /// <summary>
    /// Affiche une information ou un titre en cyan.
    /// </summary>
    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }

    /// <summary>
    /// Affiche une mise en garde en magenta.
    /// </summary>
    public static void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }
}
