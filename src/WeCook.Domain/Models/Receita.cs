using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WeCook.Domain.Base;

namespace WeCook.Domain
{
    public class Receita : Entity
    {
        public string Nome { get; set; }
        
        public string Ingredientes { get; set; }
      
        public string ModoPreparo { get; set; }
       
        public decimal TempoPreparo { get; set; }
        
        public int Rendimento { get; set; }
    
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
