using System;
using MarketList_Model;

namespace MarketList_Repository.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>, IDisposable
    {
        
    }
}