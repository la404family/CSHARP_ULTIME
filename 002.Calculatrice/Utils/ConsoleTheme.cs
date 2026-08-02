namespace Calculatrice.Utils;

public static class ConsoleTheme
{
    // Méthode pour appliquer les couleurs jaunes sur fond noir.
    // 'bool clearConsole = true' est un paramètre "optionnel" (avec valeur par défaut). 
    // Si on l'appelle sans lui fournir de paramètre, il vaudra 'true' par défaut.
    public static void ApplyTheme(bool clearConsole = true)
    {
        // Propriété statique de la classe native 'Console' qui gère la couleur d'arrière-plan.
        // 'ConsoleColor' est un Enum (une énumération) qui liste de manière stricte toutes les couleurs possibles du terminal.
        Console.BackgroundColor = ConsoleColor.Yellow;
        
        // Propriété pour la couleur du texte (avant-plan).
        Console.ForegroundColor = ConsoleColor.Black;
        
        // Si clearConsole est vrai, on efface tout l'écran. 
        // C'est nécessaire pour que la couleur d'arrière-plan remplisse l'intégralité de la fenêtre 
        // et pas seulement l'arrière des lettres que l'on tape.
        if (clearConsole)
        {
            Console.Clear();
        }
    }

    // Affiche un message d'erreur de façon temporaire en rouge.
    public static void WriteError(string message)
    {
        // On change temporairement les couleurs pour attirer l'attention (Fond rouge, texte blanc)
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        
        // On affiche l'erreur à l'écran
        Console.WriteLine(message);
        
        // On rappelle ApplyTheme pour remettre le Jaune/Noir pour la suite du programme,
        // mais on passe explicitement 'false' pour ne PAS effacer l'écran, ce qui permet
        // à l'utilisateur de pouvoir lire son message d'erreur.
        ApplyTheme(clearConsole: false);
    }

    // Remet la console dans son état d'origine (généralement Noir/Blanc)
    public static void Reset()
    {
        // Méthode native pour annuler toutes les couleurs personnalisées imposées précédemment.
        Console.ResetColor();
        Console.Clear();
    }
}
