using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCSA_Movies.Arashi256.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TCSA_MoviesArashi256Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TCSA_MoviesArashi256Context") ?? throw new InvalidOperationException("Connection string 'TCSA_MoviesArashi256Context' not found.")));
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, proxy-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    context.Response.Headers["Surrogate-Control"] = "no-store";
    await next();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");
app.Run();