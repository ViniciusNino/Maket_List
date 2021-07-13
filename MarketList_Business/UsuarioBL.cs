using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using MarketList_Repository;

namespace MarketList_Business
{
    public class UsuarioBL : BaseBusiness<Usuario>, IUsuarioBL
    {
        private UsuarioRepository usuarioRep;
        private MarketListContext _context;
        public UsuarioBL(MarketListContext context) : base(context)
        {
            _context = context;
            usuarioRep = new UsuarioRepository(_context);
        }
        private vmUsuarioAutenticado ParseUsuarioToVmUsuarioAutenticado(Usuario usuario)
        {
            UnidadeRepository unidadeRep = new UnidadeRepository(_context);
            vmUsuarioAutenticado _vmUsuarioAutenticado = new vmUsuarioAutenticado
            {
                nIdUsuarioAutenticado = usuario.Id,
                sNome = usuario.SUsuario,
                nIdPerfilUsuario = usuario.NIdPerfilUsuario,
                nIdUnidade = usuario.NIdUnidade,
                sNomeUnidade = unidadeRep.GetId(usuario.NIdUnidade).SNome
            };
            return _vmUsuarioAutenticado;
        }
        public vmUsuarioAutenticado Autenticar(Usuario usuario)
        {
            var usuarioAutenticado = usuarioRep.Autenticar(usuario);
            if (usuario == null || usuario.SSenha == null || usuario.SUsuario == null || usuarioAutenticado == null)
            {
                return new vmUsuarioAutenticado();
            }
            return ParseUsuarioToVmUsuarioAutenticado(usuarioAutenticado);
        }
    }
}