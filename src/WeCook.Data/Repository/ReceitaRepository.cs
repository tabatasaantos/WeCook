using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WeCook.Domain;
using WeCook.Domain.Interfaces;

namespace WeCook.Data.Repository
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(WeCookContext context) : base(context)
        {
        }
        public async Task<Receita> ObterReceita(Guid id)
        {
            return await Db.Receitas.AsNoTracking()
                .Include(r => r.Nome)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Receita> ObterReceitaPorCategoria(Guid id)
        {
            return await Db.Receitas.AsNoTracking()
                .Include(r => r.Nome)
                .Include(r => r.Categoria)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
