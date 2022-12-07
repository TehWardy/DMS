using DMS.Data.Brokers.Events.Security;
using DMS.Data.Brokers.Events.Security.Interfaces;
using DMS.Data.Brokers.Storages.Masterdata;
using DMS.Data.Brokers.Storages.Masterdata.Interfaces;
using DMS.Data.Brokers.Storages.Security;
using DMS.Data.Brokers.Storages.Security.Interfaces;
using DMS.Services.Foundation.Security;
using DMS.Services.Foundation.Security.Interfaces;
using DMS.Services.Orchestration.Security;
using DMS.Services.Orchestration.Security.Interfaces;
using DMS.Services.Processing.Security;
using DMS.Services.Processing.Security.Interfaces;

namespace DMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddSecurityBrokers();
            services.AddSecurityFoundationServices();
            services.AddSecurityProcessingServices();
            services.AddSecurityOrchestrationServices();
        }

        static void AddSecurityFoundationServices(this IServiceCollection services)
        {
            // event services
            services.AddTransient<IDMSRoleEventService, DMSRoleEventService>();

            // services
            services.AddTransient<IDMSUserService, DMSUserService>();
            services.AddTransient<IDMSRoleService, DMSRoleService>();
            services.AddTransient<IDMSUserRoleService, DMSUserRoleService>();
            services.AddTransient<IBucketRoleService, BucketRoleService>();
        }

        static void AddSecurityProcessingServices(this IServiceCollection services)
        {
            // event services
            services.AddTransient<IDMSRoleEventProcessingService, DMSRoleEventProcessingService>();

            // services
            services.AddTransient<IDMSUserProcessingService, DMSUserProcessingService>();
            services.AddTransient<IDMSRoleProcessingService, DMSRoleProcessingService>();
            services.AddTransient<IDMSUserRoleProcessingService, DMSUserRoleProcessingService>();
            services.AddTransient<IBucketRoleProcessingService, BucketRoleProcessingService>();
        }

        static void AddSecurityOrchestrationServices(this IServiceCollection services)
        {
            services.AddTransient<IDMSUserOrchestrationService, DMSUserOrchestrationService>();
            services.AddTransient<IDMSRoleOrchestrationService, DMSRoleOrchestrationService>();
            services.AddTransient<IDMSUserRoleOrchestrationService, DMSUserRoleOrchestrationService>();
            services.AddTransient<IBucketRoleOrchestrationService, BucketRoleOrchestrationService>();
        }

        static void AddSecurityBrokers(this IServiceCollection services)
        {
            services.AddTransient<IDMSUserBroker, DMSUserBroker>();
            services.AddTransient<IDMSRoleBroker, DMSRoleBroker>();
            services.AddTransient<IDMSUserRoleBroker, DMSUserRoleBroker>();
            services.AddTransient<IBucketRoleBroker, BucketRoleBroker>();
            services.AddTransient<IDMSAuthorizationBroker, DMSAuthorizationBroker>();

            services.AddTransient<IDMSRoleEventBroker, DMSRoleEventBroker>();
        }
    }
}