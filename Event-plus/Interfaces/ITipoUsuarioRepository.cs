using Event_plus.Domains;

namespace Event_plus.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void deletar (Guid id);
        List<TipoUsuario> lista();

        TipoUsuario BuscarPorId (Guid id);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);   
    }
}
