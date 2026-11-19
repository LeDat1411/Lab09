using BankAccountApp;
using Calculator;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xunit;


namespace CalculatorApp.Tests
{
    public class BankAccountCsvTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            using (var reader = new StreamReader("BankAccountTestData.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                foreach (var record in csv.GetRecords<TestData>())
                {
                    yield return new object[] { record.customerName, record.initialBalance, record.debitAmount, record.expectedBalance };
                }
            }
        }
        [
        Theory]
        [MemberData(nameof(GetTestData))]
        public void Debit_CsvData_UpdatesBalance(string customerName, decimal
        initialBalance, decimal debitAmount, string expectedBalance)
        {
            // Arrange
            var account = new BankAccount(customerName, initialBalance);
            // Act & Assert
            if (expectedBalance == "Insufficient funds")
            {
                Assert.Throws<InvalidOperationException>(() =>
                account.Debit(debitAmount));
            }
            else
            {
                account.Debit(debitAmount);
                Assert.Equal(decimal.Parse(expectedBalance), account.Balance);
            }
        }
        public class TestData
        {
            public string customerName { get; set; }
        public decimal initialBalance { get; set; }
            public decimal debitAmount { get; set; }
            public string expectedBalance { get; set; }
        }
    }
}
