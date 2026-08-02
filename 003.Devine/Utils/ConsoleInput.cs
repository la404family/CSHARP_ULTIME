namespace Devine.Utils;

/// <summary>
/// Boîte à outils statique pour gérer les interactions avec l'utilisateur.
/// Le choix technique de faire une classe 'static' signifie qu'on n'a pas 
/// besoin de faire un 'new ConsoleInput()' pour l'utiliser.
/// 
/// COMPARAISON avec le projet 002 (Calculatrice) :
/// - On retrouve le même pattern 'while (true)' + 'return' qui refuse de rendre la main
///   tant que la saisie n'est pas strictement valide.
/// - On ajoute ici la validation de la plage (1-100), spécifique au jeu "Devine le nombre".
/// </summary>
public static class ConsoleInput
{
    /// <summary>
    /// Demande un nombre au joueur de manière sécurisée (Programmation Défensive).
    /// La saisie est validée sur 3 critères : non-vide, entier valide, et dans la plage 1-100.
    /// </summary>
    public static int AskForGuess(string message)
    {
        // 'while (true)' crée une boucle infinie contrôlée.
        // On n'en sortira que lorsqu'un 'return' sera exécuté (saisie valide).
        // C'est le même pattern que dans ConsoleInput.GetNumber du projet 002 (Calculatrice).
        while (true)
        {
            // 'Write' (sans "Line") affiche le texte sans passer à la ligne, 
            // pour que le curseur reste juste après le message.
            Console.Write(message);

            // 'string?' : Le '?' signifie que la variable peut être 'null' (vide ou annulée).
            string? input = Console.ReadLine();

            // 1. Gestion de l'interruption : Si l'utilisateur tue l'application (Ctrl+Z sous Windows),
            // 'ReadLine()' renvoie null. Sans cette vérification, le programme planterait.
            if (input is null)
            {
                Environment.Exit(0);
            }

            // 2. Validation du format : 'int.TryParse' essaie de convertir le texte en nombre entier.
            // Contrairement à 'int.Parse' qui lèverait une exception (crash) sur une entrée invalide,
            // 'TryParse' renvoie simplement 'false' et laisse le programme continuer.
            // 'out int result' : si la conversion réussit, le résultat est rangé directement dans 'result'.
            if (int.TryParse(input, out int result))
            {
                // 3. Validation de la plage : le nombre secret est entre 1 et 100,
                // donc on refuse toute proposition en dehors de cette plage.
                if (result >= 1 && result <= 100)
                {
                    ConsoleSound.PlaySuccess();
                    return result; // Sort de la boucle et renvoie la valeur validée.
                }

                // Le nombre est un entier valide, mais hors de la plage autorisée.
                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : Le nombre doit être compris entre 1 et 100.");
            }
            else
            {
                // La saisie n'est pas un nombre entier (lettres, symboles, chaîne vide...).
                ConsoleSound.PlayError();
                ConsoleTheme.WriteError("Erreur : Saisie invalide. Veuillez entrer un nombre entier (ex: 42).");
            }
        }
    }
}
