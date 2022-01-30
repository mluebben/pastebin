// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data;
using Luebben.Data.Extensions.Microsoft.DependencyInjection;
using Luebben.Data.Mapper;
using Luebben.Data.Mapper.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pastebin.Domain.Procedures;
using Pastebin.Infrastructure.Persistence;
using System;

namespace Pastebin.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, Action<DatabaseOptionsBuilder> configureDatabaseOptions)
        {
            services.AddObjectMapper();
            services.TryAddScoped<IDbContext>(serviceProvider => 
            {
                var database = new Database(
                    ConfigureDatabase(configureDatabaseOptions),
                    serviceProvider.GetRequiredService<IObjectMapper>(),
                    serviceProvider.GetRequiredService<ITypeMapper>()
                );

                return new DbContext(database);
            });

            return services;
        }

        private static DatabaseOptions ConfigureDatabase(Action<DatabaseOptionsBuilder> configureDatabaseOptions)
        {
            var builder = new DatabaseOptionsBuilder();
            configureDatabaseOptions(builder);

            return builder.Build();
        }
    }
}
