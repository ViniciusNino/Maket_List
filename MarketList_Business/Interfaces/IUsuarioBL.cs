using MarketList_DTO;
using MarketList_Model;

namespace MarketList_Business.Interfaces
{
    public interface IUsuarioBL : IBaseBusiness<Usuario>
    {
        public vmUsuarioAutenticado Autenticar(Usuario usuario);
    }
}