using Foraging_Kentucky.Common;
using System.Security.Policy;
using Xunit.Sdk;

namespace Foraging_Kentucky.Testing
{
    public class UnitTests
    {
        [Fact]
        public void LogByReturnForTestingPass()
        {
            // Arrange
            var recipe = new Recipe() { Name = "Item Name" };

            // Act
            string actual = recipe.Name.LogByReturnForTesting(Logger.success);
            var expected = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : Item Name - The operation was successful.";

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogByReturnForTestingFail()
        {
            // Arrange
            var recipe = new Recipe() { Name = "Item Name" };

            // Act
            string actual = recipe.Name.LogByReturnForTesting(Logger.success);
            var differentTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {recipe} - The operation was successful.";

            //Assert
            Assert.NotEqual(differentTime, actual);
        }

        [Fact]
        public void MakeParagraphsPass()
        {
            // Arrange
            string testString = @"This is a test string.
It has newlines.
I just pressed enter, so that should be another.
And another!";

            // Act
            string[] actual = testString.MakeParagraphs();
            string[] expected = new string[]
            {
                "This is a test string.",
                "It has newlines.",
                "I just pressed enter, so that should be another.",
                "And another!"
            };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CapitalizeEachWordPass()
        {
            // Arrange
            var blackberry = new Item("test name");

            // Act
            var actual = blackberry.Name.CapitalizeEachWord();
            var expected = "Test Name";

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}