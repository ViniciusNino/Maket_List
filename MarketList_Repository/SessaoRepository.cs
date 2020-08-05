using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class SessaoRepository : BaseRepository<Sessao>, ISessaoRepository
    {
        public SessaoRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}