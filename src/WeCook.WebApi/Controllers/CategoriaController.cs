using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeCook.Domain;
using WeCook.Domain.Interfaces;
using WeCook.WebApi.ViewModels;

namespace WeCook.WebApi.Controllers
{
    [Authorize]
    [Route("api/categoria")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper, ICategoriaService categoriaService, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }

        [HttpGet ("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(Guid id)
        {
            var categoria = await ObterReceitaCategoria(id);

            if (categoria == null) return NotFound();

            return categoria;
        }

        [ClaimsAuthorize("Categoria", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse("Cadastrado com sucesso!");
        }

        [ClaimsAuthorize("Categoria", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Alterar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(categoriaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse("Alterado com sucesso!");
        }

        [ClaimsAuthorize("Categoria", "Excluir")]
        [HttpDelete("{id:guid}")]
        private async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
        {
           var categoriaViewModel = await ObterReceitaCategoria(id);

            if (categoriaViewModel == null) return NotFound();

            await _categoriaService.Remover(id);

            return CustomResponse("Deletado com sucesso!");
        }

        private async Task<CategoriaViewModel> ObterReceitaCategoria(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterReceitaCategoria(id));
        }
    }
}