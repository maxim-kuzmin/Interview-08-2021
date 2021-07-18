// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework.DataAccessLayer.Database.Mappers.EF.Entities.Task
{
    /// <summary>
    /// Схема сущности "Задача" сопоставителя.
    /// </summary>
    public class MapperTaskEntitySchema : MapperSchema<MapperTaskEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperTaskEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperTaskEntityObject> builder)
        {
            var setting = EntitiesSettings.Task;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.Description)
                .IsRequired()
                .IsUnicode()
                .HasColumnName(setting.DbColumnForDescription);
        }

        #endregion Public methods
    }
}