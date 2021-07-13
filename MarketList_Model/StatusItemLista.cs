using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class StatusItemLista : EntityBase
    {
        public StatusItemLista()
        {
            ItemLista = new HashSet<ItemLista>();
        }

        public string SDescricao { get; set; }

        public virtual ICollection<ItemLista> ItemLista { get; set; }
    }
}
