using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeCook.Data;
using WeCook.Domain;

namespace WeCook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly WeCookContext _context;

        public ReceitaController(WeCookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Receita>>> Get()
        {
            var receita = await _context.Categorias.AsNoTracking().ToListAsync();

            return Ok(value: receita);
        }

        [HttpGet]
        [Route("{id:int})")]
        public async Task<ActionResult<Receita>> GetReceitaId(Guid id)
        {
            var receita = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(receita);
        }

        [HttpPost]
        public async Task<ActionResult<List<Receita>>> PostReceita([FromBody] Receita model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Receitas.Add(model);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReceitaId", new { id = model.Id }, model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar uma nova receita!" });
            }
        }

        [HttpPut]
        [Route("{id:int})")]
        public async Task<ActionResult<Categoria>> PutReceita(Guid id, [FromBody] Receita model)
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Receita não encontrada!" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Entry<Receita>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar receita!" });
            }
        }

        [HttpDelete]
        [Route("{id:int})")]
        public async Task<ActionResult<List<Receita>>> DeleteReceita(Guid id)
        {
            var receita = await _context.Receitas.FirstOrDefaultAsync(x => x.Id == id);
            if (receita == null)
            {
                return NotFound(new { massage = "Receita não encontrada!" });
            }

            try
            {
                _context.Receitas.Remove(receita);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Receita removida com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { massage = "Não foi possível excluir a receita!" });
            }
        }
    }
}
