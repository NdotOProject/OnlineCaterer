
namespace OnlineCaterer.Application.DTOs.Place.Commands.Create;

public class CreatePlaceRequestValidator : AbstractValidator<CreatePlaceRequest>
{
    public CreatePlaceRequestValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(500)
            .NotEmpty();
    }
}
