using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoLivros.Entities;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime? CreationDate { get; set; }
    
    public DateTime? UpdateDate { get; set; }
    
    [StringLength(30)]
    public string? UpdateUser { get; set; }
}