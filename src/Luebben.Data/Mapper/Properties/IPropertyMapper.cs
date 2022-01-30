// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Reflection;

namespace Luebben.Data.Mapper.Properties
{
    public interface IPropertyMapper
    {
        string GetField(Type objectType, PropertyInfo property);
    }
}
