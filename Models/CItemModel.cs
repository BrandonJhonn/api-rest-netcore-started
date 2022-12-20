namespace NetCoreApi.Models;

public class CItemModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? SecretField { get; set; }
}