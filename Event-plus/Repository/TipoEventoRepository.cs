using Event_plus.Domains;
using Event_plus.Interfaces;

namespace Event_plus.Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly Event_plus _context;   

        public TipoEventoRepository(Evento_Context contexto)

        {
            _context = contexto;

        }
        public void Atualizar(Guid id, TipoEvento tipoEvento)

        {
            throw new NotImplementedException();
        }

        TipoEvento ITipoEventoRepository.BuscarPorId(Guid Id, TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        void ITipoEventoRepository.Cadastrar(TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        void ITipoEventoRepository.deletar(Guid Id)
        {
            throw new NotImplementedException();
        }

        List<TipoEvento> ITipoEventoRepository.Listar()
        {
            throw new NotImplementedException();
        }
    }
}