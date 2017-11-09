using Maze.Models;
using NUnit.Framework;

namespace Maze.Tests.Models
{
    [TestFixture]
    public class MazeDimensionPropertiesTests
    {
        public void Given_MazeDimensionProperties_Then_Rows_Are_Instatiated()
        {
            var properties = new MazeDimensionProperties();

            Assert.That(properties.Rows, Is.Not.Null);
        }
    }
}