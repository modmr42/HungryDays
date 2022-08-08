using HungryDays.Blazor.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HungryDays.Database;
using HungryDays.Database.Factories;
using HungryDays.Database.Repositories;
using HungryDays.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//db
builder.Services.AddDbContext<HungryDaysDbContext>();
builder.Services.AddSingleton<HungryDaysDbContextFactory>();

//services
builder.Services.AddScoped<HungryDayService>();
builder.Services.AddScoped<HungryItemService>();

//repos
builder.Services.AddScoped<HungryDayRepository>();
builder.Services.AddScoped<HungryItemRepository>();


var app = builder.Build();
CreateDbIfNotExists(app);

//Configure db
static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<HungryDaysDbContextFactory>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
