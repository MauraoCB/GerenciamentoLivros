using System.ComponentModel.DataAnnotations;

namespace GerenciamentoLivros.Entities;

public class Author : BaseEntity
{
    [Required]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [StringLength(30)]
    public string? Nationality { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}