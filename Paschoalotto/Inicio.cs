using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paschoalotto.pages;
using Paschoalotto.util;
using SwiftExcel;
using System.Collections.Generic;

namespace Paschoalotto
{
    [TestClass]
    public class Inicio
    {
        public static ExcelWriter ew;

        [TestInitialize]
        public void setup()
        {
            Driver driver = new Driver();

            driver.init("https://www.americanas.com.br/");

            ew = new ExcelWriter("D:/resultado.xlsx");

            ew.Write("Produto pesquisado", 1, 1);
            ew.Write("Produto selecionado", 2, 1);
            ew.Write("Preço à vista", 3, 1);
            ew.Write("Valor do cashback", 4, 1);
        }

        [TestCleanup]
        public void cleanUp()
        {
            Driver.driver.Close();
        }

        [TestMethod]
        public void Procura_ProdutoE_Retorna_Preco_AVistaE_CashBack()
        {
            List<string> produtos_pesquisados = new List<string>()
            {
                "Samsung Galaxy A70",
                "Motorola Moto One Vision",
                "Smartphone Xiaomi Redmi Note 7"
            };

            HomePage homePage = new HomePage();

            int index = 1;

            foreach (var produto_pesquisado in produtos_pesquisados)
            {
                ProductPage paginaProduto = homePage.procura_produto(produto_pesquisado).seleciona_produto(produto_pesquisado);

                string nome_produto_selecionado = paginaProduto.retorna_produto_selecionado();
                string preco_avista = paginaProduto.retorna_preco_avista();
                string cashback = paginaProduto.retorna_cash_back();

                index++;

                ew.Write(produto_pesquisado, 1, index);
                ew.Write(nome_produto_selecionado, 2, index);
                ew.Write(preco_avista, 3, index);
                ew.Write(cashback, 4, index);
            }

            ew.Save();
        }
    }
}
