// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luebben.Data
{
    public interface IDatabase
    {
        Task<List<T>> QueryAsync<T>(string sql, params Parameter[] parameters) where T : new();

        Task<T> QueryFirstAsync<T>(string sql, params Parameter[] parameters) where T : new();

        Task<T?> QueryScalarAsync<T>(string sql, params Parameter[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, params Parameter[] parameters);
    }
}
