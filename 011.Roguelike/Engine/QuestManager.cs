using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using Roguelike.Models;

namespace Roguelike.Engine
{
    public class QuestManager
    {
        private List<Agent> _questSequence;
        private int _currentStepIndex;
        private Dictionary<string, List<string>> _agentDescriptions;
        private List<string> _excuses;
        private Random _rng;

        public List<string> EnteredAges { get; private set; }

        public QuestManager()
        {
            _questSequence = new List<Agent>();
            _currentStepIndex = 0;
            _agentDescriptions = new Dictionary<string, List<string>>();
            _excuses = new List<string>();
            EnteredAges = new List<string>();
            _rng = new Random();
            LoadDialogues();
        }

        private void LoadDialogues()
        {
            try
            {
                string dialoguesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "dialogues.json");
                if (File.Exists(dialoguesPath))
                {
                    string json = File.ReadAllText(dialoguesPath);
                    var doc = JsonDocument.Parse(json).RootElement;
                    if (doc.TryGetProperty("AgentDescriptions", out var descriptionsElement))
                    {
                        foreach (var prop in descriptionsElement.EnumerateObject())
                        {
                            var list = prop.Value.EnumerateArray().Select(e => e.GetString() ?? "").ToList();
                            _agentDescriptions[prop.Name] = list;
                        }
                    }
                }

                string excusesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "excuses.json");
                if (File.Exists(excusesPath))
                {
                    string json = File.ReadAllText(excusesPath);
                    var doc = JsonDocument.Parse(json).RootElement;
                    if (doc.TryGetProperty("Excuses", out var excusesElement))
                    {
                        _excuses = excusesElement.EnumerateArray().Select(e => e.GetString() ?? "").ToList();
                    }
                }
            }
            catch { }
            
            if (_excuses.Count == 0) _excuses.Add("Vous n'êtes pas au bon bureau !");
        }

        public void InitializeQuest(List<Agent> agents)
        {
            _questSequence = agents.OrderBy(a => _rng.Next()).ToList();
            ResetQuestState();
        }

        public void ResetQuestState()
        {
            _currentStepIndex = 0;
            EnteredAges.Clear();
            foreach (var agent in _questSequence)
            {
                agent.HasBeenVisited = false;
            }
        }

        /// <summary>
        /// Retourne l'indice vers le premier agent de la séquence aléatoire.
        /// </summary>
        public string GetStartingClue()
        {
            if (_questSequence.Count == 0) return "Aucun agent n'est présent.";
            
            Agent firstAgent = _questSequence[0];
            string clue = GetRandomClueFor(firstAgent);
            return $"ACCUEIL : 'Bienvenue Kevin. Votre premier objectif : {clue}'";
        }

        /// <summary>
        /// Retourne l'indice vers l'agent courant dans la chaîne.
        /// </summary>
        public string GetCurrentObjective()
        {
            if (_currentStepIndex >= _questSequence.Count) return "Vous avez terminé !";
            Agent nextAgent = _questSequence[_currentStepIndex];
            string clue = GetRandomClueFor(nextAgent);
            return clue;
        }
        
        private string GetRandomClueFor(Agent agent)
        {
            if (_agentDescriptions.TryGetValue(agent.Name, out var clues) && clues.Count > 0)
            {
                return clues[_rng.Next(clues.Count)];
            }
            return $"Allez voir {agent.Name}.";
        }

        public enum InteractionResult
        {
            NeedsForm,
            AlreadyVisited,
            WrongAgent
        }

        public (InteractionResult Result, string Message) TryInteract(Agent agent)
        {
            string prefix = $"Vous parlez avec {agent.Name} : ";

            if (agent.HasBeenVisited)
            {
                return (InteractionResult.AlreadyVisited, prefix + "\"Je vous ai déjà donné le formulaire ! Circulez !\"");
            }

            if (_questSequence[_currentStepIndex] == agent)
            {
                // Premier agent de la séquence → dialogue d'introduction complet
                if (_currentStepIndex == 0)
                {
                    string msg = "- Kevin : \"Bonjour, je viens pour le Cerfa A-38.\"\n" +
                                 $"- {agent.Name} : \"Bonjour Monsieur. Vous ne pouvez pas avoir le Cerfa A-38 directement. " +
                                 "Le Cerfa A-38 est strictement réservé aux citoyens préalablement identifiés par le formulaire bleu B-42, " +
                                 "lui-même conditionné par la présentation d'un justificatif de domicile de moins de 12 heures... " +
                                 "Bref, je peux vous donner la liasse rose, mais pour la suite il faudra voir avec mes collègues. " +
                                 "Mais avant cela, quel est votre nom et vous avez quel âge ?\"";
                    return (InteractionResult.NeedsForm, msg);
                }
                else
                {
                    return (InteractionResult.NeedsForm, $"- {agent.Name} : \"Bonjour, un formulaire à tamponner ? Veuillez décliner votre identité et votre âge.\"");
                }
            }
            else
            {
                string excuse = _excuses[_rng.Next(_excuses.Count)];
                return (InteractionResult.WrongAgent, prefix + $"\"{excuse}\"");
            }
        }

        public enum FormResult
        {
            Success,
            WrongName,
            FinalBoss
        }

        public (FormResult Result, string Message) SubmitForm(Agent agent, string name, string age)
        {
            string prefix = $"Agent {agent.Name} : ";

            if (name.Trim() != "Kevin")
            {
                return (FormResult.WrongName, prefix + "\"Vous n'êtes pas sur le dossier ! REFUS ! Recommencez tout !\"");
            }

            // Bon nom
            EnteredAges.Add(age.Trim());
            agent.HasBeenVisited = true;
            _currentStepIndex++;

            if (_currentStepIndex >= _questSequence.Count)
            {
                return (FormResult.FinalBoss, prefix + "\"Voici votre dernier tampon... Un instant, je dois vérifier l'intégrité de votre dossier.\"");
            }
            else
            {
                Agent nextAgent = _questSequence[_currentStepIndex];
                string clue = GetRandomClueFor(nextAgent);
                return (FormResult.Success, prefix + $"\"C'est bon pour moi. Voici le {agent.RequiredForm}. Pour la suite... {clue} Suivant !\"");
            }
        }

        public bool EvaluateFinalDossier()
        {
            if (EnteredAges.Count <= 1) return true;
            
            string firstAge = EnteredAges[0];
            foreach (var age in EnteredAges)
            {
                if (age != firstAge)
                {
                    return false;
                }
            }
            return true;
        }

        public Agent? GetAgentAtStep(int index)
        {
            if (index >= 0 && index < _questSequence.Count)
                return _questSequence[index];
            return null;
        }

        public int GetQuestCount()
        {
            return _questSequence.Count;
        }
    }
}
