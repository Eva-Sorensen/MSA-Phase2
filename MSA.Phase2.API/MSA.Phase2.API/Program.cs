using Microsoft.EntityFrameworkCore;
using MSA.Phase2.API.Data;
using MSA.Phase2.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Middleware to connect to database
var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<PokemonDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add AutoMapper dependancy, this allows me to use the auto mapper easily within my controllers
// I can just inject the auto mapper and not have to worry about creating the instance ect.
builder.Services.AddAutoMapper(typeof(MapperConfig));

// Middleware to add http client to connect to Poke api
builder.Services.AddHttpClient("pokeApi", configureClient: client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
