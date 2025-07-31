using FluentValidation;
using FluentValidation.AspNetCore;
using WebApplication4.Models.Dtos.Requests;
using WebApplication4.Models.Dtos.Validators;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Services;

namespace WebApplication4.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<ProductRequestDto>, ProductRequestDtoValidator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}