using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game : IGame
    {
        public int[,] Grid { get; private set; }

        private const int LiveCell = 1;
        private const int DeadCell = 0;

        public Game(int length, int height)
        {
            Grid = new int[length, height];
        }

        public void GetNextGeneration()
        {
            var nextGenGrid = new int[Grid.GetLength(0), Grid.GetLength(1)];

            for (var i = 0; i < Grid.GetLength(0); i++)
            {
                for (var j = 0; j < Grid.GetLength(1); j++)
                {
                    var currentCell = new Coordinate(i,j);

                    if (IsCellsLivingNeighboursLessThanTwo(currentCell))
                        nextGenGrid[i, j] = DeadCell;

                    else if (IsCellAliveAndHasTwoOrThreeLivingNeighbours(currentCell))
                        nextGenGrid[i, j] = LiveCell;

                    else if (IsCellDeadAndHaveThreeLiveNeighbours(currentCell))
                        nextGenGrid[i, j] = LiveCell;

                    else if (IsCellAliveAndHaveMoreThanThreeLiveNeighbours(currentCell))
                        nextGenGrid[i, j] = DeadCell;

                    else
                        nextGenGrid[i, j] = Grid[i, j];
                }
            }
            Grid = nextGenGrid;
        }

        public void AddLivingCell(Coordinate cell)
        {
            Grid[cell.XPosition, cell.YPosition] = LiveCell;
        }

        public bool IsAlive(Coordinate cell)
        {
            return Grid[cell.XPosition, cell.YPosition] == LiveCell;
        }

        public bool IsDead(Coordinate cell)
        {
            return Grid[cell.XPosition,cell.YPosition] == DeadCell;
        }

        public int CountLivingNeighbours(Coordinate cell)
        {
            var cellsToCheck = GetCellsToCheck(cell);

            return cellsToCheck.Count(item => IsValidCoordinate(item) && IsAlive(item));
        }

        private bool IsCellsLivingNeighboursLessThanTwo(Coordinate cell)
        {
            return CountLivingNeighbours(cell) < 2;
        }

        private bool IsCellAliveAndHasTwoOrThreeLivingNeighbours(Coordinate cell)
        {
            return (CountLivingNeighbours(cell) == 2 || CountLivingNeighbours(cell) == 3) && IsAlive(cell);
        }

        private bool IsCellDeadAndHaveThreeLiveNeighbours(Coordinate cell)
        {
            return CountLivingNeighbours(cell) == 3 && IsDead(cell);
        }

        private bool IsCellAliveAndHaveMoreThanThreeLiveNeighbours(Coordinate cell)
        {
            return CountLivingNeighbours(cell) > 3 && IsAlive(cell);
        }

        public bool IsValidCoordinate(Coordinate coordinate)
        {
            try { var val = Grid[coordinate.XPosition, coordinate.YPosition]; }

            catch (IndexOutOfRangeException) { return false; }

            return true;
        }

        public List<Coordinate> GetCellsToCheck(Coordinate cell)
        {
            return new List<Coordinate>
            {
                new Coordinate(cell.XPosition, cell.YPosition + 1),
                new Coordinate(cell.XPosition, cell.YPosition - 1),
                new Coordinate(cell.XPosition + 1, cell.YPosition + 1),
                new Coordinate(cell.XPosition - 1, cell.YPosition + 1),
                new Coordinate(cell.XPosition - 1, cell.YPosition),
                new Coordinate(cell.XPosition + 1, cell.YPosition),
                new Coordinate(cell.XPosition + 1, cell.YPosition - 1),
                new Coordinate(cell.XPosition - 1, cell.YPosition - 1)
            };
        }
    }
}