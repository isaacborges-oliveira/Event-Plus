using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_plus.Domains
{
    public class TipoEvento
    {
        [Key]
        public Guid TipoEventoID { get; set; }

        [Column(TypeName = "Varchar (30)")]
        [Required(ErrorMessage = "tipo de Evento é obrigatorio.")]

        public string? TipoEventoName { get; set; }
    }

}
