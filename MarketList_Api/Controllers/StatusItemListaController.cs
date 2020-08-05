using System;
using MarketList_Business;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusItemListaController : ControllerBase
    {
        private readonly StatusItemListaBL _statusItemListaBL;
        public StatusItemListaController(StatusItemListaBL statusItemListaBL)
        {
            _statusItemListaBL = statusItemListaBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaStatusItemLista = _statusItemListaBL.List();
                if (listaStatusItemLista == null)
                    return NotFound();

                return Ok(listaStatusItemLista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult Post(StatusItemLista statusItemLista)
        {
            try
            {
                _statusItemListaBL.Adicionar(statusItemLista);
                return Ok("Status da Lista adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}