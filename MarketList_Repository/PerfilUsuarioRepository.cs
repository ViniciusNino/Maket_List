using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class PerfilUsuarioRepository : BaseRepository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        public PerfilUsuarioRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}