using CommerceAPI.Domain.Validations;

namespace CommerceAPI.Domain.Entities;

public sealed class Permission
{
    public int Id { get; private set; }
    public string VisualName { get; private set; }
    public string PermissionName { get; private set; }
    public ICollection<UserPermission> UserPermissions { get; set; }

    public Permission(string visualName, string permissionName)
    {
        Validation(visualName, permissionName);
        UserPermissions = new List<UserPermission>();
    }

    private void Validation(string visualName, string permissionName)
    {
        DomainValidationException.When(string.IsNullOrEmpty(visualName), "Nome visual deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(permissionName), "Nome permissão deve ser informado");
        
        VisualName = visualName;
        PermissionName = permissionName;
        
    }
}