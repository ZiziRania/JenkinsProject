
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using UnitTestProject2;
using OpenQA.Selenium.Support.UI;


namespace TestProject2
{
    [TestFixture]
    public class SendForm
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;
        ReadData read= new ReadData();
        Client client;


        [TearDown]
        public void Fin()
        { 
            driver.Quit();
            Console.WriteLine("je suis dans la partie fin");
        }
        [Test]
        public void WithGuest()
        {
            client= read.ReadDataFromJson();


            driver.Navigate().GoToUrl("https://form.jotform.com/241565975940367");
            driver.Manage().Window.Maximize();
            Assert.AreEqual("Your Name", driver.FindElement(By.Id("label_4")).Text);

            OpenQA.Selenium.Support.UI.SelectElement select = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("prefix_4")));
            select.SelectByValue(client.Prefix);
            driver.FindElement(By.XPath("//*[@id=\"first_4\"]")).SendKeys(client.FirstName);
            driver.FindElement(By.XPath("//*[@id=\"last_4\"]")).SendKeys(client.LastName);
            driver.FindElement(By.CssSelector("#input_5")).SendKeys(client.EmailAddress);
            driver.FindElement(By.Id("input_6_full")).SendKeys(client.ContactNumber);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_7_1")));

            //Cliquer sur YES
            driver.FindElement(By.Id("label_input_7_0")).Click();
            SelectElement selectGuestPrefix = new SelectElement(driver.FindElement(By.Id("prefix_11")));
            selectGuestPrefix.SelectByValue(client.Guest.Prefix);
            driver.FindElement(By.Id("first_11")).SendKeys(client.Guest.FirstName);
            driver.FindElement(By.XPath("//*[@id=\"last_11\"]")).SendKeys(client.Guest.LastName);
            driver.FindElement(By.CssSelector("#input_12")).SendKeys(client.Guest.EmailAddress);
            driver.FindElement(By.Id("input_13_full")).SendKeys(client.Guest.ContactNumber);



            driver.FindElement(By.Id("label_input_22_0")).Click();

            
            //select.SelectByIndex(1);
            //select.SelectByText("Miss.");

            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("input_2")));
            driver.FindElement(By.Id("input_2")).Submit();
            Assert.AreEqual("Thank You!", driver.FindElement(By.XPath("//*[@id=\"stage\"]/div[1]/div/div/h1")).Text);


            Console.WriteLine("je suis dans la partie test");
        }
        [Test]
        public void WithOutGuest()
        {
            client = read.ReadDataFromJson();


            driver.Navigate().GoToUrl("https://form.jotform.com/241565975940367");
            driver.Manage().Window.Maximize();
            Assert.AreEqual("Your Name", driver.FindElement(By.Id("label_4")).Text);

            OpenQA.Selenium.Support.UI.SelectElement select = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("prefix_4")));
            select.SelectByValue(client.Prefix);
            driver.FindElement(By.XPath("//*[@id=\"first_4\"]")).SendKeys(client.FirstName);
            driver.FindElement(By.XPath("//*[@id=\"last_4\"]")).SendKeys(client.LastName);
            driver.FindElement(By.CssSelector("#input_5")).SendKeys(client.EmailAddress);
            driver.FindElement(By.Id("input_6_full")).SendKeys(client.ContactNumber);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_7_1")));

            //Cliquer sur NO
            driver.FindElement(By.Id("label_input_7_0")).Click();



            driver.FindElement(By.Id("label_input_22_0")).Click();


            //select.SelectByIndex(1);
            //select.SelectByText("Miss.");

            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("input_2")));
            driver.FindElement(By.Id("input_2")).Submit();
            Assert.AreEqual("Thank You!", driver.FindElement(By.XPath("//*[@id=\"stage\"]/div[1]/div/div/h1")).Text);


            Console.WriteLine("je suis dans la partie test");
        }



        [SetUp]
        public void Debut()
        {
            js = (IJavaScriptExecutor)driver;
            driver = new ChromeDriver(@"C:\\selenium\chromedriver.exe");
            Console.WriteLine("je suis dans la partie setup");
        }

    }
}
