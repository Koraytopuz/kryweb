var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
options.AddPolicy("AllowAll",
    builder => builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});
builder.Services.AddAuthorization(); // Add authorization services
builder.Services.AddControllersWithViews(); // Add controller services with views

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll"); // CORS kullanýmý
app.UseAuthorization(); // Use authorization middleware

app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();