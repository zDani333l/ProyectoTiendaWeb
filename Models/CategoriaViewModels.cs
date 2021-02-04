using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWebAppTienda.Models
{
    public class CategoriaViewModels
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public int Total { get; set; }
    }
    public class CheckBoxList { 
        public List<SelectListItem> Items { get; set; }
        public IEnumerable<string> SelectedItems { get; set; }

        public List<SelectListItem> GetItems(List<CategoriaViewModels> categorias)
        {
            List<SelectListItem> aux = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                aux.Add(new SelectListItem { Text = item.NombreCategoria, Value = item.CategoriaId.ToString() });
            }
            return aux;
        }
        public CheckBoxList(IEnumerable<CategoriaViewModels> categorias)
        {
            this.Items = this.GetItems(categorias.ToList());
        }
        public CheckBoxList()
        {
            
        }
    }

  
}