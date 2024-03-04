using CrudApi.Models;

namespace CrudApi.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
