using Application.Services.FeeTypes;
using Application.Services.VehiclesTypes;
using Application.Services.VehicleTotals;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IVehicleTotalService, VehicleTotalService>();
            services.AddScoped<IFeeTypeService, FeeTypeService>();

            return services;
        }

    }
}