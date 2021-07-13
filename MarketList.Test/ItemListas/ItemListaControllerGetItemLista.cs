using System;
using System.Collections.Generic;
using MarketList_Api.Controllers;
using MarketList_Business;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketList.Test.ItemListas
{
    [TestClass]
    public class ItemListaControllerGetItemLista
    {
        [TestMethod]
        public void RetornaItemListasDeUmaLista()
        {
            //Arrange
            // List<vmItemEItemLista> lItemLista = new List<vmItemEItemLista>(){
            //     new vmItemEItemLista() { Id = 1, NIdItem = 1, NQuantidade = 3m, SUnidadeMedida = "kg", DCadastro = DateTime.Now, BAtivo = true, NIdStatusItemLista = 1, NIdUsuarioSolicitante = 1},
            //     new vmItemEItemLista() { Id = 2, NIdItem = 2, NQuantidade = 3m, SUnidadeMedida = "un", DCadastro = DateTime.Now, BAtivo = true, NIdStatusItemLista = 1, NIdUsuarioSolicitante = 1},
            //     new vmItemEItemLista() { Id = 3, NIdItem = 3, NQuantidade = 3m, SUnidadeMedida = "lt", DCadastro = DateTime.Now, BAtivo = true, NIdStatusItemLista = 1, NIdUsuarioSolicitante = 1},
            //     new vmItemEItemLista() { Id = 4, NIdItem = 4, NQuantidade = 3m, SUnidadeMedida = "kg", DCadastro = DateTime.Now, BAtivo = true, NIdStatusItemLista = 1, NIdUsuarioSolicitante = 1}
            // }; 
            var options = new DbContextOptionsBuilder<MarketListContext>()
            .UseInMemoryDatabase("RetornaItemListasDeUmaLista")
            .Options;
            var contexto = new MarketListContext(options);
            var itemListaBL = new ItemListaBL(contexto);
            var itemListaController = new ItemListaController(itemListaBL);

            //itemListaBL.AdicionarLista();
            //Act

            //Assert
        }
    }
}