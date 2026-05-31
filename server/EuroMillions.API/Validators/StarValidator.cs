namespace EuroMillions.API.Validators;

public class StarValidator : IStarValidator
{
    public void Validate(int starNumber)
    {
        if ((starNumber < 1) || (starNumber > 12))
        {
            throw new BadHttpRequestException("The star number must be between 1 and 12.");
        }
    }
}
