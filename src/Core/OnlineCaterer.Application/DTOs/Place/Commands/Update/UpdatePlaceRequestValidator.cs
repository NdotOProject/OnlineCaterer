
namespace OnlineCaterer.Application.DTOs.Place.Commands.Update;

public class UpdatePlaceRequestValidator : AbstractValidator<UpdatePlaceRequest>
{
    public UpdatePlaceRequestValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(500)
            .NotEmpty();
    }
}
