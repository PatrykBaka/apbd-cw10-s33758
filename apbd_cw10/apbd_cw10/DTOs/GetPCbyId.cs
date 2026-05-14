namespace apbd_cw10.DTOs;

public class GetPCbyId
{
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<GetPCComponent> PcComponents { get; set; } = [];

}