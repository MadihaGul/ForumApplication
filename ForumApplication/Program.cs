using ForumApplication.API.DbContexts;
using ForumApplication.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adding DB context
builder.Services.AddDbContext<ForumApplicationContext>(
 DbContextOptions => DbContextOptions.UseSqlite
    (builder.Configuration["ConnectionStrings:ForumApplicationDBConnectionString"]));
// Adding Repository service 
builder.Services.AddScoped<IForumApplicationRepository, ForumApplicationRepository>();
// Adding Mapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure for frontend 
app.UseCors(p => p.WithOrigins("http://localhost:3000")
.AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
