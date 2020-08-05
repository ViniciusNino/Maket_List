using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Model;

namespace MarketList_Business
{
    public class StatusItemListaBL : BaseBusiness<StatusItemLista>, IStatusItemListaBL
    {
        public StatusItemListaBL(MarketListContext context) : base(context)
        {
        }
    }
}