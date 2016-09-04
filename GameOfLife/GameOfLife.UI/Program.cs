using System;
using System.Data;
using System.Threading;

namespace GameOfLife.UI
{
    class Program
    {
        static void Main()
        {
            IGame gameOfLife = new Game(20, 70);
    
            PopulateGridWithIntialCells(gameOfLife);

            while(true)
            {
                PrintGrid(gameOfLife);
                Thread.Sleep(500);
                gameOfLife.GetNextGeneration();
                Console.Clear();
            }
        }

        private static void PrintGrid(IGame gameOfLife)
        {
            const string liveCell = "+";
            const string deadCell = " ";

            for (var i = 0; i < gameOfLife.Grid.GetLength(0); i++)
            {
                for (var j = 0; j < gameOfLife.Grid.GetLength(1); j++)
                {
                    Console.Write(gameOfLife.Grid[i, j] == 0 ? deadCell : liveCell);
                }
                Console.WriteLine();
            }
        }

        private static void PopulateGridWithIntialCells(IGame gameOfLife)
        {
            var rnd = new Random();

            for (var i = 0; i < 750; i++)
            {
                var x = rnd.Next(0, gameOfLife.Grid.GetLength(0));
                var y = rnd.Next(0, gameOfLife.Grid.GetLength(1));

                gameOfLife.AddLivingCell(new Coordinate(x,y));
            }
        }
    }
}
