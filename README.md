# 🪐 Martian Robots Challenge (C# Solution)

This project provides a complete solution to the **Martian Robots** coding challenge using C# and .NET. It simulates robot movement on a Mars-like grid, accounting for orientation, movement instructions, and boundary conditions.

---

## 📖 Problem Summary

- The Mars surface is modeled as a rectangular grid (e.g., `5 3`)
- Each robot is given:
  - A start coordinate and orientation (e.g., `1 1 E`)
  - A series of instructions (e.g., `RFRFRFRF`)
- Instructions include:
  - `L`: turn left 90°
  - `R`: turn right 90°
  - `F`: move forward
- If a robot moves off the grid, it is **LOST** and leaves a **scent** at its last position.
- Future robots will **ignore instructions** that would lead them off the grid from a scented position.

---

## 🧱 Solution Structure

MartianRobots.sln
├── MartianRobots.App # Console app to run simulation
├── MartianRobots.Core # Logic (models, services, enums)
├── MartianRobots.Tests # xUnit test project
└── README.md


---

## 🧪 How to Run Tests

Use Visual Studio Test Explorer or CLI:

```bash
dotnet test MartianRobots.Tests

🚀 How to Run the App
Set MartianRobots.App as the startup project

Create a text file named input.txt in the project folder with the following content:

mathematica
Copy
Edit
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
In Program.cs, read and parse the input.txt

Press F5 to run


🔧 Technologies Used
C# (.NET 6 or .NET 8)

xUnit for testing

Object-oriented design

Visual Studio 2022

📈 Future Improvements
Support for additional instruction types

JSON input/output support

Web or API-based interface

Input validation and error handling

📜 License
MIT
