using Blog.Microservice.Repository;
using Microsoft.EntityFrameworkCore;
using ReadIt.Core.DataModels;
using ReadIt.Extentions;
using ReadIt.Extentions.ImageExtention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped(typeof(IImageHandler<>), typeof(ImageHandler<>));


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ReadIt")
));
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
