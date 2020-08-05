using System.Collections.Generic;
using System.Linq;

namespace MarketList_Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> List();
        T GetId(int id);
        T Adicionar(T item);
        void AdicionarLista(List<T> listaItem);
        void Atualizar(T item);
        void AtualizarLista(List<T> listaItem);
        void Remover(T item);
        void RemoverLista(List<T> listaItem);
    }
}