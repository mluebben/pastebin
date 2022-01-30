// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Runtime.Serialization;

namespace Luebben.Data
{
    [Serializable]
    public class DataException : Exception
    {
        public DataException(string message) : base(message) { }
        public DataException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
