using System;
using Maze.Validators;
using NUnit.Framework;

namespace Maze.Tests.Validators
{
    [TestFixture]
    public class MazeValidatorTests
    {
        private MazeValidator _mazeValidator;

        [SetUp]
        public void SetUp()
        {
            _mazeValidator = new MazeValidator();
        }

        [Test]
        public void Given_MazeValidator_When_Validating_And_Maze_Is_Empty_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => _mazeValidator.Validate(""));
            Assert.That(ex.Message, Is.EqualTo("The string representation of the maze was empty."));
        }

        [Test]
        public void Given_MazeValidator_When_Validating_And_Maze_Contains_Invalid_Chars_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => _mazeValidator.Validate("_X12"));
            Assert.That(ex.Message, Is.EqualTo("The string representation of the maze contains invalid characters. Maze must only contain '_', 'X', 'S', 'G', '\\n', '\\r'"));
        }

        [Test]
        public void Given_MazeValidator_When_Validating_And_Maze_Does_Not_Contain_Starting_Point_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => _mazeValidator.Validate("_XG"));
            Assert.That(ex.Message, Is.EqualTo("The Maze must contain a starting point ('S') and a finish point ('G')"));
        }

        [Test]
        public void Given_MazeValidator_When_Validating_And_Maze_Does_Not_Contain_Finish_Point_Then_It_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => _mazeValidator.Validate("_XS"));
            Assert.That(ex.Message, Is.EqualTo("The Maze must contain a starting point ('S') and a finish point ('G')"));
        }
    }
}