using BlazorAppPrueba.Components;
using BlazorAppPruebaBD.Context;
using BlazorAppPruebaBD.Data;
using BlazorAppPruebaServicios.TareaServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("cnnString");

//builder.Services.AddDbContext<BlazorAppPruebaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<BlazorAppPruebaDbContext>(options =>options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<ITareaServicio,TareaServicio>(); 

var app = builder.Build();

// Inicializar la base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();  