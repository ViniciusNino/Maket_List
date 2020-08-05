using System;
using System.Collections.Generic;
using System.Linq;
using MarketList_Data;
using MarketList_Model;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class ItemListaRepository : BaseRepository<ItemLista>, IItemListaRepository
    {
        public ItemListaRepository(MarketListContext context) : base(context)
        {

        }
        public List<ItemLista> GetPorIdLista(int id)
        {
            return this.List().Where(x => x.NIdLista == id).ToList();
        }
    }
}