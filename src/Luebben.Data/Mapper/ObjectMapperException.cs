// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Runtime.Serialization;

namespace Luebben.Data.Mapper
{
    [Serializable]
    public class ObjectMapperException : DataException
    {
        public ObjectMapperException(string message) : base(message) { }
        public ObjectMapperException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
