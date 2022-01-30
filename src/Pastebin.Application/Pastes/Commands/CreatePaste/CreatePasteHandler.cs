// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;
using Pastebin.Domain.Procedures;

namespace Pastebin.Application.Pastes.Commands.CreatePaste
{
    public class CreatePasteHandler : IRequestHandler<CreatePasteCommand, CreatePasteResult>
    {
        private readonly IDbContext _db;

        public CreatePasteHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<CreatePasteResult> Handle(CreatePasteCommand request, CancellationToken cancellationToken)
        {
            string id = Guid.NewGuid().ToString();

            int retention = request.Retention;
            if (retention < 0)
            {
                retention = 0;
            }

            DateTime? expirationDate = null;
            if (retention > 0)
            {
                expirationDate = DateTime.Now.AddDays(request.Retention);
            }

            var result = (await _db.QueryAsync(new CreatePasteStoredProcedure
            {
                Uid = id,
                Title = request.Title,
                Language = request.Language,
                Code = request.Code,
                ExpirationDate = expirationDate
            })).First();

            return new CreatePasteResult
            {
                Id = result.Uid
            };
        }
    }
}
