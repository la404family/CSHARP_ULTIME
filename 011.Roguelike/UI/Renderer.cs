using System;
using Roguelike.Models;

namespace Roguelike.UI
{
    public class Renderer
    {
        public void DrawMapScreen(LevelData level, Player? player = null, System.Collections.Generic.List<Agent>? agents = null)
        {
            if (level == null) return;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            
            // Mode "Gamer" : on dessine précisément chaque ligne à ses coordonnées (X=0, Y=y)
            // Cela empêche les décalages liés au Buffer de la console Windows.
            for (int y = 0; y < level.Layout.Count; y++)
            {
                // Sécurité : ne pas dessiner en dehors de l'écran
                if (y >= Console.WindowHeight) break;

                Console.SetCursorPosition(0, y);
                
                string line = level.Layout[y];
                // Sécurité : tronquer si la ligne est plus grande que la fenêtre
                if (line.Length > Console.WindowWidth)
                {
                    Console.Write(line.Substring(0, Console.WindowWidth));
                }
                else
                {
                    Console.Write(line);
                }
            }

            // Dessiner les agents
            if (agents != null)
            {
                foreach (var agent in agents)
                {
                    Console.SetCursorPosition(agent.Position.X, agent.Position.Y);
                    Console.ForegroundColor = agent.Color;
                    Console.Write(agent.Symbol);
                }
            }
            
            // Dessiner le joueur par-dessus la carte initiale
            if (player != null)
            {
                Console.SetCursorPosition(player.Position.X, player.Position.Y);
                Console.ForegroundColor = player.Color;
                Console.Write(player.Symbol);
            }

            Console.ResetColor();
        }

        public void UpdatePlayer(Player player, Position oldPosition, LevelData level)
        {
            // Effacer l'ancienne position en redessinant la case de la carte (ex: '.')
            Console.SetCursorPosition(oldPosition.X, oldPosition.Y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            char tile = level.Layout[oldPosition.Y][oldPosition.X];
            Console.Write(tile);

            // Dessiner la nouvelle position
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.ForegroundColor = player.Color;
            Console.Write(player.Symbol);
            Console.ResetColor();
        }

        public void DrawUIScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================================");
            Console.WriteLine("                L'ADMINISTRATION CENTRALE");
            Console.WriteLine("============================================================");
            Console.ResetColor();
            Console.WriteLine("\n[En attente des données de Kevin...]");
        }

        public void RenderGameState(GameState state)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================================");
            Console.WriteLine("                L'ADMINISTRATION CENTRALE");
            Console.WriteLine("============================================================");
            Console.ResetColor();
            
            Console.WriteLine("\n" + state.IntroText);
            
            Console.WriteLine("\n------------------------------------------------------------");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            string patienceIcons = new string('☕', state.Patience);
            string lostIcons = new string('-', state.MaxPatience - state.Patience);
            Console.WriteLine($"PATIENCE DE KEVIN : {patienceIcons}{lostIcons}");
            Console.ResetColor();
            
            Console.WriteLine("\n------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("OBJECTIF ACTUEL :");
            WriteWrappedText(state.Objective, 60);
            Console.ResetColor();

            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DERNIER ÉCHANGE :");
            if (state.IsGameOver || state.IsFraudRestart) Console.ForegroundColor = ConsoleColor.Red;
            if (state.IsGameWon) Console.ForegroundColor = ConsoleColor.Yellow;
            WriteWrappedText(state.LastMessage, 60);
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------");

            // Gestion de l'input utilisateur (saisie du formulaire)
            if (state.IsAwaitingFormInput)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Veuillez décliner votre Prénom : ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Veuillez décliner votre Âge : ");
                string age = Console.ReadLine() ?? "";
                Console.ResetColor();
                
                string inputJson = System.Text.Json.JsonSerializer.Serialize(new { Name = name, Age = age });
                System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json"), inputJson);
            }
            else if (state.IsGameOverBurnout || state.IsGameWon || state.IsFraudRestart)
            {
                Console.WriteLine();
                if (state.IsGameWon) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Red;
                
                if (state.IsFraudRestart)
                    Console.WriteLine("Appuyez sur n'importe quelle touche pour reprendre depuis le début...");
                else
                    Console.WriteLine("Appuyez sur n'importe quelle touche pour recommencer...");
                Console.ReadKey(true);
                Console.ResetColor();
                
                string inputJson = System.Text.Json.JsonSerializer.Serialize(new { Action = "Restart" });
                System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json"), inputJson);
            }
        }

        private void WriteWrappedText(string text, int maxWidth = 60)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine();
                return;
            }

            string[] paragraphs = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (var p in paragraphs)
            {
                string[] words = p.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string currentLine = "";
                foreach (var word in words)
                {
                    if (currentLine.Length + word.Length + 1 > maxWidth)
                    {
                        Console.WriteLine(currentLine.TrimEnd());
                        currentLine = "";
                    }
                    currentLine += word + " ";
                }
                if (currentLine.Length > 0)
                {
                    Console.WriteLine(currentLine.TrimEnd());
                }
            }
        }
    }
}
