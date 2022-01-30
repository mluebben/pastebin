// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;

namespace Pastebin.Application.Pastes.Queries.GetRecentPastes
{
    public class GetRecentPastesQuery : IRequest<GetRecentPastesResult>
    {
    }
}
