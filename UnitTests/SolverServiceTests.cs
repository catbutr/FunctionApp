using FunctionApp.Model;
using FunctionApp.Services;

namespace UnitTests
{
    [TestClass]
    public class SolverServiceTests
    {

        [TestMethod]
        public void ArgumentsSet()
        {
            // Arrange
            var calculationService = new FunctionSolverService();
            var function = new PolynomialFunction(3)
            {
                valueOfA = 3,
                valueOfB = 3,
                valueOfC = 300
            };
            function.argumentsList.Add(
                new Arguments
                {
                    valueOfX = 3,
                    valueOfY = 3
                });

            // Act
            calculationService.Calculate(function);

            // Assert
            Assert.AreEqual(function.argumentsList[0].result, 408);
        }

        [TestMethod]
        public void ArgumentsNotSet()
        {
            // Arrange
            var calculationService = new FunctionSolverService();
            var function = new PolynomialFunction(2)
            {
                valueOfC = 5
            };
            function.argumentsList.Add(
                new Arguments
                {
                    valueOfX = 2,
                    valueOfY = 3
                });

            // Act
            calculationService.Calculate(function);

            // Assert
            Assert.AreEqual(function.argumentsList[0].result, null);
        }
    }
}