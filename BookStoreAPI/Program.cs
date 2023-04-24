using Data.InversionofControl;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container, and ignoring the reference loop handling
builder.Services.AddControllers().AddNewtonsoftJson(opts =>
opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("as_bookstore", new OpenApiInfo
    {
        Title = "Identity API PB Rede Social",
        Description = "API de cadastro de usuario para o Projeto de Bloco .NET",
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/mit/") }
    });
});

DependencyInjection.Inject(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/as_bookstore/swagger.json", "as_bookstore");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
