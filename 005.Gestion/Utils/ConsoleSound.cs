namespace Gestion.Utils;

/// <summary>
/// Service utilitaire statique pour les retours sonores (UX) dans la console.
/// Chaque méthode vérifie que le système d'exploitation est Windows avant d'émettre un son,
/// car Console.Beep(fréquence, durée) est spécifique à la plateforme Windows.
/// </summary>
public static class ConsoleSound
{
    /// <summary>
    /// Joue un son de confirmation d'entrée valide (bip aigu court).
    /// </summary>
    public static void PlaySuccess()
    {
        // =========================================================================
        // GUARD CLAUSE DANS UNE MÉTHODE VOID
        // =========================================================================
        // Si le système d'exploitation n'est pas Windows (ex: Linux ou macOS),
        // 'return' sans valeur met immédiatement fin à l'exécution de la méthode.
        // Cela évite d'exécuter Console.Beep qui est spécifique à Windows.
        // =========================================================================
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            // Console.Beep(fréquence_Hz, durée_ms) : bip aigu de 100ms
            Console.Beep(900, 100);
        }
        catch
        {
            /* Ignoré silencieusement si l'appareil n'a pas de haut-parleur système ou si la console est redirigée */
        }
    }

    /// <summary>
    /// Joue un son d'erreur d'entrée invalide (bip grave long).
    /// </summary>
    public static void PlayError()
    {
        // Sortie anticipée si non-Windows
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            // Bip grave (300 Hz) de 250ms pour signaler une erreur
            Console.Beep(300, 250);
        }
        catch
        {
            /* Ignoré silencieusement */
        }
    }

    /// <summary>
    /// Joue un son informatif arpégé (deux notes montantes) lors de l'affichage de résultats.
    /// </summary>
    public static void PlayInfo()
    {
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            // Note Ré (600 Hz) puis Sol (800 Hz) : arpège ascendant
            Console.Beep(600, 80);
            Console.Beep(800, 100);
        }
        catch
        {
            /* Ignoré silencieusement */
        }
    }
}
