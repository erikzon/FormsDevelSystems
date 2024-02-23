using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace frontEndForms.Modelos
{
    public class Respuesta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRespuesta { get; set; }

        [Required]
        [StringLength(256)]
        public string Valor { get; set; }

        public DateTime ValorFecha
        {
            get
            {
                if (string.IsNullOrEmpty(Valor))
                {
                    return DateTime.MinValue; // o cualquier valor predeterminado
                }
                DateTime temp;
                if (DateTime.TryParseExact(Valor, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                {
                    return temp;
                }
                else
                {
                    return DateTime.MinValue; // o cualquier valor predeterminado
                }
            }

            set
            {
                Valor = value.ToString("yyyy-MM-dd") ?? String.Empty;
            }
        }


        public int IdCampo { get; set; }

        [ForeignKey("IdCampo")]
        public Campo Campo { get; set; }
    }
}
