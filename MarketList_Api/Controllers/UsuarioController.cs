using System;
using MarketList_Business;
using MarketList_Model;
using Microsoft.AspNetCore.Mvc;

namespace MarketList_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBL _usuarioBL;
        
        public UsuarioController(UsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                var listaUsuario = _usuarioBL.List();
                if (listaUsuario == null)
                    return NotFound();
                return Ok(listaUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioBL.Adicionar(usuario);
                return Ok("Usuario adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("Autenticar")]
        public IActionResult Autenticar(Usuario usuario)
        {
            try
            {
                _usuarioBL.Autenticar(usuario);
                return Ok("Usuario Autenticado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
