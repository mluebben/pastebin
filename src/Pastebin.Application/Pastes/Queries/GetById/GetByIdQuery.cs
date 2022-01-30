// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;

namespace Pastebin.Application.Pastes.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdResult>
    {
        public string Id { get; set; }
    }
}
