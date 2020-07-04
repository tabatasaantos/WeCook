using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WeCook.Domain;
using WeCook.Domain.Interfaces;
using WeCook.Domain.Models.Validation;
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
            var categoria = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());

            return categoria;
        }

        [HttpGet ("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(Guid id)
        {
            var categoria = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterPorId(id));
            if(categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return Ok(categoriaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Alterar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            var result = await _categoriaService.Atualizar(categoria);

            return Ok(categoria);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
        {
            var categoria = await ObterCategoria(id);

            if (categoria == null) return NotFound();

            var result = await _categoriaService.Remover(id);

            if (!result) return BadRequest();

            return Ok(categoria);
        }

        private async Task<CategoriaViewModel> ObterCategoria(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));
        }


        //[HttpGet]
        //[Route("{id:guid}")]
        //public async Task<ActionResult<Categoria>> GetCategoriaId(Guid id)
        //{
        //    var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

        //    return Ok(categoria);
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<Categoria>>> PostCategoria([FromBody] Categoria model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        _context.Categorias.Add(model);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetCategoriaId", new { id = model.Id }, model);
        //    }
        //    catch
        //    {
        //        return BadRequest(new { message = "Não foi possível criar uma nova categoria!" });
        //    }
        //}

        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<ActionResult<Categoria>> PutCategoria(Guid id, [FromBody] Categoria model)
        //{
        //    if (model.Id != id)
        //    {
        //        return NotFound(new { message = "Categoria não encontrada!" });
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        _context.Entry<Categoria>(model).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return Ok(model);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return BadRequest(new { message = "Este registro já foi atualizado!" });
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(new { message = "Não foi possível atualizar categoria!" });
        //    }
        //}

        //[HttpDelete]
        //[Route("{id:guid}")]
        //public async Task<ActionResult<List<Categoria>>> DeleteCategoria(Guid id)
        //{
        //    var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        //    if (categoria == null)
        //    {
        //        return NotFound(new { massage = "Categoria não encontrada!" });
        //    }

        //    try
        //    {
        //        _context.Categorias.Remove(categoria);
        //        await _context.SaveChangesAsync();
        //        return Ok(new { message = "Categoria removida com sucesso!" });
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(new { massage = "Não foi possível excluir categoria!" });
        //    }
        //}

    }
}