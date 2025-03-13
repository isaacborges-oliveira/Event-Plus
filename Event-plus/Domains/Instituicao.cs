using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid InstituicaoID { get; set; }

        [Column(TypeName = "Varchar (40)")]
        [Required(ErrorMessage = "instituicao é obrigatorio.")]
        

        public string? InstituicaoName { get; set; }


        [Column(TypeName = "CHAR (14)")]
        [Required(ErrorMessage = "CNPJ é obrigatorio")]
        [StringLength(14)]
        public string?  CNPJ { get; set; }


        [Column(TypeName = "Varchar (50)")]
        [Required(ErrorMessage = "Fantasia é obrigatorio.")]

        public string? Fantasia { get; set; }

        [Column(TypeName = "Varchar (50)")]
        [Required(ErrorMessage = " endereco é obrigatorio.")]

        public string? endereco { get; set; }

    }
}

