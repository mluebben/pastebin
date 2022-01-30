// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Data;

namespace Luebben.Data
{
    public class Parameter
    {
        public Parameter(string parameterName, DbType dbType, int size = -1)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("Must not be empty.", nameof(parameterName));
            }
            if (size < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Must be >= -1.");
            }

            ParameterName = parameterName;
            DbType = dbType;
            Size = size;
            Precision = -1;
            Scale = -1;
            Value = null;
        }

        public ParameterDirection Direction { get; set; }

        public string ParameterName { get; set; }

        public DbType DbType { get; set; }

        public int Size { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }

        public object Value { get; set; }
    }
}
