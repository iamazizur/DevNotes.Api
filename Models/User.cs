


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("dev_notes_users")]
public class User 
{
    [Key]  public int Id{get;set;}
    public string? Name{get;set;}
    public string? Email { get; set; }
    public string? Password { get; set; }

}