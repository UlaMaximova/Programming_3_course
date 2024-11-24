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
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "Введено не число.");
        }

        [TestMethod]
        public void ValidateInput_ShouldThrowException_WhenInputIsTooLarge()
        {
            // Arrange
            string input = "2147483648"; // Больше int.MaxValue

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "Введено слишком большое число.");
        }

        [TestMethod]
        public void ValidateInput_ShouldThrowException_WhenInputIsTooSmall()
        {
            // Arrange
            string input = "-2147483649"; // Меньше int.MinValue

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ValidateInput(input), "Введено слишком маленькое число.");
        }

        [TestMethod]
        public void ValidateInput_ShouldNotThrowException_WhenInputIsValid()
        {
            // Arrange
            string input = "123";

            // Act
            ValidateInput(input);

            // Assert
            Assert.IsTrue(true); // Если исключение не выброшено, тест проходит
        }

        // Добавляем тестируемый метод ValidateInput из основного файла для доступа в тестах
        private void ValidateInput(string input)
        {
            if (!decimal.TryParse(input, out decimal number))
                throw new Exception("Введено не число.");

            if (number > int.MaxValue)
                throw new Exception("Введено слишком большое число.");

            if (number < int.MinValue)
                throw new Exception("Введено слишком маленькое число.");
        }
    }
}

