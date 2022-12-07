using DMS.Data.Brokers.Events.Masterdata;
using DMS.Data.Brokers.Events.Masterdata.Interfaces;
using DMS.Data.Brokers.Storages.Masterdata;
using DMS.Data.Brokers.Storages.Masterdata.Interfaces;
using DMS.Services.Coordination;
using DMS.Services.Coordination.Interfaces;
using DMS.Services.Foundation.Masterdata;
using DMS.Services.Foundation.Masterdata.Interfaces;
using DMS.Services.Foundation.Security;
using DMS.Services.Foundation.Security.Interfaces;
using DMS.Services.Orchestration.Masterdata;
using DMS.Services.Orchestration.Masterdata.Interfaces;
using DMS.Services.Orchestration.Security;
using DMS.Services.Orchestration.Security.Interfaces;
using DMS.Services.Processing.Masterdata;
using DMS.Services.Processing.Masterdata.Interfaces;
using DMS.Services.Processing.Security;
using DMS.Services.Processing.Security.Interfaces;

namespace DMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddMasterdataServices(this IServiceCollection services)
        {
            services.AddMasterdataBrokers();
            services.AddMasterdataFoundationServices();
            services.AddMasterdataProcessingServices();
            services.AddMasterdataOrchestrationServices();

            services.AddTransient<ICompanyCSVLineCoordinationService, CompanyCSVLineCoordinationService>();
        }

        static void AddMasterdataFoundationServices(this IServiceCollection services)
        {
            // Event Services
            _ = services.AddTransient<IBucketEventService, BucketEventService>();
            _ = services.AddTransient<ICompanyEventService, CompanyEventService>();
            _ = services.AddTransient<ISystemEventService, SystemEventService>();

            // Services
            _ = services.AddTransient<IBucketService, BucketService>();
            _ = services.AddTransient<IBucketCompanyService, BucketCompanyService>();
            _ = services.AddTransient<ICompanyService, CompanyService>();
            _ = services.AddTransient<ISystemService, SystemService>();
            _ = services.AddTransient<ICompanyReferenceService, CompanyReferenceService>();
            _ = services.AddTransient<IAddressService, AddressService>();
            _ = services.AddTransient<IBucketSystemService, BucketSystemService>();
            _ = services.AddTransient<IBucketRoleService, BucketRoleService>();
        }

        static void AddMasterdataProcessingServices(this IServiceCollection services)
        {
            // Event Services
            _ = services.AddTransient<IBucketEventProcessingService, BucketEventProcessingService>();
            _ = services.AddTransient<ICompanyEventProcessingService, CompanyEventProcessingService>();
            _ = services.AddTransient<ISystemEventProcessingService, SystemEventProcessingService>();

            // Services
            _ = services.AddTransient<IBucketProcessingService, BucketProcessingService>();
            _ = services.AddTransient<IBucketCompanyProcessingService, BucketCompanyProcessingService>();
            _ = services.AddTransient<ICompanyProcessingService, CompanyProcessingService>();
            _ = services.AddTransient<ISystemProcessingService, SystemProcessingService>();
            _ = services.AddTransient<ICompanyReferenceProcessingService, CompanyReferenceProcessingService>();
            _ = services.AddTransient<IAddressProcessingService, AddressProcessingService>();
            _ = services.AddTransient<IBucketSystemProcessingService, BucketSystemProcessingService>();
            _ = services.AddTransient<IBucketRoleProcessingService, BucketRoleProcessingService>();
            _ = services.AddTransient<IAddressProcessingService, AddressProcessingService>();
        }

        static void AddMasterdataOrchestrationServices(this IServiceCollection services)
        {
            _ = services.AddTransient<IBucketSystemOrchestrationService, BucketSystemOrchestrationService>();
            _ = services.AddTransient<IBucketOrchestrationService, BucketOrchestrationService>();
            _ = services.AddTransient<IBucketCompanyOrchestrationService, BucketCompanyOrchestrationService>();
            _ = services.AddTransient<ICompanyOrchestrationService, CompanyOrchestrationService>();
            _ = services.AddTransient<ISystemOrchestrationService, SystemOrchestrationService>();
            _ = services.AddTransient<ICompanyReferenceOrchestrationService, CompanyReferenceOrchestrationService>();
            _ = services.AddTransient<IBucketRoleOrchestrationService, BucketRoleOrchestrationService>();
        }

        static void AddMasterdataBrokers(this IServiceCollection services)
        {
            // Storage Brokers
            
            _ = services.AddTransient<IAddressBroker, AddressBroker>();
            _ = services.AddTransient<IBucketBankAccountBroker, BucketBankAccountBroker>();
            _ = services.AddTransient<IBucketBroker, BucketBroker>();
            _ = services.AddTransient<IBucketCompanyBroker, BucketCompanyBroker>();
            _ = services.AddTransient<IBucketCreditBroker, BucketCreditBroker>();
            _ = services.AddTransient<IBucketInvoiceBroker, BucketInvoiceBroker>();
            _ = services.AddTransient<IBucketOfferBroker, BucketOfferBroker>();
            _ = services.AddTransient<IBucketPurchaseOrderBroker, BucketPurchaseOrderBroker>();
            _ = services.AddTransient<IBucketRemittanceAdviceBroker, BucketRemittanceAdviceBroker>();
            _ = services.AddTransient<IBucketRoleBroker, BucketRoleBroker>();
            _ = services.AddTransient<IBucketSystemBroker, BucketSystemBroker>();
            _ = services.AddTransient<ICompanyBroker, CompanyBroker>();
            _ = services.AddTransient<ICompanyReferenceBroker, CompanyReferenceBroker>();
            _ = services.AddTransient<ICountryBroker, CountryBroker>();
            _ = services.AddTransient<ICurrencyBroker, CurrencyBroker>();
            _ = services.AddTransient<ISystemBroker, SystemBroker>();

            // Event Brokers
            _ = services.AddTransient<IBucketEventBroker, BucketEventBroker>();
            _ = services.AddTransient<ICompanyEventBroker, CompanyEventBroker>();
            _ = services.AddTransient<ISystemEventBroker, SystemEventBroker>();
        }
    }
}