using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCook.Data;
using WeCook.Domain;
using WeCook.WebApi.Services;

namespace WeCook.WebApi.Controllers
{
    public class UserController : ControllerBase
    {
    //    [HttpGet]
    //    [Route("users")]
    //    public async Task<ActionResult<List<User>>> Get([FromServices] WeCookContext context)
    //    {
    //        var users = await context
    //            .Users
    //            .AsNoTracking()
    //            .ToListAsync();
    //        return users;
    //    }

    //    [HttpPost]
    //    [Route("users")]
    //    [AllowAnonymous]
    //    public async Task<ActionResult<User>> Post(
    //        [FromServices] WeCookContext context,
    //        [FromBody] User model)
    //    {
    //        // Verifica se os dados são válidos
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);

    //        try
    //        {
    //            context.Users.Add(model);
    //            await context.SaveChangesAsync();
    //            // Esconde senha
    //            model.Password = "";
    //            return model;
    //        }
    //        catch (Exception)
    //        {
    //            return BadRequest(new { message = "Não foi possível criar o usuário" });
    //        }
    //    }

    //    [HttpPut]
    //    [Route("{id:int}")]
    //    public async Task<ActionResult<User>> Put(
    //        [FromServices] WeCookContext context,
    //        int id,
    //        [FromBody] User model)
    //    {
    //        // Verifica se os dados são válidos
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);

    //        // Verifica se o ID informado é o mesmo do modelo
    //        if (id != model.Id)
    //            return NotFound(new { message = "Usuário não encontrado" });

    //        try
    //        {
    //            context.Entry(model).State = EntityState.Modified;
    //            await context.SaveChangesAsync();
    //            return model;
    //        }
    //        catch (Exception)
    //        {
    //            return BadRequest(new { message = "Não foi possível criar o usuário" });
    //        }
    //    }

    //    [HttpPost]
    //    [Route("login")]
    //    public async Task<ActionResult<dynamic>> Authenticate(
    //                [FromServices] WeCookContext context,
    //                [FromBody] User model)
    //    {
    //        var user = await context.Users
    //            .AsNoTracking()
    //            .Where(x => x.Username == model.Username && x.Password == model.Password)
    //            .FirstOrDefaultAsync();

    //        if (user == null)
    //            return BadRequest(new { message = "Usuário ou senha inválidos" });

    //        var token = TokenService.GenerateToken(user);
    //        // Esconde a senha
    //        user.Password = "";
    //        return new
    //        {
    //            user = user,
    //            token = token
    //        };
    //    }
    }
}
