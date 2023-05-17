using InterLab.Application;
using InterLab.Application.Interface;
using InterLab.Core.Models;
using InterLab.Infrastracture;
using InterLab.MiddleWare;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Logging
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IBookMarkStockService, BookMarkStockService>();

// Register your custom typed HttpClient
builder.Services.AddHttpClient<IStockService, StockService>();

//
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<InterLabDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add new policy for localhost origin
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "localhostOrigin",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                          policy.AllowAnyHeader();
                      });
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // add localhost origin in development environment
    app.UseCors("localhostOrigin");
}

app.MapWhen(context => context.Request.Path.StartsWithSegments("/api.goperigon.com"), appBuilder => {
    appBuilder.UseMiddleware<PerigonMiddleWare>();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
