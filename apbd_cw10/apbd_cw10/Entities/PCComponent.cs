using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw10.Entities;

[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } =string.Empty;
    
    public int Amount { get; set; }
    
    [ForeignKey(nameof(PCId))]
    public PC PCs { get; set; } = null!;

    [ForeignKey(nameof(ComponentCode))]
    public Component Components { get; set; } = null!;
    
}