using System;
using MarketList_Business.Interfaces;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : Controller
    {
        private readonly ISessaoBL _sessaoBL;
        public SessaoController(ISessaoBL sessaoBL)
        {
            _sessaoBL = sessaoBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaSessao = _sessaoBL.List();
                if (listaSessao == null)
                    return NotFound();

                return Ok(listaSessao);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult Post(Sessao sessao)
        {
            try
            {
                _sessaoBL.Adicionar(sessao);
                return Ok("Sessão adicionada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
