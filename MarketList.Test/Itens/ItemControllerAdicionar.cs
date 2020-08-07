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
        public void AdicionartemValidoRetornaOk()
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
        public void teste2()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}