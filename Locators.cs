

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    
    public class Locators
    {
        // Locators = Xpath, Css, id, classname, name, tagname, linktext 
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            // Implicit waite can be declared globally
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }

        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("Chandu");
            driver.FindElement(By.Name("password")).SendKeys("Samaleti");

            // css selector paths

            // #id  /  #terms= value
            // tagname[attribute='value']
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();                    //------->parent to child Css selector

            // xpath paths
            // //tagname[@attribute='value']
            //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();            //------->parent to child Xpath
            //Thread.Sleep(3000);

            // We are giving Explicit wait for a particular thing where it take more than the implicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath("//input[@value='Sign In']")),"Sign In"));
            string errorMesasge = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMesasge);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            string hrefAttribute = link.GetAttribute("href");
            string expectedUrl = "https://rahulshettyacademy.com/documents-request";

            Assert.AreEqual(expectedUrl, hrefAttribute);                                                         //-------> we can pass here expected and actual value
        }
    }
}
