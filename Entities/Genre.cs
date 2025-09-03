using System.ComponentModel.DataAnnotations;

namespace GerenciamentoLivros.Entities;

public class Genre : BaseEntity
{
    [Required]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}