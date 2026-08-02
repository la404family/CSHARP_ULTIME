namespace Devine.Services;

/// <summary>
/// La classe GameEngine représente la "Logique Métier" (Business Logic).
/// Elle ne gère aucun affichage (pas de Console.WriteLine ici), son seul but est de 
/// conserver l'état du jeu et de faire des calculs. 
/// C'est le principe de responsabilité unique (Single Responsibility Principle).
/// </summary>
public class GameEngine
{
    // ---------------------------------------------------
    // ENCAPSULATION : Les variables d'état sont 'private'. 
    // Elles ne peuvent pas être modifiées accidentellement par un autre fichier.
    // ---------------------------------------------------
    private int _secretNumber;
    private int _attempts;

    // Propriété publique en lecture seule (get). 
    // Permet à 'Program.cs' de lire le nombre d'essais sans pouvoir le modifier.
    public int Attempts => _attempts;

    /// <summary>
    /// Initialise une nouvelle partie en générant un nombre et en remettant le compteur à zéro.
    /// </summary>
    public void StartNewGame()
    {
        // CHOIX TECHNIQUE : 'Random.Shared' (disponible depuis .NET 6)
        // C'est une instance statique thread-safe, beaucoup plus optimisée que de faire 
        // 'new Random()' à chaque fois. Le second paramètre (101) est exclusif.
        _secretNumber = Random.Shared.Next(1, 101);
        _attempts = 0;
    }

    /// <summary>
    /// Évalue la proposition du joueur par rapport au nombre secret.
    /// Retourne un statut sous forme de texte qui sera interprété par l'affichage.
    /// </summary>
    public string EvaluateGuess(int guess)
    {
        _attempts++; // Incrémentation du compteur d'essais

        if (guess < _secretNumber)
        {
            return "trop petit";
        }
        else if (guess > _secretNumber)
        {
            return "trop grand";
        }
        else
        {
            return "gagné";
        }
    }
}
