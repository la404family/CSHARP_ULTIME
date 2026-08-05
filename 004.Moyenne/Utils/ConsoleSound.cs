namespace Moyenne.Utils;

/// <summary>
/// Service utilitaire pour les retours sonores (UX) dans la console.
/// </summary>
public static class ConsoleSound
{
    /// <summary>
    /// Joue un son de confirmation d'entrée valide.
    /// </summary>
    public static void PlaySuccess()
    {
        if (!OperatingSystem.IsWindows()) return;
        try
        {
            Console.Beep(800, 100);
        }
        catch { /* Ignoré si l'appareil n'a pas de haut-parleur système */ }
    }

    /// <summary>
    /// Joue un son d'erreur d'entrée invalide.
    /// </summary>
    public static void PlayError()
    {
        if (!OperatingSystem.IsWindows()) return;
        try
        {
            Console.Beep(300, 250);
        }
        catch { /* Ignoré si l'appareil n'a pas de haut-parleur système */ }
    }

    /// <summary>
    /// Joue un son lors de l'affichage des résultats statistiques.
    /// </summary>
    public static void PlayStats()
    {
        if (!OperatingSystem.IsWindows()) return;
        try
        {
            Console.Beep(523, 100); // Do
            Console.Beep(659, 100); // Mi
            Console.Beep(784, 150); // Sol
        }
        catch { /* Ignoré si l'appareil n'a pas de haut-parleur système */ }
    }
}
