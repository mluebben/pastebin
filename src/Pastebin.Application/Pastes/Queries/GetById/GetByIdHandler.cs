// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;
using Pastebin.Domain.Procedures;

namespace Pastebin.Application.Pastes.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, GetByIdResult>
    {
        private readonly IDbContext _db;

        public GetByIdHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<GetByIdResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {

            var result = (await _db.QueryAsync(new GetPasteByIdStoredProcedure 
            { 
                Uid = request.Id 
            })).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("Paste not found");
            }

            return new GetByIdResult
            {
                Id = result.Uid,
                Title = result.Title,
                Language = result.Language,
                Code = result.Code,
                CreationDate = result.CreationDate,
                ExpirationDate = result.ExpirationDate,
            };
        }
    }
}
