using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class Usuario : EntityBase
    {
        public Usuario()
        {

            _PerfilUsuario = new PerfilUsuario();
            _StatusUsuario = new StatusUsuario();
            ItemListaNIdUsuarioCompradorNavigation = new HashSet<ItemLista>();
            ItemListaNIdUsuarioSolicitanteNavigation = new HashSet<ItemLista>();
        }
        public string SUsuario { get; set; }
        public string SSenha { get; set; }
        public int NIdPerfilUsuario { get; set; }
        public int NIdStatusUsuario { get; set; }
        public int NIdUnidade { get; set; }

        public virtual PerfilUsuario _PerfilUsuario { get; set; }
        public virtual StatusUsuario _StatusUsuario { get; set; }
        public virtual ICollection<ItemLista> ItemListaNIdUsuarioCompradorNavigation { get; set; }
        public virtual ICollection<ItemLista> ItemListaNIdUsuarioSolicitanteNavigation { get; set; }
        public virtual Unidade NIdUnidadeNavigation { get; set; }
    }
}
