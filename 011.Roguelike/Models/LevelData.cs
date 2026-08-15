using System.Collections.Generic;

namespace Roguelike.Models
{
    public class LevelData
    {
        public string Name { get; set; } = string.Empty;
        public int Width { get; set; }
        public int Height { get; set; }
        public List<string> Layout { get; set; } = new List<string>();
        public Position StartPosition { get; set; } = new Position();
        public Position ExitPosition { get; set; } = new Position();
        public List<Position> RoomCenters { get; set; } = new List<Position>();
    }
}
