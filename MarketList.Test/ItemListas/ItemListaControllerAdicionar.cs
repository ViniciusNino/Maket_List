using System.Collections.Generic;
using MarketList_Api.Controllers;
using MarketList_Business;
using MarketList_Data;
using MarketList_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketList.Test.ItemListas
{
    [TestClass]
    public class ItemListaControllerAdicionar
    {
        [TestMethod]
        public void AdicionarItemListaRetornaOkResult()
        {
            //Arrange
            List<vmItemEItemLista> lvmItemEItemLista = new List<vmItemEItemLista>(){
                new vmItemEItemLista() {Id = 1, SNome = "item1", NIdSessao = 1, nQuantidade = 2, SUnidadeMedida = "kg", nIdUsuarioLogado = 1, },
                new vmItemEItemLista() {Id = 2, SNome = "item2", NIdSessao = 2, nQuantidade = 6, SUnidadeMedida = "un", nIdUsuarioLogado = 1, },
                new vmItemEItemLista() {Id = 3, SNome = "item3", NIdSessao = 3, nQuantidade = 22, SUnidadeMedida = "lt", nIdUsuarioLogado = 1, },
                new vmItemEItemLista() {Id = 4, SNome = "item4", NIdSessao = 4, nQuantidade = 1, SUnidadeMedida = "cx", nIdUsuarioLogado = 1, }
            };

            var options = new DbContextOptionsBuilder<MarketListContext>()
                .UseInMemoryDatabase("AdicionarItemListaRetornaOkResult")
                .Options;
            var contexto = new MarketListContext(options);
            var itemListaBL = new ItemListaBL(contexto);
            var itemListaController = new ItemListaController(itemListaBL);

            //Act
            var retorno = itemListaController.Post(lvmItemEItemLista);

            //Assert
            Assert.IsInstanceOfType(retorno, typeof(OkResult));
            //Assert.AreEqual(4, lvmItemEItemLista.Count);

        }
    }
}