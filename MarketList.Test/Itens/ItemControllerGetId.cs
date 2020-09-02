using System.Threading.Tasks;
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
    public class ItemControllerGetId
    {

        [TestMethod]
        public void BuscarItemPorIdRetornaObjeto()
        {
            //Arrange
            var objeto = new vmItemEItemLista() { Id = 1, SNome = "teste", SUnidadeMedida = "Kg", NIdSessao = 1 };

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("BuscarItemPorIdRetornaObjeto")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);
            itemController.Post(objeto);

            //Act
            var actionResult = itemController.GetId(1);
            var okResult = actionResult as OkObjectResult;
            var item = okResult.Value as vmItemEItemLista;


            //Assert
            Assert.AreEqual(objeto.SNome, item.SNome);
        }

        [TestMethod]
        public void BuscarItemPorIdQueNaoExisteRetornaNotFound()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("BuscarItemPorIdQueNaoExisteRetornaNotFound")
                .Options;
            var contexto = new MarketListContext(options);
            var itemBL = new ItemBL(contexto);
            var itemController = new ItemController(itemBL);

            //Act
            var actionResult = itemController.GetId(300);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}