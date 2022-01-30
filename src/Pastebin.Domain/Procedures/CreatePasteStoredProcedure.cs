// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

namespace Pastebin.Domain.Procedures
{
    public class CreatePasteStoredProcedure : IProcedure<CreatePasteStoredProcedureResult>
    {
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
