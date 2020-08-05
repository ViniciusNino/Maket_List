using System;
using MarketList_Business;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadeController : ControllerBase
    {
        private readonly UnidadeBL _unidadeBL;
        public UnidadeController(UnidadeBL unidadeBL)
        {
            _unidadeBL = unidadeBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaunidade = _unidadeBL.List();
                if (listaunidade == null)
                    return NotFound();

                return Ok(listaunidade);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult Post(Unidade unidade)
        {
            try
            {
                _unidadeBL.Adicionar(unidade);
                return Ok("Status do Usuário adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}