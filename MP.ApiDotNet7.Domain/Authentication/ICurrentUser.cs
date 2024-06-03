namespace MP.ApiDotNet7.Domain.Authentication;

public interface ICurrentUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Permissions { get; set; }
}