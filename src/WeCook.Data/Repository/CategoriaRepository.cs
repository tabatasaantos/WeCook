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
        public async Task<Categoria> ObterNomeCategoria(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.Nome)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
