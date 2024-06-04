namespace MP.ApiDotNet7.Domain.Integrations;

public interface ISavePersonImage
{
    string Save(string imageBase64);
}