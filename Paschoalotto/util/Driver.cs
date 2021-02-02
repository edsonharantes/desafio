using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Paschoalotto.util
{
    class Driver
    {
        ChromeOptions options = new ChromeOptions();

        public static IWebDriver driver;

        public void init(string url)
        {
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             
            driver.Url = url;
        }
    }
}
