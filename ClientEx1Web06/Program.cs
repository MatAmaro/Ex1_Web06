using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Services;
using ApiClientes.Filters;
using ApiClientes.Infra;
using ApiClientes.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteService,ClienteService>();
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<IConnectionDataBase,ConnectionDataBase>();
builder.Services.AddScoped<ActionFilterCpfPost>();
builder.Services.AddScoped<ActionFilterCpfUpdate>();

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());


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
