// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Pastebin.UI.Vite
{
    public class DevelopmentServerNotRunningException : Exception
    {
        public DevelopmentServerNotRunningException(string message) : base(message) { }
    }
}
