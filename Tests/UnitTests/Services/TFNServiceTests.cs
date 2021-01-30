using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.UnitTests.Services
{
    public class TFNServiceTests
    {
        [Theory]
        [InlineData("648188480")]
        [InlineData("648188499")]
        [InlineData("648188519")]
        [InlineData("648188527")]
        [InlineData("648188535")]
        public void ValidateTFN_Returns_True_If_Tfn_Is_Valid_Nine_Digits(string tfnNumber)
        {
            // Arrange
            var weightingFactors = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 10),
                new KeyValuePair<int, int>(1, 7),
                new KeyValuePair<int, int>(2, 8),
                new KeyValuePair<int, int>(3, 4),
                new KeyValuePair<int, int>(4, 6),
                new KeyValuePair<int, int>(5, 3),
                new KeyValuePair<int, int>(6, 5),
                new KeyValuePair<int, int>(7, 2),
                new KeyValuePair<int, int>(8, 1)
            };
            var testTFNService = new TFNService();

            // Act
            var validTfn = testTFNService.ValidateTFN(tfnNumber, weightingFactors);

            // Assert
            Assert.True(validTfn);
        }

        [Theory]
        [InlineData("648188481")]
        [InlineData("648188492")]
        [InlineData("648188513")]
        [InlineData("648188524")]
        [InlineData("648188545")]
        public void ValidateTFN_Returns_False_If_Tfn_Is_Invalid_Nine_Digits(string tfnNumber)
        {
            // Arrange
            var weightingFactors = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 10),
                new KeyValuePair<int, int>(1, 7),
                new KeyValuePair<int, int>(2, 8),
                new KeyValuePair<int, int>(3, 4),
                new KeyValuePair<int, int>(4, 6),
                new KeyValuePair<int, int>(5, 3),
                new KeyValuePair<int, int>(6, 5),
                new KeyValuePair<int, int>(7, 2),
                new KeyValuePair<int, int>(8, 1)
            };
            var testTFNService = new TFNService();

            // Act
            var invalidTfn = testTFNService.ValidateTFN(tfnNumber, weightingFactors);

            // Assert
            Assert.False(invalidTfn);
        }

        [Theory]
        [InlineData("37118629")]
        [InlineData("38593474")]
        [InlineData("85655797")]
        [InlineData("37118676")]
        [InlineData("38593524")]
        public void ValidateTFN_Returns_True_If_Tfn_Is_Valid_Eight_Digits(string tfnNumber)
        {
            // Arrange
            var weightingFactors = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 10),
                new KeyValuePair<int, int>(1, 7),
                new KeyValuePair<int, int>(2, 8),
                new KeyValuePair<int, int>(3, 4),
                new KeyValuePair<int, int>(4, 6),
                new KeyValuePair<int, int>(5, 3),
                new KeyValuePair<int, int>(6, 5),
                new KeyValuePair<int, int>(8, 1)
            };
            var testTFNService = new TFNService();

            // Act
            var validTfn = testTFNService.ValidateTFN(tfnNumber, weightingFactors);

            // Assert
            Assert.True(validTfn);
        }

        [Theory]
        [InlineData("37118621")]
        [InlineData("38593472")]
        [InlineData("85655793")]
        [InlineData("37118674")]
        [InlineData("38593525")]
        public void ValidateTFN_Returns_False_If_Tfn_Is_Invalid_Eight_Digits(string tfnNumber)
        {
            // Arrange
            var weightingFactors = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0, 10),
                new KeyValuePair<int, int>(1, 7),
                new KeyValuePair<int, int>(2, 8),
                new KeyValuePair<int, int>(3, 4),
                new KeyValuePair<int, int>(4, 6),
                new KeyValuePair<int, int>(5, 3),
                new KeyValuePair<int, int>(6, 5),
                new KeyValuePair<int, int>(8, 1)
            };
            var testTFNService = new TFNService();

            // Act
            var invalidTfn = testTFNService.ValidateTFN(tfnNumber, weightingFactors);

            // Assert
            Assert.False(invalidTfn);
        }
    }
}
