using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Paschoalotto.util
{
    abstract class Actions : Driver
    {        
        public void click(IWebElement elemento, int espera = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(espera));
                wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
                elemento.Click();
            }
            catch
            {
                throw new Exception("erro ao clicar no elemento: " + elemento);
            }
        }

        public void digita(IWebElement elemento, string texto, int espera = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(espera));
                wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
                elemento.SendKeys(texto);
            }
            catch
            {
                throw new Exception("erro ao digitar no elemento: " + elemento);
            }
        }
    }
}
