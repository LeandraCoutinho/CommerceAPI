using FluentValidation;

namespace CommerceAPI.Application.DTOs.Validations;

public class PersonImageDTOValidation : AbstractValidator<PersonImageDTO>
{
    public PersonImageDTOValidation()
    {
        RuleFor(x => x.PersonId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("PersonId não pode ser menor ou igual a zero!");

        RuleFor(x => x.Image)
            .NotNull()
            .NotEmpty()
            .WithMessage("Image deve ser informado!");
    }
}