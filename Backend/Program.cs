using BookMyShow.Models;
using BookMyShow.Services;
using BookMyShow.Services.ServiceClasses;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvcCore();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookMyShowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ??
    throw new InvalidOperationException("Connection string 'BookMyShowContext' not found.")));

var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});

container.Register<IMovieDetailService, MovieDetailService>();
container.Register<IMovieShowsListService, MovieShowsListService>();
container.Register<ISeatDetailService, SeatDetailService>();
container.Register<ITheatreService, TheatreService>();
container.Register<ITicketService, TicketService>();
container.Register<IUserDetailService, UserDetailService>();

var app = builder.Build();
app.Services.UseSimpleInjector(container);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(param =>
    param.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
