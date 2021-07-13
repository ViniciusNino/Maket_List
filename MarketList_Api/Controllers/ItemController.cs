using System;
using System.Linq;
using MarketList_Business.Interfaces;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemBL _itemBL;
        public ItemController(IItemBL itemBL)
        {
            _itemBL = itemBL;
        }
        private bool ItemValido(Item item)
        {
            if (item.SNome == null || item.SUnidadeMedida == null || item.NIdSessao == 0)
                return false;
            return true;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var lista = _itemBL.ListVm().ToList();
                if (lista == null || lista.Count == 0)
                    return NotFound();

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpGet]
        [Route("GetId")]
        public ActionResult GetId(int id)
        {
            try
            {
                var item = _itemBL.GetId(id);
                if (item == null)
                    return NotFound();
                return Ok(item);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(Item item)
        {
            try
            {
                if (ItemValido(item))
                {
                    _itemBL.Adicionar(item);
                    return Ok("Item adicionado com sucesso!");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}