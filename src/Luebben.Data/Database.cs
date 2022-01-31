// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Luebben.Data.Mapper;
using Luebben.Data.Mapper.Fields;
using Luebben.Data.Mapper.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Luebben.Data
{
    public class Database : IDatabase
    {
        private DatabaseOptions _options;
        private IObjectMapper _objectMapper;
        private ITypeMapper _typeMapper;

        public Database(DatabaseOptions options, IObjectMapper objectMapper, ITypeMapper typeMapper)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _objectMapper = objectMapper ?? throw new ArgumentNullException(nameof(objectMapper));
            _typeMapper = typeMapper ?? throw new ArgumentNullException(nameof(typeMapper));
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params Parameter[] parameters)
        {
            int result;

            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = CreateCommand(connection, sql, parameters))
                {
                    result = await command.ExecuteNonQueryAsync();
                }
            }

            return result;
        }

        public async Task<List<T>> QueryAsync<T>(string sql, params Parameter[] parameters) where T : new()
        {
            var result = await DoQueryAsync<T>(sql, CommandBehavior.Default, parameters);

            return result;
        }

        public async Task<T> QueryFirstAsync<T>(string sql, params Parameter[] parameters) where T : new()
        {
            var result = await DoQueryAsync<T>(sql, CommandBehavior.SingleRow, parameters);

            return result.First();
        }

        private async Task<List<T>> DoQueryAsync<T>(string sql, CommandBehavior commandBehaviour, params Parameter[] parameters) where T : new()
        {
            var result = new List<T>();

            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = CreateCommand(connection, sql, parameters))
                {
                    DbDataReader? reader = null;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(commandBehaviour);
                        var fieldMapper = CreateFieldMapper(reader);
                        while (await reader.ReadAsync())
                        {
                            result.Add(_objectMapper.GetObject<T>(fieldMapper, reader));
                        }
                    }
                    finally
                    {
                        EnsureReaderIsClosed(reader);
                    }
                }
            }

            return result;
        }

        public async Task<T?> QueryScalarAsync<T>(string sql, params Parameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = CreateCommand(connection, sql, parameters))
                {
                    var scalar = await command.ExecuteScalarAsync();

                    return (T?)_typeMapper.Map(scalar, typeof(T));
                }
            }
        }

        protected virtual DbConnection CreateConnection()
        {
            var connection = _options.ProviderFactory.CreateConnection();
            if (connection == null)
            {
                throw new DataException($"Unable to create DbConnection object with provider factory {_options.ProviderFactory.GetType().Name}.");
            }
            connection.ConnectionString = _options.ConnectionString;
            return connection;
        }

        protected virtual DbCommand CreateCommand(DbConnection connection, string sql, Parameter[] parameters)
        {
            DbCommand? command = null;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = sql;

                foreach (var p in parameters)
                {
                    command.Parameters.Add(CreateParameter(command, p));
                }

                return command;
            }
            catch
            {
                EnsureIsDisposed(command);
                throw;
            }
        }

        protected virtual DbParameter CreateParameter(DbCommand command, Parameter parameter)
        {
            var result = command.CreateParameter();
            result.ParameterName = parameter.ParameterName;
            result.DbType = parameter.DbType;

            switch (parameter.Direction)
            {
                case ParameterDirection.Input:
                    result.Direction = System.Data.ParameterDirection.Input;
                    break;
                case ParameterDirection.Output:
                    result.Direction = System.Data.ParameterDirection.Output;
                    break;
            }

            if (parameter.Size != -1)
            {
                result.Size = parameter.Size;
            }
            if (parameter.Precision != -1)
            {
                result.Precision = (byte)parameter.Precision;
            }
            if (parameter.Scale != -1)
            {
                result.Scale = (byte)parameter.Scale;
            }

            result.Value = parameter.Value;

            return result;
        }

        protected virtual IFieldMapper CreateFieldMapper(DbDataReader reader)
        {
            var fieldCount = reader.FieldCount;
            var fieldNames = new string[fieldCount];
            for (int fieldIndex = 0; fieldIndex < fieldCount; fieldIndex++)
            {
                fieldNames[fieldIndex] = reader.GetName(fieldIndex);
            }

            return new FieldMapper(fieldNames);
        }

        private void EnsureReaderIsClosed(DbDataReader? reader)
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
            catch (Exception)
            {
                // Nothing to do here
            }
        }

        private void EnsureIsDisposed(IDisposable? disposable)
        {
            try
            {
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            catch (Exception)
            {
                // Nothing to do here
            }
        }
    }
}
