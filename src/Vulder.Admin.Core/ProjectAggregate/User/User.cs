using System.ComponentModel.DataAnnotations;
using Vulder.SharedKernel;

namespace Vulder.Admin.Core.ProjectAggregate.User;

public class User : BaseEntity
{
    [Required] public string? Email { get; set; }

    [Required] public string? Password { get; set; }

    [Required] public Role Role { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User GenerateId()
    {
        Id = Guid.NewGuid();

        return this;
    }

    public User CreateTimestamp()
    {
        CreatedAt = DateTime.UtcNow;

        return this;
    }

    public User UpdateTimestamp()
    {
        UpdatedAt = DateTime.UtcNow;

        return this;
    }
}