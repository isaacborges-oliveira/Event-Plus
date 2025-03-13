using api_filmes_senai.Domains;

namespace Event_plus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmaileSenha(string email, string senha);
    }
}
