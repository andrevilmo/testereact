using System.Text;
using backend.EF;
using backend.repository;
using backend.service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(); 


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithOrigins("http://*localhost*",
                                         "https://*localhost*",
                                          "http://*0.0.0.0*",
                                          "https://*0.0.0.0*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin(); 
                      });
});
builder.Services.AddMvc();
builder.Services.AddMvcCore(); 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services
    .AddConfig(builder.Configuration)
    .AddMyDependencyGroup();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")))
        };
    });
builder.Services.AddSwaggerGen(setup =>
{ 
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
var app = builder.Build();
//app.UseHttpsRedirection();
/*
builder.Services.AddDirectoryBrowser();
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "web")),
    RequestPath = "/web",
    EnableDirectoryBrowsing = true
});*/
/*
var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);

app.UseDefaultFiles();*/

//app.UseFileServer();
app.UseMiddleware<AuthenticationMiddleware>();
 app.Use(async (context, next) =>
 {
    string path = context.Request.Path.Value;
    await next();
    if (context.Response.StatusCode == 404 && 
       !Path.HasExtension(context.Request.Path.Value))
    {
       context.Request.Path = "/";
       await next();
    }
 });
 app.UseStaticFiles();
 //******************   we need the code below *****************************
var fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "backend","wwwroot"));

var options = new FileServerOptions
{
    FileProvider = fileProvider,
    RequestPath = "/web",
    EnableDirectoryBrowsing = true
};

app.UseFileServer(options);

//******************   we need the code above *****************************
/*
app.UseSpa(spa =>
{
    if (builder.Environment.EnvironmentName == "Development") 
    {
        spa.Options.SourcePath = "web";
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
    } 
});*/
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();


