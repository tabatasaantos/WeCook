using System.Collections.Generic;
using WeCook.Domain.Base;

namespace WeCook.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public IEnumerable<Receita> Receitas { get; set; }
    }
}
