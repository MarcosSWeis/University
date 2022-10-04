// 1. Usings to kow with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAcces;//para tener accesos al context de la base de datos
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                                       
                      });
});

// 2. Connection with DataBase (sql server)
const string CONNECTIONNAME = "UniversityDB";//EL mismo nombre que en el appsettings.json
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);//obtengo el valor que tiene UniversityDB en el appsettings.json y lo guardo en la variable connectionString
// 3. add context 
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connectionString));  //al servicio le inidco que añada un contexto del tipo, y tambien tengo que especificarle las opciones que tiene dicho contexto

// Add services to the container.
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
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
