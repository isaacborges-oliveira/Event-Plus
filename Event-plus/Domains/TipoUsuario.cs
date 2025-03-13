using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Event_plus.Domains
{
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioID { get; set; }

        [Column(TypeName = "Varchar (30)")]
        [Required(ErrorMessage = "tipo de Usuario é obrigatorio.")]

        public string? TipoUsuarioName { get; set; }
    }
}
