namespace EuroMillions.API.Validators;

public class BallValidator : IBallValidator
{
    public void Validate(int ballNumber)
    {
        if ((ballNumber < 1) || (ballNumber > 50))
        {
            throw new BadHttpRequestException("The ball number must be between 1 and 50.");
        }
    }
}
