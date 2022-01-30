// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pastebin.Application.Pastes.Commands.CreatePaste;
using Pastebin.Application.Pastes.Queries.GetById;
using Pastebin.Application.Pastes.Queries.GetRecentPastes;

namespace Pastebin.Controllers
{
    [ApiController]
    public class PasteController : Controller
    {
        private readonly IMediator _mediator;

        public PasteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/api/pastes")]
        [HttpGet]
        public async Task<ActionResult<GetRecentPastesResult>> GetRecentPastes([FromRoute] GetRecentPastesQuery request)
        {
            return await _mediator.Send(request);
        }

        [Route("/api/pastes/{id}")]
        [HttpGet]
        public async Task<ActionResult<GetByIdResult>> GetById([FromRoute] GetByIdQuery request)
        {
            return await _mediator.Send(request);
        }

        [Route("/api/pastes")]
        [HttpPost]
        public async Task<ActionResult<CreatePasteResult>> Post([FromBody] CreatePasteCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
