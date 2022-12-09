using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models
{
  public class Student
  {
    public int StudentId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [StringLength(300)]
    public string? Email { get; set; }

    [StringLength(80)]
    public string? Modulo { get; set; }

    [StringLength(300)]
    public string? Status { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [StringLength(80)]
    public string? Senha { get; set; }

    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public ICollection<Post>? Post { get; set; }
  }
}