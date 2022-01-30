// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data.Mapper.Fields;
using Luebben.Data.Mapper.Properties;
using Luebben.Data.Mapper.Types;
using System;
using System.Data.Common;

namespace Luebben.Data.Mapper
{
    public class ObjectMapper : IObjectMapper
    {
        private IPropertyMapper _propertyMapper;
        private ITypeMapper _typeMapper;

        public ObjectMapper(IPropertyMapper propertyMapper, ITypeMapper typeMapper)
        {
            _propertyMapper = propertyMapper ?? throw new ArgumentNullException(nameof(propertyMapper));
            _typeMapper = typeMapper ?? throw new ArgumentNullException(nameof(typeMapper));
        }

        public T GetObject<T>(IFieldMapper fieldMapper, DbDataReader reader) where T : new()
        {
            var resultType = typeof(T);
            var resultObject = new T();

            foreach (var property in resultType.GetProperties())
            {
                var propertyType = property.PropertyType;

                var fieldName = _propertyMapper.GetField(resultType, property);
                var fieldOrdinal = fieldMapper.GetOrdinal(fieldName);
                var fieldValue = reader.GetValue(fieldOrdinal);

                var propertyValue = _typeMapper.Map(fieldValue, propertyType);

                property.SetValue(resultObject, propertyValue);
            }

            return resultObject;
        }
    }
}
