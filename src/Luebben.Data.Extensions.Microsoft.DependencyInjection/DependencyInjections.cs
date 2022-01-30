// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data.Mapper;
using Luebben.Data.Mapper.Properties;
using Luebben.Data.Mapper.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Luebben.Data.Extensions.Microsoft.DependencyInjection
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddObjectMapper(this IServiceCollection services)
        {
            services.TryAddTransient<IPropertyMapper, PropertyMapper>();
            services.TryAddTransient<ITypeMapper, TypeMapper>();
            services.TryAddTransient<IObjectMapper, ObjectMapper>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, Action<DatabaseOptionsBuilder> configureDatabaseOptions)
        {
            // Dal
            services.AddObjectMapper();

            // Database configuration
            services.TryAddTransient(serviceProvider => CreateDatabaseOptions(configureDatabaseOptions));

            // Database
            services.TryAddTransient<IDatabase, Database>();
            
            return services;
        }

        private static DatabaseOptions CreateDatabaseOptions(Action<DatabaseOptionsBuilder> configureDatabaseOptions)
        {
            var builder = new DatabaseOptionsBuilder();
            configureDatabaseOptions(builder);

            return builder.Build();
        }
    }
}
