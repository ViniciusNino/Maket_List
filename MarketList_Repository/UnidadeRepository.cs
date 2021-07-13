using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class UnidadeRepository : BaseRepository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(MarketListContext context) : base(context)
        {
            
        }
    }
}