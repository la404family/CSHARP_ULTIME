using System;

namespace Roguelike.Models
{
    public class Player : Entity
    {
        public int Patience { get; set; } = 15;
        public int MaxPatience { get; set; } = 15;

        public Player(Position startPosition) 
            : base(startPosition, '@', ConsoleColor.Yellow)
        {
        }
    }
}
