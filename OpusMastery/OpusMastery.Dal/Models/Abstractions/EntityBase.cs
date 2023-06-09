﻿using System.ComponentModel.DataAnnotations;

namespace OpusMastery.Dal.Models.Abstractions;

public abstract class EntityBase
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
}