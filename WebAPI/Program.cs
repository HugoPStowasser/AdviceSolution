using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<AdviceSlapClient>(client =>
{
    client.BaseAddress = new Uri("https://api.adviceslip.com/");
});

builder.Services.AddScoped<Application.Interfaces.IAdviceService, Infrastructure.Services.AdviceService>();
builder.Services.AddScoped<Domain.Interfaces.IAdviceRepository, Infrastructure.Repositories.AdviceRepository>();

var app = builder.Build();

app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapScalarApiReference("scalar", options =>
{
    options.HideDarkModeToggle = true;
    options.HideClientButton = true;
    options.WithTheme(ScalarTheme.Mars);
    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    options.AddDocument("Advice", "AdviceModule", "/swagger/v1/swagger.json");
});

app.Run();