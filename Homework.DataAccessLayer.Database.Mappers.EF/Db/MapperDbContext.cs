// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Mappers.EF.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace Homework.DataAccessLayer.Database.Mappers.EF.Db
{
    /// <summary>
    /// Контекст базы данных сопоставителя.
    /// </summary>
    public abstract class MapperDbContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Сущность "Задача".
        /// </summary>
        public DbSet<MapperTaskEntityObject> Task { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        protected MapperDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}
