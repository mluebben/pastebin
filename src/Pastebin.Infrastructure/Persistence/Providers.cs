// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data;
using MySql.Data.MySqlClient;

namespace Pastebin.Infrastructure.Persistence
{
    public static class Providers
    {
        public static readonly Provider MySql = new Provider("MySql.Data.MySqlClient", MySqlClientFactory.Instance);
        //public static readonly MsSql = new Provider("System.Data.SqlClient", SqlClientFactory.Instance);
    }
}
