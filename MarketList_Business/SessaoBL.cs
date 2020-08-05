using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Model;

namespace MarketList_Business
{
    public class SessaoBL : BaseBusiness<Sessao>, ISessaoBL
    {
        public SessaoBL(MarketListContext context) : base(context)
        {
        }
    }
}