using System;
using MarketList_Api.Controllers;
using MarketList_Business;
using MarketList_Data;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarketList.Test.Itens
{
    [TestClass]
    public class ItemControllerAdicionar
    {
        [TestMethod]
        public void AdicionartemValido()
        {
            //Arrange
            var id = 1;
            var comando = new Item { Id = id, SNome = "Queijo", SUnidadeMedida = "Kg", NIdSessao = 1 };

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("AdicionartemValido")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            var actionResult = itemController.Post(comando);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [DataRow(1, "Queijo", "Kg", 0)]
        [DataRow(1, "Queijo", null, 1)]
        [DataRow(1, null, "Kg", 1)]
        [TestMethod]
        public void AdicionarItemComCamposNullRetornaErro(int id, string nome, string un, int idSessao)
        {
            var comando = new Item { Id = id, SNome = nome, SUnidadeMedida = un, NIdSessao = idSessao };

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("AdicionarItemComCamposNullRetornaErro")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            var actionResult = itemController.Post(comando);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }
    }
}