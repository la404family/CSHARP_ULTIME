using System;
using System.IO;
using System.Threading;
using System.Text.Json;
using Roguelike.UI;
using Roguelike.Data;
using Roguelike.Models;

namespace Roguelike.Engine
{
    public class GameManager
    {
        private string _mode;
        private Renderer _renderer;
        private LevelData _currentLevel = null!;
        private Player _player = null!;
        private QuestManager _questManager = null!;
        private System.Collections.Generic.List<Agent> _agents = null!;
        private string _ipcFilePath;
        private GameState _gameState = null!;

        public GameManager(string mode)
        {
            _mode = mode;
            _renderer = new Renderer();
            _ipcFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "state.json");
            
            InitializeGame();
        }

        private void InitializeGame()
        {
            try
            {
                // Nettoyage de sécurité
                string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                if (File.Exists(inputPath)) { try { File.Delete(inputPath); } catch { } }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Levels", "level01.json");
                _currentLevel = LevelLoader.LoadLevel(path);
                
                // Initialisation du joueur
                _player = new Player(new Position(_currentLevel.StartPosition.X, _currentLevel.StartPosition.Y));
                
                // Initialisation des agents et de la quête
                _agents = new System.Collections.Generic.List<Agent>();
                _questManager = new QuestManager();
                
                // Agents fixes dans leurs bureaux spécifiques
                _agents.Add(new Agent(new Position(49, 12), "Josiane", "Formulaire B-42", ConsoleColor.Magenta));
                _agents.Add(new Agent(new Position(67, 11), "Bernadette", "Cerfa 1138-bis", ConsoleColor.Green));
                _agents.Add(new Agent(new Position(67, 19), "Gertrude", "Laissez-passer A-39", ConsoleColor.Cyan));
                _agents.Add(new Agent(new Position(102, 17), "Jacqueline", "Timbre Fiscal de 14,99€", ConsoleColor.Gray));
                _agents.Add(new Agent(new Position(87, 19), "Micheline", "Dossier Z-77 Dérogatoire", ConsoleColor.Blue));
                _agents.Add(new Agent(new Position(81, 8), "Francine", "Annexe K-90 en triple exemplaire", ConsoleColor.Yellow));
                _agents.Add(new Agent(new Position(96, 10), "Huguette", "Justificatif de Non-Existence", ConsoleColor.Red));

                _questManager.InitializeQuest(_agents);

                _gameState = new GameState
                {
                    IntroText = "", // Sera rempli par PlayIntroSequence()
                    Patience = _player.Patience,
                    MaxPatience = _player.MaxPatience,
                    LastMessage = "Kevin entre dans le bâtiment avec appréhension...",
                    Objective = "En attente...",
                    IsGameOver = false,
                    IsGameOverBurnout = false,
                    IsAwaitingFormInput = false,
                    IsFinalBossSequence = false
                };
                
                if (_mode == "map")
                {
                    SaveGameState();
                    Console.Clear();
                    _renderer.DrawMapScreen(_currentLevel, _player, _agents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de chargement du niveau : {ex.Message}");
            }
        }

        public void Start()
        {
            // 1. Affichage initial en fonction de la console (Carte ou Interface)
            if (_mode == "map")
            {
                _renderer.DrawMapScreen(_currentLevel, _player, _agents);
            }
            else if (_mode == "ui")
            {
                _renderer.DrawUIScreen();
            }

            // 2. Séquence d'introduction (uniquement sur la carte pour piloter l'UI)
            if (_mode == "map")
            {
                PlayIntroSequence();
            }

            // 3. Lancement de la boucle de jeu principale
            RunGameLoop();
        }

        private void SaveGameState()
        {
            try
            {
                string json = JsonSerializer.Serialize(_gameState);
                File.WriteAllText(_ipcFilePath, json);
            }
            catch { }
        }

        private void PlayIntroSequence()
        {
            var introPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "intro.json");
            if (File.Exists(introPath))
            {
                try
                {
                    string json = File.ReadAllText(introPath);
                    var doc = JsonDocument.Parse(json).RootElement;
                    if (doc.TryGetProperty("IntroLines", out var linesElement))
                    {
                        _gameState.IntroText = "";
                        foreach (var line in linesElement.EnumerateArray())
                        {
                            _gameState.IntroText += line.GetString() + "\n";
                            SaveGameState();
                            Thread.Sleep(1500);
                        }
                    }
                }
                catch { }
            }


            _gameState.Objective = _questManager.GetStartingClue();
            _gameState.LastMessage = "Trouvez le premier bureau !";
            SaveGameState();
        }

        private void RunGameLoop()
        {
            // Boucle de la console UI
            if (_mode != "map")
            {
                string lastJson = "";
                while (true)
                {
                    try
                    {
                        if (File.Exists(_ipcFilePath))
                        {
                            string json = File.ReadAllText(_ipcFilePath);
                            if (json != lastJson) // Anti-clignotement (optimisation)
                            {
                                lastJson = json;
                                var state = JsonSerializer.Deserialize<GameState>(json);
                                if (state != null)
                                {
                                    _renderer.RenderGameState(state);
                                    if (state.IsGameOver)
                                    {
                                        Thread.Sleep(5000);
                                        Environment.Exit(0);
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(200); // Rafraîchissement régulier
                }
            }

            while (true)
            {
                // Gestion de la pause UI si on attend un input de formulaire
                if (_gameState.IsAwaitingFormInput || _gameState.IsGameOverBurnout || _gameState.IsGameWon)
                {
                    string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                    if (File.Exists(inputPath))
                    {
                        // Dans le cas général (Burnout ou autre), on le consommera ici. 
                        // Le FormInput sera géré lors de l'interaction (voir plus bas)
                    }
                    Thread.Sleep(100);
                    continue;
                }

                Direction input = InputHandler.GetInput();
                Thread.Sleep(16); // ~60 polls/s — évite le spin CPU tout en restant réactif

                if (input != Direction.None)
                {
                    Position newPos = new Position(_player.Position.X, _player.Position.Y);

                    if (input == Direction.Interact)
                    {
                        // Vérifier les agents adjacents
                        Agent? adjacentAgent = null;
                        foreach (var agent in _agents)
                        {
                            int dx = Math.Abs(agent.Position.X - _player.Position.X);
                            int dy = Math.Abs(agent.Position.Y - _player.Position.Y);
                            if (dx + dy == 1) // Adjacent orthognalement
                            {
                                adjacentAgent = agent;
                                break;
                            }
                        }

                        if (adjacentAgent != null)
                        {
                            var interaction = _questManager.TryInteract(adjacentAgent);
                            _gameState.LastMessage = interaction.Message;

                            if (interaction.Result == QuestManager.InteractionResult.WrongAgent)
                            {
                                _player.Patience--;
                                _gameState.Patience = _player.Patience;
                                
                                if (_player.Patience <= 0)
                                {
                                    _gameState.IsGameOverBurnout = true;
                                    _gameState.LastMessage = interaction.Message + "\n\n*** BURNOUT TOTAL ! ***\nKevin jette ses dossiers en l'air et part élever des chèvres. GAME OVER.";
                                    SaveGameState();
                                    
                                    // Attente de l'appui sur une touche depuis UI
                                    string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                                    while (!File.Exists(inputPath)) { Thread.Sleep(100); }
                                    try { File.Delete(inputPath); } catch { }
                                    
                                    // Recommencer
                                    InitializeGame();
                                    PlayIntroSequence();
                                    continue;
                                }
                            }
                            else if (interaction.Result == QuestManager.InteractionResult.NeedsForm)
                            {
                                if (!string.IsNullOrEmpty(interaction.Message))
                                {
                                    _gameState.LastMessage = interaction.Message;
                                }
                                // Nettoyage de sécurité avant d'attendre
                                string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                                if (File.Exists(inputPath)) { try { File.Delete(inputPath); } catch { } }

                                _gameState.IsAwaitingFormInput = true;
                                SaveGameState();

                                // Attente de la saisie (Nom + Âge)
                                while (!File.Exists(inputPath)) { Thread.Sleep(100); }

                                string name = "";
                                string age = "";
                                bool inputRead = false;
                                while (!inputRead)
                                {
                                    try
                                    {
                                        string inputJson = File.ReadAllText(inputPath);
                                        if (string.IsNullOrWhiteSpace(inputJson)) 
                                        {
                                            Thread.Sleep(50);
                                            continue;
                                        }

                                        var doc = JsonDocument.Parse(inputJson).RootElement;
                                        var action = doc.TryGetProperty("Action", out var actionProp) ? actionProp.GetString() : null;
                                        if (action == "Restart")
                                        {
                                            _questManager.ResetQuestState();
                                        }
                                        else
                                        {
                                            name = doc.TryGetProperty("Name", out var nameProp) ? nameProp.GetString() ?? "" : "";
                                            age = doc.TryGetProperty("Age", out var ageProp) ? ageProp.GetString() ?? "" : "";
                                        }
                                        File.Delete(inputPath);
                                        inputRead = true;
                                    }
                                    catch (IOException)
                                    {
                                        // Fichier potentiellement en cours d'écriture par l'interface
                                        Thread.Sleep(50);
                                    }
                                    catch (System.Text.Json.JsonException)
                                    {
                                        // JSON invalide ou incomplet
                                        Thread.Sleep(50);
                                    }
                                }

                                _gameState.IsAwaitingFormInput = false;

                                // On soumet au QuestManager
                                var formResult = _questManager.SubmitForm(adjacentAgent, name, age);
                                _gameState.LastMessage = formResult.Message;

                                if (formResult.Result == QuestManager.FormResult.WrongName)
                                {
                                    _player.Patience--;
                                    _gameState.Patience = _player.Patience;
                                    _questManager.ResetQuestState(); // Punition extrême !
                                    _gameState.Objective = _questManager.GetStartingClue();
                                }
                                else if (formResult.Result == QuestManager.FormResult.FinalBoss)
                                {
                                    _gameState.IsFinalBossSequence = true;
                                    SaveGameState();

                                    // Lancement de l'animation de vérification finale
                                    bool isClean = _questManager.EvaluateFinalDossier();
                                    _gameState.BossSequenceLines.Add("--- VÉRIFICATION DU DOSSIER ---");
                                    SaveGameState(); Thread.Sleep(1500);

                                    for (int i = 0; i < _questManager.EnteredAges.Count; i++)
                                    {
                                        Agent? a = _questManager.GetAgentAtStep(i);
                                        string aName = a != null ? a.Name : "Agent";
                                        string typedAge = _questManager.EnteredAges[i];
                                        _gameState.BossSequenceLines.Add($"> Chez {aName}, vous avez déclaré avoir {typedAge} ans.");
                                        _gameState.LastMessage = string.Join("\n", _gameState.BossSequenceLines);
                                        SaveGameState(); Thread.Sleep(1500);
                                    }

                                    if (isClean)
                                    {
                                        _gameState.BossSequenceLines.Add("\n\"Le dossier est... parfait. Inédit.\"");
                                        _gameState.BossSequenceLines.Add("VOICI LE LÉGENDAIRE CERFA A-38 ! VOUS AVEZ VAINCU L'ADMINISTRATION !");
                                        _gameState.LastMessage = string.Join("\n", _gameState.BossSequenceLines);
                                        _gameState.IsGameWon = true;
                                        SaveGameState();
                                        
                                        // Attente de l'appui sur une touche depuis UI
                                        string winInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                                        while (!File.Exists(winInputPath)) { Thread.Sleep(100); }
                                        try { File.Delete(winInputPath); } catch { }
                                        
                                        // Recommencer
                                        InitializeGame();
                                        PlayIntroSequence();
                                        continue;
                                    }
                                    else
                                    {
                                        _gameState.BossSequenceLines.Add("\n\"ATTENDEZ ! Les âges ne correspondent pas ! FRAUDE !\"");
                                        _gameState.BossSequenceLines.Add("Votre dossier est REFUSÉ et DÉTRUIT. Retournez voir n'importe quel agent pour tout recommencer !");
                                        _gameState.LastMessage = string.Join("\n", _gameState.BossSequenceLines);
                                        
                                        _gameState.IsFraudRestart = true;
                                        _gameState.Objective = "DOSSIER DÉTRUIT - La boucle recommence.";
                                        
                                        SaveGameState();
                                        
                                        // Attente de l'appui sur une touche depuis UI
                                        string fraudInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.json");
                                        while (!File.Exists(fraudInputPath)) { Thread.Sleep(100); }
                                        try { File.Delete(fraudInputPath); } catch { }

                                        _questManager.ResetQuestState();
                                        _gameState.Objective = _questManager.GetStartingClue();
                                        _gameState.IsFinalBossSequence = false;
                                        _gameState.IsFraudRestart = false;
                                        _gameState.BossSequenceLines.Clear();
                                        _gameState.LastMessage = "Le jeu reprend. Allez voir le guichet de départ !";
                                        SaveGameState();
                                    }
                                }
                                else if (formResult.Result == QuestManager.FormResult.Success)
                                {
                                    _gameState.Objective = _questManager.GetCurrentObjective();
                                }
                            }
                            
                            SaveGameState();
                        }
                        else
                        {
                            // L'utilisateur a appuyé sur E mais il n'y a personne
                            _gameState.LastMessage = "Kevin parle dans le vide... Il n'y a pas d'agent administratif juste à côté de lui !";
                            SaveGameState();
                        }
                    }
                    else
                    {
                        switch (input)
                        {
                            case Direction.Up: newPos.Y--; break;
                            case Direction.Down: newPos.Y++; break;
                            case Direction.Left: newPos.X--; break;
                            case Direction.Right: newPos.X++; break;
                        }

                        // Vérifier les collisions (on ne peut marcher que sur '.')
                        if (newPos.X >= 0 && newPos.X < _currentLevel.Width &&
                            newPos.Y >= 0 && newPos.Y < _currentLevel.Height)
                        {
                            // Vérifier s'il y a un agent sur la case
                            bool agentCollision = false;
                            foreach (var agent in _agents)
                            {
                                if (agent.Position.X == newPos.X && agent.Position.Y == newPos.Y)
                                {
                                    agentCollision = true;
                                    break;
                                }
                            }

                            if (!agentCollision)
                            {
                                char tile = _currentLevel.Layout[newPos.Y][newPos.X];
                                if (tile == '.')
                                {
                                    Position oldPos = new Position(_player.Position.X, _player.Position.Y);
                                    _player.Position = newPos;
                                    
                                    // Mise à jour visuelle optimisée
                                    _renderer.UpdatePlayer(_player, oldPos, _currentLevel);
                                }
                            }
                        }
                    }
                }

                // Temporisation courte pour le polling (fluide pour la manette)
                Thread.Sleep(30);
            }
        }
    }
}
