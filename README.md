# 🪐 Martian Robots (C# Solution)

![CI](https://github.com/ThabisoDev/MartianRobots/actions/workflows/dotnet.yml/badge.svg)
![License](https://img.shields.io/github/license/ThabisoDev/MartianRobots)
![.NET](https://img.shields.io/badge/.NET-6.0-blue)
![Tests](https://img.shields.io/badge/tests-xUnit%20✔️-success)

> A clean, test-driven C# simulation for the **Martian Robots** coding challenge. Includes a modular design, xUnit tests, and full instructions.

---

## 📦 Project Structure

```plaintext
MartianRobots.sln
├── MartianRobots.App       # Console app entry point
├── MartianRobots.Core      # Logic, models, services
├── MartianRobots.Tests     # Unit tests using xUnit
├── input.txt               # Sample input for the app
└── .github/workflows       # GitHub Actions CI workflow
🧠 Problem Description
Mars is a grid defined by its upper-right coordinates (e.g. 5 3)

Each robot has a:

Start position + orientation (X Y D)

Instruction string (L, R, F)

Rules:

If a robot moves off the grid, it is LOST

LOST robots leave a scent at their last position

Future robots ignore moves that would make them LOST from a scented position

💻 How to Run the Console App
Open the solution in Visual Studio 2022

Set MartianRobots.App as the startup project

Add content to input.txt in the App project folder, e.g.:

text
Copy
Edit
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
Press Ctrl+F5 to run

✅ Example Output
text
Copy
Edit
1 1 E
3 3 N LOST
2 3 S
🧪 How to Run Tests
Run tests using Visual Studio Test Explorer or the CLI:

bash
Copy
Edit
dotnet test MartianRobots.Tests
Test cases to implement:

Robots survive edge cases

Robots get marked as LOST

Scent prevents repeated losses

🔄 Continuous Integration (CI)
GitHub Actions runs every time you push to main.

✅ The workflow:

Restores packages

Builds the solution

Runs all tests

View the CI status here:
👉 GitHub Actions

📈 Future Improvements
CLI argument for input file

JSON or YAML input support

API wrapper or web frontend

Roslyn analyzer for invalid moves

🧰 Technologies Used
C# (.NET 6 / .NET 8)

xUnit

Visual Studio 2022

GitHub Actions

OOP Design Patterns

📄 License
This project is licensed under the MIT License.