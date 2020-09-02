using System.Collections.Generic;
using MarketList_DTO;
using MarketList_Model;

namespace MarketList_Business.Interfaces
{
    public interface IListaBL : IBaseBusiness<Lista>
    {
        public IEnumerable<vmListaUnidade> GetPorUnidade(int id);
    }
}