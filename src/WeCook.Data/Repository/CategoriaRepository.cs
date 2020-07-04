using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WeCook.Domain;
using WeCook.Domain.Interfaces;

namespace WeCook.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(WeCookContext context) : base(context)
        {
        }
        public async Task<Categoria> ObterCategoria(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.Nome)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Categoria> ObterReceitaCategoria(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.Receitas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
