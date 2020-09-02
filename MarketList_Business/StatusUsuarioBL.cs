using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Model;

namespace MarketList_Business
{
    public class StatusUsuarioBL : BaseBusiness<StatusUsuario>, IStatusUsuarioBL
    {
        public StatusUsuarioBL(MarketListContext context) : base(context)
        {
        }
    }
}