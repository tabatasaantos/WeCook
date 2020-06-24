using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeCook.Data;
using WeCook.Domain;

namespace WeCook.WebApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoriaController : MainController
    {
        private readonly WeCookContext _context;

        public CategoriaController(WeCookContext context)
        {
            _context = context;
        }

        //GET v1/categoria
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            var categoria = await _context.Categorias.AsNoTracking().ToListAsync();

            return Ok(value: categoria);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Categoria>> GetCategoriaId(Guid id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<List<Categoria>>> PostCategoria([FromBody] Categoria model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Categorias.Add(model);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategoriaId", new { id = model.Id }, model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar uma nova categoria!" });
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<Categoria>> PutCategoria(Guid id, [FromBody] Categoria model)
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Categoria não encontrada!" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Entry<Categoria>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar categoria!" });
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<List<Categoria>>> DeleteCategoria(Guid id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound(new { massage = "Categoria não encontrada!" });
            }

            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { massage = "Não foi possível excluir categoria!" });
            }
        }

    }
}