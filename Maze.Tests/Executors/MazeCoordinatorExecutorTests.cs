using System;
using Maze.Executors.MazeCoordinatorExecutor;
using Maze.Executors.MazePathfinderAlgorithmExecutor;
using Maze.Executors.MazeTransformerExecutor;
using Maze.Models;
using Maze.Services.MazeProvider;
using Maze.Validators;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Executors
{
    [TestFixture]
    public class MazeCoordinatorExecutorTests
    {
        private MazeCoordinatorExecutor _executor;
        private Mock<IMazeSource> _mazeSourceMock;
        private Mock<IMazeValidator> _mazeValidatorMock;
        private Mock<IMazeTransformerExecutor> _mazeTransformerMock;
        private Mock<IMazePathfinderAlgorithmExecutor> _mazePathfinderAlgorithmExecutorMock;

        [SetUp]
        public void SetUp()
        {
            _mazeSourceMock = new Mock<IMazeSource>();
            _mazeValidatorMock = new Mock<IMazeValidator>();
            _mazeTransformerMock = new Mock<IMazeTransformerExecutor>();
            _mazePathfinderAlgorithmExecutorMock = new Mock<IMazePathfinderAlgorithmExecutor>();

            _executor = new MazeCoordinatorExecutor(
                _mazeSourceMock.Object,
                _mazeValidatorMock.Object,
                _mazeTransformerMock.Object,
                _mazePathfinderAlgorithmExecutorMock.Object
            );
        }

        [Test]
        public void Given_Null_MazeSource_Dependency_When_Constructing_MazeCoordinatorExecutor_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new MazeCoordinatorExecutor(
                    null,
                    _mazeValidatorMock.Object,
                    _mazeTransformerMock.Object,
                    _mazePathfinderAlgorithmExecutorMock.Object
                ));

            Assert.That(ex.ParamName, Is.EqualTo("mazeSource"));
        }

        [Test]
        public void Given_Null_MazeValidator_Dependency_When_Constructing_MazeCoordinatorExecutor_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new MazeCoordinatorExecutor(
                    _mazeSourceMock.Object,
                    null,
                    _mazeTransformerMock.Object,
                    _mazePathfinderAlgorithmExecutorMock.Object
                ));

            Assert.That(ex.ParamName, Is.EqualTo("mazeValidator"));
        }

        [Test]
        public void Given_Null_MazeTransformerExecutor_Dependency_When_Constructing_MazeCoordinatorExecutor_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new MazeCoordinatorExecutor(
                    _mazeSourceMock.Object,
                    _mazeValidatorMock.Object,
                    null,
                    _mazePathfinderAlgorithmExecutorMock.Object
                ));

            Assert.That(ex.ParamName, Is.EqualTo("mazeTransformer"));
        }

        [Test]
        public void Given_Null_MazePathfinderAlgorithmExecutor_Dependency_When_Constructing_MazeCoordinatorExecutor_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new MazeCoordinatorExecutor(
                    _mazeSourceMock.Object,
                    _mazeValidatorMock.Object,
                    _mazeTransformerMock.Object,
                    null
                ));

            Assert.That(ex.ParamName, Is.EqualTo("mazePathfinderAlgorithmExecutor"));
        }

        [Test]
        public void Given_Valid_Arguments_When_Constructing_MazeCoordinatorExecutor_Then_It_Can_Create_Instance()
        {
            Assert.IsInstanceOf<IMazeCoordinatorExecutor>(_executor);
        }

        [Test]
        public void Given_MazeCoordinatorExecutor_When_Executing_Then_Maze_Is_Solved()
        {
            var mazeInput = "path/to/maze";
            var mazeStr = @"____G__X
                            ___XXX__
                            X______X
                            __XXXX__
                            ___X____
                            __S__X__";

            var maze = new MazeModel();

            _mazeSourceMock.Setup(x => x.GetMaze(mazeInput))
                .Returns(mazeStr);

            _mazeTransformerMock.Setup(x => x.Execute(mazeStr))
                .Returns(maze);

            var expectedSolution = new Solution();

            _mazePathfinderAlgorithmExecutorMock.Setup(x => x.Execute(maze))
                .Returns(expectedSolution);

            var actualSolution = _executor.Execute(mazeInput);

            Assert.That(actualSolution, Is.EqualTo(expectedSolution));
        }
    }
}