using TarefasAPI.Data;

namespace TarefasAPI.Repositories;

    public class CategoriaRepository
    {
        private readonly TarefasApiContext _contexto;
        public CategoriaRepository(TarefasApiContext contexto)
        {
            _contexto = contexto;
        }
    }
