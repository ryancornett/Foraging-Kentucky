using Foraging_Kentucky.Domain;
using Foraging_Kentucky.Common;
using System.Reflection;
using System.Security.Policy;
using Xunit.Sdk;

namespace Foraging_Kentucky.Testing
{
    public class UnitTests
    {
        [Fact]
        public void LogByMethodName()
        {
            //Arrange
            string methodName = MethodBase.GetCurrentMethod().Name;

            // Act
            var expected = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {methodName} - The operation was successful.";
            var actual = Logger.LogMethodNameByReturnForTesting("LogByMethodName", Logger.success);

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void LogExtensionByReturnForTestingPass()
        {
            // Arrange
            var recipe = new Recipe() { Name = "Item Name" };

            // Act
            string actual = recipe.Name.LogExtensionByReturnForTesting(Logger.success);
            var expected = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : Item Name - The operation was successful.";

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogExtensionByReturnForTestingFail()
        {
            // Arrange
            var recipe = new Recipe() { Name = "Item Name" };

            // Act
            string actual = recipe.Name.LogExtensionByReturnForTesting(Logger.success);
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