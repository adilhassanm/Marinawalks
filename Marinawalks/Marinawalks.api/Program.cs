using Marinawalks.api.Data;
using Marinawalks.api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//lets add our dbcontext services here with options of sql server and connection string
builder.Services.AddDbContext<MariwalksDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Marinawalks"));

}
);

//create builder for next dependency injection

builder.Services.AddScoped<IRegionRepository, RegionRepository>();//whenevr we ask for iregionrep give me its implemetation,and after adding them to services we can use them in controller
//inject autmapper profile

builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
