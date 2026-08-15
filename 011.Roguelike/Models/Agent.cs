using System;

namespace Roguelike.Models
{
    public class Agent : Entity
    {
        public string Name { get; set; }
        public string RequiredForm { get; set; }
        public bool HasBeenVisited { get; set; }

        public Agent(Position position, string name, string requiredForm, ConsoleColor color) 
            : base(position, name[0], color)
        {
            Name = name;
            RequiredForm = requiredForm;
            HasBeenVisited = false;
        }
    }
}
