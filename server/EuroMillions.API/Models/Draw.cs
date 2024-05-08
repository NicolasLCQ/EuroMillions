using EuroMillions.API.Entities;

namespace EuroMillions.API.Models;

public class Draw
{
    public string Day { get; set; } = null!;
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }
    public int Number4 { get; set; }
    public int Number5 { get; set; }
    public int Star1 { get; set; }
    public int Star2 { get; set; }
    
    public t_Draw ToEntity()
    {
        return new t_Draw
        {
            Day = this.Day,
            Number1 = this.Number1,
            Number2 = this.Number2,
            Number3 = this.Number3,
            Number4 = this.Number4,
            Number5 = this.Number5,
            Star1 = this.Star1,
            Star2 = this.Star2
        };
    }
    
    public static Draw? FromEntity(t_Draw? draw)
    {
        if(draw == null)
        {
            return null;
        }
        
        return new Draw
        {
            Day = draw.Day,
            Number1 = draw.Number1,
            Number2 = draw.Number2,
            Number3 = draw.Number3,
            Number4 = draw.Number4,
            Number5 = draw.Number5,
            Star1 = draw.Star1,
            Star2 = draw.Star2
        };
    }
}