using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid UsuarioID { get; set; }

        [Required(ErrorMessage = "O tipo usuario e obrigatorio")]
        public Guid TiposUsuarioID { get; set; }
        [ForeignKey("TipoUsuarioID")]
        public TipoUsuario? TipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome e obrigatorio")]

        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O Email e obrigatorio")]

        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A Senha e obrigatoria")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 60")]

        public string? Senha { get; set; }

    }
}