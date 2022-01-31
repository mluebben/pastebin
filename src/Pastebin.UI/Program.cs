// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using MediatR;
using Pastebin.Infrastructure;
using Pastebin.Infrastructure.Persistence;
using Pastebin.UI.Vite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(options => options.RootPath = "client-app/dist");
builder.Services.AddMediatR(
    typeof(Pastebin.UI.Anchor).Assembly,
    typeof(Pastebin.Infrastructure.Anchor).Assembly,
    typeof(Pastebin.Application.Anchor).Assembly,
    typeof(Pastebin.Domain.Anchor).Assembly
);
builder.Services.AddDbContext(options => {
    options.UseProvider(Providers.MySql);
    options.UseConnection(builder.Configuration.GetConnectionString("default"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// SPA configuration
app.UseSpaStaticFiles();
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "client-app";
    if (app.Environment.IsDevelopment())
    {
        // Launch development server for Vue.js
        spa.UseViteDevelopmentServer();
    }
});


app.Run();
