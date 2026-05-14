using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_cw10.Entities;

[Table("ComponentManufacturers")]
public class ComponentManufacturers
{
    
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbrevation {get; set;} = string.Empty;
    [MaxLength(300)]
    public string FullName {get; set;} = string.Empty;
    [Column(TypeName = "date")]
    public DateOnly FoundationDate {get; set;}
    
    public ICollection<Component> Components { get; set; } = [];
    
}