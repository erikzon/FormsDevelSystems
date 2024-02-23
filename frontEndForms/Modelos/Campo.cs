using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace frontEndForms.Modelos
{
    public class Campo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCampo { get; set; }

        [Required]
        [StringLength(256)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(256)]
        public string Titulo { get; set; }

        [Required]
        public bool Requerido { get; set; }

        [Required]
        [StringLength(25)]
        public string TipoCampo { get; set; }

        public Guid IdEncuesta { get; set; }

        [ForeignKey("IdEncuesta")]
        public Encuesta Encuesta { get; set; }

        public List<Respuesta> Respuestas { get; set; }
    }
}
