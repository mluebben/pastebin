// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;
using Pastebin.Domain.Procedures;

namespace Pastebin.Application.Pastes.Queries.GetRecentPastes
{
    public class GetRecentPastesHandler : IRequestHandler<GetRecentPastesQuery, GetRecentPastesResult>
    {
        private readonly IDbContext _db;

        public GetRecentPastesHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<GetRecentPastesResult> Handle(GetRecentPastesQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.QueryAsync(new GetRecentPastesStoredProcedure
            {
            });

            return new GetRecentPastesResult
            {
                Pastes = result.Select(o => new Paste
                {
                    Id = o.Uid,
                    Title = o.Title,
                    Language = o.Language,
                    Code = o.Code,
                    CreationDate = o.CreationDate,
                    ExpirationDate = o.ExpirationDate
                }).ToList()
            };
        }
    }
}
