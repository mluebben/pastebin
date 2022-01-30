// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;

namespace Pastebin.Application.Pastes.Commands.CreatePaste
{
    public class CreatePasteCommand : IRequest<CreatePasteResult>
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public int Retention { get; set; }
    }
}
