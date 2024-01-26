using activity_dashboard.Server.Architecture.Implementation.Repository;
using activity_dashboard.Server.Architecture.Implementation.Services;
using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(async c =>
{
    // include all project's xml comments
    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        if (!assembly.IsDynamic)
        {
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(baseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        }
    }

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "activity-dashboard",
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUserRepository, UsersRepository>();
builder.Services.AddTransient<IActivityTypeRepository, ActivityTypeRepository>();
builder.Services.AddTransient<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseJwtTokenMiddleware();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
    options.RoutePrefix = "swagger";
    options.DisplayRequestDuration();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
