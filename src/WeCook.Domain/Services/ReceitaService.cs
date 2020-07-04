using System;
using System.Threading.Tasks;
using WeCook.Domain.Interfaces;
using WeCook.Domain.Models.Validation;

namespace WeCook.Domain.Services
{
    public class ReceitaService : BaseService, IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        public ReceitaService(IReceitaRepository receitaRepository, INotificador notificador) : base(notificador)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task Adicionar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita)) return;

            await _receitaRepository.Adicionar(receita);
        }

        public async Task Atualizar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita)) return;

            await _receitaRepository.Atualizar(receita);
        }

        public async Task Remover(Guid id)
        {
            await _receitaRepository.Remover(id);
        }

        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }
    }
}
