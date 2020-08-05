using System;
using System.Linq;
using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MarketListContext context) : base(context)
        {

        }

        public Usuario Autenticar(Usuario usuario)
        {
            return this.List().Where(x => x.SUsuario == usuario.SUsuario && x.SSenha == usuario.SSenha && x.NIdStatusUsuario == 1).FirstOrDefault();
        }
    }
}