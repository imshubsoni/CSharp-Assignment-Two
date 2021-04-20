using System;

namespace AssignmentTwo
{
    class Program
    {
         static void Main(string[] args)
        {
            // This is 25 Cell Grid (5X5)
            // It can be changed to any dimension, program will work file without having to change any other code part.
            int[,] grid = new int[,]
            {
                { 0,0,0,0,0},
                { 0,0,1,0,0},
                { 0,0,1,0,0},
                { 0,0,1,0,0},
                { 0,0,0,0,0},
            };

            // Asking for runtime input for number of generations to be printed 
            Console.Write("Please enter value of N ( How many generations you want to print ? ) :");
            int numberOfGenerations = Convert.ToInt32(Console.ReadLine());

            // defining symbols for dead and alive cell, it can be changed as per the choice
            char deadCellCharacter = 'X';
            char aliveCellCharacter = 'O';

            // Creating Conway's Game Object
            // We need to pass Four arguments to the constructor - First - Grid
            //                                                   - Second - Dead Cell Symbol
            //                                                   - Third - Alive Cell Symbol
            //                                                   - Fourth - Number of Generation to be printed.
            GameLibrary gameLibraryObject = new GameLibrary(grid, deadCellCharacter , aliveCellCharacter, numberOfGenerations); 
     
        }
    }
}
