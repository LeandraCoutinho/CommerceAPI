using CommerceAPI.Domain.Validations;

namespace CommerceAPI.Domain.Entities;

public class PersonImage
{
    public int Id { get; private set; }
    public int PersonId { get; private set; }
    public string? ImageUrl { get; private set; }
    public string? ImageBase { get; private set; }
    public Person Person { get; set; }

    public PersonImage(int personId, string? imageUrl, string? imageBase)
    {
        Validation(personId);
        ImageUrl = imageUrl;
        ImageBase = imageBase;
    }

    private void Validation(int personId)
    {
        DomainValidationException.When(personId == 0, "Id pessoa deve ser informado");
        PersonId = personId;
    }
}