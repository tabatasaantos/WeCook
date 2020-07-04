using System;
using System.Linq;
using System.Threading.Tasks;
using WeCook.Domain.Interfaces;
using WeCook.Domain.Models.Validation;

namespace WeCook.Domain.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;  
        }

        public async Task<bool> Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            if (_categoriaRepository.Buscar(c => c.Nome == categoria.Nome).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome informado.");
                return false;
            }

            await _categoriaRepository.Adicionar(categoria);
            return true;
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            if (_categoriaRepository.Buscar(c => c.Nome == categoria.Nome && c.Id != categoria.Id).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome infomado.");
                return false;
            }

            await _categoriaRepository.Atualizar(categoria);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_categoriaRepository.ObterReceitaCategoria(id).Result.Receitas.Any())
            {
                Notificar("A categoria possui receitas cadastrados!");
                return false;
            }

            await _categoriaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
