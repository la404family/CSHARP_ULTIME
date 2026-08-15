using System;
using System.Collections.Generic;

namespace Roguelike.Models
{
    public class GameState
    {
        public string IntroText { get; set; } = string.Empty;
        public int Patience { get; set; }
        public int MaxPatience { get; set; }
        public string LastMessage { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public bool IsGameOver { get; set; }
        public bool IsGameOverBurnout { get; set; }
        public bool IsGameWon { get; set; }
        public bool IsAwaitingFormInput { get; set; }
        public bool IsFinalBossSequence { get; set; }
        public bool IsFraudRestart { get; set; }
        public System.Collections.Generic.List<string> BossSequenceLines { get; set; } = new System.Collections.Generic.List<string>();
    }
}
