using MarianRobots.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarianRobots.Core.Models
{
    public class Grid
    {
        public int MaxX { get; }
        public int MaxY { get; }

        private readonly HashSet<string> _scents = new();

        public Grid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsInside(Position position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X <= MaxX && position.Y <= MaxY;
        }

        public void AddScent(Position position, Direction direction)
        {
            _scents.Add(GetScentKey(position, direction));
        }

        public bool HasScent(Position position, Direction direction)
        {
            return _scents.Contains(GetScentKey(position, direction));
        }

        private string GetScentKey(Position position, Direction direction)
        {
            return $"{position.X}:{position.Y}:{direction}";
        }
    }
}
