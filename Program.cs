using Emissions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEmissionsOrchestratorService, EmissionsOrchestratorService>();
builder.Services.AddSingleton<IEmissionsCalculatorService, EmissionsCalculatorService>();
builder.Services.AddSingleton<IOpenSkyTokenService, OpenSkyTokenService>();
builder.Services.AddHttpClient<IOpenSkyService, OpenSkyService>();

//Controllers and OpenAPI
builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews(); 





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseExceptionHandler("/Home/Error");

}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();


app.Run();
