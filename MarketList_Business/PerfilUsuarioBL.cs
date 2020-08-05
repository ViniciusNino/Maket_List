using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Model;

namespace MarketList_Business
{
    public class PerfilUsuarioBL : BaseBusiness<PerfilUsuario>, IPerfilUsuarioBL
    {
        public PerfilUsuarioBL(MarketListContext context) : base(context)
        {
        }
    }
}