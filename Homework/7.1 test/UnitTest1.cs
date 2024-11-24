using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ValidateInput_ShouldThrowException_WhenInputIsNotANumber()
        {
            // Arrange
            string input = "abc";

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "������� �� �����.");
        }

        [TestMethod]
        public void ValidateInput_ShouldThrowException_WhenInputIsTooLarge()
        {
            // Arrange
            string input = "2147483648"; // ������ int.MaxValue

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "������� ������� ������� �����.");
        }

        [TestMethod]
        public void ValidateInput_ShouldThrowException_WhenInputIsTooSmall()
        {
            // Arrange
            string input = "-2147483649"; // ������ int.MinValue

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "������� ������� ��������� �����.");
        }

        [TestMethod]
        public void ValidateInput_ShouldNotThrowException_WhenInputIsValid()
        {
            // Arrange
            string input = "123";

            // Act
            ValidateInput(input);

            // Assert
            Assert.IsTrue(true); // ���� ���������� �� ���������, ���� ��������
        }

        // ��������� ����������� ����� ValidateInput �� ��������� ����� ��� ������� � ������
        private void ValidateInput(string input)
        {
            if (!decimal.TryParse(input, out decimal number))
                throw new Exception("������� �� �����.");

            if (number > int.MaxValue)
                throw new Exception("������� ������� ������� �����.");

            if (number < int.MinValue)
                throw new Exception("������� ������� ��������� �����.");
        }
    }
}

