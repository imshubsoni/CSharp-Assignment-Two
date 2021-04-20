using System;

namespace AssignmentTwo
{
    public class GameLibrary
    {
        private int _numberOfColumns;
        private int _numberOfRows;
        private int _numberOfGenerations;
        public int[,] Grid;
        private int[,] _temporaryGrid;
        private char _deadCell;
        private char _aliveCell;

        // Constructor to define the above decalred varibales and it will call PrintingAllGenerations() function -
        // - to start the program and print the required.
        public GameLibrary(int[,] grid, char deadCell, char aliveCell, int numberOfGenerations)
        {   
            Grid = grid;
            _deadCell = deadCell;
            _aliveCell = aliveCell;
            _numberOfGenerations = numberOfGenerations;

            _numberOfColumns = Grid.GetLength(0);
            _numberOfRows = Grid.GetLength(1);
            
            _temporaryGrid = new int[_numberOfColumns, _numberOfRows];

            PrintingAllGenerations();
        }


        // This method marks the start of the console process.
        // It will print the grid with alive and dead cells for number of time user entered
        // This calls two method - First - FindingTheNextGenerationOfGrid()
        //                       - Second - PrintingTheGenerationToConsole()
        public void PrintingAllGenerations()
        {
            for (int i = 0; i < _numberOfGenerations; i++)
            {
                Console.WriteLine($"This is generation number {i+1} :- ");
                FindingTheNextGenerationOfGrid();
                PrintingTheGenerationToConsole();
            }   
        }


        // This method finds the value of each and every grid item for the next generation
        // It stores the information in a temporary Grid.
        public void FindingTheNextGenerationOfGrid()
        {
            for (int i = 1; i < _numberOfColumns - 1; i++)
            {
                for (int j = 1; j < _numberOfRows - 1; j++)
                {
                    int numberOfAliveNeighbours = NumberOfNeighboursToTheCell(i, j);

                    if (Grid[i, j] == 1 && numberOfAliveNeighbours < 2)
                    {
                        _temporaryGrid[i, j] = 0;
                    }
                    else if (Grid[i, j] == 1 && numberOfAliveNeighbours > 3)
                    {
                        _temporaryGrid[i, j] = 0;
                    }
                    else if (Grid[i, j] == 1 && (numberOfAliveNeighbours == 2 || numberOfAliveNeighbours == 3))
                    {
                        _temporaryGrid[i, j] = 1;
                    }
                    else if (Grid[i, j] == 0 && numberOfAliveNeighbours == 3)
                    {
                        _temporaryGrid[i, j] = 1;
                    }
                }
            }
        }
        

        // Getting the number of alive neighbours near the grid item.
        private int NumberOfNeighboursToTheCell(int columns, int rows)
        {
            int totalNeighbour = 0;

            for (int i = columns - 1; i <= columns + 1; i++)
                for (int j = rows - 1; j <= rows + 1; j++)
                    totalNeighbour += Grid[i, j];

            return totalNeighbour - Grid[columns, rows];
        }


        // Once the FinidingTheNextGeneration() method completes it's task and store data to the temporary grid
        // this method will print the grid to the console.
        public void PrintingTheGenerationToConsole()
        {
            for (int i = 0; i < _numberOfColumns; i++)
            {
                for (int j = 0; j < _numberOfRows; j++)
                {
                    Grid[i, j] = _temporaryGrid[i, j];

                    if (Grid[i, j] == 0)
                        Console.Write(_deadCell + " ");

                    else
                        Console.Write(_aliveCell + " ");

                    _temporaryGrid[i, j] = 0;
                }

                Console.WriteLine();
            }

            Console.Write("\n\n");
        }
    }
}