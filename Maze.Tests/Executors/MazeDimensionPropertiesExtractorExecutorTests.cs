using System.Linq;
using Maze.Executors.MazeDimensionPropertiesExtractorExecutor;
using NUnit.Framework;

namespace Maze.Tests.Executors
{
    [TestFixture]
    public class MazeDimensionPropertiesExtractorExecutorTests
    {
        [Test]
        public void Given_MazeDimensionPropertiesExtractorExecutor_When_Executing_Then_The_Expected_Result_Is_Returned()
        {
            var mazeStr = @"_S.GX";

            var executor = new MazeDimensionPropertiesExtractorExecutor();

            var dimensionProperties = executor.Execute(mazeStr);

            Assert.That(dimensionProperties.RowsLength, Is.EqualTo(2));
            Assert.That(dimensionProperties.ColumnsLength, Is.EqualTo(2));
            Assert.That(dimensionProperties.Rows.Count, Is.EqualTo(2));
            Assert.That(dimensionProperties.Rows.Single(x => x == "_S"), Is.Not.Null);
            Assert.That(dimensionProperties.Rows.Single(x => x == "GX"), Is.Not.Null);
        }
    }
}