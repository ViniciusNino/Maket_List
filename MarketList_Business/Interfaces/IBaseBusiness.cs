using System.Linq;

namespace MarketList_Business.Interfaces
{
    public interface IBaseBusiness<T> where T : class
    {
        T GetId(int id);
        IQueryable<T> List();
        T Adicionar(T item);
        void Remover(int id);
    }
}