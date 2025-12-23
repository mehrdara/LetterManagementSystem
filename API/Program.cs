using Infrastructure.Extensions;
using Infrastructure.Persistence.Extensions;
using API.Common;
using Application.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("default", opt =>
    {
        opt.AllowAnyHeader()
            .AllowAnyOrigin();
    });
});
var app = builder.Build();
app.ApplyMigrations();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
//app.MapIdentityApi<AppUser>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
