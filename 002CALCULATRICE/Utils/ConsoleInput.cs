using System.Globalization;

// On place ce fichier dans le namespace Utils car il contient des outils liés à l'interface utilisateur (Console).
namespace Calculatrice.Utils;

public static class ConsoleInput
{
    // Fonction qui demande, lit et valide un nombre. 
    // Elle renvoie obligatoirement un 'double'.
    public static double GetNumber(string message)
    {
        // 'while (true)' crée une boucle infinie. 
        // On n'en sortira que lorsqu'un 'return' ou un 'Environment.Exit' sera exécuté.
        while (true)
        {
            // Affiche le message sans passer à la ligne (contrairement à WriteLine).
            Console.Write(message);
            
            // Lit la frappe au clavier jusqu'à ce que l'utilisateur appuie sur Entrée.
            // 'string?' : Le point d'interrogation signifie que la variable peut être 'null' (vide ou annulée).
            string? input = Console.ReadLine();
            
            // 1. Gestion de l'interruption : Si l'utilisateur tue l'application (Ctrl+Z), 'input' sera null.
            if (input == null)
            {
                // 'Environment.Exit(0)' coupe le programme immédiatement avec le code 0 (qui signifie "tout s'est bien passé").
                Environment.Exit(0);
            }

            // Remplace les virgules éventuelles par des points pour faciliter la conversion.
            string normalizedInput = input.Replace(',', '.');
            
            // 'double.TryParse' essaie de convertir la chaîne de caractères (string) en nombre décimal (double).
            // - NumberStyles.Any : Accepte les nombres négatifs, les espaces blancs, etc.
            // - CultureInfo.InvariantCulture : Force l'utilisation du point '.' comme séparateur (standard américain/international).
            // - 'out double result' : Si la conversion réussit, la méthode range le résultat directement dans la nouvelle variable 'result'.
            if (double.TryParse(normalizedInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                // Saisie valide : on émet le petit son de succès et on retourne la valeur 
                // (le fait de faire un 'return' casse instantanément la boucle while).
                ConsoleSound.PlaySuccess();
                return result;
            }
            
            // Si le code arrive ici, c'est que TryParse a renvoyé 'false' (la saisie était par exemple "A" ou un texte vide).
            // On joue le son d'erreur, on affiche le message rouge, et la boucle while recommence à son point de départ.
            ConsoleSound.PlayError();
            ConsoleTheme.WriteError("Erreur : veuillez entrer un nombre valide.");
        }
    }

    // Fonction qui demande et valide un opérateur (+, -, *, /)
    // Elle renvoie une 'string' contenant l'opérateur.
    public static string GetOperator()
    {
        while (true)
        {
            Console.Write("Saisissez un opérateur (+, -, *, /) : ");
            
            // Pareil, 'string?' permet d'accepter potentiellement un flux interrompu (null).
            string? op = Console.ReadLine();
            
            if (op == null)
            {
                Environment.Exit(0);
            }
            
            // '||' signifie "OU". On vérifie que 'op' correspond strictement à l'une de ces 4 chaînes.
            if (op == "+" || op == "-" || op == "*" || op == "/")
            {
                ConsoleSound.PlaySuccess();
                return op; // Casse la boucle et renvoie l'opérateur validé.
            }
            
            // Si ce n'est pas un de ces 4 caractères, c'est une erreur.
            ConsoleSound.PlayError();
            ConsoleTheme.WriteError("Erreur : opérateur non reconnu.");
        }
    }
}
