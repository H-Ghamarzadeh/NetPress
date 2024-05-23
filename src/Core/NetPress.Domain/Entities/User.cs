using Microsoft.AspNetCore.Identity;

namespace NetPress.Domain.Entities;

public class User : IdentityUser
{
    public string? AvatarUrl { get; set; }
    public virtual ICollection<UserMetaData> UserMetaData { get; set; } = new List<UserMetaData>();
}