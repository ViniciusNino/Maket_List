using System;
using MarketList_Business;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly ItemBL _itemBL;

        public ItemController(ItemBL itemBL)
        {
            _itemBL = itemBL;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var lista = _itemBL.ListVm();
                if (lista == null)
                    return NotFound();


                return Ok(lista);
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
                _itemBL.Adicionar(item);
                return Ok("Item adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}