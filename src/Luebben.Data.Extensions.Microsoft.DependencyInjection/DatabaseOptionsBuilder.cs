// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System.Data.Common;

namespace Luebben.Data.Extensions.Microsoft.DependencyInjection
{
    public class DatabaseOptionsBuilder
    {
        public DatabaseOptionsBuilder UseProviderFactory(DbProviderFactory factory)
        {
            ProviderFactory = factory;

            return this;
        }

        public DatabaseOptionsBuilder UseProviderName(string providerName)
        {
            ProviderFactory = DbProviderFactories.GetFactory(providerName);

            return this;
        }

        public DatabaseOptionsBuilder UseProvider(Provider provider)
        {
            ProviderFactory = provider.Factory;
            provider.Register();
            
            return this;
        }

        public DatabaseOptionsBuilder UseConnection(string connectionString)
        {
            ConnectionString = connectionString;

            return this;
        }

        public DbProviderFactory? ProviderFactory { get; set; }

        public string? ConnectionString { get; set; }

        public DatabaseOptions Build()
        {
            return new DatabaseOptions(ProviderFactory, ConnectionString);
        }
    }
}
