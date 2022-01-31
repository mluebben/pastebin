// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;

namespace Luebben.Data.Mapper.Types
{
    public interface ITypeMapper
    {
        object? Map(object? value, Type targetType);
    }
}
