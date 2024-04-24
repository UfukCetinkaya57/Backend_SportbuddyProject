using Autofac.Extensions.DependencyInjection;
using Autofac;
using BusinessLayer.DependcyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Servisleri konteyn�ra ekle.

builder.Services.AddControllers();
// Swagger/OpenAPI yap�land�rmas� hakk�nda daha fazla bilgi i�in: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// HTTP iste�i boru hatt�n� yap�land�r.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS politikas�n� uygula
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
