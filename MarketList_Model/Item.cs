using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class Item : EntityBase
    {
        public Item()
        {
            ItemLista = new HashSet<ItemLista>();
        }

        public string SNome { get; set; }
        public int NIdSessao { get; set; }
        public string SUnidadeMedida { get; set; }


        public virtual Sessao NIdSessaoNavigation { get; set; }
        public virtual ICollection<ItemLista> ItemLista { get; set; }
    }
}
