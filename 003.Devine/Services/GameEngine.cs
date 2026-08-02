namespace Devine.Services;

/// <summary>
/// Enumération représentant le résultat d'une proposition du joueur.
/// 
/// CHOIX TECHNIQUE : On utilise un 'enum' plutôt que des chaînes de caractères ("trop petit", "gagné"...)
/// car un enum est vérifié par le compilateur. Si on fait une faute de frappe dans un string, 
/// le compilateur ne la détectera jamais et le bug se manifestera silencieusement à l'exécution.
/// Avec un enum, toute erreur est repérée instantanément à la compilation.
/// </summary>
public enum GuessResult
{
    TooLow,
    TooHigh,
    Correct
}

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
    // L'opérateur '=>' crée une "expression-bodied property" : une propriété calculée
    // qui retourne directement la valeur sans avoir besoin d'un corps { get { return ... } }.
    // Permet à 'Program.cs' de lire le nombre d'essais sans pouvoir le modifier.
    public int Attempts => _attempts;

    /// <summary>
    /// Initialise une nouvelle partie en générant un nombre et en remettant le compteur à zéro.
    /// </summary>
    public void StartNewGame()
    {
        // CHOIX TECHNIQUE : 'Random.Shared' (disponible depuis .NET 6)
        // C'est une instance statique thread-safe, beaucoup plus optimisée que de faire 
        // 'new Random()' à chaque fois. Le second paramètre (101) est exclusif,
        // donc on obtient un nombre entre 1 et 100 inclus.
        _secretNumber = Random.Shared.Next(1, 101);
        _attempts = 0;
    }

    /// <summary>
    /// Évalue la proposition du joueur par rapport au nombre secret.
    /// Retourne un <see cref="GuessResult"/> qui sera interprété par l'affichage.
    /// </summary>
    public GuessResult EvaluateGuess(int guess)
    {
        _attempts++; // Incrémentation du compteur d'essais

        // CHOIX TECHNIQUE : 'switch expression' (C# 8+)
        // Même syntaxe que dans CalculatorEngine.Calculate du projet 002.
        // Le mot-clé 'true' permet d'écrire des conditions booléennes à la place 
        // de comparer une seule variable. C'est l'équivalent moderne et compact d'un if/else if/else.
        return true switch
        {
            _ when guess < _secretNumber => GuessResult.TooLow,
            _ when guess > _secretNumber => GuessResult.TooHigh,
            _ => GuessResult.Correct
        };
    }
}
