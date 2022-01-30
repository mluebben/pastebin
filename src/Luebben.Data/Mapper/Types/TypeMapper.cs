// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;

namespace Luebben.Data.Mapper.Types
{
    public class TypeMapper : ITypeMapper
    {
        public object Map(object value, Type targetType)
        {
            if (value == DBNull.Value)
            {
                value = null;
            }

            var underlyingType = Nullable.GetUnderlyingType(targetType);
            if (underlyingType == typeof(double))
            {
                return value == null ? new double?() : new double?((double)Convert.ChangeType(value, underlyingType));
            }
            else if (underlyingType == typeof(decimal))
            {
                return value == null ? new decimal?() : new decimal?((decimal)Convert.ChangeType(value, underlyingType));
            }
            else if (underlyingType == typeof(DateTime))
            {
                return value == null ? new DateTime?() : new DateTime?((DateTime)Convert.ChangeType(value, underlyingType));
            }

            return Convert.ChangeType(value, targetType);
        }

        //private object GetDefault(Type t)
        //{
        //    return GetType().GetMethod(nameof(GetDefaultGeneric)).MakeGenericMethod(t).Invoke(this, null);
        //}

        //private T GetDefaultGeneric<T>()
        //{
        //    return default(T);
        //}
    }
}
