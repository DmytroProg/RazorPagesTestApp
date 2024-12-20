﻿using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesTestAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesTestAppContext") ??
                         throw new InvalidOperationException(
                             "Connection string 'RazorPagesTestAppContext' not found.")));

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(10);
    opt.Cookie.IsEssential = true;
    opt.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();