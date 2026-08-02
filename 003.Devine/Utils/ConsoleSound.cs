namespace Devine.Utils;

/// <summary>
/// Gère le retour sonore de l'application, exactement comme dans le projet 002 (Calculatrice).
/// Chaque interaction importante produit un son différent pour guider le joueur "à l'oreille".
/// </summary>
public static class ConsoleSound
{
    /// <summary>
    /// Son bref et aigu pour confirmer qu'une saisie est acceptée.
    /// </summary>
    public static void PlaySuccess()
    {
        // 'OperatingSystem.IsWindows()' (C# 9+) : Console.Beep(fréquence, durée) n'est supporté 
        // nativement que sous Windows. Sur Linux/Mac, on se rabat sur le Beep système standard.
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(800, 200);
        }
        else
        {
            Console.Beep();
        }
    }

    /// <summary>
    /// Son grave et long pour signaler une erreur de saisie.
    /// </summary>
    public static void PlayError()
    {
        if (OperatingSystem.IsWindows())
        {
            // Fréquence basse (300 Hz) pendant plus longtemps (500ms) : effet "buzzer".
            Console.Beep(300, 500);
        }
        else
        {
            Console.Beep();
        }
    }

    /// <summary>
    /// Son court pour accompagner un indice ("C'est plus" / "C'est moins").
    /// Un petit bip neutre qui signale "essaie encore !".
    /// </summary>
    public static void PlayHint()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(600, 150);
        }
        else
        {
            Console.Beep();
        }
    }

    /// <summary>
    /// Mélodie de victoire jouée quand le joueur devine le bon nombre.
    /// Un arpège montant (Do-Mi-Sol-Do) pour célébrer la réussite.
    /// </summary>
    public static void PlayVictory()
    {
        if (OperatingSystem.IsWindows())
        {
            // Les sons sont synchrones : chaque Beep bloque l'exécution le temps de jouer,
            // ce qui garantit un enchaînement parfait sans superposition.
            Console.Beep(523, 150);  // Do
            Console.Beep(659, 150);  // Mi
            Console.Beep(784, 150);  // Sol
            Console.Beep(1047, 400); // Do (octave supérieure, tenu plus longtemps)
        }
        else
        {
            Console.Beep();
        }
    }
}
