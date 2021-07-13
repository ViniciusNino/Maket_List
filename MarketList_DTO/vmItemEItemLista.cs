using MarketList_Model;

namespace MarketList_DTO
{
    public class vmItemEItemLista : Item
    {
        public int? nIdItemLista { get; set; }
        public decimal nQuantidade { get; set; }
        public int nIdUsuarioLogado { get; set; }
    }
}