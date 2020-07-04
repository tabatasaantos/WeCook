using System;
using System.Threading.Tasks;

namespace WeCook.Domain.Interfaces
{
    public interface ICategoriaService : IDisposable
    {
        Task<bool> Adicionar(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Remover(Guid id);
    }
}
