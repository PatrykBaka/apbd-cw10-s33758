using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_cw10.Entities;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbrevation { get; set; } = string.Empty;
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Component> Components { get; set; } = [];
    
}