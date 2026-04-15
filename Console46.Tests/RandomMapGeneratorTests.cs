using ConsoleApp46;
using NUnit.Framework;

namespace Console46.Tests
{
    [TestFixture]
    public class RandomMapGeneratorTests
    {
        [Test]
        public void Generate_ShouldNotThrowException()
        {
            var generator = new RandomMapGenerator();
            char[,] map = new char[25, 25];
            Assert.DoesNotThrow(() => generator.Generate(map));
        }

        [Test]
        public void Generate_ShouldFillMapWithNonEmptyCells()
        {   //попа
            var generator = new RandomMapGenerator();
            char[,] map = new char[25, 25];
            generator.Generate(map);
            bool hasContent = false;
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    if (map[i, j] != '.') hasContent = true;
            Assert.IsTrue(hasContent);
        }
    }
}