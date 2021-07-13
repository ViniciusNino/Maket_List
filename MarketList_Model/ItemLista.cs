using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class ItemLista : EntityBase
    {
        public int NIdLista { get; set; }
        public int NIdItem { get; set; }
        public decimal NQuantidade { get; set; }
        public string SUnidadeMedida { get; set; }
        public DateTime DCadastro { get; set; }
        public bool BAtivo { get; set; }
        public int NIdStatusItemLista { get; set; }
        public int NIdUsuarioSolicitante { get; set; }
        public int? NIdUsuarioComprador { get; set; }

        public virtual Item NIdItemNavigation { get; set; }
        public virtual Lista NIdListaNavigation { get; set; }
        public virtual StatusItemLista NIdStatusItemListaNavigation { get; set; }
        public virtual Usuario NIdUsuarioCompradorNavigation { get; set; }
        public virtual Usuario NIdUsuarioSolicitanteNavigation { get; set; }
    }
}
