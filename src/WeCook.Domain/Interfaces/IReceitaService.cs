using System;
using System.Threading.Tasks;

namespace WeCook.Domain.Interfaces
{
    public interface IReceitaService : IDisposable
    {
        Task<bool> Adicionar(Receita receita);
        Task<bool> Atualizar(Receita receita);
        Task<bool> Remover(Guid id);
    }
}
