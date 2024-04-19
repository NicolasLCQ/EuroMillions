using System.ComponentModel.DataAnnotations;


namespace EuroMillions.API.Entities;

/// <summary>
/// Table des resultats
/// </summary>
public partial class t_Draw
{
    [Key] public int Id { get; set; }
    [StringLength(8)] public string Day { get; set; } = null!;
    public DateOnly Date { get; set; }
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }
    public int Number4 { get; set; }
    public int Number5 { get; set; }
    public int Star1 { get; set; }
    public int Star2 { get; set; }
}
