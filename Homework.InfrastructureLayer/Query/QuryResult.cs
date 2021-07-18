// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Homework.InfrastructureLayer.Query
{
    /// <summary>
    /// Результат запроса.
    /// </summary>
    public class QueryResult
    {
        #region Properties

        /// <summary>
        /// Признак успешности выполнения.
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// Сообщения об ошибках.
        /// </summary>
        public HashSet<string> ErrorMessages { get; } = new HashSet<string>();

        #endregion Properties
    }
}