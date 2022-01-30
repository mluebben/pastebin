// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Luebben.Data.Mapper.Fields
{
    public interface IFieldMapper
    {
        int GetOrdinal(string fieldName);
    }
}
