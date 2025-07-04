using MarianRobots.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarianRobots.Core.Models
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position MoveForward(Direction direction)
        {
            return direction switch
            {
                Direction.N => new Position(X, Y + 1),
                Direction.E => new Position(X + 1, Y),
                Direction.S => new Position(X, Y - 1),
                Direction.W => new Position(X - 1, Y),
                _ => this
            };
        }

        public override string ToString() => $"{X} {Y}";
    }
}
