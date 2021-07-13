using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketList_Model
{
    public partial class Unidade : EntityBase
    {
        public Unidade()
        {
            Lista = new HashSet<Lista>();
            Usuario = new HashSet<Usuario>();
        }
        public string SNome { get; set; }
        public virtual ICollection<Lista> Lista { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
