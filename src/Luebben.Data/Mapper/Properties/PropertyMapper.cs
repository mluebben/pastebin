// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Reflection;

namespace Luebben.Data.Mapper.Properties
{
    public class PropertyMapper : IPropertyMapper
    {
        public string GetField(Type objectType, PropertyInfo property)
        {
            if (objectType == null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Name;
        }
    }
}
