using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IComentarioRepository
    {
        void cadastrar (ComentarioEvento comentarioEvento); 
        void Deletar (Guid id);
        List<ComentarioEvento> lista (Guid id);
        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
    }
}
