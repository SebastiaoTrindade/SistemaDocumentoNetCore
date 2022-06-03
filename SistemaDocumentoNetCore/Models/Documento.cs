using System.ComponentModel.DataAnnotations;

namespace SistemaDocumentoNetCore.Models
{
    public class Documento
    {
        [Key]
        public int DocumentoId { get; set; }

        [Required(ErrorMessage ="Insira o Campo Código!")]
        [Display(Name ="Código")]       
        public int Codigo { get; set; }

        [Required(ErrorMessage ="Insira o Campo Título!")]
        [Display(Name ="Título")]
        [MaxLength(200)]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Insira o Campo Processo!")]
        [MaxLength(200)]
        public string? Processo { get; set; }

        [Required(ErrorMessage = "Insira o Campo Categoria!")]
        [MaxLength(200)]
        public string? Categoria { get; set; }

        [Required(ErrorMessage = "Insira o Arquivo!")]
        public string? Arquivo { get; set; }
    }
}
