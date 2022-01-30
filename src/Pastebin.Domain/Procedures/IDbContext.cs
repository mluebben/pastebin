// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Pastebin.Domain.Procedures
{
    public interface IDbContext
    {
        Task<IEnumerable<TResult>> QueryAsync<TResult>(IProcedure<TResult> procedure) where TResult : new();
    }
}
