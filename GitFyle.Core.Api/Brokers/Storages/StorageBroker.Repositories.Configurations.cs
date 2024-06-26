﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using GitFyle.Core.Api.Models.Foundations.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitFyle.Core.Api.Brokers.Storages;

internal partial class StorageBroker
{
    void AddRepositoryConfigurations(EntityTypeBuilder<Repository> builder)
    {
        builder.Property(repository => repository.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(repository => repository.Owner)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(repository => repository.ExternalId)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(contribution => new
        {
            contribution.Name,
            contribution.Owner,
            contribution.ExternalId,
            contribution.SourceId
        });

        builder.HasOne(x => x.Source)
            .WithOne(x => x.Repository);
    }
}