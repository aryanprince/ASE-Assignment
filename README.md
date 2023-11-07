<div align="center">

# Lexical Interpreter Engine

![image](https://github.com/aryanprince/Lexical-Interpreter-Engine/assets/45622345/7a060c29-2ab2-4514-835e-af774cfd2474)

![C#](https://img.shields.io/badge/c%23-000000.svg?style=for-the-badge&logo=c-sharp&logoColor=239120) ![.Net](https://img.shields.io/badge/.NET-000000?style=for-the-badge&logo=.net&logoColor=c792ea) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-000000.svg?style=for-the-badge&logo=visual-studio&logoColor=5c2d91) ![GitHub Actions](https://img.shields.io/badge/github%20actions%20ci-000000.svg?style=for-the-badge&logo=github&logoColor=white)

A .NET C# WinForms application that takes lexical tokens from a specially-tailored domain-specific language and visually translates them into geometric designs drawn on a canvas

Built part of the Advanced Software Engineering course at Leeds Beckett University

![](https://hits.dwyl.com/aryanprince/ASE-Assignment.svg?style=flat-square)
[![CI Build and Test](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml)

<!-- 
# Issues badge doesn't work cus repo not public
[![GitHub issues](https://img.shields.io/github/issues/aryanprince/ASE-Assignment?logo=github)](https://github.com/aryanprince/ASE-Assignment/issues) 
-->

</div>

## Test Code for Program

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

## Continous Integration (CI) Workflows

This project leverages GitHub Actions to implement 5 distinct CI workflows, optimizing the entire development process. 

[![CI Build and Test](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/ci-build-and-test.yml) - Automatically builds and tests code for quality assurance.

[![PR Validator](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-validator.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-validator.yml) - Checks PR names for consistency and style.

[![PR Labeler](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-labeler.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/pr-labeler.yml) - Assigns labels to PRs based on file changes.

[![Add Issue To Project](https://github.com/aryanprince/ASE-Assignment/actions/workflows/add-issue-to-project.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/add-issue-to-project.yml) - Automatically adds issues to the active project.

[![Assign Author to Issue/PR](https://github.com/aryanprince/ASE-Assignment/actions/workflows/assign-author-to-issue-pr.yml/badge.svg)](https://github.com/aryanprince/ASE-Assignment/actions/workflows/assign-author-to-issue-pr.yml) - Tags issues and PRs with the author’s name.

## Naming Conventions

Hungarian Notation is used for WinForms controls, and PascalCase is used for almost everything else.

## How to Run

1. Clone the repo
2. Open the solution in Visual Studio
3. Build the solution
4. Run the program
5. Enjoy!
