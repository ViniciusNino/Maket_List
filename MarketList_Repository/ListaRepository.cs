using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class ListaRepository : BaseRepository<Lista>, IListaRepository
    {
        public ListaRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}