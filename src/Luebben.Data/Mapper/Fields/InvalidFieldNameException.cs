// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Runtime.Serialization;

namespace Luebben.Data.Mapper.Fields
{
    [Serializable]
    public class InvalidFieldNameException : ObjectMapperException
    {
        public InvalidFieldNameException(string message) : base(message) { }
        public InvalidFieldNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
