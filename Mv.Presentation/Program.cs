using Mv.Infrastructure;
using Mv.Presentation.Extensions;
using Mv.Presentation.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// --- Infrastructure ---
builder.Services.AddInfrastructure(builder.Configuration);
builder.Configuration.AddJsonFile("secrets.json", true, true);

// --- Presentation Extension ---
builder.AddSerilogCustom();

builder.Services.AddHttpContextAccessor();


// =========================================================================
// || -_-_-_-_-_-_-_-_-_-_-_-_-_-_ APP BUILD _-_-_-_-_-_-_-_-_-_-_-_-_-_- ||
// =========================================================================
var app = builder.Build();

// --- Custom Middlewares ---
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();

// --- Swagger UI ---
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Dashboard API");
    c.DocExpansion(DocExpansion.None);
  });
}

// --- Allow Static Files ---
app.UseStaticFiles();

// --- CORS ---
app.UseCors(options => options
  .AllowAnyMethod()
  .AllowAnyHeader()
  .SetIsOriginAllowed(_ => true)
  .AllowCredentials());

// --- Authentication & Authorization ---
app.UseAuthentication();
app.UseAuthorization();

// --- Endpoints ---
app.MapControllers();

app.Run();
