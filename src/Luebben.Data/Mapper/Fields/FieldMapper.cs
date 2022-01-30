// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;

namespace Luebben.Data.Mapper.Fields
{
    public class FieldMapper : IFieldMapper
    {
        private string[] _fieldNames;

        public FieldMapper(string[] fieldNames)
        {
            _fieldNames = fieldNames ?? throw new ArgumentNullException(nameof(fieldNames));
        }

        public int GetOrdinal(string fieldName)
        {
            // Nach Feldnamen suchen (case sensitive)
            for (int i = 0; i < _fieldNames.Length; i++)
            {
                if (string.Equals(fieldName, _fieldNames[i]))
                {
                    return i;
                }
            }

            // Nach Feldnamen suchen (case insenstive)
            for (int i = 0; i < _fieldNames.Length; i++)
            {
                if (string.Equals(fieldName, _fieldNames[i], StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            // Feldname nicht gefunden
            throw new InvalidFieldNameException($"Field name {fieldName} is invalid.");
        }
    }
}
