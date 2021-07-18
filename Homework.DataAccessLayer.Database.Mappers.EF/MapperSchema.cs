// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Entities;

namespace Homework.DataAccessLayer.Database.Mappers.EF
{
    /// <summary>
    /// Схема сопоставителя.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntityObject> : DataLayer.Mappers.EF.MapperSchema<EntitiesSettings, TEntityObject>
        where TEntityObject : class
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors
    }
}