using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Model;

namespace MarketList_Business
{
    public class UnidadeBL : BaseBusiness<Unidade>, IUnidadeBL
    {
        public UnidadeBL(MarketListContext context) : base(context)
        {
        }
    }
}