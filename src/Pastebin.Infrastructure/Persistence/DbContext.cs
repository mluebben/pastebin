// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data;
using Pastebin.Domain.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pastebin.Infrastructure.Persistence
{
    public class DbContext : IDbContext
    {
        private readonly IDatabase _db;

        public DbContext(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TResult>> QueryAsync<TResult>(IProcedure<TResult> procedure) where TResult : new()
        {
            var sql = CompileSql(procedure);
            var parameters = CompileParameters(procedure);

            return await _db.QueryAsync<TResult>(sql, parameters);
        }

        private string CompileSql<TResult>(IProcedure<TResult> procedure)
        {
            var procedureName = CompileProcedureName(procedure);

            var propertyInfos = procedure.GetType().GetProperties();
            var parameterNames = propertyInfos.Select(pi => "@" + pi.Name);

            return "call " + procedureName + "(" + string.Join(", ", parameterNames) + ")";
        }

        private string CompileProcedureName<TResult>(IProcedure<TResult> procedure)
        {
            string className = procedure.GetType().Name;
            string procedureName = className.Replace("StoredProcedure", "");

            return procedureName;
        }

        private Parameter[] CompileParameters<TResult>(IProcedure<TResult> procedure)
        {
            var propertyInfos = procedure.GetType().GetProperties();
            return propertyInfos.Select(pi => CreateParameter(procedure, pi)).ToArray();
        }

        private Parameter CreateParameter<TResult>(IProcedure<TResult> procedure, PropertyInfo pi)
        {
            var parameterName = GetParameterName(procedure, pi);
            var parameterType = GetParameterType(procedure, pi);
            var parameterSize = GetParameterSize(procedure, pi);
            var parameterValue = GetParameterValue(procedure, pi);

            return new Parameter(parameterName, parameterType, parameterSize) 
            { 
                Direction = ParameterDirection.Input,
                Value = parameterValue
            };
        }


        private string GetParameterName<TResult>(IProcedure<TResult> procedure, PropertyInfo pi)
        {
            return "@" + pi.Name;
        }

        private System.Data.DbType GetParameterType<TResult>(IProcedure<TResult> procedure, PropertyInfo pi)
        {
            // TODO Hier kann man doch bestimmt schon Klassen Luebben.Data verwenden TypeMapper
            if (pi.PropertyType == typeof(DateTime?))
            {
                return System.Data.DbType.DateTime;
            }

            return System.Data.DbType.String;
        }

        private int GetParameterSize<TResult>(IProcedure<TResult> procedure, PropertyInfo pi)
        {
            return -1;
        }

        private object? GetParameterValue<TResult>(IProcedure<TResult> procedure, PropertyInfo pi)
        {
            return pi.GetValue(procedure);
        }
    }
}
