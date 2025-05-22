using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("User")]
public class User {
    [Key]
    public int Id {get; set;}
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }
 
}