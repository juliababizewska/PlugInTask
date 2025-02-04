# PlugInTask

PlugInTask is a command-line application developed in C# using the .NET Framework, designed with plugin architecture. It provides three core functionalities: count, reverse, and help.

## Functionality

- **count**: Computes and outputs the number of characters in the provided input string.
- **reverse**: Outputs the reversed version of the provided input string.
- **help**: Displays the usage instructions and command descriptions.

## Installation
  To set up PlugInTask, follow these steps:
- Clone the repository.
- Open the project in Visual Studio.
- Build the soultion to generate executable files.
 
## Usage
The application is executed via the command line using the following syntax:
    _PlugInFinal.exe {comand} {input}_

  ## Available Commands
  - count:  _PlugInFinal.exe --count Hello World_

    expected output: 11

  - reverse: _PlugInFinal.exe --reverse Hello World_

    expected output: dlroW olleH

  - help: _PlugInFinal.exe --help_

    expected output:\
    Syntax: PlugInFinal.exe {command} {input}\
Commands:\
        --count -> Returns the length of the input\
        --help -> Displays manual\
        --reverse -> Reverses given input

## Unit tests
The application includes two unit tests to ensure its core functionality works correctly:
- **Count test**
- **Reverse test**

    
