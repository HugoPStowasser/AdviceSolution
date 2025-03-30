﻿using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAdviceRepository, AdviceRepository>();
            services.AddHttpClient<AdviceSlapClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.adviceslip.com/");
            });
            services.AddScoped<Application.Interfaces.IAdviceService, AdviceService>();

            return services;
        }
    }
}
