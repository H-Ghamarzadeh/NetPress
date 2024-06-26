﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index(nameof(CommentId), IsUnique = false)]
[Index(nameof(Key), IsUnique = false)]
public class CommentMetaData : BaseEntity
{
    [Required]
    public int CommentId { get; set; }
    public virtual Comment? Comment { get; set; }
    [Required]
    public required string Key { get; set; }
    public string? Value { get; set; }
}