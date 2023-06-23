using Infra;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositorio, RepositorioLinq2DB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
}

app.UseFileServer();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
),

    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings = { [".properties"] = "application/x-msdownload" }
    }
});

app.UseDefaultFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting(); 

app.MapControllers();

app.Run();

