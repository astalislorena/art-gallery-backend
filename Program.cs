using ArtGallery.Data;
using ArtGallery.Providers;
using ArtGallery.Providers.InstitutionProvider;
using ArtGallery.Providers.UserProvider;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ArtGalleryDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("ArtDb")));
builder.Services.AddScoped<IArtProvider, ArtProvider>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IInstitutionProvider, InstitutionProvider>();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllCors", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});
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
app.UseCors("AllCors");

app.MapControllers();

app.Run();
