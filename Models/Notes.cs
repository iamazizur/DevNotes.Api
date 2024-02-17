using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Note
{
    [Key] public int Id { get; set; }
    [NotNull] public string? Title { get; set; }
    public string? Description { get; set; }

    [Required] public int UserId { get; set; }
    [ForeignKey("UserId")] public User? User { get; set; }

}