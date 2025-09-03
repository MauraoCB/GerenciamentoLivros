namespace GerenciamentoLivros.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public int IdGenre { get; set; }
    public int IdAuthor { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Synopsis { get; set; }
    public string? ISBN { get; set; }
    public string? Edition { get; set; }
    public int? PublicationYear { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string GenreName { get; set; } = string.Empty;
}
