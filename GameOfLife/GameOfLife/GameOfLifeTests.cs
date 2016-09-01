using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void GivenTheCellIsAliveItShouldReturnTrue()
        {
            IGame gameOfLife = new Game(4, 8);
            var coordinate = new Coordinate(1,1);

            gameOfLife.AddLivingCell(coordinate);

            Assert.IsTrue(gameOfLife.IsAlive(coordinate));
        }

        [Test]
        public void GivenTheCellIsDeadItShouldReturnTrue()
        {
            IGame gameOfLife = new Game(4, 8);
            var coordinate = new Coordinate(1, 4);

            Assert.IsTrue(gameOfLife.IsDead(coordinate));
        }

        [Test]
        public void GivenThereIsNoLivingNeighboursItShouldReturn0()
        {
            IGame gameOfLife = new Game(4, 8);
            var coordinate = new Coordinate(3, 3);

            Assert.AreEqual(0, gameOfLife.CountLivingNeighbours(coordinate));
        }

        [Test]
        public void GivenThereIsOneLivingNeighboursItShouldReturn1()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(3, 4));

            Assert.AreEqual(1, gameOfLife.CountLivingNeighbours(new Coordinate(3, 3)));
        }
        
        [Test]
        public void GivenThereIsThreeLivingNeighboursItShouldReturn3()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(3, 4));
            gameOfLife.AddLivingCell(new Coordinate(3, 2));
            gameOfLife.AddLivingCell(new Coordinate(2, 3));

            Assert.AreEqual(3, gameOfLife.CountLivingNeighbours(new Coordinate(3, 3)));
        }
        
        [Test]
        public void GivenLiveCellHasZeroLiveNeighboursItShouldDie()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(3, 4));

            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsDead(new Coordinate(3,4)));
        }
        
        [Test]
        public void GivenDeadCellHasZeroLiveNeighboursItShouldStayTheSame()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsDead(new Coordinate(2,6)));
        }
        
        [Test]
        public void GivenLiveCellOneLiveNeighboursItShouldDie()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(2,7));
            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsDead(new Coordinate(2,6)));
        }

        [Test]
        public void GivenLiveCellHasTwoLiveNeighboursItShouldSurviveTheNextGeneration()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(0,0));
            gameOfLife.AddLivingCell(new Coordinate(0, 1));
            gameOfLife.AddLivingCell(new Coordinate(1, 0));
            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsAlive(new Coordinate(0, 0)));
        }
        
        [Test]
        public void GivenADeadCellHasTwoLiveNeighboursItShouldStayDead()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(0, 1));
            gameOfLife.AddLivingCell(new Coordinate(1, 0));
            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsDead(new Coordinate(0, 0)));
        }
        
        [Test]
        public void GivenALiveCellHasThreeLiveNeighboursItShouldSurviveNextGeneration()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(1,3));
            gameOfLife.AddLivingCell(new Coordinate(1,4));
            gameOfLife.AddLivingCell(new Coordinate(1,2));
            gameOfLife.AddLivingCell(new Coordinate(0,3));

            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsAlive(new Coordinate(1, 3)));
        }
        
        [Test]
        public void GivenADeadCellHasThreeLiveNeighboursItShouldComeToLife()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(1,4));
            gameOfLife.AddLivingCell(new Coordinate(1,2));
            gameOfLife.AddLivingCell(new Coordinate(0,3));

            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsAlive(new Coordinate(1, 3)));
        }
        
        [Test]
        public void GivenLiveCellHasMoreThanThreeLiveNeighboursItShouldDie()
        {
            IGame gameOfLife = new Game(4, 8);

            gameOfLife.AddLivingCell(new Coordinate(1,3));
            gameOfLife.AddLivingCell(new Coordinate(1,4));
            gameOfLife.AddLivingCell(new Coordinate(1,2));
            gameOfLife.AddLivingCell(new Coordinate(0,3));
            gameOfLife.AddLivingCell(new Coordinate(2,3));

            gameOfLife.GetNextGeneration();

            Assert.IsTrue(gameOfLife.IsDead(new Coordinate(1, 3)));
        }
    }
}
