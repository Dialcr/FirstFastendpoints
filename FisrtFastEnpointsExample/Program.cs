
using FastEndpoints;
using FastEndpoints.Security;
using FisrtFastEnpointsExample.Midellware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddFastEndpoints()
    .AddCookieAuth(validFor: TimeSpan.FromMinutes(10)) //configure cookie auth
    .AddAuthorization(); //add this
builder.Services.AddScoped<CustomMiddleware>();
builder.Services.AddScoped<CookieMiddellware>();


builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"),
    appBuilder =>
    {
        appBuilder.UseMiddleware<CustomMiddleware>();
    });
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"),
    appBuilder =>
    {
        appBuilder.UseMiddleware<CookieMiddellware>();
    });
//app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication() //add this
    .UseAuthorization() //add this
    .UseFastEndpoints();

app.MapControllers();

app.Run();












