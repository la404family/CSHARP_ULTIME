using System.Text;

namespace FiltreCSV.Utils;

/// <summary>
/// Service utilitaire pour la gestion des couleurs, du thème et de l'encodage de la console.
/// </summary>
public static class ConsoleTheme
{
    private const ConsoleColor DefaultBackground = ConsoleColor.Black;
    private const ConsoleColor DefaultForeground = ConsoleColor.Cyan;

    /// <summary>
    /// Applique le thème graphique et configure l'encodage UTF-8.
    /// </summary>
    public static void ApplyTheme()
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        catch
        {
            // Ignoré si le terminal ne permet pas de changer la codepage
        }

        Console.BackgroundColor = DefaultBackground;
        Console.ForegroundColor = DefaultForeground;
        Console.Clear();
    }

    /// <summary>
    /// Réinitialise la console aux couleurs d'origine du système.
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
    /// Affiche une information ou un titre en jaune.
    /// </summary>
    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }

    /// <summary>
    /// Affiche un message d'avertissement en magenta.
    /// </summary>
    public static void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(message);
        Console.ForegroundColor = DefaultForeground;
    }
}
