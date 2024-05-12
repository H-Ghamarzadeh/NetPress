using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index(nameof(OptionName), IsUnique = false)]
public class Option : BaseEntity
{
    public required string OptionName { get; set; }
    public string? OptionValue { get; set; }
}