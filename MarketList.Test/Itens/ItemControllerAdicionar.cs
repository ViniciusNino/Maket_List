using System;
using MarketList_Api.Controllers;
using MarketList_Business;
using MarketList_Data;
using MarketList_Model;
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

            var mock = new Mock<ILogger<ItemController>>();

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("MarketLisContext")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            itemController.Post(comando);

            //Assert
            var item = itemController.GetId(id);
            Assert.IsNotNull(item);
        }

        [DataRow(1, "Queijo", "Kg", null)]
        [DataRow(1, "Queijo", null, 1)]
        [DataRow(1, null, "Kg", 1)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AdicionarItemInvalidoRetornaErro(int id, string nome, string un, int idSessao)
        {
            var comando = new Item { Id = id, SNome = nome, SUnidadeMedida = un, NIdSessao = idSessao };

            var mock = new Mock<ILogger<ItemController>>();

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("MarketLisContext")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            itemController.Post(comando);

            //Assert

        }
    }
}