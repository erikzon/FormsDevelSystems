using System.ComponentModel.DataAnnotations;

namespace frontEndForms.Modelos
{
    public class Encuesta
    {
        [Key]
        public Guid IdEncuesta { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public List<Campo> Campos { get; set; }
    }
}
