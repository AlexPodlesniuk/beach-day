using FluentValidation;

namespace BeachDayFinder.Prediction.Application.Queries.FindNextWarmestDay;

public class FindNextWarmestDayValidator : AbstractValidator<FindNextWarmestDay>
{
    public FindNextWarmestDayValidator()
    {
        RuleFor(x => x.RequestedLocation)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.RequestedLocation)} should not be empty");
        
        RuleFor(x => x.RequestedLocation.Lat)
            .Must(x => x.IsValidCoordinate())
            .WithMessage(x => $"{nameof(x.RequestedLocation.Lat)} should be a valid coordinate with not more than 6 digits");
        
        RuleFor(x => x.RequestedLocation.Lon)
            .Must(x => x.IsValidCoordinate())
            .WithMessage(x => $"{nameof(x.RequestedLocation.Lon)} should be a valid coordinate with not more than 6 digits");
        
        RuleFor(x => x.RequestedLocation)
            .Must(x => x.IsEnEurope())
            .WithMessage(x => $"{nameof(x.RequestedLocation)} should be in Europe");

        RuleFor(x => x.RequesterId)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.RequesterId)} should not be empty");
    }
}