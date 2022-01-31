// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Luebben.Data.Mapper.Types
{
    public class TypeMapper : ITypeMapper
    {
        public object? Map(object? value, Type targetType)
        {
            object? intermediateValue = value;

            if (intermediateValue == DBNull.Value)
            {
                intermediateValue = null;
            }

            var underlyingType = Nullable.GetUnderlyingType(targetType);
            if (underlyingType == typeof(double))
            {
                return intermediateValue == null ? new double?() : new double?((double)Convert.ChangeType(intermediateValue, underlyingType));
            }
            else if (underlyingType == typeof(decimal))
            {
                return intermediateValue == null ? new decimal?() : new decimal?((decimal)Convert.ChangeType(intermediateValue, underlyingType));
            }
            else if (underlyingType == typeof(DateTime))
            {
                return intermediateValue == null ? new DateTime?() : new DateTime?((DateTime)Convert.ChangeType(intermediateValue, underlyingType));
            }

            return Convert.ChangeType(intermediateValue, targetType);
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
