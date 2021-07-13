using System.Collections.Generic;
using MarketList_DTO;
using MarketList_Model;

namespace MarketList_Business.Interfaces
{
    public interface IItemListaBL : IBaseBusiness<ItemLista>
    {
        public IEnumerable<vmItemEItemLista> GetItemLista(int id);
        void AdicionarLista(List<vmItemEItemLista> vmItemEItemLista);
        void Atualizar(int id, List<vmItemEItemLista> lvmItensFront);
    }
}