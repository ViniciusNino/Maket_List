using System.Collections.Generic;
using MarketList_DTO;
using MarketList_Model;

namespace MarketList_Business.Interfaces
{
    public interface IItemBL : IBaseBusiness<Item>
    {
        IEnumerable<vmItemEItemLista> ListVm();
    }
}