using System;
using System.Collections.Generic;
using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_DTO;
using MarketList_Model;
using MarketList_Repository;
using MarketList_Repository.Interfaces;

namespace MarketList_Business
{
    public class ItemBL : BaseBusiness<Item>, IItemBL
    {
        public ItemBL(MarketListContext context) : base(context)
        {
        }
        private vmItemEItemLista ParseItemToVmItemEItemLista(Item item)
        {
            vmItemEItemLista vmItemEItemLista = new vmItemEItemLista
            {
                Id = item.Id,
                SNome = item.SNome,
                SUnidadeMedida = item.SUnidadeMedida
            };
            return vmItemEItemLista;
        }
        public IEnumerable<vmItemEItemLista> ListVm()
        {
            var lItem = this.List();
            List<vmItemEItemLista> lvmItemEItemLista = new List<vmItemEItemLista>();

            foreach (var i in lItem)
            {
                lvmItemEItemLista.Add(ParseItemToVmItemEItemLista(i));
            }
            return lvmItemEItemLista;
        }
        public vmItemEItemLista GetIdVm(int id)
        {
            try
            {
                return ParseItemToVmItemEItemLista(this.GetId(id));
            }
            catch (Exception)
            {
                return new vmItemEItemLista();
            }
        }
    }
}