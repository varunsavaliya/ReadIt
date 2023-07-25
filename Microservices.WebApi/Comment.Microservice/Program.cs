using Comment.Microservice.Repository;
using Microsoft.EntityFrameworkCore;
using Notification.Microservice.Models;
using Notification.Microservice.Repository;
using ReadIt.Core.DataModels;
using ReadIt.Extentions;
using ReadIt.Extentions.ImageExtention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddSignalR();
//builder.Services.AddScoped<INotificationHub, NotifyHub>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
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
