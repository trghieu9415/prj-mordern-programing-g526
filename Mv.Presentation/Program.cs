using Mv.Infrastructure;
using Mv.Presentation.Extensions;
using Mv.Presentation.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options => {
  options.ValidateOnBuild = false;
  options.ValidateScopes = false;
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Configuration.AddJsonFile("secrets.json", true, true);

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddCors();
builder.Services.AddWebApiDefaults();
builder.Services.AddSwaggerDocument();
builder.AddSerilogCustom();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Dashboard API");
    c.DocExpansion(DocExpansion.None);
  });
}

app.UseStaticFiles();

app.UseCors(options => options
  .AllowAnyMethod()
  .AllowAnyHeader()
  .SetIsOriginAllowed(_ => true)
  .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
