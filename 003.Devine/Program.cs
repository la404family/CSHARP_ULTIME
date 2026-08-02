using Devine.Services;
using Devine.Utils;

// ========================================================================
// Projet 003 : Devine le nombre (Version Modulaire)
// ------------------------------------------------------------------------
// Ce fichier 'Program.cs' utilise les "Top-level statements" (C# 9+).
// Son rôle est d'agir comme un "Contrôleur" : il orchestre la vue (la console)
// et le modèle (GameEngine), mais il ne fait aucun calcul mathématique lui-même.
// ========================================================================

Console.WriteLine("======================================");
Console.WriteLine("   BIENVENUE DANS DEVINE LE NOMBRE !");
Console.WriteLine("======================================\n");

// Instanciation du moteur de jeu. 
// On crée un "objet" GameEngine qui va mémoriser notre partie en cours.
bool playAgain = true;

while (playAgain)
{
    engine.StartNewGame();
    bool isGameOver = false;

    Console.WriteLine("\nJ'ai choisi un nombre entre 1 et 100. À vous de deviner !");

    while (!isGameOver)
    {
        int guess = ConsoleInput.AskForNumber("\nVotre proposition : ");
        string status = engine.EvaluateGuess(guess);

        if (status == "trop petit")
        {
            ConsoleInput.PrintColoredMessage("C'est plus !", status);
        }
        else if (status == "trop grand")
        {
            ConsoleInput.PrintColoredMessage("C'est moins !", status);
        }
        else if (status == "gagné")
        {
            ConsoleInput.PrintColoredMessage($"Bravo ! Vous avez trouvé le nombre en {engine.Attempts} essai(s) !", "gagné");
            isGameOver = true;
        }
    }

    Console.WriteLine("\nVoulez-vous rejouer ? (O/N)");
    string? response = Console.ReadLine();
    if (response?.Trim().ToLower() == "n")
    {
        playAgain = false;
    }
}

Console.WriteLine("\nMerci d'avoir joué ! Appuyez sur ENTRÉE pour fermer la fenêtre...");
Console.ReadLine(); // Empêche la fenêtre .exe de se fermer toute seule !
