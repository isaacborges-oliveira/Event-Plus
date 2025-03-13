using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api_filmes_senai.Domains;
using Projeto_Event_Plus.Domains;

namespace Event_plus.Domains
{
    
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioID { get; set; }

        public Guid? UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuarios { get; set; }

        public Guid? EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Eventos? Eventos { get; set; }

        [Column(TypeName = "VArchar (200)")]
        [Required(ErrorMessage = "descricao é obrigatorio")]

        string? descricao {  get; set; }

        [Column(TypeName = "bool (14)")]
        bool  exibe { get; set; }                                                                                                                                                                       
    }
}
