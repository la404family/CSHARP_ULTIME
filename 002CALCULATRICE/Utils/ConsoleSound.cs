namespace Calculatrice.Utils;

public static class ConsoleSound
{
    // Émet un son pour marquer la validation réussie d'une saisie.
    public static void PlaySuccess()
    {
        // 'OperatingSystem.IsWindows()' (C# 9+) permet de savoir si le programme tourne sous Windows.
        // C'est utile car sous Linux ou Mac, 'Console.Beep(fréquence, durée)' n'est pas toujours supporté 
        // et peut être ignoré silencieusement.
        if (OperatingSystem.IsWindows())
        {
            // Paramètres : Fréquence en Hertz (800 = assez aigu), Durée en millisecondes (200 = rapide)
            Console.Beep(800, 200); 
        }
        else
        {
            // Appel sans paramètre, qui émet le son de cloche (bell) standard du système d'exploitation, s'il existe.
            Console.Beep(); 
        }
    }

    // Émet un son grave pour signaler une erreur.
    public static void PlayError()
    {
        if (OperatingSystem.IsWindows())
        {
            // Fréquence basse (300) pendant plus longtemps (500ms) pour imiter un son de buzzer d'erreur.
            Console.Beep(300, 500); 
        }
        else
        {
            Console.Beep();
        }
    }

    // Émet une petite mélodie pour annoncer le résultat du calcul.
    public static void PlayResult()
    {
        if (OperatingSystem.IsWindows())
        {
            // On enchaîne 3 Beeps pour créer un arpège montant (Do, Mi, Sol) comme petit jingle de succès.
            // Le programme est "bloqué" (synchrone) pendant qu'un son joue, donc ils s'enchaînent parfaitement sans se superposer.
            Console.Beep(523, 150); // Do
            Console.Beep(659, 150); // Mi
            Console.Beep(784, 300); // Sol
        }
        else
        {
            Console.Beep();
        }
    }
}
