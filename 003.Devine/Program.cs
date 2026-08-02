// 💡 Note sur l'architecture et les noms :
// Le dossier du projet s'appelle "003.Devine". Cependant, en C#, un espace de noms 
// (namespace) n'a pas le droit de commencer par un chiffre.
// J'ai donc choisi le nom "Devine" et je l'ai inscrit explicitement tout en haut 
// des autres fichiers que nous avons créés :
//   - Services/GameEngine.cs  (où j'ai écrit "namespace Devine.Services;")
//   - Utils/ConsoleInput.cs   (où j'ai écrit "namespace Devine.Utils;")
//   - Utils/ConsoleTheme.cs   (où j'ai écrit "namespace Devine.Utils;")
//   - Utils/ConsoleSound.cs   (où j'ai écrit "namespace Devine.Utils;")

// Les directives 'using' permettent d'importer nos espaces de noms personnalisés.
// Sans elles, on devrait taper "Devine.Services.GameEngine" au lieu de juste "GameEngine".
using Devine.Services;
using Devine.Utils;

// ========================================================================
// Projet 003 : Devine le nombre (Version Modulaire)
// ------------------------------------------------------------------------
// Ce fichier 'Program.cs' utilise les "Top-level statements" (C# 9+).
// Son rôle est d'agir comme un "Contrôleur" : il orchestre la vue (la console)
// et le modèle (GameEngine), mais il ne fait aucun calcul mathématique lui-même.
// ========================================================================

// 0. INITIALISATION
// On appelle la méthode statique ApplyTheme pour colorer toute la console avant de commencer.
// Même principe que dans le projet 002 (Calculatrice).
ConsoleTheme.ApplyTheme();

Console.WriteLine("======================================");
Console.WriteLine("   BIENVENUE DANS DEVINE LE NOMBRE !");
Console.WriteLine("======================================\n");

// Instanciation du moteur de jeu. 
// On crée un "objet" GameEngine qui va mémoriser notre partie en cours.
// Le mot-clé 'new' alloue un espace en mémoire pour stocker l'état du jeu
// (le nombre secret, le compteur d'essais), et 'var' laisse le compilateur
// déduire automatiquement le type (ici GameEngine).
var engine = new GameEngine();

// 'bool' (booléen) : un type qui ne peut contenir que 'true' (vrai) ou 'false' (faux).
// On l'utilise pour contrôler la boucle "rejouer".
bool playAgain = true;

// 1. BOUCLE PRINCIPALE — UNE ITÉRATION = UNE PARTIE
while (playAgain)
{
    // On demande au moteur de générer un nouveau nombre secret et de remettre les compteurs à zéro.
    engine.StartNewGame();

    Console.WriteLine("\nJ'ai choisi un nombre entre 1 et 100. À vous de deviner !");

    // Variable sentinelle qui contrôle la boucle de devinette de la partie en cours.
    bool isGameOver = false;

    // 2. BOUCLE DE DEVINETTE — UNE ITÉRATION = UN ESSAI
    while (!isGameOver)
    {
        // On appelle notre utilitaire sécurisé pour récupérer un nombre valide entre 1 et 100.
        int guess = ConsoleInput.AskForGuess("\nVotre proposition : ");

        // On soumet la proposition au moteur de jeu et on récupère un 'GuessResult' (enum).
        // Contrairement à l'ancienne version qui renvoyait des strings ("trop petit", "gagné"...),
        // l'enum est vérifié à la compilation : impossible de faire une faute de frappe.
        GuessResult result = engine.EvaluateGuess(guess);

        // 'switch' sur un enum : le compilateur nous avertira si on oublie un cas.
        // C'est beaucoup plus sûr qu'un switch sur des chaînes de caractères.
        switch (result)
        {
            case GuessResult.TooLow:
                ConsoleSound.PlayHint();
                ConsoleTheme.WriteHint("C'est plus !", isTooHigh: false);
                break;

            case GuessResult.TooHigh:
                ConsoleSound.PlayHint();
                ConsoleTheme.WriteHint("C'est moins !", isTooHigh: true);
                break;

            case GuessResult.Correct:
                ConsoleSound.PlayVictory();
                ConsoleTheme.WriteSuccess(
                    $"Bravo ! Vous avez trouvé le nombre en {engine.Attempts} essai(s) !");
                isGameOver = true;
                break;
        }
    }

    // 3. DEMANDE DE REDÉMARRAGE
    Console.WriteLine();
    Console.WriteLine("Voulez-vous rejouer ? (Appuyez sur 'O' pour Oui, n'importe quelle autre touche pour quitter)");

    // 'ConsoleKeyInfo' est une "structure" (struct) contenant les informations sur la touche frappée.
    // 'Console.ReadKey(intercept: true)' lit la frappe mais le paramètre 'true' masque la lettre à l'écran.
    // Même approche que dans le projet 002 (Calculatrice).
    ConsoleKeyInfo key = Console.ReadKey(intercept: true);

    // 'key.Key' correspond à une énumération (ConsoleKey) représentant la touche physique du clavier.
    if (key.Key == ConsoleKey.O)
    {
        // Si la touche est 'O', on réapplique le thème (ce qui appelle Console.Clear())
        // et on recommence tout en haut de la boucle 'while (playAgain)'.
        ConsoleTheme.ApplyTheme();
    }
    else
    {
        // Si on appuie sur n'importe quelle autre touche, on met 'playAgain' à false
        // pour que la condition du 'while' échoue et qu'on sorte de la boucle.
        playAgain = false;
    }
}

// 4. RESTAURATION ET FIN
// Une fois sorti de la boucle, on nettoie les couleurs que l'on avait imposées au terminal,
// pour rendre son terminal dans son état naturel Noir/Blanc d'origine. C'est la bonne pratique !
ConsoleTheme.Reset();
