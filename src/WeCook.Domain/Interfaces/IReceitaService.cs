using System;
using System.Threading.Tasks;

namespace WeCook.Domain.Interfaces
{
    public interface IReceitaService : IDisposable
    {
        Task Adicionar(Receita receita);
        Task Atualizar(Receita receita);
        Task Remover(Guid id);
    }
}
