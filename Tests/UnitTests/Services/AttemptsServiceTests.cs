using Infrastructure.Services;
using System.Collections.Generic;
using Xunit;

namespace Tests.UnitTests.Services
{
    public class AttemptsServiceTests
    {
        [Fact]
        public void CheckIfLinking_Returns_True_If_Attempts_Are_Linked()
        {
            // Arrange
            var tfnNumber = "123456789";
            var previousAttempts = new List<string> { "443459871", "123459876" };
            var testAttemptService = new AttemptsService();

            // Act
            var isLinking = testAttemptService.CheckIfLinking(tfnNumber, previousAttempts);

            // Assert
            Assert.True(isLinking);
        }

        [Fact]
        public void CheckIfLinking_Returns_False_If_Attempts_Are_Not_Linked()
        {
            // Arrange
            var tfnNumber = "123456789";
            var previousAttempts = new List<string> { "44345678", "123459876" };
            var testAttemptService = new AttemptsService();

            // Act
            var isLinking = testAttemptService.CheckIfLinking(tfnNumber, previousAttempts);

            // Assert
            Assert.False(isLinking);
        }
    }
}
