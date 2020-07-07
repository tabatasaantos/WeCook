using System;
using System.Threading.Tasks;

namespace WeCook.Domain.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> ObterReceitaCategoria(Guid id);
    }
}
