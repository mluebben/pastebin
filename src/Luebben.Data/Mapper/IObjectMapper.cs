// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data.Mapper.Fields;
using System.Data.Common;

namespace Luebben.Data.Mapper
{
    public interface IObjectMapper
    {
        T GetObject<T>(IFieldMapper fieldMapper, DbDataReader reader) where T : new();
    }
}
