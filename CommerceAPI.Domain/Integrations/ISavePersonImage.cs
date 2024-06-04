namespace CommerceAPI.Domain.Integrations;

public interface ISavePersonImage
{
    string Save(string imageBase64);
}