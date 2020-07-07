using System;
using System.Collections.Generic;
using WeCook.Domain.Base;

namespace WeCook.Domain
{
    public class Receita : Entity
    {
        public string Nome { get; set; }
        
        public string Ingredientes { get; set; }
      
        public string ModoPreparo { get; set; }
       
        public int TempoPreparoEmMin { get; set; }
         
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
