using System.ComponentModel.DataAnnotations;

namespace MarketList_Model
{
    public class EntityBase
    {
        [Key]
        public virtual int Id { get; set; }
    }
}