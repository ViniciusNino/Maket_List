using System;
using System.Collections.Generic;
using System.Linq;
using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using MarketList_Repository;
using MarketList_Repository.Interfaces;

namespace MarketList_Business
{
    public class ItemListaBL : BaseBusiness<ItemLista>, IItemListaBL
    {
        private ItemListaRepository itemListaRep;
        private MarketListContext _context;
        public ItemListaBL(MarketListContext context) : base(context)
        {
            _context = context;
            itemListaRep = new ItemListaRepository(_context);
        }
        private vmItemEItemLista ParseItemListaToVmItemEItemLista(ItemLista itemLista, ItemRepository itemRep)
        {
            vmItemEItemLista vmItemEItemLista = new vmItemEItemLista()
            {
                nIdItemLista = itemLista.Id,
                nQuantidade = itemLista.NQuantidade,
                SNome = itemRep.GetId(itemLista.NIdItem).SNome,
                SUnidadeMedida = itemLista.SUnidadeMedida
            };
            return vmItemEItemLista;
        }
        private ItemLista CriarItem(vmItemEItemLista vmItemEItemLista, int nIdLista)
        {
            ItemLista itemLista = new ItemLista();
            itemLista.NIdLista = nIdLista;
            itemLista.NIdItem = vmItemEItemLista.Id;
            itemLista.NQuantidade = vmItemEItemLista.nQuantidade;
            itemLista.SUnidadeMedida = vmItemEItemLista.SUnidadeMedida;
            itemLista.DCadastro = DateTime.Now;
            itemLista.BAtivo = true;
            itemLista.NIdStatusItemLista = 1; // Solicitado
            itemLista.NIdUsuarioSolicitante = vmItemEItemLista.nIdUsuarioLogado;
            return itemLista;
        }
        private Lista CriarLista(List<vmItemEItemLista> vmItemEItemLista)
        {
            UsuarioRepository usuarioRep = new UsuarioRepository(_context);
            ListaRepository listaRep = new ListaRepository(_context);
            Lista lista = new Lista();

            lista.NIdUsuario = vmItemEItemLista[0].nIdUsuarioLogado;
            lista.NIdUnidade = usuarioRep.GetId(vmItemEItemLista[0].nIdUsuarioLogado).NIdUnidade;
            lista.BAtivo = true;
            lista.DCadastro = DateTime.Now;
            return listaRep.Adicionar(lista);
        }
        private List<ItemLista> AddItensListaExistente(List<vmItemEItemLista> lvmItensFront, int id)
        {
            List<vmItemEItemLista> lvmItemAdd = lvmItensFront.Where(x => x.Id != 0).ToList();
            List<ItemLista> lItemListaAdd = new List<ItemLista>();
            if (lvmItemAdd.Count != 0)
            {
                foreach (var i in lvmItemAdd)
                {
                    lItemListaAdd.Add(CriarItem(i, id));
                }
            }
            return lItemListaAdd;
        }
        private List<ItemLista> AtualizarItensListaExistente(List<vmItemEItemLista> lvmItensFront, List<ItemLista> lItemListaAntiga)
        {
            List<vmItemEItemLista> lvmItensAtualizar = lvmItensFront.Where(x => x.Id == 0).ToList();

            if (lvmItensAtualizar.Count != 0)
            {
                foreach (var i in lItemListaAntiga)
                {
                    for (int n = 0; n < lvmItensAtualizar.Count; n++)
                    {
                        if (i.Id == lvmItensAtualizar[n].nIdItemLista)
                        {
                            i.NQuantidade = lvmItensAtualizar[n].nQuantidade;
                            n = lvmItensAtualizar.Count;
                        }
                        lItemListaAntiga.Remove(i);
                    }
                }
            }
            return lItemListaAntiga;
        }
        private List<ItemLista> RemoverItensListaExistente(List<vmItemEItemLista> lvmItensFront, List<ItemLista> lItemListaAntiga)
        {
            List<vmItemEItemLista> lvmItensAtualizar = lvmItensFront.Where(x => x.Id == 0).ToList();

            if (lvmItensAtualizar.Count != 0)
            {
                foreach (var i in lItemListaAntiga)
                {
                    for (int n = 0; n < lvmItensAtualizar.Count; n++)
                    {
                        if (i.Id == lvmItensAtualizar[n].nIdItemLista)
                        {
                            lItemListaAntiga.Remove(i);
                            n = lvmItensAtualizar.Count;
                        }
                    }
                }
            }
            return lItemListaAntiga;
        }
        public IEnumerable<vmItemEItemLista> GetItemLista(int id)
        {
            ItemListaRepository itemListaRep = new ItemListaRepository(_context);
            ItemRepository itemRep = new ItemRepository(_context);
            var lItemLista = itemListaRep.GetPorIdLista(id);
            List<vmItemEItemLista> lvmItemEItemLista = new List<vmItemEItemLista>();

            foreach (var itemLista in lItemLista)
            {
                lvmItemEItemLista.Add(ParseItemListaToVmItemEItemLista(itemLista, itemRep));
            }

            return lvmItemEItemLista;
        }
        public void AdicionarLista(List<vmItemEItemLista> vmItemEItemLista)
        {
            try
            {
                ItemListaRepository itemListaRep = new ItemListaRepository(_context);
                List<ItemLista> lItemLista = new List<ItemLista>();

                int idLista = CriarLista(vmItemEItemLista).Id;
                foreach (var i in vmItemEItemLista)
                {
                    lItemLista.Add(CriarItem(i, idLista));
                }
                itemListaRep.AdicionarLista(lItemLista);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível realizar a persistência dos dados! Mensagem: " + e.Message);
            }

        }
        public void Atualizar(int id, List<vmItemEItemLista> lvmItensFront)
        {
            try
            {
                List<ItemLista> lItemListaAntiga = itemListaRep.GetPorIdLista(id).ToList();

                var listaAdd = AddItensListaExistente(lvmItensFront, id);
                var listaAtualizar = AtualizarItensListaExistente(lvmItensFront, lItemListaAntiga);
                var listaRemover = RemoverItensListaExistente(lvmItensFront, lItemListaAntiga);
                if (listaAdd.Count > 0)
                    itemListaRep.AdicionarLista(listaAdd);
                if (listaAtualizar.Count > 0)
                    itemListaRep.AtualizarLista(listaAtualizar);
                if (listaRemover.Count > 0)
                    itemListaRep.RemoverLista(listaRemover);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível atualizar a Lista! Mensagem: " + e.Message);
            }
        }
    }
}