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
    [Route("api/receita")]
    [ApiController]
    public class ReceitaController : MainController
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;

        public ReceitaController(IReceitaRepository receitaRepository, IReceitaService receitaService, IMapper mapper, INotificador notificador) : base (notificador)
        {
            _receitaRepository = receitaRepository;
            _receitaService = receitaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReceitaViewModel>> ObterTodos()
        {
            var receita = _mapper.Map<IEnumerable<ReceitaViewModel>>(await _receitaRepository.ObterTodos());

            return receita;
        }

        [HttpGet("{id:guid})")]
        public async Task<ActionResult<ReceitaViewModel>> ObterPorId(Guid id)
        {
            var receita = await ObterReceita(id);

            if (receita == null) return NotFound();

            return receita;
        }

        [HttpPost]
        public async Task<ActionResult<ReceitaViewModel>> Adicionar(ReceitaViewModel receitaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _receitaService.Adicionar(_mapper.Map<Receita>(receitaViewModel));

            return CustomResponse("Adicionado com sucesso!");
        }

        [HttpPut]
        [Route("{id:guid})")]
        public async Task<ActionResult<Receita>> Alterar(Guid id, ReceitaViewModel receitaViewModel)
        {
            if (id != receitaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(receitaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _receitaService.Atualizar(_mapper.Map<Receita>(receitaViewModel));

            return CustomResponse("Alterado com sucesso!");
        }

        [HttpDelete]
        [Route("{id:guid})")]
        public async Task<ActionResult<ReceitaViewModel>> Excluir(Guid id)
        {
            var receitaViewModel = await ObterReceita(id);

            if (receitaViewModel == null) return NotFound();

            await _receitaService.Remover(id);

            return CustomResponse("Deletado com sucesso!");
        }

        private async Task<ReceitaViewModel> ObterReceita(Guid id)
        {
            return _mapper.Map<ReceitaViewModel>(await _receitaRepository.ObterReceita(id));
        }
    }
}
