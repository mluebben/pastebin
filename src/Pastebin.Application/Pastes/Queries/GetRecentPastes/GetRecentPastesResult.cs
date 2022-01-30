// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Pastebin.Application.Pastes.Queries.GetRecentPastes
{
    public class GetRecentPastesResult
    {
        public List<Paste> Pastes { get; set; }
    }

    public class Paste
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
