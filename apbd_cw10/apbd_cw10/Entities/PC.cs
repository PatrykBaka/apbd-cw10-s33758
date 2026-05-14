namespace apbd_cw10.Entities; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PCs")]
public class PC
{

    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public ICollection<PCComponent> PCComponents { get; set; } = [];

}