using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Notes
{
    [Key] public int Id { get; set; }
    [NotNull] public string? Description { get; set; }
    [ForeignKey("UserId")] public User? User { get; set; }
    [NotNull] public string? Title { get; set; }
}