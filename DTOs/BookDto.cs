namespace GerenciamentoLivros.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public int IdGenre { get; set; }
    public int IdAuthor { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Synopsis { get; set; }
    public string? ISBN { get; set; }
    public string? Edition { get; set; }
    public int? PublicationYear { get; set; }
}
