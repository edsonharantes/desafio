using OpenQA.Selenium;
using Paschoalotto.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Paschoalotto.pages
{
    class SearchPage : Actions
    {
        IWebElement grid_produtos => driver.FindElement(By.CssSelector("div[class*='SearchTop'] + div"));

        public ProductPage seleciona_produto(string nome_produto)
        {
            IReadOnlyCollection<IWebElement> lista_produtos = grid_produtos.FindElements(By.CssSelector("div[class*='col__StyledCol']"));

            Assert.IsTrue(lista_produtos.Count > 0);

            foreach (IWebElement produto in lista_produtos)
            {
                IWebElement texto = produto.FindElement(By.CssSelector("div[class*='src__Wrapper'] > a > span[class*='src__Text']"));

                if (texto.Text.ToUpper().Contains(nome_produto.ToUpper()))
                {
                    click(produto);
                    return new ProductPage();
                }               
            }

            throw new Exception("produto não encontrado na lista de procura");
        }
    }
}
