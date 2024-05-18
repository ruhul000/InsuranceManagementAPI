using InsuranceManagementAPI;
using InsuranceManagementAPI.CustomAttribute;
using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Helper;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions 
{ 
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory(),
    WebRootPath = "wwwroot"
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//Configure Database Services
builder.Services.AddDbContext<PolicyDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PolicyAPIConnectionString")));

// Configure Autor Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Configure Helper
builder.Services.AddScoped(typeof(IMappingFactory<>), typeof(MappingFactory<>));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddHttpContextAccessor();
// Configure App Services
#region--------- APP SERVICES
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBankBranchService, BankBranchService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IInsuranceCompanyService, InsuranceCompanyService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IMarineCargoTariffService, MarineCargoTariffService>();
builder.Services.AddScoped<IFinalMRService, FinalMRService>();
builder.Services.AddScoped<IReportingService, ReportingService>();
builder.Services.AddScoped<IMediclaimTariffService, MediclaimTariffService>();
builder.Services.AddScoped<IBankPaymentService, BankPaymentService>();
builder.Services.AddScoped<IMotorTariffService, MotorTariffService>();

#endregion

// Configure App Repositories
#region--------- APP REPOSITORIES
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankBranchRepository, BankBranchRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IInsuranceCompanyRepository, InsuranceCompanyRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IMarineCargoTariffRepository, MarineCargoTariffRepository>();
builder.Services.AddScoped<IFinalMRRepository, FinalMRRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IMediclaimTariffRepository, MediclaimTariffRepository>();
builder.Services.AddScoped<IBankPaymentRepository, BankPaymentRepository>();
builder.Services.AddScoped<IMotorTariffRepository, MotorTariffRepository>();
#endregion

// Configure App Factories
#region--------- APP FACTORIES
builder.Services.AddScoped<IBankFactory, BankFactory>();
builder.Services.AddScoped<IBankBranchFactory, BankBranchFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IClientFactory, ClientFactory>();
builder.Services.AddScoped<IInsuranceCompanyFactory, InsuranceCompanyFactory>();
builder.Services.AddScoped<ICompanyFactory, CompanyFactory>();
builder.Services.AddScoped<IBranchFactory, BranchFactory>();
builder.Services.AddScoped<IDepartmentFactory, DepartmentFactory>();
builder.Services.AddScoped<IDesignationFactory, DesignationFactory>();
builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();
builder.Services.AddScoped<IAgentFactory, AgentFactory>();
builder.Services.AddScoped<ICurrencyFactory, CurrencyFactory>();
builder.Services.AddScoped<IMarineCargoTariffFactory, MarineCargoTariffFactory>();
builder.Services.AddScoped<IFinalMRFactory, FinalMRFactory>();
builder.Services.AddScoped<IMediclaimTariffFactory, MediclaimTariffFactory>();
builder.Services.AddScoped<IBankPaymentFactory, BankPaymentFactory>();
builder.Services.AddScoped<IMotorTariffFactory, MotorTariffFactory>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure API Version
#region--------- API VERSIONING
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
#endregion

// Add JWT Authentication Option in Swagger
builder.Services.AddSwaggerGen(c => 
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{ }
        }
    });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "The API Key to access the API",
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "ApiKey"
                }
            },
            new string[]{ }
        }
    });

});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

// Configure JWT Validation
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:Key"]))
    };
});

// Default Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                                
        });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins("http://192.168.1.235", "http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant());

        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    }
});


//builder.Services.AddControllers();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

//app.UseCors("myAppCors");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
