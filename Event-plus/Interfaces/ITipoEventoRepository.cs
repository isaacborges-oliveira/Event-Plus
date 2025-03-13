using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEvento);  

        void deletar (Guid Id);
        List<TipoEvento> Listar();
        TipoEvento BuscarPorId (Guid Id, TipoEvento tipoEvento);
        void Atualizar(Guid Id, TipoEvento tipoEvento);
    }
}
