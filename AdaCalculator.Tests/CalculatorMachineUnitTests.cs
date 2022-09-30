using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCalculator.Tests
{
    public class CalculatorMachineUnitTests
    {
        [Fact]
        public void Calculate_ShouldCallCalculator()
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>()));

            CalculatorMachine calcMachine = new(mock.Object);

            (string operation, double result) seila = calcMachine.Calculate("sum", 2.2, 4.0);

            mock.Verify(x => x.Calculate("sum", 2.2, 4.0), Times.Once);

        }

        [Fact]
        public void Calculate_Sum_ShouldReturnCorrectResults()
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("sum", 6.2));

            CalculatorMachine calculatorMachine = new(mock.Object);

            (string operation, double result) calculatorMachineResult = calculatorMachine.Calculate("sum", 2.2, 4.0);

            Assert.Equal(6.2 , calculatorMachineResult.result);
            Assert.Equal("sum", calculatorMachineResult.operation);
        }




    }
}
