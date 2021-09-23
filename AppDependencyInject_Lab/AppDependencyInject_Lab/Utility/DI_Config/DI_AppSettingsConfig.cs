using AppDependencyInject_Lab.Utility.AppSettingsClasses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppDependencyInject_Lab.Utility.DI_Config
{
  public static class DI_AppSettingsConfig
  {
        #region ajouter la méthode statique AddAppSettingsConfig qui retourne les IServiceCollection Versio groupés ici
        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WazeForecastSettings>(configuration.GetSection("WazeForecast"));
            services.Configure<StripeSettings>(configuration.GetSection("Stripe"));
            services.Configure<TwilioSettings>(configuration.GetSection("Twilio"));

            return services;
        }

        #endregion
    }
}