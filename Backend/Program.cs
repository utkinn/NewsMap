using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NewsMap;
using NewsMap.Auth;
using NewsMap.Dto.News;
using NewsMap.Repositories.News;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddTransient<ArticleRepository>()
    .AddTransient<ArticleTagRepository>();

builder.Services
    .AddControllers()
    .AddControllersAsServices();  // For validating controller DI on startup

builder.Services
    .AddTransient<PostArticleRequestToModelConverter>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpLogging(_ => new HttpLoggingOptions());
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var options = builder.Configuration.GetRequiredSection(JwtOptions.SectionName).Get<JwtOptions>() ??
                  throw new Exception("Failed to get JwtOptions.");
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = options.Issuer,
        ValidateIssuer = true,
        ValidAudience = options.Audience,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(options.Key),
    };
});

builder.Services
    .AddOptions<JwtOptions>()
    .BindConfiguration(JwtOptions.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddDbContext<NewsMapDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")))
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<NewsMapDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "auth_cookie";
    options.Cookie.SameSite = SameSiteMode.None;
    options.LoginPath = new PathString("/api/contests");
    options.AccessDeniedPath = new PathString("/api/contests");
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy => policy.AllowAnyOrigin());
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:5000");