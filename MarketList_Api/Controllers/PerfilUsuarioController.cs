using System;
using MarketList_Business.Interfaces;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilUsuarioController : Controller
    {
        private readonly IPerfilUsuarioBL _perfilUsuarioBL;
        public PerfilUsuarioController(IPerfilUsuarioBL perfilUsuarioBL)
        {
            _perfilUsuarioBL = perfilUsuarioBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaPerfilUsuario = _perfilUsuarioBL.List();
                if (listaPerfilUsuario == null)
                    return NotFound();

                return Ok(listaPerfilUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public IActionResult Post(PerfilUsuario perfilUsuario)
        {
            try
            {
            _perfilUsuarioBL.Adicionar(perfilUsuario);
            return Ok("Perfil do Usuário adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}