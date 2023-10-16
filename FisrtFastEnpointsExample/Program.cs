
using FastEndpoints;
using FastEndpoints.Security;
using FisrtFastEnpointsExample.Midellware;
using FisrtFastEnpointsExample.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddFastEndpoints();
builder.Services
    .AddFastEndpoints()
    .AddJWTBearerAuth("TokenSigningKeTestFastEndpointEncoding") //add this
    .AddAuthorization();
builder.Services.AddScoped<CustomMiddleware>();
builder.Services.AddScoped<AuthService,AuthService>();


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


app.UseHttpsRedirection();

//app.UseFastEndpoints();
//app.UseAuthorization();
app.UseAuthentication() //add this
    .UseAuthorization() //add this
    .UseFastEndpoints();

app.MapControllers();

app.Run();












