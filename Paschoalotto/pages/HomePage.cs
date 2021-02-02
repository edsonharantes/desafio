using OpenQA.Selenium;
using Paschoalotto.util;

namespace Paschoalotto.pages
{
    class HomePage : Actions
    {
        IWebElement search_box => driver.FindElement(By.CssSelector("input[id=h_search-input]"));
        IWebElement search_button => driver.FindElement(By.CssSelector("button[id=h_search-btn]")); 
        public SearchPage procura_produto(string produto)
        {
            digita(search_box, produto);            
            click(search_button);

            return new SearchPage();
        }
    }
}
