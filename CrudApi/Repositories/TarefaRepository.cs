using CrudApi.Models;
using CrudApi.Repositories;
using CrudApiBackEnd.Models;

namespace CrudApiBackEnd.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
