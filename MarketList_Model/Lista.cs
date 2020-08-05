using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class Lista : EntityBase
    {
        public Lista()
        {
            ItemLista = new HashSet<ItemLista>();
        }

        public int NIdUnidade { get; set; }
        public int NIdUsuario { get; set; }
        public bool BAtivo { get; set; }
        public DateTime DCadastro { get; set; }
        public string SNome { get; set; }

        public virtual Unidade NIdUnidadeNavigation { get; set; } 
        public virtual Unidade NIdUsuarioNavigation { get; set; }
        //public virtual Usuario NIdUsuarioNavigation { get; set; }
        public virtual ICollection<ItemLista> ItemLista { get; set; }
    }
}
