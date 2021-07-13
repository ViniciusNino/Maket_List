using System;
using System.Linq;
using System.Reflection;
using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Repository;

namespace MarketList_Business
{
    public abstract class BaseBusiness<T> : IBaseBusiness<T> where T : class
    {
        private BaseRepository<T> _rep;
        private MarketListContext _marketListContest;
        public BaseBusiness(MarketListContext marketListContext)
        {
            _marketListContest = marketListContext;
            _rep = new BaseRepository<T>(_marketListContest);
        }
        public T GetId(int id)
        {
            try
            {
                return _rep.GetId(id);
            }
            catch (Exception e)
            {

                throw new Exception("Não foi possível realizar a consulta! Mensagem: " + e.Message);
            }
        }
        public IQueryable<T> List()
        {
            try
            {
                return _rep.List();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível realizar a consulta! Mensagem: " + e.Message);
            }
        }
        public T Adicionar(T item)
        {
            try
            {
                _rep.Adicionar(item);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível realizar a persistência dos dados! Mensagem: " + e.Message);
            }
            return item;
        }
        public void Atualizar(T item)
        {
            try
            {
                _rep.Atualizar(item);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível realizar a atualização dos dados! " + e.Message);
            }
        }
        public void Remover(int id)
        {
            try
            {
                var entity = _rep.GetId(id);
                if (entity == null)
                    throw new Exception("Entidade não encontrada!");
                _rep.Remover(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível relaizar a exclusão! Mensagem: " + e.Message);
            }
        }
    }
}