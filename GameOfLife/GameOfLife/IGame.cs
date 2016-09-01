namespace GameOfLife
{
    public interface IGame
    {
        int[,] Grid { get; }
        void GetNextGeneration();
        void AddLivingCell(Coordinate cell);
        bool IsAlive(Coordinate cell);
        bool IsDead(Coordinate cell);
        int CountLivingNeighbours(Coordinate cell);
    }
}