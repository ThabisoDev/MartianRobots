using MarianRobots.Core.Enums;
using MarianRobots.Core.Models;
using MarianRobots.Core.Services;


using System.Text.RegularExpressions;

string inputFilePath = Path.Combine(AppContext.BaseDirectory, "Input.txt");

List<(Robot robot, string instructions)> robotInstructions = new();
Grid grid;

// Validate direction characters
bool IsValidInstructions(string input) => Regex.IsMatch(input, "^[LRF]+$", RegexOptions.IgnoreCase);

if (File.Exists(inputFilePath))
{
    Console.WriteLine($"Reading from: {inputFilePath}");

    var lines = File.ReadAllLines(inputFilePath)
        .Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

    try
    {
        // Grid size
        var gridParts = lines[0].Trim().Split(' ');
        if (gridParts.Length != 2 || !int.TryParse(gridParts[0], out var maxX) || !int.TryParse(gridParts[1], out var maxY))
            throw new FormatException("Invalid grid dimensions.");

        grid = new Grid(maxX, maxY);

        // Robot instructions
        for (int i = 1; i < lines.Count; i += 2)
        {
            var robotParts = lines[i].Trim().Split(' ');
            if (robotParts.Length != 3 ||
                !int.TryParse(robotParts[0], out var x) ||
                !int.TryParse(robotParts[1], out var y) ||
                !Enum.TryParse(robotParts[2], out Direction dir))
                throw new FormatException($"Invalid robot position: '{lines[i]}'");

            var instr = lines[i + 1].Trim().ToUpper();
            if (!IsValidInstructions(instr))
                throw new FormatException($"Invalid instructions: '{instr}'");

            robotInstructions.Add((new Robot(new Position(x, y), dir), instr));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in input.txt: {ex.Message}");
        return;
    }
}
else
{
    Console.WriteLine("No input.txt found. Switching to manual input...");

    grid = GetValidGrid();

    while (true)
    {
        Console.Write("\nEnter robot start position (e.g., 1 1 E), or press Enter to finish: ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) break;

        var parts = input.Trim().Split(' ');
        if (parts.Length != 3 ||
            !int.TryParse(parts[0], out var x) ||
            !int.TryParse(parts[1], out var y) ||
            !Enum.TryParse(parts[2], out Direction direction))
        {
            Console.WriteLine("Invalid format. Use: X Y D (e.g., 3 2 N)");
            continue;
        }

        Console.Write("Enter instructions (L/R/F only): ");
        var instructions = Console.ReadLine()?.Trim().ToUpper() ?? "";

        if (!IsValidInstructions(instructions))
        {
            Console.WriteLine(" Invalid instructions. Only use characters: L, R, F");
            continue;
        }

        robotInstructions.Add((new Robot(new Position(x, y), direction), instructions));
    }
}

var simulator = new RobotSimulator(grid);

Console.WriteLine("\n🔁 Simulation Output:");
foreach (var (robot, instructions) in robotInstructions)
{
    var result = simulator.Execute(robot, instructions);
    Console.WriteLine(result);
}

// === Helper ===
Grid GetValidGrid()
{
    while (true)
    {
        Console.Write("Enter grid size (e.g., 5 3): ");
        var input = Console.ReadLine()?.Trim().Split(' ');

        if (input?.Length == 2 &&
            int.TryParse(input[0], out var maxX) &&
            int.TryParse(input[1], out var maxY) &&
            maxX >= 0 && maxY >= 0)
        {
            return new Grid(maxX, maxY);
        }

        Console.WriteLine("Invalid input. Please enter two positive integers separated by a space.");
    }
}

