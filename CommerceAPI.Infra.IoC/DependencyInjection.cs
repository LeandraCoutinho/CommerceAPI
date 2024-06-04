using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommerceAPI.Application.Mapping;
using CommerceAPI.Application.Services;
using CommerceAPI.Application.Services.Interfaces;
using CommerceAPI.Domain.Authentication;
using CommerceAPI.Domain.Integrations;
using CommerceAPI.Domain.Repositories;
using CommerceAPI.Infra.Data.Authentication;
using CommerceAPI.Infra.Data.Context;
using CommerceAPI.Infra.Data.Integrations;
using CommerceAPI.Infra.Data.Repositories;

namespace CommerceAPI.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, serverVersion));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonImageRepository, PersonImageRepository>();
        services.AddScoped<ISavePersonImage, SavePersonImage>();
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPersonImageService, PersonImageService>();
        
        return services;
    }
}