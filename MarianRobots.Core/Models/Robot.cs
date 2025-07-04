using MarianRobots.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarianRobots.Core.Models
{
    public class Robot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsLost { get; private set; }

        public Robot(Position startPosition, Direction startDirection)
        {
            Position = startPosition;
            Direction = startDirection;
            IsLost = false;
        }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => Direction
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => Direction
            };
        }

        public void MarkLost()
        {
            IsLost = true;
        }

        public void MoveForward(Grid grid)
        {
            var nextPosition = Position.MoveForward(Direction);

            if (grid.IsInside(nextPosition))
            {
                Position = nextPosition;
            }
            else
            {
                MarkLost();
            }
        }

        public override string ToString()
        {
            return $"{Position} {Direction}" + (IsLost ? " LOST" : string.Empty);
        }
    }
}
