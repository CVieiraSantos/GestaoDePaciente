using GestaoDePaciente.Infrastructure;
using Microsoft.OpenApi.Models;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddInfraStructure(builder.Configuration);


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.MapControllers();

//app.Run();



var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger (OBRIGATÓRIO)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestão de Pacientes API",
        Version = "v1",
        Description = "API responsável pela gestão de pacientes",
        Contact = new OpenApiContact
        {
            Name = "Carlos Vieira",
            Email = "carlos.eduvieirasantos@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/carlos-vieirasantos/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

// Infra
builder.Services.AddInfraStructure(builder.Configuration);

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestão de Pacientes API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


