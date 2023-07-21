WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT_NAME");

if (!string.IsNullOrEmpty(environmentName))
{
    Console.WriteLine(environmentName);
    builder.Configuration.AddJsonFile($"Backend/appsettings.{environmentName}.json");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

if (environmentName == "Local" || environmentName == "Development")
{
    Console.WriteLine($"Swagger Docs live at https://localhost:7001/swagger/index.html");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
