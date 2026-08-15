namespace Roguelike.Models
{
    public abstract class Entity
    {
        public Position Position { get; set; }
        public char Symbol { get; set; }
        public System.ConsoleColor Color { get; set; }

        protected Entity(Position position, char symbol, System.ConsoleColor color)
        {
            Position = position;
            Symbol = symbol;
            Color = color;
        }
    }
}
