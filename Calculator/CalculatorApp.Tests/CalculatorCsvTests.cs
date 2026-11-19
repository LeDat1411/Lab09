using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Xunit;
using CalculatorType = Calculator.BasicMath.BasicMaths;

namespace BasicMathTests
{
    public class CalculatorCsvTests
    {
        // Method to read test data from a CSV file
        public static IEnumerable<object[]> GetTestData(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach (var record in csv.GetRecords<TestData>())
                {
                    yield return new object[] { record.A, record.B, record.Expected };
                }
            }
        }
        // Test method for Add operation using CSV data
        [Theory]
        [MemberData(nameof(GetTestData), parameters: "add_testdata.csv")]
        public void Add_CsvData_ReturnsCorrectSum(double a, double b, double expected)
        {
            // Arrange: Create an instance of Calculator
            var calculator = new CalculatorType();
            // Act: Call the Add method
            double result = calculator.Add(a, b);
            // Assert: Verify the result
            Assert.Equal(expected, result);
        }
        // Test method for Subtract operation using CSV data
        [Theory]
        [MemberData(nameof(GetTestData), parameters: "subtract_testdata.csv")]
        public void Subtract_CsvData_ReturnsCorrectDifference(double a, double b, double expected)
        {
            // Arrange: Create an instance of Calculator
            var calculator = new CalculatorType();
            // Act: Call the Subtract method
            double result = calculator.Subtract(a, b);
            // Assert: Verify the result
            Assert.Equal(expected, result);
        }

        // Test method for Multiply operation using CSV data
        [Theory]
        [MemberData(nameof(GetTestData), parameters: "multiply_testdata.csv")]
    public void Multiply_CsvData_ReturnsCorrectProduct(double a, double b, double expected)
        {
            // Arrange: Create an instance of Calculator
            var calculator = new CalculatorType();
            // Act: Call the Multiply method
            double result = calculator.Multiply(a, b);
            // Assert: Verify the result
            Assert.Equal(expected, result);
        }
        // Test method for Divide operation using CSV data
        [Theory]
        [MemberData(nameof(GetTestData), parameters: "divide_testdata.csv")]
        public void Divide_CsvData_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            // Arrange: Create an instance of Calculator
            var calculator = new CalculatorType();
            // Act: Call the Divide method
            double result = calculator.Divide(a, b);
            // Assert: Verify the result
            Assert.Equal(expected, result);
        }
        // Class to represent the test data structure
        public class TestData
        {
            public double A { get; set; }
            public double B { get; set; }
            public double Expected { get; set; }
        }
    }
}