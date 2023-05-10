using InterLab.Application;
using InterLab.Application.Interface;
using InterLab.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register services
builder.Services.AddScoped<IStockDataService, StockDataService>();
// Register your custom typed HttpClient
builder.Services.AddHttpClient<IStockDataService, StockDataService>();

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
