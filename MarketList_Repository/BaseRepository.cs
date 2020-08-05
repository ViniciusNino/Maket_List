using System;
using System.Collections.Generic;
using System.Linq;
using MarketList_Data;
using MarketList_Repository.Interfaces;

namespace MarketList_Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private MarketListContext _context;
        private IQueryable<T> _enumer;
        public BaseRepository(MarketListContext context)
        {
            _context = context;
            _enumer = context.Set<T>().AsQueryable();
        }
        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }
        public T Adicionar(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
            return item;
        }
        public void AdicionarLista(List<T> listaItem)
        {
            foreach (var item in listaItem)
            {
                _context.Set<T>().Add(item);
            }
            _context.SaveChanges();
        }
        public void Atualizar(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
        public void AtualizarLista(List<T> listaItem)
        {
            foreach (var item in listaItem)
            {
                _context.Set<T>().Update(item);
            }
            _context.SaveChanges();
        }
        public void Remover(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
        public void RemoverLista(List<T> listaItem)
        {
            foreach (var item in listaItem)
            {
                _context.Set<T>().Remove(item);
            }
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}