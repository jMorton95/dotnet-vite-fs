var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((context, config) =>
{
    Console.WriteLine(context.HostingEnvironment.EnvironmentName);
    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}", true, true);
});


var settings = builder.Configuration.GetSection("Settings");

//Console.WriteLine(settings.ToString());
//builder.Configuration.GetSection("Settings").Bind(new Settings());

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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Console.WriteLine($"{app.Environment.EnvironmentName} Writeline");


app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
