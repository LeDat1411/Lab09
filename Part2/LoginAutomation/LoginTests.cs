
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NUnit.Framework;
using Allure.NUnit;
using NUnit.Framework;

namespace LoginAutomation
{
    [AllureNUnit]
    public class LoginTests
    {
        public static IEnumerable<TestCaseData> GetTestData()
        {
            using var reader = new StreamReader("LoginTestData.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var record in csv.GetRecords<TestData>())
            {
                yield return new TestCaseData(record.username, record.password);
            }
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void Login_WithValidCredentials_ShouldSucceed(
            string username,
            string password)
        {
            using IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("C:\\Users\\Admin\\source\\repos\\Part2\\Part2\\login.html");
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("loginButton")).Click();

            Thread.Sleep(2000);
        }

        public class TestData
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}