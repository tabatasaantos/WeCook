using System;
using System.Linq;
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

        public async Task<bool> Adicionar(Receita receita)
        {
            if (!ExecutarValidacao(new ReceitaValidation(), receita)) return false;

            if (_receitaRepository.Buscar(r => r.Nome == receita.Nome).Result.Any())
            {
                Notificar("Já existe uma receita com este nome informado.");
                return false;
            }

            await _receitaRepository.Adicionar(receita);
            return true;
        }

        public async Task<bool> Atualizar(Receita receita)
        {
            await _receitaRepository.Atualizar(receita);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _receitaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _receitaRepository?.Dispose();
        }
    }
}
