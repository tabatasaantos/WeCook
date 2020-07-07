using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeCook.Domain;
using WeCook.Domain.Interfaces;
using WeCook.WebApi.ViewModels;

namespace WeCook.WebApi.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper, ICategoriaService categoriaService)
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

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            Categoria teste = _mapper.Map<Categoria>(categoriaViewModel);

            await _categoriaService.Adicionar(teste);

            return Ok("Cadastrado com sucesso!");
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Alterar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return Ok(categoriaViewModel);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return Ok("Alterado com sucesso!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
        {
           var categoriaViewModel = await ObterReceitaCategoria(id);

            if (categoriaViewModel == null) return NotFound();

            await _categoriaService.Remover(id);

            return Ok("Deletado com sucesso!");
        }

        private async Task<CategoriaViewModel> ObterReceitaCategoria(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterReceitaCategoria(id));
        }
    }
}