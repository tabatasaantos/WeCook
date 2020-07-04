using System;
using System.Threading.Tasks;

namespace WeCook.Domain.Interfaces
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        Task<Receita> ObterReceita(Guid id);
        Task<Receita> ObterReceitaPorCategoria(Guid id);
    }
}
