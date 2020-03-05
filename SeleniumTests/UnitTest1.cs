using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Diagnostics;

namespace SeleniumTodos
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        //[TestMethod]
        //public void ReadingDataFromExcelTestMethod()
        //{
        //    try
        //    {
        //        ExcelReader.PopulateInCollection(@"C:\Users\jacke\source\repos\dotnet-sqldb-tutorial-master\SeleniumTests\ExcelSpreadsheets\DataDrivenTesting.xlsx");
        //        Debug.WriteLine(ExcelReader.ReadData(1, "Name"));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}


        [TestMethod]
        [TestCategory("Chrome")]
        public void CreateNew()
        {
            ExcelReader.PopulateInCollection(@"C:\Users\jacke\source\repos\dotnet-sqldb-tutorial-master\SeleniumTests\ExcelSpreadsheets\DataDrivenTesting.xlsx");
            var on = 0;
            var i = 1;
            do
            {
                try
                {
                    var test = ExcelReader.ReadData(i, "Todos");
                    driver.Navigate().GoToUrl(appURL + "/");
                    driver.FindElement(By.LinkText("Create New")).Click();
                    driver.FindElement(By.Id("Description")).Click();
                    driver.FindElement(By.Id("Description")).Clear();
                    driver.FindElement(By.Id("Description")).SendKeys(test);
                    driver.FindElement(By.XPath("//div[2]/div")).Click();
                    driver.FindElement(By.XPath("//input[@value='Create']")).Click();
                    driver.FindElement(By.XPath("//*[contains(.,$test)]"));
                    i += 1;
                }
                catch (Exception e)
                {
                    on += 1;
                }
            } while (on == 0) ;
        }

        //[TestMethod]
        //[TestCategory("Chrome")]
        //public void CreateNewFail()
        //{
        //    driver.Navigate().GoToUrl(appURL + "/");
        //    driver.FindElement(By.LinkText("Create New")).Click();
        //    driver.FindElement(By.Id("Description")).Click();
        //    driver.FindElement(By.Id("Description")).Clear();
        //    driver.FindElement(By.Id("Description")).SendKeys("Test");
        //    driver.FindElement(By.XPath("//div[2]/div")).Click();
        //    driver.FindElement(By.XPath("//input[@value='Create']")).Click();
        //    driver.FindElement(By.XPath("//*[contains(.,'I will fail you!')]"));
        //}
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://dotnetappsqldb20200228104146.azurewebsites.net";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}