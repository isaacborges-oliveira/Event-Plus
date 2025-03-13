using Projeto_Event_Plus.Domains;

namespace Event_plus.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar (Eventos novoEvento
            );
        void Deletar (Guid id);
        List<Eventos> Listar();
        List<Eventos> ListarPorId (Guid id);
        List<Eventos> ProximosEventos (Guid id);
        Eventos BuscarPorId(Guid id);

            Void Atualizar
        Eventos BuscarPorId (Guid id);  


    }
}
