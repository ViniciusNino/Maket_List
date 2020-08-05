using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class StatusUsuarioRepository : BaseRepository<StatusUsuario>, IStatusUsuarioRepository
    {
        public StatusUsuarioRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}