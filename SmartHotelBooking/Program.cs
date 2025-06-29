using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SmartHotelBooking.Helpers;
using SmartHotelBooking.Repositories.Implementations;
using SmartHotelBooking.Repositories.Implementations.SmartHotelBooking.Repositories;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Implementations;
using SmartHotelBooking.Services.Interfaces;
using SmartHotelBooking.Services;
using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using Microsoft.OpenApi.Models;
using SmartHotelBooking.Mappers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//Add controller
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<HotelBookingContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS policy in the service configuration:
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => {
            policy.WithOrigins("http://localhost:4200")
                           .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
        });
});



// Configuration for JwtService
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
// JWT Configuration
var key = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

// Enable JWT input in swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization using Bearer. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
});
// Register JwtService and interface
builder.Services.AddScoped<IJwtService, JwtService>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ILoyaltyAccountRepository, LoyaltyAccountRepository>();

// Register services (business logic)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ILoyaltyAccountService, LoyaltyAccountService>();

// Add AutoMapper (assuming you have profiles created)
builder.Services.AddAutoMapper(typeof(Program));

// NEW ADDED CODE

//builder.Services.AddAutoMapper(typeof(MappingProfile));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
var app = builder.Build();

//Exception Handling Middleware
app.UseMiddleware<SmartHotelBooking.Middlewares.ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
//Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // ? Shows full 500 error
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();