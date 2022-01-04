using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Vulder.SharedKernel;

namespace Vulder.Admin.Core.ProjectAggregate.User;

public class User : BaseEntity
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public Role Role { get; set; }

    [Required]
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public User GenerateId()
    {
        Id = Guid.NewGuid();

        return this;
    }

    public User CreateTimestamp()
    {
        CreatedAt = DateTimeOffset.Now;

        return this;
    }

    public User UpdateTimestamp()
    {
        UpdatedAt = DateTimeOffset.Now;

        return this;
    }
}