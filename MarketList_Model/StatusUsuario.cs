using System;
using System.Collections.Generic;

namespace MarketList_Model
{
    public partial class StatusUsuario : EntityBase
    {
        public StatusUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public string SDescricao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
