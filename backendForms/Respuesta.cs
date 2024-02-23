using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backendForms
{
    public class Respuesta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRespuesta { get; set; }

        [StringLength(256)]
        public string Valor { get; set; }

        public int IdCampo { get; set; }

        [ForeignKey("IdCampo")]
        public Campo Campo { get; set; }
    }
}
