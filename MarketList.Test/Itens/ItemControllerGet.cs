using System.Collections.Generic;
using MarketList_Api.Controllers;
using MarketList_Business;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarketList.Test.Itens
{
    [TestClass]
    public class ItemControllerGet
    {
        [TestMethod]
        public void ListaTodosItensCadastrado()
        {
            //Arrange
            var listaItem = new List<vmItemEItemLista>{
                new vmItemEItemLista { Id = 1, SNome = "queijo", SUnidadeMedida = "Kg", NIdSessao = 1 },
                new vmItemEItemLista { Id = 2, SNome = "presunto", SUnidadeMedida = "Kg", NIdSessao = 1},
                new vmItemEItemLista { Id = 3, SNome = "papel toalha", SUnidadeMedida = "Un", NIdSessao = 2}
            };

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("ListaTodosItensCadastrado")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);
            foreach (var item in listaItem)
            {
                itemController.Post(item);
            }

            //Act
            var actionResult = itemController.Get();
            var okResult = actionResult as ObjectResult;
            var retorno = okResult.Value as List<vmItemEItemLista>;

            //Assert
            Assert.AreEqual(3, retorno.Count);
        }

        [TestMethod]
        public void RetornaNotFoundQuandoNaoTemItemCadastrado()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("RetornaNotFoundQuandoNaoTemItemCadastrado")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            var actionResult = itemController.Get();

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

         [TestMethod]
        public void RetornaListaNullQuandoNaoTemItemCadastrado()        {
            //Arrange
            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("RetornaListaNullQuandoNaoTemItemCadastrado")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            var actionResult = itemController.Get();
            var okResult = actionResult as ObjectResult;

            //Assert
            Assert.IsNull(okResult);
        }
    }
}
