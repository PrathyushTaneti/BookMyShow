using BookMyShowAPI.Services;
using BookMyShowAPI.Services.ServiceClasses;
using SimpleInjector;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvcCore();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});

container.Register<IMovieDetailService, MovieDetailService>();
container.Register<ISeatDetailService, MovieShowsListService>();
container.Register<ISeatDetailService, SeatDetailService>();
container.Register<ITheatreService, TheatreService>();
container.Register<ITicketService, TicketService>();
container.Register<IUserDetailService, UserDetailService>();

var app = builder.Build();
app.Services.UseSimpleInjector(container);
container.Verify();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// simple injector ; get connection string from appsettings 
