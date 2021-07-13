using System.Collections.Generic;
using System.Linq;
using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using MarketList_Repository;

namespace MarketList_Business
{
    public class ListaBL : BaseBusiness<Lista>, IListaBL
    {
        private ListaRepository listaRep;
        private MarketListContext _context;
        public ListaBL(MarketListContext context) : base(context)
        {
            _context = context;
            listaRep = new ListaRepository(_context);
        }
        private vmListaUnidade ParseListaToVmListaUnidade(Lista lista)
        {
            UsuarioRepository usuarioRep = new UsuarioRepository(_context);
            vmListaUnidade lisUni = new vmListaUnidade
            {
                nIdLista = lista.Id,
                sNome = lista.SNome,
                sNomeUsuario = usuarioRep.GetId(lista.NIdUsuario).SUsuario,//db.Usuario.Where(x => x.NIdUsuario == i.NIdUsuario).FirstOrDefault().SUsuario,
                dCadastro = lista.DCadastro
            };
            return lisUni;
        }
        public IEnumerable<vmListaUnidade> GetPorUnidade(int id)
        {
            List<Lista> lLista = listaRep.List().Where(x => x.NIdUnidade == id && x.BAtivo == true).ToList();
            List<vmListaUnidade> lvmUnidade = new List<vmListaUnidade>();
            if (lLista.Count > 0)
            {
                foreach (var i in lLista)
                {
                    lvmUnidade.Add(ParseListaToVmListaUnidade(i));
                }
            }
            return lvmUnidade;
        }
    }
}