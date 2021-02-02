using OpenQA.Selenium;
using Paschoalotto.util;

namespace Paschoalotto.pages
{
    class ProductPage : Actions
    {
        IWebElement preco_avista => driver.FindElement(By.CssSelector("div[class*='priceSales']"));
        IWebElement cash_back => driver.FindElement(By.CssSelector("span[class*='cashback']"));
        IWebElement nome_produto => driver.FindElement(By.CssSelector("div[class*='ProductInfoContainer'] > div + div > span"));

        public string retorna_preco_avista()
        {
            return preco_avista.Text;
        }
        public string retorna_cash_back()
        {
            string cashback = cash_back.Text;            
            cashback = cashback.Remove(9);

            return cashback.Trim();
        }

        public string retorna_produto_selecionado()
        {
            return nome_produto.Text.Trim();
        }
    }
}
