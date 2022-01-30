// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using System.Data.Common;

namespace Luebben.Data
{
    public class Provider
    {
        public Provider(string name, DbProviderFactory factory)
        {
            Name = name;
            Factory = factory;
        }

        public string Name { get; }

        public DbProviderFactory Factory { get; }

        public void Register()
        {
            if (IsRegistered)
            {
                DbProviderFactories.RegisterFactory(Name, Factory);
            }
        }

        public bool IsRegistered
        {
            get { return DbProviderFactories.TryGetFactory(Name, out var _); }
        }
    }
}
