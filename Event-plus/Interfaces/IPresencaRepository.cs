using Projeto_Event_Plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IPresencaRepository
    {
        void  Deletar(Guid id);
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid id);  
        void Atualizar (Guid id,Presenca presenca);
        List<Presenca> ListarMinhas(Guid id);
        void Inscrever(Presenca Inscricao);
    }
}
