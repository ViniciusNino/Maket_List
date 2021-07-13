using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class StatusItemListaRepository : BaseRepository<StatusItemLista>, IStatusItemListaRepository
    {
        public StatusItemListaRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}