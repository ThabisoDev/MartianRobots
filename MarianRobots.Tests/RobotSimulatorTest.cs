using MarianRobots.Core.Enums;
using MarianRobots.Core.Models;
using MarianRobots.Core.Services;
using Xunit;

namespace MartianRobots.Tests;

public class RobotSimulatorTests
{
    [Fact]
    public void Robot_ExecutesInstructionsCorrectly()
    {
        // Arrange
        var grid = new Grid(5, 3);
        var robot = new Robot(new Position(1, 1), Direction.E);
        var simulator = new RobotSimulator(grid);

        // Act
        var result = simulator.Execute(robot, "RFRFRFRF");

        // Assert
        Assert.Equal("1 1 E", result);
    }

    [Fact]
    public void Robot_GetsLost_WhenMovingOffGrid()
    {
        var grid = new Grid(5, 3);
        var robot = new Robot(new Position(3, 2), Direction.N);
        var simulator = new RobotSimulator(grid);

        var result = simulator.Execute(robot, "FRRFLLFFRRFLL");

        Assert.Equal("3 3 N LOST", result);
    }

    [Fact]
    public void Robot_IgnoresMoveOffGrid_IfScentIsPresent()
    {
        var grid = new Grid(5, 3);

        // First robot leaves a scent at 3 3 N
        var first = new Robot(new Position(3, 2), Direction.N);
        var sim = new RobotSimulator(grid);
        var lostResult = sim.Execute(first, "FRRFLLFFRRFLL");

        // Second robot, same start position and instructions
        var second = new Robot(new Position(3, 2), Direction.N);
        var safeResult = sim.Execute(second, "FRRFLLFFRRFLL");

        Assert.Equal("3 3 N LOST", lostResult);
        Assert.Equal("3 2 N", safeResult); // didn't fall again
    }

    [Fact]
    public void Robot_ThrowsException_OnInvalidInstruction()
    {
        var grid = new Grid(5, 5);
        var robot = new Robot(new Position(1, 1), Direction.N);
        var simulator = new RobotSimulator(grid);

        Assert.Throws<InvalidOperationException>(() => simulator.Execute(robot, "LFX")); // X is invalid
    }

    [Fact]
    public void Simulates_Example_From_InputFile()
    {
        // Arrange
        var grid = new Grid(5, 3);
        var simulator = new RobotSimulator(grid);

        var results = new List<string>();

        var robot1 = new Robot(new Position(1, 1), Direction.E);
        var instr1 = "RFRFRFRF";

        var robot2 = new Robot(new Position(3, 2), Direction.N);
        var instr2 = "FRRFLLFFRRFLL";

        var robot3 = new Robot(new Position(0, 3), Direction.W);
        var instr3 = "LLFFFLFLFL";

        // Act
        results.Add(simulator.Execute(robot1, instr1));
        results.Add(simulator.Execute(robot2, instr2));
        results.Add(simulator.Execute(robot3, instr3));

        // Assert
        var expected = new List<string>
    {
        "1 1 E",
        "3 3 N LOST",
        "2 3 S"
    };

        Assert.Equal(expected, results);
    }

}
