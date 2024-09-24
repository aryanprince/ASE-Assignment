<div align="center">

![image](https://github.com/aryanprince/Lexical-Interpreter-Engine/assets/45622345/5e90afff-e5b2-4a89-875f-02f9d7aa6f68)

# 🖌️ Lexical Interpreter Engine

![C#](https://img.shields.io/badge/c%23-000000.svg?style=for-the-badge&logo=c-sharp&logoColor=239120)
![.Net](https://img.shields.io/badge/.NET-000000?style=for-the-badge&logo=.net&logoColor=c792ea)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-000000.svg?style=for-the-badge&logo=visual-studio&logoColor=5c2d91)
![GitHub Actions](https://img.shields.io/badge/github%20actions%20ci-000000.svg?style=for-the-badge&logo=github&logoColor=white)

A .NET C# WinForms application that takes lexical tokens from a specially-tailored domain-specific language and visually translates them into geometric designs drawn on a canvas

![hits](https://hits.dwyl.com/aryanprince/ASE-Assignment.svg?style=flat-square)
[![CI Build and Test](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml)
[![GitHub issues](https://img.shields.io/github/issues/aryanprince/ASE-Assignment?logo=github)](https://github.com/aryanprince/ASE-Assignment/issues)

</div>

## ✨ Introduction

The Lexical Interpreter Engine is a powerful C# WinForms-based interpreter designed to transform a custom domain-specific language into graphical geometric designs. The interpreter parses and visualizes the commands in real-time, drawing shapes on a canvas based on the lexical tokens provided.

Built to demonstrate concepts of lexical analysis and geometric rendering, it serves as both a functional interpreter and a learning tool for understanding how visualizations can be driven by code.

## 🌟 Features

- **Lexical Token Parsing**: Translates tokens from a DSL (Domain-Specific Language) into corresponding visual elements.
- **Geometric Rendering**: Draws shapes like triangles, rectangles, squares, and circles on a canvas based on token values.
- **Control Structures**: Supports basic programming constructs such as if, while, and pen for creating dynamic designs.
- **Dynamic Canvas**: Real-time rendering of geometric designs.
- **C# and WinForms**: Built using the powerful .NET framework and WinForms for the UI.
- **GitHub Actions CI Workflows**: Automated CI workflows using GitHub Actions for building and testing.

## 🚀 Tech Stack

- **Language**: C# (.NET Framework)
- **Framework**: WinForms
- **IDE**: Visual Studio
- **Version Control**: Git & GitHub
- **CI/CD**: GitHub Actions

## 🌐 CI/CD Workflows

This project features robust CI/CD processes implemented using GitHub Actions:

[![CI Build and Test](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml) - Automatically builds and tests code for quality assurance.

[![PR Validator](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-validator.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-validator.yml) - Checks PR names for consistency and style.

[![PR Labeler](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-labeler.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-labeler.yml) - Assigns labels to PRs based on file changes.

[![Add Issue To Project](https://github.com/aryanprince/ASE-Assignment/actions/workflows/add-issue-to-project.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/add-issue-to-project.yml) - Automatically adds issues to the active project.

[![Assign Author to Issue/PR](https://github.com/aryanprince/ASE-Assignment/actions/workflows/assign-author-to-issue-pr.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/assign-author-to-issue-pr.yml) - Tags issues and PRs with the author’s name.

## 🛠️ Getting Started

Follow these steps to get up and running with the Lexical Interpreter Engine:

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 5.0+
- Git

### Installation

1. Clone the repository:

```bash
git clone https://github.com/aryanprince/Lexical-Interpreter-Engine.git
cd Lexical-Interpreter-Engine
```

2. Open in Visual Studio:

Open the `LexicalEngine.sln` solution file in Visual Studio.

3. Build the solution:

Build the project using Visual Studio.

4. Run the program:

Execute the project and try out the below test code in the program.

## 🎨 Test Code for Program

```txt
var x = 50
triangle x
var y = 125
var x = x + 20
rectangle x y
pen 3
if x > 25
  var x = x + 25
  square x
endif
pen 2
while 3
  var y = y + x
  circle y
endwhile
fill 1
pen 1
move x y
triangle y
var x = 250
move x x
rectangle x x
```

## 🎯 Roadmap

- **Extended Geometric Shapes**: Add support for additional shapes (polygons, ellipses, etc.).
- **Advanced Error Handling**: Improve lexical error reporting and debugging features.
- **Save/Export Designs**: Allow users to save the rendered designs as image files.

## 🔑 License

- [MIT License](https://github.com/dev3-extensions/toolkit/blob/main/LICENSE).
