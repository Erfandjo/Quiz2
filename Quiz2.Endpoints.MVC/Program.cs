using App.Domain.AppServices.Quiz2.Card;
using App.Domain.AppServices.Quiz2.CodeVerify;
using App.Domain.AppServices.Quiz2.Transaction;
using App.Domain.Core.Quiz2.Card.AppServices;
using App.Domain.Core.Quiz2.Card.Data.Repositories;
using App.Domain.Core.Quiz2.Card.Services;
using App.Domain.Core.Quiz2.CodeVerify.AppServices;
using App.Domain.Core.Quiz2.CodeVerify.Data.Repositories;
using App.Domain.Core.Quiz2.CodeVerify.Services;
using App.Domain.Core.Quiz2.Transaction.AppServices;
using App.Domain.Core.Quiz2.Transaction.Data.Repositories;
using App.Domain.Core.Quiz2.Transaction.Services;
using App.Domain.Services.Quiz2.Card;
using App.Domain.Services.Quiz2.CodeVerify;
using App.Domain.Services.Quiz2.Transaction;
using App.Infra.Data.Repos.Ef.Quiz2.Card;
using App.Infra.Data.Repos.Ef.Quiz2.Transaction;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify.Repositories;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICodeVerifyRepository , CodeVerifyRepository>();
builder.Services.AddScoped<ITransactionRepository , TransactionRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICodeVerifyService , CodeVerifyService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICardAppService, CardAppService>();
builder.Services.AddScoped<ICodeVerifyAppService, CodeVerifyAppService>();
builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
