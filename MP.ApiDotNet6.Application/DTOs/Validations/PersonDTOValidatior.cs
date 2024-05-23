using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Validations;

public class PersonDTOValidatior : AbstractValidator<PersonDTO>
{
    // vai validar os dados que vem de fora
    public PersonDTOValidatior()
    {
        RuleFor(x => x.Document)
            .NotEmpty()
            .NotNull()
            .WithMessage("Documento deve ser informado");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome deve ser infotmado");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage("Celular deve ser informado");
    }
}