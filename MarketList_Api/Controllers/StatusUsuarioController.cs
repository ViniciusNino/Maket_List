using System;
using MarketList_Business;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusUsuarioController : ControllerBase
    {
        private readonly StatusUsuarioBL _statusUsuarioBL;
        public StatusUsuarioController(StatusUsuarioBL statusUsuarioBL)
        {
            _statusUsuarioBL = statusUsuarioBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaStatusUsuario = _statusUsuarioBL.List();
                if (listaStatusUsuario == null)
                    return NotFound();

                return Ok(listaStatusUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult Post(StatusUsuario statusUsuario)
        {
            try
            {
                _statusUsuarioBL.Adicionar(statusUsuario);
                return Ok("Status do Usuário adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}