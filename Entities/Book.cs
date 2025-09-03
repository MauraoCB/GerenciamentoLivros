using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoLivros.Entities;

public class Book : BaseEntity
{
    [Required]
    [StringLength(30)]
    public string Title { get; set; } = null!;

    [StringLength(150)]
    public string? Synopsis { get; set; }

    [StringLength(20)]
    public string? ISBN { get; set; }

    [StringLength(15)]
    public string? Edition { get; set; }

    public int? PublicationYear { get; set; }

    [ForeignKey(nameof(Author))]
    public int IdAuthor { get; set; }
    public virtual Author Author { get; set; } = null!;

    [ForeignKey(nameof(Genre))]
    public int IdGenre { get; set; }
    public virtual Genre Genre { get; set; } = null!;
}