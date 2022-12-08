using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models
{
  public class Post
  {
    public int PostId { get; set; }

    [Required(ErrorMessage = "O texto é obrigatório")]
    [MaxLength(300, ErrorMessage = "O texto pode ter no máximo 300 caracteres")]
    public string? Descricao { get; set; }

    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    [Required(ErrorMessage = "O id do estudante é obrigatório")]
    public int StudentId { get; set; }
    public Student? Student { get; set; }
  }
}