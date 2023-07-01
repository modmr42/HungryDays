using HungryDays.Database;
using HungryDays.Database.Entities;
using HungryDays.Database.Factories;
using HungryDays.Database.Repositories;
using HungryDays.Domain.Factories;
using HungryDays.Domain.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.


//db
builder.Services.AddDbContext<HungryDaysDbContext>();
builder.Services.AddScoped<HungryDaysDbContextFactory>();
//db auth
builder.Services.AddIdentityCore<HungryUserEntity>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<HungryDaysDbContext>();

//services
builder.Services.AddScoped<HungryDayService>();
builder.Services.AddScoped<HungryItemService>();
builder.Services.AddScoped<JwtService>();

//repos
builder.Services.AddScoped<HungryDayRepository>();
builder.Services.AddScoped<HungryItemRepository>();

//factories
builder.Services.AddScoped<HungryDayFactory>();
builder.Services.AddScoped<HungryItemFactory>();


//base logic
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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



if (app.Environment.IsDevelopment())
{
    //swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(builder =>
{
    if (app.Environment.IsDevelopment()) 
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
    else
    {
        builder
        .WithOrigins("http://localhost:6073")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
