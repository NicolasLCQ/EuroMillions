namespace EuroMillions.Application.Models;

public class DrawDate
{
    private readonly DateTime _value;

    private DrawDate(DateTime value) => _value = value.Date;

    public static implicit operator DateTime(DrawDate drawDate) => drawDate._value;

    public static implicit operator DrawDate(DateTime dateTime) => new DrawDate(dateTime);
}
