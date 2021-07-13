using System;
using System.Collections.Generic;
using MarketList_Business.Interfaces;
using MarketList_DTO;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemListaController : Controller
    {
        private readonly IItemListaBL _itemListaBL;
        public ItemListaController(IItemListaBL itemListaBL)
        {
            _itemListaBL = itemListaBL;
        }

        [HttpGet]
        [Route("GetItemLista")]
        public IActionResult GetItemLista(int id)
        {
            try
            {
                var itemLista = _itemListaBL.GetItemLista(id);
                if (itemLista == null)
                    return NotFound();

                return Ok(itemLista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        [Route("Post")]
        public IActionResult Post(List<vmItemEItemLista> vmItemEItemLista)
        {
            try
            {
                _itemListaBL.AdicionarLista(vmItemEItemLista);
                return Ok("Item adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("PostAlualizarItens")]
        public IActionResult Post(int id, List<vmItemEItemLista> lvmItensFront)
        {
            try
            {
                _itemListaBL.Atualizar(id, lvmItensFront);
                return Ok("Item atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}