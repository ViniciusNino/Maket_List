using System;
using MarketList_Business.Interfaces;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaController : Controller
    {
        private readonly IListaBL _listaBL;
        public ListaController(IListaBL listaBL)
        {
            _listaBL = listaBL;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var lLista = _listaBL.List();
                if (lLista == null)
                    return NotFound();
                return Ok(lLista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetPorUnidade")]
        public IActionResult GetPorUnidade(int id)
        {
            try
            {
                var listaUnidade = _listaBL.GetPorUnidade(id);
                if (listaUnidade == null)
                    return NotFound();
                return Ok(listaUnidade);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(Lista lista)
        {
            try
            {
                _listaBL.Adicionar(lista);
                return Ok("Lista adicionada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}