using System.Reflection;
using CiaAerea.Contexts;
using CiaAerea.Services;
using CiaAerea.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CiaAereaContexts>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();

builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API para controle de Aeronaves.",
        Description = "Colocar uma descrição",
        TermsOfService = new Uri("https://codingsonata.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Contact us",
            Url = new Uri("https://codingsonata.com/terms"),
            Email = "myemail@server.com"
        },

        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://codingsonata.com/terms")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
