// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Rtp.Web.Api.Brokers.DateTime;
using Rtp.Web.Api.Brokers.Logging;
using Rtp.Web.Api.Brokers.Storage;
//using OtripleS.Web.Api.Brokers.UserManagement;
//using OtripleS.Web.Api.Models.Users;
//using OtripleS.Web.Api.Services.Foundations.StudentContacts;
//using OtripleS.Web.Api.Services.Foundations.Students;
//using OtripleS.Web.Api.Services.Foundations.Users;
using JsonStringEnumConverter = Newtonsoft.Json.Converters.StringEnumConverter;

namespace Rtp.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            AddNewtonSoftJson(services);
            services.AddLogging();
            services.AddDbContext<StorageBroker>();
            AddBrokers(services);
            //AddFoundationServices(services);

           /* services.AddIdentityCore<User>()
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<StorageBroker>()
                    .AddDefaultTokenProviders();
         */
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "Rtp.Core.Api",
                        Version = "v1"
                    }
                );
            });
        }

        public static void Configure(
            IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(options =>

                options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Rtp.Core.Api v1"));
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static void AddBrokers(IServiceCollection services)
        {
            //services.AddScoped<IUserManagementBroker, UserManagementBroker>();
            services.AddScoped<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            //services.AddTransient<IStudentService, StudentService>();
            
        }

        private static void AddNewtonSoftJson(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new JsonStringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }
    }
}
