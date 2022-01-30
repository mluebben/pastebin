// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System;
using System.Data.Common;

namespace Luebben.Data
{
    public class DatabaseOptions
    {
        public DatabaseOptions(DbProviderFactory providerFactory, string connectionString)
        {
            ProviderFactory = providerFactory ?? throw new ArgumentNullException(nameof(providerFactory));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public DbProviderFactory ProviderFactory { get; }

        public string ConnectionString { get; }
    }
}
