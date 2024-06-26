using CommerceAPI.Domain.Validations;

namespace CommerceAPI.Domain.Entities;

public class UserPermission
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int PermissionId { get; private set; }
    public User User { get; set; }
    public Permission Permission { get; set; }
    
    public UserPermission(int userId, int permissionId)
    {
        Validation(userId, permissionId);
    }

    public void Validation(int userId, int permissionId)
    {
        DomainValidationException.When(userId == 0, "Id usuário deve ser informado");
        DomainValidationException.When(permissionId == 0, "Id permissão deve ser informado");
        
        UserId = userId;
        PermissionId = permissionId;
    }
}