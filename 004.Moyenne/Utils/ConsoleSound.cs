namespace Moyenne.Utils;

/// <summary>
/// Service utilitaire statique pour les retours sonores (UX) dans la console.
/// </summary>
public static class ConsoleSound
{
    /// <summary>
    /// Joue un son de confirmation d'entrée valide.
    /// </summary>
    public static void PlaySuccess()
    {
        // =========================================================================
        // UTILISATION DU RETURN DANS UNE MÉTHODE VOID (Guard Clause)
        // =========================================================================
        // Si le système d'exploitation n'est pas Windows (ex: Linux ou macOS),
        // 'return' sans valeur met immédiatement fin à l'exécution de la méthode.
        // Cela évite d'exécuter Console.Beep qui est spécifique à Windows.
        // =========================================================================
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            // Console.Beep(fréquence_Hz, durée_ms)
            Console.Beep(800, 100);
        }
        catch 
        { 
            /* Ignoré silencieusement si l'appareil n'a pas de haut-parleur système ou si la console est redirigée */ 
        }
    }

    /// <summary>
    /// Joue un son d'erreur d'entrée invalide.
    /// </summary>
    public static void PlayError()
    {
        // Sortie anticipée si non-Windows
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            Console.Beep(300, 250);
        }
        catch 
        { 
            /* Ignoré silencieusement */ 
        }
    }

    /// <summary>
    /// Joue un son arpégé lors de l'affichage des résultats statistiques.
    /// </summary>
    public static void PlayStats()
    {
        if (!OperatingSystem.IsWindows()) return;

        try
        {
            // Note Do (523 Hz), Mi (659 Hz), Sol (784 Hz)
            Console.Beep(523, 100); 
            Console.Beep(659, 100); 
            Console.Beep(784, 150); 
        }
        catch 
        { 
            /* Ignoré silencieusement */ 
        }
    }
}

