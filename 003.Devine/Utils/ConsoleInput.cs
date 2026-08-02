namespace Devine.Utils;

/// <summary>
/// Boîte à outils statique pour gérer les interactions avec l'utilisateur.
/// Le choix technique de faire une classe 'static' signifie qu'on n'a pas 
/// besoin de faire un 'new ConsoleInput()' pour l'utiliser.
/// </summary>
public static class ConsoleInput
{
    /// <summary>
    /// Demande un nombre à l'utilisateur de manière sécurisée (Programmations Défensive).
    /// </summary>
    public static int AskForNumber(string message)
    {
        int result = 0;
        bool isValid = false;

        // Boucle infinie "contrôlée" : on ne sort de la boucle que si la saisie est valide.
        while (!isValid)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            // CHOIX TECHNIQUE : 'int.TryParse' au lieu de 'int.Parse'.
            // - int.Parse("bonjour") fait planter le programme (Exception).
            // - int.TryParse("bonjour", out result) renvoie juste 'false' sans planter.
            // On vérifie aussi que l'entrée n'est pas vide (IsNullOrWhiteSpace).
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out result))
            {
                isValid = true;
            }
            else
            {
                // Si la saisie n'est pas un nombre, on affiche une erreur et la boucle recommence
                PrintColoredMessage("Erreur : Saisie invalide. Veuillez entrer un nombre entier (ex: 42).", "erreur");
            }
        }

        return result;
    }

    /// <summary>
    /// Affiche un texte avec une couleur différente selon le statut.
    /// </summary>
    public static void PrintColoredMessage(string message, string status = "base")
    {
        // CHOIX TECHNIQUE : 'switch' plutôt que plein de 'if / else if'.
        // C'est beaucoup plus lisible quand on a de multiples conditions 
        // basées sur la valeur d'une seule variable.
        switch (status.ToLower())
        {
            case "trop grand":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "trop petit":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case "erreur":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "gagné":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case "base":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        Console.WriteLine(message);
        Console.ResetColor(); // Important : remettre la couleur par défaut après !
    }
}
