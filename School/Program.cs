using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    );

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CUSTOM_CORS", policy =>
    {
        policy.WithOrigins("http://localhost:3000");
    });
});

//todos los servicios van encima de var app = builder.Build();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.UseAuthorization();

app.MapControllers();

app.UseCors("CUSTOM_CORS");

app.Run();
