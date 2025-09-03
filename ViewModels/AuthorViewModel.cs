namespace GerenciamentoLivros.ViewModels;

public class AuthorViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Nationality { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
}
