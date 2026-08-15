using System;
using Roguelike.Engine;
using Roguelike.UI;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur : Ce programme doit être lancé avec des arguments ('map' ou 'ui').");
                Console.WriteLine("Veuillez utiliser le fichier 'roguelike_start.bat' pour démarrer le jeu.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            string mode = args[0].ToLower();

            // 1. Positionnement et dimensionnement de la console
            WindowManager.InitializeConsole(mode);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 2. Lancement du moteur de jeu
            GameManager gameManager = new GameManager(mode);
            gameManager.Start();
        }
    }
}
