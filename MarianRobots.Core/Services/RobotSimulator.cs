using MarianRobots.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarianRobots.Core.Services
{
    public class RobotSimulator
    {
        private readonly Grid _grid;

        public RobotSimulator(Grid grid)
        {
            _grid = grid;
        }

        public string Execute(Robot robot, string instructions)
        {
            foreach (char command in instructions)
            {
                if (robot.IsLost) break;

                switch (command)
                {
                    case 'L':
                        robot.TurnLeft();
                        break;

                    case 'R':
                        robot.TurnRight();
                        break;

                    case 'F':
                        var currentPos = robot.Position;
                        var currentDir = robot.Direction;
                        var nextPos = currentPos.MoveForward(currentDir);

                        if (!_grid.IsInside(nextPos))
                        {
                            if (!_grid.HasScent(currentPos, currentDir))
                            {
                                _grid.AddScent(currentPos, currentDir);
                                robot.MarkLost();
                            }
                        }
                        else
                        {
                            robot.MoveForward(_grid);
                        }
                        break;

                    default:
                        throw new InvalidOperationException($"Unsupported instruction: '{command}'");
                        
                }
            }

            return robot.ToString();
        }
    }
}
