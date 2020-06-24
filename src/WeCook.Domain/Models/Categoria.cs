using System.ComponentModel.DataAnnotations;
using WeCook.Domain.Base;

namespace WeCook.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
    }
}
