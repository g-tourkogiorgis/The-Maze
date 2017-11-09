using System;
using System.Collections.Generic;
using Maze.Executors.MazeDimensionPropertiesExtractorExecutor;
using Maze.Executors.MazeTransformerExecutor;
using Maze.Models;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Executors
{
    [TestFixture]
    public class MazeTransformerExecutorTests
    {
        private MazeTransformerExecutor _executor;
        private Mock<IMazeDimensionPropertiesExtractorExecutor> _mazeDimensionPropertiesExtractorMock;

        [SetUp]
        public void SetUp()
        {
            _mazeDimensionPropertiesExtractorMock = new Mock<IMazeDimensionPropertiesExtractorExecutor>();

            _executor = new MazeTransformerExecutor(_mazeDimensionPropertiesExtractorMock.Object);
        }

        [Test]
        public void Given_Null_MazePathfinderAlgorithmExecutor_Dependency_When_Constructing_MazeTransformerExecutor_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new MazeTransformerExecutor(
                    null
                ));

            Assert.That(ex.ParamName, Is.EqualTo("mazeDimensionPropertiesExtractor"));
        }

        [Test]
        public void Given_Valid_Arguments_When_Constructing_MazeCoordinatorExecutor_Then_It_Can_Create_Instance()
        {
            Assert.IsInstanceOf<IMazeTransformerExecutor>(_executor);
        }
    }
}